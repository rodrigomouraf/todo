using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.API.Controllers.TodoController;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetAll("rodrigomoura");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetAllDone("rodrigomoura");
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetAllUndone("rodrigomoura");
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetInactiveForToday(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetByPeriod(
            "rodrigomoura",
            false,
            DateTime.Now.Date
        );
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetByPeriod(
            "rodrigomoura",
            true,
            DateTime.Now.Date.AddDays(1)
        );
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
        [FromServices]ITodoRepository repository
    )
    {
        return repository.GetByPeriod(
            "rodrigomoura",
            false,
            DateTime.Now.Date.AddDays(1)
        );
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody]CreateTodoCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "rodrigomoura";
        return (GenericCommandResult)handler.Handle(command); 
    }

    [Route("")]
    [HttpPatch]
    public GenericCommandResult Update(
        [FromBody]UpdateTodoCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "rodrigomoura";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPatch]
    public GenericCommandResult MarkAsDone(
        [FromBody]MarkTodoAsDoneCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "rodrigomoura";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPatch]
    public GenericCommandResult MarkAsUndone(
        [FromBody]MarkTodoAsUndoneCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "rodrigomoura";
        return (GenericCommandResult)handler.Handle(command);
    }
} 
