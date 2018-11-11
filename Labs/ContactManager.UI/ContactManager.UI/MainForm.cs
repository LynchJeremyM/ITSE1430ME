// ITSE-1430-20630
// Jeremy Lynch
// 11/20/18

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class MainForm : Form, IValidatableObject
    {
        #region Construction
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _contactList.DisplayMember = "ContactName";

            _messageList.DisplayMember = "Subject";

            RefreshContacts();
            RefreshMessages();
        }

        #endregion

        #region Public Members

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            throw new NotImplementedException();
        }

        #endregion
       
        #region Event Handlers

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Jeremy Lynch\nITSE-140-20630\nContact Manager", "About", MessageBoxButtons.OK);
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to exit?",
                "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void OnContactAdd( object sender, EventArgs e )
        {
            var form = new ContactForm();
            if (form.ShowDialog(this) == DialogResult.Cancel)
               return;

            Compare(form);

            _contacts.Add(form.Contact);
            RefreshContacts();
        }

        private void OnContactRemove( object sender, EventArgs e )
        {
            RemoveContact();
        }

        private void OnContactSendMessage( object sender, EventArgs e )
        {
            var selected = GetSelectedContact();
            if(selected == null)
            {
                return;
            }

            var name = selected.ContactName;
            var emailAddress = selected.EmailAddress;

            var form = new MessageForm(name, emailAddress);
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _messages.Add(form.Message);
            RefreshMessages();
        }

        private void OnContactEdit( object sender, EventArgs e )
        {
            EditContact();
        }

        private void OnContactDoubleClick( object sender, EventArgs e )
        {
            EditContact();
        }

        #endregion

        #region Private Members

        private void Compare(ContactForm contact)
        {
            while (_contacts.FindByName(contact.Contact.ContactName) != null)
            {
                MessageBox.Show("Name must be unique.", "Close");
                EditContact(contact);
            } 
        }

        private void RefreshContacts()
        {
            var contacts = from m in _contacts.GetAll()
                           orderby m.ContactName
                           select m;

            _contactList.Items.Clear();

            _contactList.Items.AddRange(contacts.ToArray());
        }

        private void EditContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            var form = new ContactForm();
            form.Contact = item;
            form.Text = "Edit Contact";
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _contacts.Edit(item.ContactName, form.Contact);
            RefreshContacts();
        }

        private void EditContact(ContactForm contact)
        {
            var form = new ContactForm();
            form.Contact = contact.Contact;

            if (contact.ShowDialog(this) == DialogResult.Cancel)
                return;
        }

        private void RefreshMessages()
        {
            var messages = from m in _messages.GetAll()
                           orderby m.Subject
                           select m;

            _messageList.Items.Clear();

            _messageList.Items.AddRange(messages.ToArray());
        }

        private void RemoveContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            if (MessageBox.Show("Do you want to delete this contact?",
                 "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _contacts.Remove(item.ContactName);

            RefreshContacts();
        }

        private ContactItem GetSelectedContact()
        {
            return _contactList.SelectedItem as ContactItem;
        }

        private ContactList _contacts = new ContactList();

        private MessageList _messages = new MessageList();

        #endregion
    }
}
