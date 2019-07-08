using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Accounts;
using EquipmentReservation.Application.Equipments;
using EquipmentReservation.Application.Reservations;
using EquipmentReservation.Application.Reservations.Commands;
using EquipmentReservation.Application.Reservations.Exceptions;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationAppService _reservationAppService;
        private readonly IReservationQueryService _reservationQueryService;
        private readonly IAccountQueryService _accountQueryService;
        private readonly IEquipmentQueryService _equipmentQueryService;

        public ReservationController(
            IReservationAppService reservationAppService, 
            IReservationQueryService reservationQueryService,
            IAccountQueryService accountQueryService,
            IEquipmentQueryService equipmentQueryService)
        {
            _reservationAppService = reservationAppService;
            _reservationQueryService = reservationQueryService;
            _accountQueryService = accountQueryService;
            _equipmentQueryService = equipmentQueryService;
        }

        public IActionResult Index()
        {
            var reservations = _reservationQueryService.GetAllReservationListData().ReservationListDataList;
            return View(reservations);
        }

        public IActionResult NewReservation()
        {
            var model = new ReservationViewModel();
            model.AccountList = _accountQueryService.GetAllAccountData().AccountDataList;
            model.EquipmentList = _equipmentQueryService.GetAllEquipmentData().EquipmentDataList;
            return View(model);
        }

        [HttpPost]
        public IActionResult NewReservation(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AccountList = _accountQueryService.GetAllAccountData().AccountDataList;
                model.EquipmentList = _equipmentQueryService.GetAllEquipmentData().EquipmentDataList;
                ModelState.AddModelError(string.Empty, "入力内容が不正です。");
                return View(model);
            }

            var command = new RegisterReservationRequest()
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
                model.AccountList = _accountQueryService.GetAllAccountData().AccountDataList;
                model.EquipmentList = _equipmentQueryService.GetAllEquipmentData().EquipmentDataList;
                ModelState.AddModelError(string.Empty, "予約が重複しています。");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditReservation(string id)
        {
            var request = new GetReservationListDataRequest() { ReservationId = id };
            var response = _reservationQueryService.GetReservationListData(request);

            var model = new ReservationViewModel();
            model.AccountList = _accountQueryService.GetAllAccountData().AccountDataList;
            model.EquipmentList = _equipmentQueryService.GetAllEquipmentData().EquipmentDataList;
            model.Id = response.ReservationListData.Id;
            model.SelectedAccountId = response.ReservationListData.AccountId;
            model.SelectedEquipmentId = response.ReservationListData.EquipmentId;
            model.StartDate = response.ReservationListData.StartDateTime;
            model.StartTime = response.ReservationListData.StartDateTime;
            model.EndDate = response.ReservationListData.EndDateTime;
            model.EndTime = response.ReservationListData.EndDateTime;
            model.PurposeOfUse = response.ReservationListData.PurposeOfUse;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditReservation(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AccountList = _accountQueryService.GetAllAccountData().AccountDataList;
                model.EquipmentList = _equipmentQueryService.GetAllEquipmentData().EquipmentDataList;
                ModelState.AddModelError(string.Empty, "入力内容が不正です。");
                return View(model);
            }

            var command = new ChangeReservationInfoRequest()
            {
                Id = model.Id,
                AccountId = model.SelectedAccountId,
                EquipmentId = model.SelectedEquipmentId,
                StartDateTime = model.GetStartDateTime().Value,
                EndDateTime = model.GetEndDateTime().Value,
                PurposeOfUse = model.PurposeOfUse
            };

            try
            {
                _reservationAppService.ChangeReservationInfo(command);
            }
            catch (ReservationDupulicationException)
            {
                model.AccountList = _accountQueryService.GetAllAccountData().AccountDataList;
                model.EquipmentList = _equipmentQueryService.GetAllEquipmentData().EquipmentDataList;
                ModelState.AddModelError(string.Empty, "予約が重複しています。");
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}