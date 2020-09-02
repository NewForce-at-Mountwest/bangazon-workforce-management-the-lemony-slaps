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
                SELECT d.Id,
                       d.Name,
                        d.Budget
                FROM Departments d
                JOIN Employee e ON d.
            ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Departments> departments = new List<Departments>();
                    while (reader.Read())
                    {
                        Departments department = new Departments
                    }
                    return View();
                }

                // GET: DepartmentsController/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: DepartmentsController/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: DepartmentsController/Create
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

                // GET: DepartmentsController/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: DepartmentsController/Edit/5
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

                // GET: DepartmentsController/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: DepartmentsController/Delete/5
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
    }
}
