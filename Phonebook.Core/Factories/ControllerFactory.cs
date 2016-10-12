using Phonebook.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{
    public class ControllerFactory
    {
        public static IContactController CreateContactController()
        {
            //return new ContactController(); //OLD

            return new ContactControllerSQLDB();
        }

        public static IUserController CreateUserController()
        {
            return new UserControllerSQL();
        }
    }
}
