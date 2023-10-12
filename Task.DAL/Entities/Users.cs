using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.DAL.Entities;

public class Users
{
    [Key]
    public int Id { get; set; }
    public string? Surname { get; set; }
    public string? Name {  get; set; }
    public string? Middlename { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "date")]
    public DateTime Birthday { get; set; }
}