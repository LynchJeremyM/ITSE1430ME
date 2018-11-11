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
    public class MessageList
    {
        #region Public Members

        public void Add( MessageItem message )
        {
            if (message == null)
                return;

            _messages.Add(message);
        }

        public IEnumerable<MessageItem> GetAll()
        {
            return from message in _messages
                   select new MessageItem()
                   {
                       EmailAddress = message.EmailAddress,
                       Subject = message.Subject,
                       Message = message.Message
                   };
        }

        #endregion 

        #region Private Members

        private List<MessageItem> _messages = new List<MessageItem>();

        #endregion
    }
}
