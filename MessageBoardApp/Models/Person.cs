using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardApp.Models
{
  public class Person
  {
    public Person()
    {
      this.Messages = new HashSet<Message>();
    }
    public int PersonId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
    public static List<Person> GetAllPersons()
    {
      var apiCallTask = ApiHelper.GetPersons();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(jsonResponse.ToString());

      return personList;
    }

    public static Person GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetPerson(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Person person = JsonConvert.DeserializeObject<Person>(jsonResponse.ToString());

      return person;
    }

    public static void Post(Person person)
    {
      string jsonPerson = JsonConvert.SerializeObject(person);
      var apiCallTask = ApiHelper.PostPerson(jsonPerson);
    }

    public static void Patch(Person person)
    {
      string jsonPerson = JsonConvert.SerializeObject(person);
      var apiCallTask = ApiHelper.PatchPerson(person.PersonId, jsonPerson);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeletePerson(id);
    }
  }
}