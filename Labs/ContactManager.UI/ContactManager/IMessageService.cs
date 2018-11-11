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
    /// <summary>Provides services for sending messages.</summary>
    public interface IMessageService
    {
        /// <summary>Sends a message.</summary>
        void Send( string emailAddress, string subject, string message );
    }
}
