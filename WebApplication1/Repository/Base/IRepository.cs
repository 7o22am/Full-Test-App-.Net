namespace WebApplication1.Repository.Base
{
    public interface IRepository<T> where T : class 
    {
         T FinedbyId(int id);
         IEnumerable<T> GetAll();

       Task< T >FinedbyIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
     
}
