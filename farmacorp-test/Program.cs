// See https://aka.ms/new-console-template for more information
using System.Collections;
using data.access;
using data.access.data.extensions;
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
            .AddScoped<IProductExpressRepository, ProductExpressRepository>()
            .AddScoped<IProductTypeRepository, ProductTypeRepository>()
            .AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
            .AddScoped<ISaleExpressRepository, SaleExpressRepository>()
            .AddScoped<IBarCodeRepository, BarCodeRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()

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

SeedDatabase(host);

static async Task example(IHost host)
{
    using IServiceScope serviceScope = host.Services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    //var y = provider.GetRequiredService<ApplicationDbContext>();
    TestExercises testExercises = provider.GetRequiredService<TestExercises>();


    await testExercises.transactSaleExpressStrategyt01();
    await testExercises.transactSaleExpressStrategyt02();
    await testExercises.transactSaleExpressStrategyt03();
    await testExercises.transactSaleExpressStrategyt04();
    
    await testExercises.transactSaleGanaMaxStrategyt01();
    await testExercises.transactSaleGanaMaxStrategyt04();

}

example(host).Wait();


Console.WriteLine("Hello, World!");
Console.ReadKey();

void SeedDatabase(IHost host)
{
    using (var scope = host.Services.CreateScope())
        try
        {
            var scopedContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Seeder.Initialize(scopedContext);
        }
        catch
        {
            throw;
        }
}

host.Run();