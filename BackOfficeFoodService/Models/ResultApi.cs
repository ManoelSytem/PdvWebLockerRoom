﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class ResultApi
    {
        public string code { get; set; }
        public string description { get; set; }
        public bool erro { get; set; }
    }

}
