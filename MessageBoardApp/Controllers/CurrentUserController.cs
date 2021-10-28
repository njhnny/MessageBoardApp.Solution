using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using MessageBoardApp.Models;
using System.Threading.Tasks;


namespace MessageBoardApp.Controllers
{
  public class CurrentUserController : Controller
  {
    [HttpPost]
    public ActionResult Edit(CurrentUser currentUser)
    {
      CurrentUser.Patch(currentUser);
      return RedirectToAction("Index", "Persons");
    }
  }
} 