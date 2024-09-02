using CRUDEXAMPLE.Data.Context;
using CRUDEXAMPLE.Data.Entities;
using CRUDEXAMPLE.Data.Models;
using CRUDEXAMPLE.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CRUDEXAMPLE.Services.Concrate;

public class TaskDataService:ITaskDataService
{
    private readonly ApplicationDbContext _context;

    public TaskDataService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TaskDataModel taskDataModel)
    {
        TaskData taskData = new TaskData();
        taskData.Name = taskDataModel.Name;
        taskData.Description = taskDataModel.Description;
        taskData.LastTime = taskDataModel.LastTime;
        taskData.Type = taskDataModel.Type;
        await _context.Tasks.AddAsync(taskData);
        await _context.SaveChangesAsync();

    }
    public async Task UpdateAsync(TaskDataModel taskDataModel)
    {
        var taskData = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == taskDataModel.Id.Value);
        taskData.Name = taskDataModel.Name;
        taskData.Description = taskDataModel.Description;
        taskData.LastTime = taskDataModel.LastTime;
        taskData.Type = taskDataModel.Type;
        _context.Tasks.Update(taskData);
        await _context.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(int id)
    {
        var taskData = await _context.Tasks.FirstOrDefaultAsync(x=>x.Id == id);
        taskData.IsArchive = true;
        taskData.DeletedDate = DateTime.UtcNow;
        _context.Update(taskData);
        await _context.SaveChangesAsync();
    }

    
    public async Task<List<TaskDataModel>> GetAllAsync() 
    {
        var tasks = await _context.Tasks.Where(x=>!x.IsArchive).ToListAsync();
        var result = tasks.Select(x => new TaskDataModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            LastTime = x.LastTime,
            Type = x.Type,
        }).ToList();
        return result;
    }

    public async Task<TaskDataModel> GetByIdAsync(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(o => o.Id == id);
        var result = new TaskDataModel { Description = task.Description, Id = task.Id, LastTime = task.LastTime, Name = task.Name, Type = task.Type };
        return result;
    }
}
