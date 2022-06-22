using EFOneToManyAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFOneToManyAssignment.Data
{
    public class CRUDManager
    {
        DemoDbContext DemoDbContext;
        public CRUDManager()
        {
            DemoDbContext = new DemoDbContext();
        }
        public void InsertEmployeeWithItsOrgnization(Employee employee, List<EmployeeOrganizations> employeeOrganizationsList)
        {
            var Employee = new Employee
            {
                Name = employee.Name,
                Address = employee.Address,
                EmployeesOrganizations = employeeOrganizationsList
            };
            DemoDbContext.Add(Employee);
            DemoDbContext.SaveChanges();


        }

        public void UpdateEmployeeAndOrgnization(int empId, string empname, List<EmployeeOrganizations> UpdateList)
        {
            var updateemp = DemoDbContext.Employees.Where(emp => emp.Id == empId).Include(e => e.EmployeesOrganizations).First();
            if (updateemp != null)
            {
                updateemp.Name = empname;
                updateemp.EmployeesOrganizations = UpdateList;
                DemoDbContext.Employees.Update(updateemp);
                DemoDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine(" No Record Exist With This Id " + empId);
            }

        }

        public void DeleteEmployeebyId(int empId)
        {
            var deleteEmp = DemoDbContext.Employees.Where(emp => emp.Id == empId).Include(e => e.EmployeesOrganizations).First();
            if (deleteEmp != null)
            {
                DemoDbContext.Employees.Remove(deleteEmp);
                deleteEmp.EmployeesOrganizations.Clear();
                DemoDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("No Record Found With This Id : " + empId);
            }
        }

        public void PrintAllEmployeedetails()
        {
            var employee = DemoDbContext.Employees.Include(e => e.EmployeesOrganizations).ToList();
            if (employee != null)
            {
                foreach (Employee emp in employee)
                {
                    Console.WriteLine("Employe Name   :" + emp.Name);
                    Console.WriteLine("Employee Address:" + emp.Address);
                    Console.WriteLine("Employee Organization Details");
                    foreach (EmployeeOrganizations employeeOrganizations in emp.EmployeesOrganizations)
                    {
                        Console.WriteLine("Employee Organization  :" + employeeOrganizations.OrgnizatinName);
                    }
                    Console.WriteLine();

                }
            }
            else
            {
                Console.WriteLine(" Record not Found with Id :");
            }
        }

    }
}
