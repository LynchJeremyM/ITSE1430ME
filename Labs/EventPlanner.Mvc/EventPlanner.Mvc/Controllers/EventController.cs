/* Jeremy Lynch
 * ITSE 1430
 * 12/9/2018
 */
using System;
using System.Linq;
using System.Web.Mvc;
using EventPlanner.Mvc.App_Start;
using EventPlanner.Mvc.Models;

namespace EventPlanner.Mvc.Controllers
{
    public class EventController : Controller
    {
        public EventController ()
        {
            _database = DatabaseFactory.Database;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult My()
        {

            var criteria = new EventCriteria();
            criteria.IncludePrivate = true;
            criteria.IncludePublic = false;
            criteria.BeginDate = DateTime.Today;

            var items = from i in _database.GetAll(criteria)
                        orderby i.StartDate
                        select i;

            return View(items.Select(i => new EventModel(i)));
        }

        [HttpGet]
        public ActionResult Public()
        {

            var criteria = new EventCriteria();
            criteria.IncludePrivate = false;
            criteria.IncludePublic = true;
            criteria.BeginDate = DateTime.Today;

            var items = from i in _database.GetAll(criteria)
                        orderby i.StartDate
                        select i;

            return View(items.Select(i => new EventModel(i)));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var criteria = new EventCriteria();
                criteria.IncludePrivate = true;
                criteria.IncludePublic = true;
                var item = _database.GetAll(criteria).FirstOrDefault(i => i.Id == id);

                return View(new EventModel(item));

            } catch (Exception e)
            {             
                ModelState.AddModelError("", e.Message);
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new EventModel();

            model.StartDate = DateTime.Today;
            model.EndDate = DateTime.Today;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create( EventModel model)
        {
            if (ModelState.IsValid)
            { try
                {
                    var item = model.ToDomain();

                    _database.Add(item);

                    if(item.IsPublic)
                    {
                        return RedirectToAction("Public");
                    }

                    return RedirectToAction("My");
                }catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var criteria = new EventCriteria();
            criteria.IncludePrivate = true;
            criteria.IncludePublic = true;
            var item = _database.GetAll(criteria).FirstOrDefault(i => i.Id == id);

            return View(new EventModel(item));
        }

        [HttpPost]
        public ActionResult Edit(EventModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = model.ToDomain();
                    var criteria = new EventCriteria();
                    criteria.IncludePrivate = true;
                    criteria.IncludePublic = true;
                    var existing = _database.GetAll(criteria).FirstOrDefault(i => i.Id == model.Id);

                    _database.Update(existing.Id, item);

                    if (item.IsPublic)
                    {
                        return RedirectToAction("Public");
                    }

                    return RedirectToAction("My");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return HttpNotFound();
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var criteria = new EventCriteria();
            criteria.IncludePrivate = true;
            criteria.IncludePublic = true;
            var item = _database.GetAll(criteria).FirstOrDefault(i => i.Id == id);

            return View(new EventModel(item));
        }

        [HttpPost]
        public ActionResult Delete(EventModel model)
        {
            try
            {
                _database.Remove(model.Id);

                if(model.IsPublic)
                {
                    return RedirectToAction("Public");
                }

                return RedirectToAction("My");
            }catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return HttpNotFound();
            }
        }

        private readonly IEventDatabase _database;
    }
}