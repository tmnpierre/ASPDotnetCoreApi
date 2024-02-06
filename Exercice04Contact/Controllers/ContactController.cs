using Exercice04Contact.Models;
using Exercice04Contact.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IRepository<Contact> _contactRepository;

    public ContactsController(IRepository<Contact> contactRepository) { _contactRepository = contactRepository; }

    // GET: api/Contacts
    [HttpGet]
    public IActionResult GetAll() { var contacts = _contactRepository.GetAll(); return Ok(contacts); }

    // GET: api/Contacts/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contact = _contactRepository.GetById(id);
        
        if (contact == null) return NotFound("Contact non trouvé.");
        else return Ok(contact);
    }

    // GET: api/Contacts/{firstName}
    [HttpGet("byname/{firstName}")]
    public IActionResult GetByFirstName(string firstName)
    {
        var contact = _contactRepository.FindByName(firstName);

        if (contact == null) return NotFound("Contact non trouvé.");
        else return Ok(contact);
    }


    // POST: api/Contacts
    [HttpPost]
    public IActionResult Create([FromBody] Contact contact)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var created = _contactRepository.Create(contact);

        if (!created) return BadRequest("Impossible de créer le contact.");
        else return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
    }


    // PUT: api/Contacts/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Contact contact)
    {
        if (contact == null) return BadRequest("Les données du contact ne sont pas valides.");

        var contactToUpdate = _contactRepository.GetById(id);
        
        if (contactToUpdate == null) return NotFound("Contact à mettre à jour non trouvé.");

        contact.Id = id;

        bool updated = _contactRepository.Update(contact);
        
        if (!updated) return BadRequest("Mise à jour du contact échouée.");
        else return NoContent();
    }


    // DELETE: api/Contacts/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var contactToDelete = _contactRepository.GetById(id);
        
        if (contactToDelete == null) return NotFound("Contact à supprimer non trouvé.");

        bool deleted = _contactRepository.Delete(id);
        
        if (!deleted) return BadRequest("Suppression du contact échouée.");
        else return NoContent();
    }
}
