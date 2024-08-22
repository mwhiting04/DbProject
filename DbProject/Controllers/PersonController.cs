using DbProject.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DbProject.Controllers
{
    public class PersonController : Controller
    {
        private readonly AdventureWorks2022Context _db = new AdventureWorks2022Context();

        // GET: Person
        public ActionResult Index(string sortOrder, int? page)
        {
            // Debugging statements
            System.Diagnostics.Debug.WriteLine($"Received sortOrder: {sortOrder}");
            System.Diagnostics.Debug.WriteLine($"Received page: {page}");


            ViewBag.CurrentSort = sortOrder; // Ensure this line sets the value correctly
            ViewBag.IdSortParm = sortOrder == "Id" ? "Id_desc" : "Id";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "Title_desc" : "Title";
            ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            ViewBag.LastNameSortParm = sortOrder == "LastName" ? "LastName_desc" : "LastName";
            ViewBag.ModifiedDateSortParm = sortOrder == "ModifiedDate" ? "ModifiedDate_desc" : "ModifiedDate";
            ViewBag.CurrentPage = page ?? 1;

            var businessEntities = _db.BusinessEntities
                .Include(be => be.Person)
                .Where(be => be.Person != null);

            // Debugging before sorting
            System.Diagnostics.Debug.WriteLine($"Querying with sortOrder: {sortOrder}");

            switch (sortOrder)
            {
                case "Id":
                    businessEntities = businessEntities.OrderBy(be => be.BusinessEntityID);
                    break;
                case "Id_desc":
                    businessEntities = businessEntities.OrderByDescending(be => be.BusinessEntityID);
                    break;
                case "Title":
                    businessEntities = businessEntities.OrderBy(be => be.Person.Title);
                    break;
                case "Title_desc":
                    businessEntities = businessEntities.OrderByDescending(be => be.Person.Title);
                    break;
                case "FirstName":
                    businessEntities = businessEntities.OrderBy(be => be.Person.FirstName);
                    break;
                case "FirstName_desc":
                    businessEntities = businessEntities.OrderByDescending(be => be.Person.FirstName);
                    break;
                case "LastName":
                    businessEntities = businessEntities.OrderBy(be => be.Person.LastName);
                    break;
                case "LastName_desc":
                    businessEntities = businessEntities.OrderByDescending(be => be.Person.LastName);
                    break;
                case "ModifiedDate":
                    businessEntities = businessEntities.OrderBy(be => be.Person.ModifiedDate);
                    break;
                case "ModifiedDate_desc":
                    businessEntities = businessEntities.OrderByDescending(be => be.Person.ModifiedDate);
                    break;
                default:
                    businessEntities = businessEntities.OrderBy(be => be.BusinessEntityID);
                    break;
            }

            // Debugging after sorting
            System.Diagnostics.Debug.WriteLine("Sorting applied");

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            var pagedList = businessEntities.ToPagedList(pageNumber, pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_PersonListPartial", pagedList);
            }

            return View(pagedList);
        }



        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var businessEntity = _db.BusinessEntities
                .Include(be => be.Person)
                .SingleOrDefault(be => be.BusinessEntityID == id);

            if (businessEntity == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetailsPartial", businessEntity);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            var businessEntity = new BusinessEntity();
            return PartialView("_CreatePartial", businessEntity);
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,FirstName,LastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        if (person.BusinessEntityID == 0)
                        {
                            var newBusinessEntity = new BusinessEntity();
                            _db.BusinessEntities.Add(newBusinessEntity);
                            _db.SaveChanges();
                            person.BusinessEntityID = newBusinessEntity.BusinessEntityID;
                        }
                        else
                        {
                            // Check if BusinessEntityID exists
                            var businessEntity = _db.BusinessEntities.Find(person.BusinessEntityID);
                            if (businessEntity == null)
                            {
                                return Json(new { success = false, message = "BusinessEntityID does not exist." });
                            }
                        }

                        person.ModifiedDate = DateTime.Now;
                        person.PersonType = "EM";
                        person.EmailPromotion = 0;
                        person.NameStyle = false;

                        _db.Persons.Add(person);
                        int changes = _db.SaveChanges(); // Check the number of changes

                        if (changes > 0)
                        {
                            transaction.Commit();
                            return Json(new { success = true });
                        }
                        else
                        {
                            return Json(new { success = false, message = "No changes were made." });
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        if (ex.InnerException != null)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.InnerException.Message);
                        }
                        throw;
                    }
                }
            }
            return PartialView("_CreatePartial", person);
        }

        // POST: Person/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessEntity businessEntity, string sortOrder, int? page)
        {
            if (ModelState.IsValid)
            {
                var existingEntity = _db.BusinessEntities
                    .Include(be => be.Person)
                    .SingleOrDefault(be => be.BusinessEntityID == businessEntity.BusinessEntityID);

                if (existingEntity == null)
                {
                    return Json(new { success = false, message = "Entity not found." });
                }

                // Update person details
                existingEntity.Person.Title = businessEntity.Person.Title;
                existingEntity.Person.FirstName = businessEntity.Person.FirstName;
                existingEntity.Person.LastName = businessEntity.Person.LastName;
                existingEntity.Person.ModifiedDate = DateTime.Now;

                _db.SaveChanges();

                // Return JSON with success and redirect URL including sortOrder and page parameters
                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", new { sortOrder = sortOrder, page = page })
                });
            }
            return Json(new { success = false, message = "Invalid data." });
        }

        // POST: Person/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var businessEntity = _db.BusinessEntities
                    .Include(be => be.Person)
                    .SingleOrDefault(be => be.BusinessEntityID == id);

                if (businessEntity != null)
                {
                    // Remove the person
                    if (businessEntity.Person != null)
                    {
                        _db.Persons.Remove(businessEntity.Person);
                    }

                    // Remove the business entity
                    _db.BusinessEntities.Remove(businessEntity);
                    _db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Record not found." });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting entity: " + ex.Message);
                return Json(new { success = false, message = "An error occurred while deleting the record." });
            }
        }
    }
}
