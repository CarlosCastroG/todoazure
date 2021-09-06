using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using todoazure.Common.Models;
using todoazure.Functions.Entities;
using todoazure.Functions.Functions;
using todoazure.Test.Helpers;
using Xunit;

namespace todoazure.Test.Tests
{
    public class TodoApiTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void CreateTodo_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoRequest);

            // Act
            IActionResult response = await TodoAPI.CreateTodo(request, mockTodos, logger);

            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

        }

        [Fact]
        public async void UpdateTodo_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);

            // Act
            IActionResult response = await TodoAPI.UpdateTodo(request, mockTodos, todoId.ToString(), logger);

            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }


        [Fact]
        public async void DeleteTodo_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            TodoEntity todoEntity = TestFactory.GetTodoEntity();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);

            // Act
            IActionResult response = await TodoAPI.DeleteTodo(request, todoEntity, mockTodos, todoId.ToString(), logger);

            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public void GetTodoById_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockEmployee = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo EmployeeRequest = TestFactory.GetTodoRequest();
            Guid EmployeeId = Guid.NewGuid();
            TodoEntity todoEntity = TestFactory.GetTodoEntity();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(EmployeeId, EmployeeRequest);

            // Act
            IActionResult response = TodoAPI.GetTodoById(request, todoEntity, EmployeeId.ToString(), logger);
            
            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async void GetAllTodos_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockEmployee = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo EmployeeRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(EmployeeRequest);

            // Act
            IActionResult response = await TodoAPI.GetAllTodos(request, mockEmployee, logger);
           
            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
