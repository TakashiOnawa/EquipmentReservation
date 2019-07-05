using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Accounts;
using EquipmentReservation.Application.Equipments;
using EquipmentReservation.Application.Reservations;
using EquipmentReservation.Application.Reservations.Commands;
using EquipmentReservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationAppService _reservationAppService;
        private readonly IReservationQueryService _reservationQueryService;
        private readonly IAccountAppService _accountAppService;
        private readonly IEquipmentAppService _equipmentAppService;

        public ReservationController(
            IReservationAppService reservationAppService, 
            IReservationQueryService reservationQueryService,
            IAccountAppService accountAppService,
            IEquipmentAppService equipmentAppService)
        {
            _reservationAppService = reservationAppService;
            _reservationQueryService = reservationQueryService;
            _accountAppService = accountAppService;
            _equipmentAppService = equipmentAppService;
        }

        public IActionResult Index()
        {
            var reservations = _reservationQueryService.GetAllReservation();
            return View(reservations);
        }

        public IActionResult NewReservation()
        {
            var reservation = new ReservationViewModel()
            {
                AccountList = _accountAppService.GetAllAccount(),
                EquipmentList = _equipmentAppService.GetAllEquipment()
            };

            return View(reservation);
        }

        [HttpPost]
        public IActionResult RegisterReservation(ReservationViewModel model)
        {
            var command = new RegisterReservationCommand()
            {
                AccountId = model.SelectedAccountId,
                EquipmentId = model.SelectedEquipmentId,
                From = model.GetFromDateTime().Value,
                To = model.GetToDateTime().Value
            };

            _reservationAppService.RegisterReservation(command);

            return Redirect("Index");
        }
    }
}