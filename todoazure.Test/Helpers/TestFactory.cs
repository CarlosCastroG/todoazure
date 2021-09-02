using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using todoazure.Common.Models;
using todoazure.Functions.Entities;

namespace todoazure.Test.Helpers
{
    public class TestFactory
    {
        public static TodoEntity GetTodoEntity()
        {
            return new TodoEntity
            {
                ETag = "*",
                PartitionKey = "TODO",
                RowKey = Guid.NewGuid().ToString(),
                DateTimeEmployee = DateTime.UtcNow,
                IdEmployee = "ID",
                Consolidated = false,
                Type = 0,
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Guid todoId, Todo todoRequest)
        {
            string request = JsonConvert.SerializeObject(todoRequest);
            return new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamFromString(request),
                Path = $"/{todoId}"
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Guid todoId)
        {
            return new DefaultHttpRequest(new DefaultHttpContext())
            {
                Path = $"/{todoId}"
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Todo todoRequest)
        {
            string request = JsonConvert.SerializeObject(todoRequest);
            return new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamFromString(request),
            };
        }

        public static DefaultHttpRequest CreateHttpRequest()
        {
            return new DefaultHttpRequest(new DefaultHttpContext());
        }

        public static Todo GetTodoRequest()
        {
            return new Todo
            {
                DateTimeEmployee = DateTime.UtcNow,
                IdEmployee = "*",
                Consolidated = false,
                Type = 0
            };
        }

        public static Stream GenerateStreamFromString(string stringToConvert)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(stringToConvert);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;
            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}