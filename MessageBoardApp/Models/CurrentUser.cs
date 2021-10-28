using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardApp.Models
{
  public class CurrentUser
  {
    public int CurrentUserId { get; set; }
    public int PersonId { get; set; }
    public static CurrentUser GetCurrentUser()
    {
      var apiCallTask = ApiHelper.GetCurrentUser();
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      CurrentUser currentUser = JsonConvert.DeserializeObject<CurrentUser>(jsonResponse.ToString());

      return currentUser;
    }

    public static void Patch(CurrentUser currentUser)
    {
      string jsonCurrentUser = JsonConvert.SerializeObject(currentUser);
      var apiCallTask = ApiHelper.PatchCurrentUser(currentUser.CurrentUserId, jsonCurrentUser);
    }
  }
}