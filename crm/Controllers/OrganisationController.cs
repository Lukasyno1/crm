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
        public ActionResult Index(string name, string type, string sortValue)
        {
            using (var context = new CrmDbContext())
            {
                var data = context.Organisations.ToList();

                if (!String.IsNullOrEmpty(name))
                    data = data.Where(x => !String.IsNullOrEmpty(x.name) && x.name.Contains(name)).ToList();

                if (!String.IsNullOrEmpty(type))
                    data = data.Where(x => x.type.ToString() == type).ToList();

                if(!String.IsNullOrEmpty(sortValue))
                {
                    switch (sortValue)
                    {
                        case "name":
                            data = data.OrderBy(x => x.name).ToList();
                            break;

                        case "type":
                            data = data.OrderBy(x => x.type).ToList();
                            break;

                        case "creationDate":
                            data = data.OrderBy(x => x.type).ToList();
                            break;

                        case "updateDate":
                            data = data.OrderBy(x => x.type).ToList();
                            break;
                    }   

                }

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

        public ActionResult Delete(int id)
        {
            using (var context = new CrmDbContext())
            {
                var data = context.Organisations.Where(x => x.id == id).FirstOrDefault();
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrganisationModel organisation)
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
