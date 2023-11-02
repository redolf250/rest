using System.ComponentModel.DataAnnotations;

namespace rest.Models;

public class Person
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }
}