using CRUDEXAMPLE.Data.Models;

namespace CRUDEXAMPLE.Services.Abstract;

public interface ITaskDataService
{
    Task AddAsync(TaskDataModel taskDataModel);
    Task UpdateAsync(TaskDataModel taskDataModel);
    Task SoftDeleteAsync(int id);
    Task<List<TaskDataModel>> GetAllAsync();
    Task<TaskDataModel> GetByIdAsync(int id);
}
