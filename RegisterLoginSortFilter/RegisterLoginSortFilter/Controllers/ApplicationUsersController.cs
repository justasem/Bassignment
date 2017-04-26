using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegisterLoginSortFilter.Models;
using PagedList;

namespace RegisterLoginSortFilter.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        public ViewResult Index(SortFilterPageParams parameters)
        {

            ViewBag.CurrentSort = parameters.sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(parameters.sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortParm = parameters.sortOrder == "Email" ? "email_desc" : "Email";

            if (parameters.searchEmailString!= null)
            {
                parameters.page = 1;
            }
            else
            {
                parameters.searchEmailString = parameters.currentFilter;
            }

            ViewBag.CurrentFilter = parameters.searchEmailString;

            if (parameters.searchNameString != null)
            {
                parameters.page = 1;
            }
            else
            {
                parameters.searchNameString = parameters.currentFilter;
            }

            ViewBag.CurrentFilter = parameters.searchNameString;

            var users = from u in db.Users
                        select u;

            if (!string.IsNullOrEmpty(parameters.searchEmailString))
            {
                users = users.Where(u => u.Email.Contains(parameters.searchEmailString));
            }
            if (!string.IsNullOrEmpty(parameters.searchNameString))
            {
                users = users.Where(u => u.Name.Contains(parameters.searchNameString));
            }

            switch (parameters.sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.Name);
                    break;
                case "Email":
                    users = users.OrderBy(u => u.Email);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(u => u.Email);
                    break;
                default:
                    users = users.OrderBy(u => u.Name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (parameters.page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
