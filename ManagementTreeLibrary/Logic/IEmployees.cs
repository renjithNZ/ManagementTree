using ManagementTreeLibrary.Models;
using System.Collections.Generic;

namespace ManagementTreeLibrary.Logic
{
    public interface IEmployees
    {
      
    List<Employee> GetEmployees();
        List<string> GetTreeList(List<Employee> employees);
    }
}