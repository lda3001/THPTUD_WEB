using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TH_Harmic.Models;

namespace TH_Harmic.Controllers
{
    public class ContactsController : Controller
    {
        private readonly Th2Context _context;

        public ContactsController(Th2Context context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            ViewBag.productCategories = _context.TbProductCategories.ToList();
            ViewBag.productNew = _context.TbProducts.Where(m => m.IsNew).ToList();
            return View();
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbContact = await _context.TbContacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (tbContact == null)
            {
                return NotFound();
            }

            return View(tbContact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/Contact/Create")]
        public IActionResult Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                _context.SaveChanges();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbContact = await _context.TbContacts.FindAsync(id);
            if (tbContact == null)
            {
                return NotFound();
            }
            return View(tbContact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,Name,Phone,Email,Message,IsRead,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] TbContact tbContact)
        {
            if (id != tbContact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbContactExists(tbContact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbContact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbContact = await _context.TbContacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (tbContact == null)
            {
                return NotFound();
            }

            return View(tbContact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbContact = await _context.TbContacts.FindAsync(id);
            if (tbContact != null)
            {
                _context.TbContacts.Remove(tbContact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbContactExists(int id)
        {
            return _context.TbContacts.Any(e => e.ContactId == id);
        }
    }
}
