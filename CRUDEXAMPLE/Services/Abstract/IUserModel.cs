using CRUDEXAMPLE.Data.Entities;

namespace CRUDEXAMPLE.Services.Abstract
{
    public interface IUserModel
    {
        User AddAsync(User user);
    }
}
