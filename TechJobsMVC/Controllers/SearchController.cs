﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
    }
    public IActionResult Results(string searchType, string searchTerm)
    {
        jobResults.Clear();
        jobResults = JobData.FindByColumnAndValue(searchType, searchTerm);
        if (jobResults.Count == 0)
        {
            Dictionary<string, string> resultToAdd = new Dictionary<string, string>();
            resultToAdd.Add("noResult", searchTerm);
            jobResults.Add(resultToAdd);

        }
        return Redirect("Index");
    }

}
