using System;

namespace EquipmentReservation.Application.Accounts
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
