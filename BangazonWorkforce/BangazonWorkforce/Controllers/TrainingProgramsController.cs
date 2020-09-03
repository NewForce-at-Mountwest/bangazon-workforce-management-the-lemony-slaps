using BangazonWorkforce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BangazonWorkforce.Controllers
{
    public class TrainingProgramsController : Controller
    {
        private readonly IConfiguration _config;

        public TrainingProgramsController(IConfiguration config)
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
        // GET: TrainingPrograms
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    DateTime today = DateTime.Today;
                    cmd.CommandText = @"
                SELECT tp.Id,
                    tp.Name,
                    tp.StartDate,
                    tp.EndDate,
                    tp.MaxAttendees
                    FROM TrainingProgram tp
                    WHERE EndDate > @today
                ";
                    cmd.Parameters.Add(new SqlParameter("@today", today));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TrainingPrograms> trainingList = new List<TrainingPrograms>();
                    while (reader.Read())
                    {
                        TrainingPrograms trainingToAdd = new TrainingPrograms
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                            MaxAttendees = reader.GetInt32(reader.GetOrdinal("MaxAttendees"))
                        };

                        trainingList.Add(trainingToAdd);
                    }

                    reader.Close();


                    return View(trainingList);
                }
            }
        }

        // GET: TrainingPrograms/Details/5
        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    DateTime today = DateTime.Today;
                    cmd.CommandText = @"
                SELECT tp.Id,
                    tp.Name,
                    tp.StartDate,
                    tp.EndDate,
                    tp.MaxAttendees
                    FROM TrainingPrograms tp
                    WHERE EndDate > @today
                ";
                    cmd.Parameters.Add(new SqlParameter("@today", today));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TrainingPrograms> trainingList = new List<TrainingPrograms>();
                    while (reader.Read())
                    {
                        TrainingPrograms trainingToAdd = new TrainingPrograms
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                            MaxAttendees = reader.GetInt32(reader.GetOrdinal("MaxAttendees"))
                        };

                        trainingList.Add(trainingToAdd);
                    }

                    reader.Close();


                    return View(trainingList);
                }
            }
        }

        // GET: TrainingPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: TrainingPrograms/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TrainingPrograms/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TrainingPrograms/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TrainingPrograms/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TrainingPrograms/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
