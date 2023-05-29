using Wallet.Models;
using System.Collections.Generic;

namespace Wallet.Repository
{
    public interface IAccountRepository
    {

        Account Create(Account entity);
        Account Update(Account entity);
        Account Get(int id);
        int Delete(int id);
    }
}
