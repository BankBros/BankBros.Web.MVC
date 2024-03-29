﻿using Anonymous.FormsCrossCutting.Helpers;
using BankBros.Backend.Entity.Concrete;
using BankBrossBankacilik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace BankBrossBankacilik.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ErrorViewer erv = new ErrorViewer();
            erv.IsViewed = true;
            Session["ErrMsg"] = erv;
            return View();
        }
      
        public ActionResult Login()
        {
            
            return View();
        }
        public ActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(string tc,string pw)
        {
            try
            {               
                Login login1 = new Login();
                login1.Username = tc;
                login1.Password = pw;
                login1.applicationId = "4";
                login1.applicationName = "Web";

                var result = Task.Run(() => ApiHelper<AccesToken>.Post(login1,"/api/auth/login/customer")).Result;
                if (result != null)
                {
                    Session["Token"] = "Bearer "+result.Token;
                    var customer =  Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", Session["Token"].ToString()));
                    Session.Add("customer", customer.Result);
                   
                    return RedirectToAction("Account", "InHome");
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                   
                    return View();
                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return View();
            }
        }
        [HttpPost]
        public ActionResult Register(string tc,string pw,string ad, string soyad,string email,string tel, string gizliSoru,string gizliCevap,string il,string ilce)
        {
            try
            {               
                Register register = new Register();
                register.Username = tc;
                register.Password = pw;
                register.FirstName = ad;
                register.LastName = soyad;
                register.Email = email;
                register.PhoneNumber = tel;
                register.SecretQuestion = gizliSoru;
                register.SecretAnswer = gizliCevap;
                register.Address = il+"/"+ ilce.ToUpper();
                register.TCKN = tc;

                var result = Task.Run(() => ApiHelper<AccesToken>.Post(register, "/api/auth/register/customer")).Result;
                if (result != null)
                {
                    
                    Session["Token"] = "Bearer " + result.Token;
                    return RedirectToAction("Account", "InHome");
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return View();
                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return View();
            }           
        }
    }
}