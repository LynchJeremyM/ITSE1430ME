// ITSE-1430-20630
// Jeremy Lynch
// 11/20/18

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class MessageItem
    {
        // Contact's email address
        public string EmailAddress
        {
            get => _emailAddress ?? "";
            set => _emailAddress = value;
        }
        private string _emailAddress = "";

        // Message's subject
        public string Subject
        {
            get => _subject ?? "";
            set => _subject = value;
        }
        private string _subject = "";

        // Message's content
        public string Message
        {
            get => _message ?? "";
            set => _message = value;
        }
        private string _message = "";
    }
}
