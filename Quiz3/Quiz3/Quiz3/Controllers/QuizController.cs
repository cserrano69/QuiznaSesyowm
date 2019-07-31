using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz3.Models;
using Quiz3.App_Code;
using System.Data.SqlClient;

namespace Quiz3.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            User principal = new User();
            return View(principal);
        }

        [HttpPost]

        public ActionResult Add(User user)
        {
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"INSERT INTO Yikes VALUES(@Name, @Agent, @Item, @SRP, @TSP, @SalesDiscount)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Agent", user.SalesAgent);
                    cmd.Parameters.AddWithValue("@Item", user.VehicleName);
                    cmd.Parameters.AddWithValue("@SRP", user.OSP);
                    cmd.Parameters.AddWithValue("@TSP", user.DSP);
                    cmd.Parameters.AddWithValue("@SalesDiscount", user.SalesDiscount);
                    cmd.ExecuteNonQuery();
                }
            }

            Session["Name"] = user.Name;
            Session["Agent"] = user.SalesAgent;
            Session["Item"] = user.VehicleName;
            Session["SRP"] = user.OSP;
            Session["TSP"] = user.DSP;
            Session["Discount"] = user.SalesDiscount;
            Session["Condition"] = user.Condition;

            return RedirectToAction("Index");
        }


    }
}