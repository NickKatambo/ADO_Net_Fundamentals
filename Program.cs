﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SampleAppOne
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            WriteLine($"Connection String: {cnnString}");
            ConnectionModel model = new ConnectionModel();
            model.Connect(cnnString.ConnectionString);

            WriteLine("### Command section ###");
            CommandModel commandModel = new CommandModel();
            commandModel.GetProductsCountScalar();

            ReadKey();
        }
    }
}
