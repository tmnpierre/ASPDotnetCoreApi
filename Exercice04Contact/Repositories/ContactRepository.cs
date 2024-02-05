using Exercice04Contact.Data;
using Exercice04Contact.Models;

namespace Exercice04Contact.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly ApplicationDbContext? _db;

        public ContactRepository(ApplicationDbContext db) { _db = db; }

        public bool Create(Contact entity)
        {
            _db.Contacts.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public Contact GetById(int id) { return _db.Contacts.Find(id); }

        public List<Contact> GetAll() { return _db.Contacts.ToList(); }

        public bool Update(Contact entity)
        {
            var contactFromDb = GetById(entity.Id);
            if (contactFromDb == null) { return false; }

            _db.Entry(contactFromDb).CurrentValues.SetValues(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var contact = _db.Contacts.Find(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
                return _db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
