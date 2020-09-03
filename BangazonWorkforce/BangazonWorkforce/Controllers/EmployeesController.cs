using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BangazonWorkforce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using BangazonWorkforce.Models;

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
            return View();
        }
    

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Department.Name, Department.Id  FROM Department";

                    SqlDataReader reader = cmd.ExecuteReader();

                    EmployeeDepartmentViewModel viewModel = new EmployeeDepartmentViewModel();
                    while (reader.Read())
                    {
                        Departments department = new Departments
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                            

                        };
                        SelectListItem DepartmentOptionTag = new SelectListItem()
                        {
                            Text = department.Name,
                            Value = department.Id.ToString()
                        };


                        viewModel.departments.Add(DepartmentOptionTag);
                    }

                    reader.Close();

                    return View(viewModel);
                }

            }
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDepartmentViewModel viewModel)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO Employee
                ( FirstName, LastName, DepartmentId )
                 VALUES
                 ( @firstName, @lastName, @departmentId )";
                        cmd.Parameters.Add(new SqlParameter("@firstName", viewModel.employee.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@lastName", viewModel.employee.LastName));
                        cmd.Parameters.Add(new SqlParameter("@slackHandle", viewModel.employee.DepartmentId));
                        cmd.ExecuteNonQuery();

                        return RedirectToAction(nameof(Index));
                    }
                }
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
            try { 
            
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
