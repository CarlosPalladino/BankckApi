using BankckApi;
using BankckApi.Cqrs.Commands;
using BankckApi.Cqrs.Handlers;
using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
     {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddTransient<Seed>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddTransient<AccountCommand, AccountHandler>();

        builder.Services.AddMediatR(typeof(Program).Assembly);

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //builder.Services.AddScoped<CustomerInterface, CustomerInterface>();
        builder.Services.AddScoped<AccoutInterface, AccoutRepository>();
        //builder.Services.AddScoped<ExChangeRateInterface, ExchanRateRepository>();
        //builder.Services.AddScoped<ExChangeRateInterface, ExchanRateRepository>();
        //builder.Services.AddScoped<CurrencyInterface, CurrencyRepository>();



        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        var app = builder.Build();
        if (args.Length == 1 && args[0].ToLower() == "seeddata")
            SeeData(app);

        void SeeData(IHost app)
        {

            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopedFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<Seed>();
                service.SeedDataContext();
            }
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}