using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{

    public interface IContactController
    {
        List<Contact> GetAll();
        Contact Get(Int32 id);
        void Add(Contact contact);
        void Delete(Contact contact);
        void Edit(Contact contact);

    }
}
