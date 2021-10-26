using System.ComponentModel.DataAnnotations;

namespace MessageBoardApp.Models
{
  public class Group
  {
    public Group()
    {
    }
    public int GroupId { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "Maximum amount of characters for the group name is 30")]
    public string Name { get; set; }
  }
}