using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MessageBoardApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardApp.Controllers
{
  public class MessagesController : Controller
  {
    public ActionResult Index()
    {
      var allMessages = Message.GetAllMessages();
      return View(allMessages);
    }

    public ActionResult Create()
    {
      var groups = Group.GetAllGroups();
      ViewBag.GroupId = new SelectList(groups, "GroupId", "Name");
      ViewBag.CurrentUser = CurrentUser.GetCurrentUser();
      return View();
    }

    [HttpPost]
    public ActionResult Create(Message message)
    {
      Message.Post(message);
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Message message = Message.GetDetails(id);
      ViewBag.Person = Person.GetDetails(message.PersonId);
      ViewBag.Group = Group.GetDetails(message.GroupId);
      return View(message);
    }

    public ActionResult Edit(int id)
    {
      var groups = Group.GetAllGroups();
      ViewBag.GroupId = new SelectList(groups, "GroupId", "Name");
      ViewBag.CurrentUser = CurrentUser.GetCurrentUser();
      Message message = Message.GetDetails(id);
      return View(message);
    }

    [HttpPost]
    public ActionResult Edit(Message message)
    {
      Message.Patch(message);
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Message message = Message.GetDetails(id);
      ViewBag.CurrentUser = CurrentUser.GetCurrentUser();
      return View(message);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Message.Delete(id);
      return RedirectToAction("Index");
    }
  }
}