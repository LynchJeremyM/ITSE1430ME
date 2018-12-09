/* Jeremy Lynch
 * ITSE 1430
 * 12/9/2018
 */
using System;
using EventPlanner.Memory;

namespace EventPlanner.Mvc.App_Start
{
    public class DatabaseFactory
    {
        //Static constructors are called just before the type is referenced the first time
        static DatabaseFactory()
        {

            //Create an instance of your IEventDatabase class...
            var db = new MemoryEventDatabase();

            var evt1 = new ScheduledEvent();

            evt1.Id = 0;
            evt1.Name = "Not Public";
            evt1.IsPublic = false;
            evt1.StartDate = new DateTime(2019, 1, 20);
            evt1.EndDate = new DateTime(2019, 1, 21);

            db.Add(evt1);

            evt1.Id = 0;
            evt1.Name = "Hello";
            evt1.IsPublic = false;
            evt1.StartDate = new DateTime(2019, 5, 24);
            evt1.EndDate = new DateTime(2019, 7, 20);

            db.Add(evt1);

            evt1.Id = 0;
            evt1.Name = "Public";
            evt1.IsPublic = true;
            evt1.StartDate = new DateTime(2020, 1, 18);
            evt1.EndDate = new DateTime(2020, 6, 27);

            db.Add(evt1);

            evt1.Id = 0;
            evt1.Name = "Unfortunate";
            evt1.IsPublic = true;
            evt1.StartDate = new DateTime(2019, 1, 20);
            evt1.EndDate = new DateTime(2019, 5, 22);

            db.Add(evt1);

            Database = db;
        }

        //Don't allow any instances to be created
        private DatabaseFactory()
        { }

        //The only instance
        public static IEventDatabase Database { get; }
    }
}