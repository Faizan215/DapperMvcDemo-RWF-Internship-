using Dapper;
using DapperMvcDemo.Data.DataAccess;
using DapperMvcDemo.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperMvcDemo.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ISqlDataAccess _db;

        public PersonRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Person person)
        {
            try
            {
                Console.WriteLine($"Adding Person: {person.Name}, {person.Email}, {person.Address}, DeptId: {person.DepartmentId}");

                if (person.DepartmentId <= 0)
                {
                    Console.WriteLine("ERROR: DepartmentId is invalid. Fix form submission.");
                    return false;
                }

                await _db.SaveData("sp_create_person", new
                {
                    person.Name,
                    person.Email,
                    person.Address,
                    person.DepartmentId
                });

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            try
            {
                Console.WriteLine($"Updating Person: Id={person.Id}, Name={person.Name}, Email={person.Email}, Address={person.Address}, DepartmentId={person.DepartmentId}");

                await _db.SaveData("sp_update_person", new
                {
                    person.Id,
                    person.Name,
                    person.Email,
                    person.Address,
                    person.DepartmentId
                });

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Console.WriteLine($"Deleting Person: Id={id}");
                await _db.SaveData("sp_delete_person", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            try
            {
                var result = await _db.GetData<Person, dynamic>("sp_get_person", new { Id = id });
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            try
            {
                var people = await _db.GetData<Person, dynamic>("sp_get_people", new { });
                return people;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Person>();
            }
        }

        public async Task<IEnumerable<Person>> SearchPersonsAsync(string term)
        {
            try
            {
                var parameters = new { SearchTerm = $"%{term}%" };
                return await _db.GetData<Person, dynamic>("sp_SearchPersons", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchPersonsAsync: {ex.Message}");
                return new List<Person>();
            }
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            try
            {
                return await _db.GetData<Department, dynamic>("sp_GetAllDepartments", new { });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetDepartmentsAsync: {ex.Message}");
                return new List<Department>();
            }
        }

        public async Task<IEnumerable<Person>> GetPersonsByDepartmentAsync(int departmentId)
        {
            try
            {
                return await _db.GetData<Person, dynamic>("sp_GetPersonsByDepartment", new { DepartmentId = departmentId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPersonsByDepartmentAsync: {ex.Message}");
                return new List<Person>();
            }
        }

        
        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            try
            {
                var people = await _db.GetData<Person, dynamic>("sp_get_people", new { });
                return people;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllPersonsAsync: {ex.Message}");
                return new List<Person>();
            }
        }
    }
}
