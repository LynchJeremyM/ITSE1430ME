// ITSE-1430-20630
// Jeremy Lynch
// 11/20/18

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactList
    {
        #region Public Members
        public void Add( ContactItem contact)
        {
            if (contact == null)
                return;

            _contacts.Add(contact);
        }

        public void Edit( string contactName, ContactItem contact )
        {
            Remove(contactName);

            Add(contact);
        }

        public void Remove( string name)
        {
            var contact = FindByName(name);
            if (contact != null)
                _contacts.Remove(contact);
        }

        public IEnumerable<ContactItem> GetAll()
        {
            return from contact in _contacts
                   select new ContactItem()
                   {
                       ContactName = contact.ContactName,
                       EmailAddress = contact.EmailAddress
                   };
        }

        #endregion

        #region Private Members

        private ContactItem FindByName( string name )
        { 
            return (from m in _contacts
                    where String.Compare(name, m.ContactName, true) == 0
                    select m).FirstOrDefault();
        }

        private List<ContactItem> _contacts = new List<ContactItem>();

        #endregion
    }
}
