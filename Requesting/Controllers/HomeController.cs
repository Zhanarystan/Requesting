using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Requesting.Interfaces;
using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestRepository _requestRepository;

        public HomeController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<ActionResult> Index()
        {
            var requests = await _requestRepository.GetRequests();
            
            return View(requests);
        }

        
        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> GetRequest(int id)
        {
            return View(await _requestRepository.GetRequest(id));
        }


        public async Task<ActionResult> DeleteRequest(int id)
        {
            await _requestRepository.DeleteRequest(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> CreateRequest(Request request)
        {
            await _requestRepository.CreateRequest(request);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
