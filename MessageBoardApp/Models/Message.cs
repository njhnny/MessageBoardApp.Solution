using System;
using System.ComponentModel.DataAnnotations;

namespace MessageBoardApp.Models
{
  public class Message
  {
    public Message()
    {
      this.PostDate = DateTime.Now;
    }

    public int MessageId { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "Maximum amount of characters for the header is 30")]
    public string Header { get; set; }
    [Required]
    public string Body { get; set; }
    public DateTime PostDate { get; set; }
    public string UserId { get; set; }
    public int GroupId { get; set; }
  }
}