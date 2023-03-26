using Homeo.Data.Interfaces;
using Homeo.Identity.Data;

namespace Homeo.Data.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        private readonly IdentityDataContext _identityContext;

        public UnitOfWork(IdentityDataContext identityContext) {
            _identityContext = identityContext;
        }

        public void Commit() {
            _identityContext.SaveChanges();
        }
    }
}
