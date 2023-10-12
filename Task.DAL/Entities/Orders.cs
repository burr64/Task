using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.DAL.Entities;

public class Orders
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public Users? User { get; set; }
    public int Price {  get; set; }
}