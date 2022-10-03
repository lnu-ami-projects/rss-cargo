﻿using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var changer = new ChangeFunctionality();
            var printer = new PrintFunctionality();

            while (true)
            {
                try
                {   
                    Console.WriteLine("1. Insert data to all tables");
                    Console.WriteLine("2. Print data");
                    Console.WriteLine("3. Delete All Data");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("\n");
                    
                    Console.Write("Enter flag:\t");
                    var flag = Convert.ToInt32(Console.ReadLine());
                    
                    switch (flag)
                    {
                        case 1:
                            Console.Write("Enter n:\t");
                            var n = Convert.ToInt32(Console.ReadLine());
                            changer.TablesInsertion(n);
                            Console.WriteLine("Insertion is done successfully\n");
                            break;
                        
                        case 2:
                            printer.PrintAllData();
                            break;
                        
                        case 3:
                            changer.TablesDeletion();
                            Console.WriteLine("Deletion is done successfully\n");
                            break;
                        
                        case 0:
                            return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}