using API_Net.Repository;

namespace API_Net.Services
{
    public interface IUnitOfWork
    {
        public TareaRepository TareaRepository { get; set; }

        public Task<int> Complete();
    }
}
