using CRUDEXAMPLE.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRUDEXAMPLE.Data.Models;
public class TaskDataModel
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Görev ismi gereklidir.")]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime LastTime { get; set; }
    public TaskDataType Type { get; set; }

}
