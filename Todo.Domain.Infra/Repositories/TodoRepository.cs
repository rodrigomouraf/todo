using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;
public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;
    public TodoRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Create(TodoItem todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Date);
    }

    public TodoItem GetById(Guid id, string user)
    {
        return _context.Todos
            .FirstOrDefault(TodoQueries.GetById(id, user));
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, bool done, DateTime date)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, done, date))
            .OrderBy(x => x.Date);
    }

    public void Update(TodoItem todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        _context.SaveChanges();
    }
    /*
    public async Task CreateAsync(TodoItem todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync(string user)
    {
        return await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetAllDoneAsync(string user)
    {
        return await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetAllUndoneAsync(string user)
    {
        return await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Date)
            .ToListAsync();
    }

    public async Task<TodoItem> GetByIdAsync(Guid id, string user)
    {
        return await _context.Todos
            .FirstOrDefaultAsync(TodoQueries.GetById(id, user));
    }

    public async Task<IEnumerable<TodoItem>> GetByPeriodAsync(string user, bool done, DateTime date)
    {
        return await _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, done, date))
            .OrderBy(x => x.Date)
            .ToListAsync();
    }

    public async Task UpdateAsync(TodoItem todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    */
}