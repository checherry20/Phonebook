using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{

    public interface IUserController
    {
        User GetUser(string username, string password);
    }
}
