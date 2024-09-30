using DbProject.Models;
using PagedList;
using System;
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
            ViewBag.CurrentSort = sortOrder; // Store the current sort order for the pager
            ViewBag.CurrentPage = page ?? 1; // Set the current page

            // Debugging statements
            System.Diagnostics.Debug.WriteLine($"Received sortOrder: {sortOrder}");
            System.Diagnostics.Debug.WriteLine($"Received page: {page}");

            var customPeople = _db.CustomPersons.AsQueryable();

            // Debugging before sorting
            System.Diagnostics.Debug.WriteLine($"Querying with sortOrder: {sortOrder}");

            // Apply sorting based on the sortOrder parameter
            switch (sortOrder)
            {
                case "CustomPersonID":
                    customPeople = customPeople.OrderBy(cp => cp.CustomPersonID);
                    break;
                case "CustomPersonID_desc":
                    customPeople = customPeople.OrderByDescending(cp => cp.CustomPersonID);
                    break;
                case "Title":
                    customPeople = customPeople.OrderBy(cp => cp.Title);
                    break;
                case "Title_desc":
                    customPeople = customPeople.OrderByDescending(cp => cp.Title);
                    break;
                case "FirstName":
                    customPeople = customPeople.OrderBy(cp => cp.FirstName);
                    break;
                case "FirstName_desc":
                    customPeople = customPeople.OrderByDescending(cp => cp.FirstName);
                    break;
                case "LastName":
                    customPeople = customPeople.OrderBy(cp => cp.LastName);
                    break;
                case "LastName_desc":
                    customPeople = customPeople.OrderByDescending(cp => cp.LastName);
                    break;
                case "PrimaryEmailAddress":
                    customPeople = customPeople.OrderBy(cp => cp.PrimaryEmailAddress);
                    break;
                case "PrimaryEmailAddress_desc":
                    customPeople = customPeople.OrderByDescending(cp => cp.PrimaryEmailAddress);
                    break;
                case "ModifiedDate":
                    customPeople = customPeople.OrderBy(cp => cp.ModifiedDate);
                    break;
                case "ModifiedDate_desc":
                    customPeople = customPeople.OrderByDescending(cp => cp.ModifiedDate);
                    break;
                default:
                    customPeople = customPeople.OrderBy(cp => cp.CustomPersonID);
                    break;
            }

            // Set pagination parameters
            int pageSize = 25;
            int pageNumber = (page ?? 1);



            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentPage = pageNumber; // Sets current page for the view

            // Apply pagination
            var pagedList = customPeople.ToPagedList(pageNumber, pageSize);

            // Return partial view for AJAX requests or full view
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PersonListPartial", pagedList);
            }

            return View(pagedList);
        }


        // GET: Person/Details
        public ActionResult Details(int id)
        {
            var person = _db.CustomPersons.SingleOrDefault(p => p.CustomPersonID == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetailsPartial", person); // Return the partial view with person details
        }


        // GET: Person/Create
        public ActionResult Create()
        {
            var businessEntity = new CustomPerson();
            return PartialView("_CreatePartial", businessEntity);
        }


        // POST: Person/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Title,FirstName,LastName")] CustomPerson customPerson)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        // Populate required fields
                        customPerson.ModifiedDate = DateTime.Now;
                        customPerson.PersonType = "EM";
                        customPerson.EmailPromotion = 0;
                        customPerson.NameStyle = false;

                        _db.CustomPersons.Add(customPerson);
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
                        return Json(new { success = false, message = "An error occurred while creating the record." });
                    }
                }
            }
            // If ModelState is not valid, return a partial view with validation messages
            return PartialView("_CreatePartial", customPerson);
        }



        // POST: Person/Edit
        [HttpPost]
        public ActionResult Edit(CustomPerson customPerson, string sortOrder, int? page)
        {
            if (ModelState.IsValid)
            {
                // Log the CustomPersonID for debugging
                Console.WriteLine("CustomPersonID: " + customPerson.CustomPersonID);

                // Fetch the existing CustomPerson entity
                var existingPerson = _db.CustomPersons
                    .SingleOrDefault(cp => cp.CustomPersonID == customPerson.CustomPersonID);

                if (existingPerson == null)
                {
                    return Json(new { success = false, message = "Entity not found." });
                }

                // Update person details
                existingPerson.Title = customPerson.Title;
                existingPerson.FirstName = customPerson.FirstName;
                existingPerson.LastName = customPerson.LastName;
                existingPerson.PrimaryEmailAddress = customPerson.PrimaryEmailAddress;
                existingPerson.ModifiedDate = DateTime.Now;

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "An error occurred while saving changes: " + ex.Message });
                }

                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", new { sortOrder = sortOrder, page = page })
                });
            }

            // If validation fails, return the form with validation messages
            return PartialView("_DetailsPartial", customPerson);
        }



        // POST: Person/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Find the CustomPerson entity by its ID
            var customPerson = _db.CustomPersons.Find(id);

            if (customPerson == null)
            {
                return Json(new { success = false, message = "Entity not found." });
            }

            // Remove the entity from the DbSet
            _db.CustomPersons.Remove(customPerson);
            _db.SaveChanges();

            return Json(new { success = true });
        }
    }
}
