using System;
using System.Collections.Generic;

namespace visma_test.Models
{
    public class UserModel
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Surname {get;set;}
        public string Phone {get;set;}
        public string Login {get;set;}
        public List<DateTime> Attempts {get;set;}
    }   
}