using BangazonWorkforce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BangazonWorkforce.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IConfiguration _config;

        public DepartmentsController(IConfiguration config)
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
        // GET: DepartmentsController
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                Select d.Id, d.Name AS 'Department Name', d.Budget, (SELECT COUNT(e.DepartmentId) FROM Employee e WHERE e.DepartmentId=d.id) AS 'Num of Employees'
FROM Department d";


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Departments> departments = new List<Departments>();
                    while (reader.Read())
                    {
                        Departments department = new Departments
                        {
                            //Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Department Name")),
                            Budget = reader.GetInt32(reader.GetOrdinal("Budget")),
                            NumofEmployees = reader.GetInt32(reader.GetOrdinal("Num of Employees"))
                        };

                        departments.Add(department);

                    };

                    reader.Close();
                    return View(departments);

                }
            }
        }


        //                // GET: DepartmentsController/Details/5
        //                public ActionResult Details(int id)
        //                {
        //                    return View();
        //                }

        //                // GET: DepartmentsController/Create
        //                public ActionResult Create()
        //                {
        //                    return View();
        //                }

        //                // POST: DepartmentsController/Create
        //                [HttpPost]
        //                [ValidateAntiForgeryToken]
        //                public ActionResult Create(IFormCollection collection)
        //                {
        //                    try
        //                    {
        //                        return RedirectToAction(nameof(Index));
        //                    }
        //                    catch
        //                    {
        //                        return View();
        //                    }
        //                }

        //                // GET: DepartmentsController/Edit/5
        //                public ActionResult Edit(int id)
        //                {
        //                    return View();
        //                }

        //                // POST: DepartmentsController/Edit/5
        //                [HttpPost]
        //                [ValidateAntiForgeryToken]
        //                public ActionResult Edit(int id, IFormCollection collection)
        //                {
        //                    try
        //                    {
        //                        return RedirectToAction(nameof(Index));
        //                    }
        //                    catch
        //                    {
        //                        return View();
        //                    }
        //                }

        //                // GET: DepartmentsController/Delete/5
        //                public ActionResult Delete(int id)
        //                {
        //                    return View();
        //                }

        //                // POST: DepartmentsController/Delete/5
        //                [HttpPost]
        //                [ValidateAntiForgeryToken]
        //                public ActionResult Delete(int id, IFormCollection collection)
        //                {
        //                    try
        //                    {
        //                        return RedirectToAction(nameof(Index));
        //                    }
        //                    catch
        //                    {
        //                        return View();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
