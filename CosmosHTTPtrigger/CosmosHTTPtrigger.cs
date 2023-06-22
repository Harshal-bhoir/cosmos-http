using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using CosmosHTTPtrigger.Models;

namespace CosmosHTTPtrigger;

public static class CosmosHTTPtrigger
{
    [FunctionName("CosmosHTTPtrigger")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [CosmosDB(
            databaseName: "Employees",
            containerName: "Employees",
            SqlQuery ="select * from c",
            Connection = "CosmosDbConnectionString")] IEnumerable<Employee> employees,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        foreach (Employee employee in employees)
        {
            log.LogInformation(employee.EmpName);
        }
        return new OkResult();

    }
}

