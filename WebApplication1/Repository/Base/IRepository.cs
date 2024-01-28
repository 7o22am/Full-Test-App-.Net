namespace WebApplication1.Repository.Base
{
    public interface IRepository<T> where T : class 
    {
         T FinedbyId(int id);
         IEnumerable<T> GetAll();

        Task< T >FinedbyIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

       
        void AddOne(T myItem);

        void UpdateOne(T myItem);

        void DeleteOne(T myItem);

        void AddList(IEnumerable<T> myList);

        void UpdateList(IEnumerable<T> myList);

        void DeleteList(IEnumerable<T> myList);
    }
     
}
