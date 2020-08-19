using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crm.Models;
using crm.Models.Organisation;

namespace crm.Controllers
{
    public class OrganisationController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new CrmDbContext())
            {
                var data = context.Organisations.ToList();
                return View(data);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrganisationModel organisation)
        {
            using (var context = new CrmDbContext())
            {
                organisation.created_at = DateTime.UtcNow;
                organisation.updated_at = DateTime.UtcNow;
                context.Organisations.Add(organisation);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (var context = new CrmDbContext())
            {
                var data = context.Organisations.Where(x => x.id == id).FirstOrDefault();
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganisationModel organisation)
        {
            using (var context = new CrmDbContext())
            { 
                var data = context.Organisations.FirstOrDefault(x => x.id == id);
               
                if (data != null)
                {
                    data.name = organisation.name;
                    data.type = organisation.type;
                    data.ghosted = organisation.ghosted;
                    data.updated_at = DateTime.UtcNow;
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (var context = new CrmDbContext())
            {
                var data = context.Organisations.FirstOrDefault(x => x.id == id);
                if (data != null)
                {
                    context.Organisations.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
        }
    }
}
