using DevFreela.Application.Commands.CreateProject;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using DevFreela.API.Filters;
using DevFreela.Application.Validators;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.ConfigureServices(services =>
        {
            var connectionString = services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("DevFreelaConnection");
            services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly); });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            });
        })
        .Configure(app =>
        {
            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        });
    })
    .Build();

await host.RunAsync();


