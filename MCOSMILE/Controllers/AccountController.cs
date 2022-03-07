using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MCOSMILE.Models;

namespace MCOSMILE.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(MCOSMILE.Models.Login login)
        {
            using (DbModels2 db = new DbModels2())
            {
                var userDetails = db.Logins.Where(x => x.username == login.username && x.password == login.password).FirstOrDefault();
                if (userDetails == null)
                {
                    return View("~/Views/Account/Login.cshtml");

                }
                else
                {
                    Session["Id"] = userDetails.Id;
                    return View("~/Views/Home/Index.cshtml");
                }
            }


        }
    }
}