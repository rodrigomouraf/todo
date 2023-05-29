using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTests 
{
    private readonly TodoItem _validTodo = new TodoItem("Titulo Aqui", "rodrigo", DateTime.Now);
    
    [TestMethod]
    public void give_a_new_one_todo_the_same_cannot_be_completed() {
        Assert.AreEqual(_validTodo.Done, false);
    }
}