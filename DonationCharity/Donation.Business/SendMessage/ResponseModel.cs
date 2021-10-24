﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Data.Entities
{
    public class ResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
