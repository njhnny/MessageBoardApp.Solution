using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MessageBoardApp.Models
{
  public class Message
  {
    public Message()
    {
      this.PostDate = DateTime.Now;
    }

    public int MessageId { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public DateTime PostDate { get; set; }
    public int PersonId { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public virtual Person Person { get; set; }
    public static List<Message> GetAllMessages()
    {
      var apiCallTask = ApiHelper.GetMessages();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messageList;
    }

    public static Message GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetMessage(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());
      
      return message;
    }

    public static void Post(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.PostMessage(jsonMessage);
    }

    public static void Patch(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.PatchMessage(message.MessageId, jsonMessage);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteMessage(id);
    }
  }
}