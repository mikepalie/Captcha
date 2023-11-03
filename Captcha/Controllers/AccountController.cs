using Captcha.Models;
using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Captcha.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Index()
        {
            var account = new Account();
            return View("Index", account);
        }

        [HttpPost]
        public ActionResult Save(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", account);
            }
            else
            {
                if (!this.IsCaptchaValid(""))
                {
                    ViewBag.error = "Invalid Captcha";
                    return View("Index", account);
                }
                else
                {
                    ViewBag.account = account;
                    return View("Success");
                }
            }
        }



    }
}