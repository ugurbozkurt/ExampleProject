using CRUDEXAMPLE.Data.Enums;

namespace CRUDEXAMPLE.Data.Entities;

public class TaskData:BaseEntitiy
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime LastTime { get; set; }
    public TaskDataType Type { get; set; }
}
