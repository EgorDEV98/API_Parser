﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API;
using API.Service;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = Company.Bankrot();           //Вызов метода
            test.data = "";                         //Параметры поиска
            Console.WriteLine(test.GetJSON());      //Получить JSON
        }
    }
}
