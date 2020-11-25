using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementTreeLibrary.Models;

namespace ManagementTreeLibrary.Logic
{

    public class Employees : IEmployees
    {
        List<string> NewList = new List<string>();

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,Name="Tom",ManagerID=0},
                new Employee{Id=2,Name="Mickey",ManagerID=1},
                new Employee{Id=3,Name="Jerry",ManagerID=1},
                new Employee{Id=4,Name="John", ManagerID=2},
                new Employee{Id=5,Name="Sarah", ManagerID=1}
            };
            return employees;
        }

        public List<string> GetTreeList(List<Employee> employees)
        {
            if (employees != null && employees.Any())
            {
                foreach (Employee employee in employees.OrderBy(i => i.ManagerID))
                {
                    if (employee.ManagerID == 0)
                    {
                        NewList.Add($"->{employee.Name}");//Add root manager to a list
                        GetChildTree(employee.Id, employees, 2);//Get employees under root manager.
                        break;
                    }
                }
            }
            else
            {
                NewList.Add("The list is empty");
            }
            return NewList;
        }

        private List<string> GetChildTree(int Id, List<Employee> employeeList, int order)
        {
            List<Employee> children = employeeList.Where(x => x.ManagerID == Id).ToList().OrderBy(y => y.Name).ToList();//Get employees under a manager

            string result = new StringBuilder().Insert(0, "->", order).ToString();

            int nextOrder = order + 1;

            foreach (Employee child in children)
            {
                NewList.Add(result + (child.Name));
                GetChildTree(child.Id, employeeList, nextOrder);
            }
            return NewList;

        }

    }
}
