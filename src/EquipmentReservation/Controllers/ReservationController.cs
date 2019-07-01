using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Services.Commands;
using EquipmentReservation.Application.Services.Interfaces;
using EquipmentReservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationApplicationService _reservationApplicationService;

        public ReservationController(IReservationApplicationService reservationApplicationService)
        {
            _reservationApplicationService = reservationApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewReservation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterReservation(ReservationViewModel model)
        {
            var command = new RegisterReservationCommand()
            {
                AccountId = model.Account.Id,
                EquipmentId = model.Equipment.Id,
                From = model.FromDateTime(),
                To = model.ToDateTime()
            };

            _reservationApplicationService.RegisterReservation(command);

            return Redirect("Index");
        }
    }
}