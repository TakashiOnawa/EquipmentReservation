using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentReservation.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewReservation()
        {
            return View();
        }
    }
}