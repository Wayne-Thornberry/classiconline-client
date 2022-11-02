using Newtonsoft.Json;
using Proline.ClassicOnline.EventQueue;
using Proline.Resource.IO;
using System;
using System.Collections.Generic;
using Console = Proline.Resource.Console;

namespace Proline.ClassicOnline.Engine
{
    public class Program
    { 
        private static void Main(string[] args)
        {  
            try
            {
                Component.InitializeComponents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
