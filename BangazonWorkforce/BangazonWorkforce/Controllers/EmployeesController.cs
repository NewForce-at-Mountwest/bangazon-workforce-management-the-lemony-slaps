using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BangazonWorkforce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace BangazonWorkforce.Controllers
{

    public class EmployeesController : Controller
    {
        private readonly IConfiguration _config;

        public EmployeesController(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                      SELECT e.FirstName AS [First Name], e.LastName AS [Last Name], d.[Name] AS [Department Name],
                       c.Make AS [Computer Make], c.Manufacturer AS [Computer Manufacturer], tP.[Name] AS [Training Program]
                       FROM Employee e
                       LEFT JOIN Department d on e.DepartmentId = d.Id
                       LEFT JOIN ComputerEmployee cE on cE.EmployeeId = e.Id
                       LEFT JOIN Computer c on cE.ComputerId = c.Id
                       LEFT JOIN EmployeeTraining eT on eT.EmployeeId = e.Id
                       LEFT JOIN TrainingProgram tP on eT.TrainingProgramId = tP.Id
                       WHERE e.Id = @id AND cE.UnassignDate is NULL";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Employees employee = null;

                    while (reader.Read())
                    {
                        if (employee == null && reader.IsDBNull(reader.GetOrdinal("Training Program")) && reader.IsDBNull(reader.GetOrdinal("Computer Make")))
                            employee = new Employees
                            {
                                FirstName = reader.GetString(reader.GetOrdinal("First Name")),
                                LastName = reader.GetString(reader.GetOrdinal("Last Name")),
                                department = new Departments
                                {
                                    Name = reader.GetString(reader.GetOrdinal("Department Name")),
                                },
                                computer = new Computers
                                {
                                    Make = reader.GetString(reader.GetOrdinal("Computer Make")),
                                    Manufacturer = reader.GetString(reader.GetOrdinal("Computer Manufacturer"))
                                }
                            };
                        else if (employee == null && !reader.IsDBNull(reader.GetOrdinal("Training Program")) && !reader.IsDBNull(reader.GetOrdinal("Computer Make")))
                            employee = new Employees
                            {
                                FirstName = reader.GetString(reader.GetOrdinal("First Name")),
                                LastName = reader.GetString(reader.GetOrdinal("Last Name")),
                                department = new Departments
                                {
                                    Name = reader.GetString(reader.GetOrdinal("Department Name")),
                                },
                                computer = new Computers
                                {
                                    Make = reader.GetString(reader.GetOrdinal("Computer Make")),
                                    Manufacturer = reader.GetString(reader.GetOrdinal("Computer Manufacturer"))
                                }
                            };
                        TrainingPrograms TrainingProgramList = new TrainingPrograms
                        {
                            Name = reader.GetString(reader.GetOrdinal("Training Program"))
                        };

                        employee.TrainingProgramList.Add(TrainingProgramList);

                    }
                    reader.Close();

                    return View(employee);
                }
            }
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
