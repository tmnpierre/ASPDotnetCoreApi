using Exercice04Contact.Models;

namespace Exercice04Contact.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Create (T entity);

        T GetById(int id);

        List<T> GetAll(string? search = null);

        bool Update (T entity);

        bool Delete (int id);

        T FindByName(string name);
    }
}
