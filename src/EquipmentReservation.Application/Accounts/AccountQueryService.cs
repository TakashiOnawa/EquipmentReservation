using EquipmentReservation.Application.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Accounts
{
    public class AccountQueryService : IAccountQueryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountQueryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public GetAllAccountDataResponse GetAllAccountData()
        {
            return new GetAllAccountDataResponse()
            {
                AccountDataList = _unitOfWork.AccountDataQuery.GetAccountData()
            };
        }
    }
}
