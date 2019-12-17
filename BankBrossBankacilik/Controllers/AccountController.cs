using Anonymous.FormsCrossCutting.Helpers;
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
    public class AccountController : Controller
    {
        // GET: Account
        public async Task<ActionResult> newAccount()
        {
            string token = Session["Token"].ToString();
            try
            {
                
                var result = await Task.Run(() => ApiHelper<string>.Post(null, "/api/Account", token));

                if (result != null)
                {

                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["ErrMsg"] = "Yeni Hesap Açıldı "+result;
                    return RedirectToAction("Account", "InHome", customer);
                   
                }
                else
                {
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["ErrMsg"] = "Hesap Açarken Bir Sorun Oluştu";
                    return RedirectToAction("Account", "InHome",customer);

                }
            }
            catch (Exception e)
            {
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                Session["ErrMsg"] = "İstek İşlenirken Bir Sorun Oluştu ("+e.Message+")";
                return RedirectToAction("Account", "InHome", customer);
            }
        }

            public async Task<ActionResult> deleteAccount(int AccountNumber)
            {
            string token = Session["Token"].ToString();
            try
                {
                   
                    var result = await Task.Run(() => ApiHelper<string>.Delete("/api/Account/"+AccountNumber, token));

                    if (result != null)
                    {
                        var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["ErrMsg"] = "Hesap Silme Başarılı : " + result;
                    return RedirectToAction("Account", "InHome", customer);

                    }
                    else
                    {
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["ErrMsg"] = "Hesap Silerken Bir Sorun Oluştu ";
                    return RedirectToAction("Account", "InHome", customer);

                }
                }
                catch (Exception e)
                {

                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                Session["ErrMsg"] = "İstek İşlenirken Bir Sorun Oluştu (" + e.Message + ")";
                return RedirectToAction("Account", "InHome", customer);
            }

            }
        }
}