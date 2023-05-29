using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;
[TestClass]
public class TodoQueriesTests
{
    private List<TodoItem> _items;
    public TodoQueriesTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", "outrousuario", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "rodrigomoura", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "outrousuario", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "rodrigomoura", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "outrousuario", DateTime.Now));
    }
    [TestMethod]
    public void Must_return_tasks_only_from_user_rodrigomoura()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("rodrigomoura"));
        Assert.AreEqual(2, result.Count());
    }
}