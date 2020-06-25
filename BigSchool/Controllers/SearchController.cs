using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BigSchool.ViewModels;

namespace BigSchool.Controllers
{
    
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        // GET: Search
        public SearchController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index(string category, string search)
        {
           
            var lec = _dbContext.Courses.Include( c => c.Place);
            if (!String.IsNullOrEmpty(search))
            {
                lec = lec.Where(c => c.LecturerID.Contains(search) || c.Category.Name.Contains(search));
                ViewBag.Search = search;
            }
            var categories = lec.OrderBy(c => c.Category.Name).Select(c => c.Category.Name).Distinct();
            ViewBag.Category = new SelectList(categories);
            return View(lec.ToList());
        }
    }
}