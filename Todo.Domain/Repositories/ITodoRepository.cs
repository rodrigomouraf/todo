using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;
public interface ITodoRepository 
{
    void Create(TodoItem todo);
    void Update(TodoItem todo);
    TodoItem GetById(Guid id, string user);
    IEnumerable<TodoItem> GetAll(string user);
    IEnumerable<TodoItem> GetAllDone(string user);
    IEnumerable<TodoItem> GetAllUndone(string user);
    IEnumerable<TodoItem> GetByPeriod(string user, bool done, DateTime date);
    /*
    Task CreateAsync(TodoItem todo);
    Task UpdateAsync(TodoItem todo);
    Task<TodoItem> GetByIdAsync(Guid id, string user);
    Task<IEnumerable<TodoItem>> GetAllAsync(string user);
    Task<IEnumerable<TodoItem>> GetAllDoneAsync(string user);
    Task<IEnumerable<TodoItem>> GetAllUndoneAsync(string user);
    Task<IEnumerable<TodoItem>> GetByPeriodAsync (string user, bool done, DateTime date);
    */
}