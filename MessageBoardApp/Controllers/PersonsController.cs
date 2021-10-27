using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using MessageBoardApp.Models;
using System.Threading.Tasks;


namespace MessageBoardApp.Controllers
{
  public class PersonsController : Controller
  {
    public ActionResult Index()
    {
      var allPersons = Person.GetAllPersons();
      return View(allPersons);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Person person)
    {
      Person.Post(person);
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Person person = Person.GetDetails(id);
      return View(person);
    }

    public ActionResult Edit(int id)
    {
      Person person = Person.GetDetails(id);
      return View(person);
    }

    [HttpPost]
    public ActionResult Edit(Person person)
    {
      Person.Post(person);
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Person person = Person.GetDetails(id);
      return View(person);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Person.Delete(id);
      return RedirectToAction("Index");
    }
  }
}