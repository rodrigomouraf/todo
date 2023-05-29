using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;
[TestClass]
public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título da Tarefa", "rodrigo", DateTime.Now);
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());    
    [TestMethod]
    public void given_an_invalid_command_should_stop_execution()
    {
        var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }
    [TestMethod]
    public void given_a_valid_command_should_create_the_task()
    {
        var result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}
