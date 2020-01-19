using System;
using System.Collections.Generic;

namespace visma_test.Models
{
    public class UserInfoViewModel
    {
        public int Id {get;set;}
        public string Phone {get;set;}
        public string Login {get;set;}
        public List<DateTime> Attempts {get;set;}
    }   
}