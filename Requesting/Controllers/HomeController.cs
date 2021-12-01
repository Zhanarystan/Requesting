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
        private readonly IClientRepository _clientRepository;
        private readonly IRequestRepository _requestRepository;

        public HomeController(IClientRepository clientRepository, IRequestRepository requestRepository)
        {
            _clientRepository = clientRepository;
            _requestRepository = requestRepository;
        }

        public async Task<ActionResult> Index()
        {

            return View(await _requestRepository.GetAllRequests());
        }

        [HttpGet]
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRequest(int clientId)
        {
            ViewBag.ClientId = clientId;
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetRequest(int id)
        {
            return View(await _requestRepository.GetRequest(id));
        }

        [HttpPost]
        public async Task<ActionResult> EditRequest(Request request)
        {
            _requestRepository.UpdateRequest(request);
            return RedirectToAction("Index");
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

        [HttpPost]
        public async Task<ActionResult> CreateClient(Client client)
        {
            var clientId = await _clientRepository.CreateClient(client);
            return RedirectToAction("CreateRequest", new { clientId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
