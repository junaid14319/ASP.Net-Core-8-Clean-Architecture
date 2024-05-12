using AspNetCoreCA.Application;
using AspNetCoreCA.Application.Interfaces;
using AspNetCoreCA.Infrastructure.Identity;
using AspNetCoreCA.Infrastructure.Identity.Contexts;
using AspNetCoreCA.Infrastructure.Identity.Models;
using AspNetCoreCA.Infrastructure.Identity.Seeds;
using AspNetCoreCA.Infrastructure.Persistence;
using AspNetCoreCA.Infrastructure.Persistence.Contexts;
using AspNetCoreCA.Infrastructure.Resources.Services;
using AspNetCoreCA.WebApi.Infrastracture.Extensions;
using AspNetCoreCA.WebApi.Infrastracture.Middlewares;
using AspNetCoreCA.WebApi.Infrastracture.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddJwt(builder.Configuration);

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.AddSwaggerWithVersioning();
builder.Services.AddCors(x =>
{
    x.AddPolicy("Any", b =>
    {
        b.AllowAnyOrigin();
        b.AllowAnyHeader();
        b.AllowAnyMethod();

    });
});
builder.Services.AddCustomLocalization(builder.Configuration);

builder.Services.AddHealthChecks();
builder.Services.AddSingleton<ITranslator, Translator>();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<IdentityContext>().Database.MigrateAsync();
    await services.GetRequiredService<ECommDbContext>().Database.MigrateAsync();
    
    //Seed Data
    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCoreCA.WebApi v1"));
}

app.UseCustomLocalization();
app.UseCors("Any");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerWithVersioning();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHealthChecks("/health");

app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();