using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardApp.Models
{
  public class Group
  {
    public Group()
    {
      this.Messages = new HashSet<Message>();
    }
    public int GroupId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Message> Messages { get; set; }

    public static List<Group> GetAllGroups()
    {
      var apiCallTask = ApiHelper.GetGroups();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

      return groupList;
    }

    public static Group GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetGroup(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Group group = JsonConvert.DeserializeObject<Group>(jsonResponse.ToString());

      return group;
    }

    public static void Post(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      var apiCallTask = ApiHelper.PostGroup(jsonGroup);
    }

    public static void Patch(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      var apiCallTask = ApiHelper.PatchGroup(group.GroupId, jsonGroup);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteGroup(id);
    }
  }
}