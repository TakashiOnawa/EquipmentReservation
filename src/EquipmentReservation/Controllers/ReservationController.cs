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

            var request = new RegisterReservationRequest()
            {
                AccountId = model.SelectedAccountId,
                EquipmentId = model.SelectedEquipmentId,
                StartDateTime = model.GetStartDateTime().Value,
                EndDateTime = model.GetEndDateTime().Value,
                PurposeOfUse = model.PurposeOfUse
            };

            try
            {
                _reservationAppService.RegisterReservation(request);
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

        public IActionResult EditReservation(string reservationId)
        {
            var model = CreateReservationViewModel(reservationId);
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

            var request = new ChangeReservationInfoRequest()
            {
                ReservationId = model.Id,
                AccountId = model.SelectedAccountId,
                EquipmentId = model.SelectedEquipmentId,
                StartDateTime = model.GetStartDateTime().Value,
                EndDateTime = model.GetEndDateTime().Value,
                PurposeOfUse = model.PurposeOfUse
            };

            try
            {
                _reservationAppService.ChangeReservationInfo(request);
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

        public IActionResult CancelReservation(string reservationId)
        {
            var model = CreateReservationViewModel(reservationId);
            return View(model);
        }

        [HttpPost]
        public IActionResult CancelReservation(ReservationViewModel model)
        {
            var request = new CancelReservationRequest()
            {
                ReservationId = model.Id
            };

            _reservationAppService.CancelReservation(request);

            return RedirectToAction("Index");
        }

        private ReservationViewModel CreateReservationViewModel(string reservationId)
        {
            var request = new GetReservationDataRequest()
            {
                ReservationId = reservationId
            };
            var response = _reservationQueryService.GetReservationData(request);

            var model = new ReservationViewModel();
            model.AccountList = _accountQueryService.GetAllAccountData().AccountDataList;
            model.EquipmentList = _equipmentQueryService.GetAllEquipmentData().EquipmentDataList;
            model.Id = response.ReservationData.Id;
            model.SelectedAccountId = response.ReservationData.AccountId;
            model.SelectedEquipmentId = response.ReservationData.EquipmentId;
            model.StartDate = response.ReservationData.StartDateTime;
            model.StartTime = response.ReservationData.StartDateTime;
            model.EndDate = response.ReservationData.EndDateTime;
            model.EndTime = response.ReservationData.EndDateTime;
            model.PurposeOfUse = response.ReservationData.PurposeOfUse;

            return model;
        }
    }
}