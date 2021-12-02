using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Requesting.Interfaces;
using Requesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requesting.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRequestRepository _requestRepository;

        public AdminController(IAdminRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _requestRepository.GetRequests());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetRequest(int id)
        {
            return View(await _requestRepository.GetRequest(id));
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateRequest(Request request)
        {
            await _requestRepository.UpdateRequest(request);
            return RedirectToAction("Index");
        }

   
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            await _requestRepository.DeleteRequest(id);
            return RedirectToAction("Index");
        }
    }
}
