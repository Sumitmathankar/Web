﻿using API_CRUD_PRACT_1.Models;
using API_CRUD_PRACT_1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_PRACT_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>?>> GetEmployees()
      {
            if (await _repository.GetAllEmployee() == null)
            {
                return NotFound();
            }

            return await _repository.GetAllEmployee();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _repository.Add(employee);
            return CreatedAtAction("PostEmployee", new { id = employee.Id }, employee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById_ActionResultOfT(int id)
        {
            var employee = await _repository.GetEmployee(id);
            return employee == null ? NotFound() : employee;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }




        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            try
            {
                await _repository.Update(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetEmployee(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


    }
}
