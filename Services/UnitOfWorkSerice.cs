using API_Net.DataAccess;
using API_Net.Repository;
namespace API_Net.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;
        public TareaRepository TareaRepository { get; set; }
        public UnitOfWorkService(ContextDB contextDB)
        {
            _contextDB = contextDB;
            TareaRepository = new TareaRepository(contextDB);
        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();
        }
    }
}

