using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EquipmentReservation.Application.Accounts.Data;
using EquipmentReservation.Domain.Accounts;

namespace EquipmentReservation.Application.Accounts
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountAppService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public IEnumerable<AccountData> GetAllAccount()
        {
            return _accountRepository.FindAll().
                Select(_ => new AccountData() { Id = _.Id.Value, Name = _.Name.Value }).ToArray();
        }
    }
}
