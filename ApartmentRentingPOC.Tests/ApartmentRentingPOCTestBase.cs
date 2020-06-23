using System;
using System.Data.Common;
using Abp.TestBase;
using ApartmentRentingPOC;
using ApartmentRentingPOC.EntityFramework;
using ApartmentRentingPOC.Migrations.SeedData;
using Castle.MicroKernel.Registration;

/// <summary>
/// This is base class for all our test classes.
/// It prepares ABP system, modules and a fake, in-memory database.
/// Seeds database with initial data (<see cref="ApartmentRentingPOCInitialDataBuilder"/>).
/// Provides methods to easily work with DbContext.
/// </summary>
public abstract class ApartmentRentingPOCTestBase : AbpIntegratedTestBase<ApartmentRentingPOCTestModule>
{
    protected ApartmentRentingPOCTestBase()
    {
        //Seed initial data
        UsingDbContext(context => new ApartmentRentingPOCInitialDataBuilder().Build(context));
    }

    protected override void PreInitialize()
    {
        //Fake DbConnection using Effort!
        LocalIocManager.IocContainer.Register(
            Component.For<DbConnection>()
                .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                .LifestyleSingleton()
        );

        base.PreInitialize();
    }

    public void UsingDbContext(Action<ApartmentRentingPOCDbContext> action)
    {
       UsingDbContext(action);
    }
}