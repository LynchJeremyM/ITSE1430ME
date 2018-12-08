using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventPlanner.Memory;

namespace EventPlanner.Mvc.App_Start
{
    public static class DatabaseFactory
    {     
        static DatabaseFactory()
        {
            IEventDatabase baseline = new MemoryEventDatabase();
            _eventDatabaseFactory = baseline;           
        }

        #region Private Members

        private static IEventDatabase _eventDatabaseFactory;

        #endregion
    }
}