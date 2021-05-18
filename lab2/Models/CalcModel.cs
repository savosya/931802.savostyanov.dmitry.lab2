using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class CalcModel
    {
        public int a { get; set; }
        public int b { get; set; }
        public string Operation { get; set; }
        public string Calculate()
        {
            return Operation switch
            {
                "+" => $"{a} + {b} = {a + b}",
                "-" => $"{a} - {b} = {a - b}",
                "*" => $"{a} * {b} = {a * b}",
                "/" => b == 0 ? "Can't devide by zero": $"{a} / {b} = {a / b}",
                _ => "Invalid input"
            };
        }
    }
    
}
