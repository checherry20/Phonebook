using Phonebook.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.Website.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        // GET: Contact
        IContactController contactController = ControllerFactory.CreateContactController();
        public ActionResult Index()
        {
            return View(contactController.GetAll());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View(contactController.Get(id));
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View(new Contact());
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                contactController.Add(contact);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(Int32 id)
        {
            return View(contactController.Get(id));
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                // TODO: Add update logic here
                contactController.Edit(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View(contactController.Get(id));
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(Contact contact)
        {
            try
            {
                // TODO: Add delete logic here
                contactController.Delete(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
