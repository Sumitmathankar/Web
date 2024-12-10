using API_CRUD_PRACT_1.Models;
using API_CRUD_PRACT_1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_PRACT_1.Service
{
    public class SQLEmployeeRepository:IEmployeeRepository
    {
        private readonly Appdbcontext context;

        public SQLEmployeeRepository(Appdbcontext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<Employee>> Add(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<ActionResult<IEnumerable<Employee>?>> GetAllEmployee()
        {
            if (context.Employees == null)
            {
                return null;
            }
            return await context.Employees.ToListAsync();

        }


        public async Task<Employee> Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
            return employee;
        }


        public async Task<ActionResult<Employee>?> GetEmployee(int Id)
        {
            if (context.Employees == null)
            {
                return null;
            }
            var employee = await context.Employees.FindAsync(Id);

            if (employee == null)
            {
                return null;
            }

            return employee;
        }



        public async Task<Employee?> Update(int id, Employee employee)
        {
            //if (id != employee.Id)  optional Beacuse we CHECK ON conTROLLE enD POINt 
            //{
            //    return null;
            //}

            context.Entry(employee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;

        }
        private bool EmployeeExists(int id)
        {
            return (context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    




}
}
