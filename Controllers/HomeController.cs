using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

using HelloInWorld.Models;
using HelloInWorld.Core;



namespace HelloInWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemRepository itemRepository;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
            itemRepository = RepositoryFactory<Repository>.GetRepository();
        }

        public IActionResult Index()
        {
            return View(itemRepository);
        }

        public IActionResult Create()
        {
            var item = itemRepository.Create();

            return RedirectToAction("Edit", new {id=item.id});

        }

        public IActionResult Details(int id)
        {
            var item = itemRepository.GetItems(id).FirstOrDefault();

            if(item==null)
            {
                //Redirect to Error page
            }

            ViewBag.id = item.id;
            ViewBag.Header = item.Header;
            ViewBag.Content = item.Content;

            return View();

        }

        public IActionResult Modify(int id, string header, string content)
        {
            if(itemRepository.IsItemExists(id))
            {
                var item = itemRepository.GetItems(id).FirstOrDefault();
                item.Header = header;
                item.Content = content;
                //item.Save();
                return RedirectToAction("Index");
            }

            var routeValues = new RouteValueDictionary()
            {
                {"Header", "Nothing delete"},
                {"Message", "The item which wanted delete is not exists"}

            };

            return RedirectToAction("Error", routeValues);
        }
        public IActionResult Remove(int id)
        {
            if(itemRepository.IsItemExists(id))
            {
                itemRepository.Remove(id);

                return RedirectToAction("Index");
            }
            
            var routeValues = new RouteValueDictionary()
            {
                {"Header", "Nothing delete"},
                {"Message", "The item which wanted delete is not exists"}

            };

            return RedirectToAction("Error", routeValues);
        }
        public IActionResult Edit(int id)
        {
            if(itemRepository.IsItemExists(id))
            {
                 ViewBag.id = id;
                return View(itemRepository);
            }

            var routeValues = new RouteValueDictionary()
            {
                {"Header", "Nothing edit"},
                {"Message", "The item which wanted edit is not exists"}

            };

            return RedirectToAction("Error", routeValues);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string header, string message)
        {
            var errorViewModel = new ErrorViewModel();

            var routeValues = RouteData.Values;

            

            errorViewModel.Header = header;
            errorViewModel.Message = message;

            errorViewModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(errorViewModel);
        }
    }
}
