using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Todo
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string description {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime DueDate {get; set;}
    }
}