﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Auth.GetAccessTokenAsync("cucu");
            Console.ReadKey();
        }
    }
}
