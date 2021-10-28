using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MessageBoardApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardApp.Controllers
{
  public class GroupsController : Controller
  {
    public ActionResult Index()
    {
      var allGroups = Group.GetAllGroups();
      return View(allGroups);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Group group)
    {
      Group.Post(group);
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var group = Group.GetDetails(id);
      ViewBag.Messages = Message.GetAllMessages();
      return View(group);
    }

    public ActionResult Edit(int id)
    {
      var group = Group.GetDetails(id);
      return View(group);
    }

    [HttpPost]
    public ActionResult Edit(Group group)
    {
      int id = group.GroupId;
      Group.Patch(group);
      return RedirectToAction("Details", id);
    }

    public ActionResult Delete(int id)
    {
      var group = Group.GetDetails(id);
      return View(group);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Group.Delete(id);
      return RedirectToAction("Index");
    }
  }
}