using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Accounts;
using EquipmentReservation.Application.Equipments;
using EquipmentReservation.Application.Reservations;
using EquipmentReservation.Application.Reservations.Commands;
using EquipmentReservation.Application.Reservations.Exceptions;
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
            var model = new ReservationViewModel();
            model.AccountList = _accountAppService.GetAllAccount();
            model.EquipmentList = _equipmentAppService.GetAllEquipment();
            return View(model);
        }

        [HttpPost]
        public IActionResult NewReservation(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AccountList = _accountAppService.GetAllAccount();
                model.EquipmentList = _equipmentAppService.GetAllEquipment();
                ModelState.AddModelError(string.Empty, "入力内容が不正です。");
                return View(model);
            }

            var command = new RegisterReservationCommand()
            {
                AccountId = model.SelectedAccountId,
                EquipmentId = model.SelectedEquipmentId,
                StartDateTime = model.GetStartDateTime().Value,
                EndDateTime = model.GetEndDateTime().Value,
                PurposeOfUse = model.PurposeOfUse
            };

            try
            {
                _reservationAppService.RegisterReservation(command);
            }
            catch (ReservationDupulicationException)
            {
                ModelState.AddModelError(string.Empty, "予約が重複しています。");
            }

            return Redirect("Index");
        }
    }
}