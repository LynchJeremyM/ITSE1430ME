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
    public partial class MessageForm : Form, IMessageService
    {
        #region Construction
        public MessageForm( string name, string emailAddress )
        {
            _name = name;
            _emailAddress = emailAddress;
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _txtName.Text = _name;
            _txtEmailAddress.Text = _emailAddress;
        }

        #endregion

        #region Public Members

        public MessageItem Message { get; set; }

        #endregion

        #region Event Handlers

        private void OnSend( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            Send(_txtEmailAddress.Text, _txtSubject.Text, _txtName.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        public void Send( string emailAddress, string subject, string message )
        {
            var messageItem = new MessageItem();
            {
                messageItem.EmailAddress = emailAddress;
                messageItem.Subject = subject;
                messageItem.Message = message;
            }

            Message = messageItem;
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Private Members

        private void OnValidateSubject( object sender, CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_txtSubject.Text))
            {
                _errors.SetError(_txtSubject, "Subject is required.");
                e.Cancel = true;
            } else
            {
                _errors.SetError(_txtSubject, "");
            }
        }

        string _name;

        string _emailAddress;

        #endregion
    }
}
