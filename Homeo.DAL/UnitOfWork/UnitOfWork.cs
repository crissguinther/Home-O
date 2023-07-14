using Homeo.DAL.Interfaces;
using Homeo.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace Homeo.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork {
        private readonly IdentityDataContext _identityContext;

        public UnitOfWork(IdentityDataContext identityContext) {
            _identityContext = identityContext;
        }

        public void Commit() {
            _identityContext.SaveChanges();
        }

        public void Rollback() {
            var modified = _identityContext.ChangeTracker.Entries()
                    .Where(e => e.State != EntityState.Unchanged).ToList();

            foreach(var entity in modified) {
                entity.CurrentValues.SetValues(entity.OriginalValues);
                entity.State = EntityState.Unchanged;
            }
        }
    }
}
