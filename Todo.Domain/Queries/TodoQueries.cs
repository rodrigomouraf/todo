using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries;
public static class TodoQueries
{
    public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user) => x => x.Id == id && x.User == user;
    public static Expression<Func<TodoItem, bool>> GetAll(string user) => x => x.User == user;
    public static Expression<Func<TodoItem, bool>> GetAllDone(string user) => x => x.User == user && x.Done;
    public static Expression<Func<TodoItem, bool>> GetAllUndone(string user) => x => x.User == user && !x.Done;
    public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, bool done, DateTime date) => 
        x => x.User == user && x.Done == done && x.Date.Date == date;
}