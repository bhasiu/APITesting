﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITesting.Models
{
    public class CreateUserRequest
    {
        public CreateUserRequest(string firstName, string lastName, string job)
        {
            FirstName = firstName;
            LastName = lastName;
            Job = job;
        }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
       
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        public string Job { get; set; }
    }
}
