// ITSE-1430-20630
// Jeremy Lynch
// 11/20/18

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class ContactForm : Form 
    {
        #region Construction

        public ContactForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        public ContactItem Contact { get; set; }

        #endregion

        #region Event Handlers

        private void ContactForm_Load( object sender, EventArgs e )
        {
            if (Contact != null)
            {
                _txtName.Text = Contact.ContactName;
                _txtEmailAddress.Text = Contact.EmailAddress;
            }

            ValidateChildren();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var contact = new ContactItem();
            {
                contact.ContactName = _txtName.Text;
                contact.EmailAddress = _txtEmailAddress.Text;
            }

            Contact = contact;
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Private Members

        private void OnValidateName( object sender, CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_txtName.Text))
            {
                _errors.SetError(_txtName, "Contact Name is required.");
                e.Cancel = true;
            } else
            {
                _errors.SetError(_txtName, "");
            }

        }

        private void OnValidateEmailAddress( object sender, CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_txtEmailAddress.Text))
            {
                _errors.SetError(_txtEmailAddress, "Email Address is required.");
                e.Cancel = true;
            } else
            {
                if (!IsValidEmail(_txtEmailAddress.Text))
                {
                    _errors.SetError(_txtEmailAddress, "Email Address is not in correct format.");
                    e.Cancel = true;
                } else
                    _errors.SetError(_txtEmailAddress, "");
            }
        }

        private bool IsValidEmail( string source )
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            } catch
            { };

            return false;
        }
        #endregion
    }
}
