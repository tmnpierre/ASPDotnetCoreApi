namespace Exercice04Contact.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Create (T entity);

        T GetById(int id);

        List<T> GetAll();

        bool Update (T entity);

        bool Delete (int id);
    }
}
