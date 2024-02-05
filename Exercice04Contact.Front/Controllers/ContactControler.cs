using Exercice04Contact.Front.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice04Contact.Front.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ContactsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("API");
            var contacts = await client.GetFromJsonAsync<List<Contact>>("contacts");
            return View(contacts);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var client = _clientFactory.CreateClient("API");
            var contact = await client.GetFromJsonAsync<Contact>($"contacts/{id}");
            if (contact == null) return NotFound();

            return View(contact);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Gender,Avatar")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("API");
                var response = await client.PostAsJsonAsync("contacts", contact);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(contact);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var client = _clientFactory.CreateClient("API");
            var contact = await client.GetFromJsonAsync<Contact>($"contacts/{id}");
            if (contact == null) return NotFound();

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Gender,Avatar")] Contact contact)
        {
            if (id != contact.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("API");
                var response = await client.PutAsJsonAsync($"contacts/{id}", contact);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the contact.");
                }
            }
            return View(contact);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var client = _clientFactory.CreateClient("API");
            var contact = await client.GetFromJsonAsync<Contact>($"contacts/{id}");
            if (contact == null) return NotFound();

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _clientFactory.CreateClient("API");
            var response = await client.DeleteAsync($"contacts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
