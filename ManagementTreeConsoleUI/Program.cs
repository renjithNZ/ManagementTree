using ManagementTreeLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManagementTreeLibrary.Models;


namespace ManagementTreeConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            displayManagementTree();
        }

        static void displayManagementTree()
        {
            Employees employees = new Employees();
            List<Employee> employeeList = employees.GetEmployees();

            List<string> DisplayList = employees.GetTreeList(employeeList);

            if (DisplayList != null && DisplayList.Count > 0)
            {
                foreach (string list in DisplayList)
                {
                    Console.WriteLine(list);
                }
            }
            else
            {
                Console.WriteLine("Warning: Empty list");
            }
            Console.Read();
        }
    }
}
