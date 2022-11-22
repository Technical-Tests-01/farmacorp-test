// See https://aka.ms/new-console-template for more information
using System.Collections;
using data.access;
using data.access.data.repository;
using data.access.data.repository.impl;
using farmacorp_test;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using services.business.logic;
using services.business.logic.impl;

using static data.access.Utils;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
            services.AddDbContext<ApplicationDbContext>()


            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IProductErpRepository, ProductErpRepository>()
            .AddScoped<IProductTypeRepository, ProductTypeRepository>()
            .AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
            .AddScoped<ISaleExpressRepository, SaleExpressRepository>()

            .AddScoped<IUnitOfWork, UnitOfWork>()

            //.AddScoped(typeof(IBusinessRuleStrategy))
            .AddScoped<IBusinessRuleStrategy, SaleExpressBusiness>()
            .AddScoped<IBusinessRuleStrategy, SaleGanaMaxBusiness>()

            //.AddScoped<ISaleExpressBusiness, SaleExpressBusiness>()
            //.AddScoped<ISaleGanaMaxBusiness, SaleGanaMaxBusiness>()

            .AddScoped<TestExercises>()
            //.AddTransient<OperationLogger>())
            )
    .Build();



static async Task example(IHost host)
{
    using IServiceScope serviceScope = host.Services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    var y = provider.GetRequiredService<ApplicationDbContext>();
    TestExercises testExercises = provider.GetRequiredService<TestExercises>();
    var x = await testExercises.testExerciceOne();
    testExercises.testExerciceTwo();

}

example(host).Wait();


Console.WriteLine("Hello, World!");
Console.ReadKey();



host.Run();