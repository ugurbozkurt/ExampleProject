namespace CRUDEXAMPLE.Data.Entities;

public abstract class BaseEntitiy
{
    public int Id { get; set; }
    public bool IsArchive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
