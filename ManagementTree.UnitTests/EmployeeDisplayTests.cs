using System;
using System.Collections.Generic;
using System.Linq;
using ManagementTreeLibrary.Logic;
using ManagementTreeLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManagementTree.UnitTests
{
    [TestClass]
    public class EmployeeDisplayTests
    {
        [TestMethod]
        public void GetTreeListTest_NullEmployeeList()
        {
            //Arrange
            List<Employee> employeeList = null;
            Employees employees = new Employees();

            //Act
            List<string> DisplayList = employees.GetTreeList(employeeList);
            string expectedValue = "The list is empty";
            //Assert
            Assert.IsTrue(DisplayList[0].ToString() == expectedValue);
        }

        [TestMethod]
        public void GetTreeListTest_EmptyEmployeeList()
        {
            //Arrange
                Employees employees = new Employees();
            List<Employee> employeeList = new List<Employee>();
            //Act
            List<string> DisplayList = employees.GetTreeList(employeeList);
            string expectedValue = "The list is empty";
            //Assert
            Assert.IsTrue(DisplayList[0].ToString() == expectedValue);
        }

        [TestMethod]
        public void GetTreeListTest_EmployeeList()
        {
            //Arrange
            Employees employees = new Employees();
            List<Employee> employeeList = employees.GetEmployees();

            List<string> DisplayList = employees.GetTreeList(employeeList);

            List<string> ExpectedList = new List<string>();
            
            ExpectedList.Add("->Tom");
            ExpectedList.Add("->->Jerry");
            ExpectedList.Add("->->Mickey");
            ExpectedList.Add("->->->John");
            ExpectedList.Add("->->Sarah");
            //Assert
            Assert.IsTrue(DisplayList.Count== ExpectedList.Count);
        }
    }
}
