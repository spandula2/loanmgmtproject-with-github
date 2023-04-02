using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LoanMgmtSystem.Models;
using MySql.Data.MySqlClient;

namespace LoanMgmtSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login obj)
        {
            ApiLoginController APILogin = new ApiLoginController();
            RegistrationDetails Reg = new RegistrationDetails();
            Reg = APILogin.Login(obj);

            if (Reg != null)
            {
                Session["CustId"] = Reg.CustId;
                Session["Role"] = Reg.Roles;
                return RedirectToAction("Index", "Loan");
            }
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistration(RegistrationDetails obj)
        {
            ApiLoginController APILogin = new ApiLoginController();
            string Flags = APILogin.SaveUserDetail(obj);
            if (Flags == "Y")
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.Message = Flags;
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}