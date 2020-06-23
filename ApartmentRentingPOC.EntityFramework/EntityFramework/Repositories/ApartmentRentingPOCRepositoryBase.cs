using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ApartmentRentingPOC.EntityFramework.Repositories
{
    public abstract class ApartmentRentingPOCRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ApartmentRentingPOCDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ApartmentRentingPOCRepositoryBase(IDbContextProvider<ApartmentRentingPOCDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ApartmentRentingPOCRepositoryBase<TEntity> : ApartmentRentingPOCRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ApartmentRentingPOCRepositoryBase(IDbContextProvider<ApartmentRentingPOCDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
