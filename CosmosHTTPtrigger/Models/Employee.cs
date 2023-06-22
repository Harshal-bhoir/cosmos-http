﻿using System;
using Newtonsoft.Json;

namespace CosmosHTTPtrigger.Models
{
	public class Employee
	{
        [JsonProperty("id")]
        public string? Id { get; set; }

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpDepartment { get; set; }
    }
}

