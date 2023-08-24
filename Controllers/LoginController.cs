using FinalProject.Models;
using FinalProject.Models.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class LoginController : Controller
    {
        public bool isLogin = false;
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel models)
        {
            List<UserModel> datas = ClientRequest<UserModel>.instance.GetDatasByKeyValue("UserName",models.UserName);
            if(datas != null)
            {
                foreach(UserModel e in datas)
                {
                    if (e.Password == models.Password) isLogin = true;
                }
            }
            if (isLogin)
            {
                return RedirectToAction("Index","Dashboard");
            }
            return View();
        }

    }   
}
