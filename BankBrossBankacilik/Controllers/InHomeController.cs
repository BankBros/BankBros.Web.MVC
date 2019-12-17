using Anonymous.FormsCrossCutting.Helpers;
using BankBros.Backend.Entity.Concrete;
using BankBros.Backend.Entity.Dtos;
using BankBrossBankacilik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BankBrossBankacilik.Controllers
{
    public class InHomeController : Controller
    {
        public async Task<ActionResult> AddBill()
        {
            try
            {
               
                Customer obj = Session["customer"] as Customer;
                if (obj == null)
                {
                    obj = new Customer();
                    Session["customer"] = obj;
                }

                Bill fatura = new Bill();
                fatura.Amount = 10;
                fatura.CustomerId = obj.CustomerDetails.Id;
                fatura.Name = "EskiBorçlar";
                fatura.OrganizationId = 1;

                var result1 = await Task.Run(() => ApiHelper1<string>.Post(fatura, "/api/Bill/"));
                if (result1 != null)
                {

                    
                    return RedirectToAction("Bill", "InHome");

                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Bill", "InHome");

                }
            }
            catch (Exception e)
            {

                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Bill", "InHome");
            }

        }

        public async Task<ActionResult> Credit()
        {
            try
            {
                
                Customer obj = Session["customer"] as Customer;
                if (obj == null)
                {
                    obj = new Customer();
                    Session["customer"] = obj;
                }
                string token = Session["Token"].ToString();
                var result = await Task.Run(() => ApiHelper<List<CreditRequestDto>>.Get("/api/Credit" ,token));

                if (result != null)
                {
                    return View(result);

                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Login", "Home");

                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Login", "Home");
            }

        }

        public async Task<ActionResult> Bill()
        {
            try
            {
                
                Customer obj = Session["customer"] as Customer;
                if (obj == null)
                {
                    obj = new Customer();
                    Session["customer"] = obj;
                }                

                var result = await Task.Run(() => ApiHelper1<List<Bill>>.Get("/api/Bill/"+obj.CustomerDetails.Id));

                if (result != null)
                {
                    return View(result);

                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "InHome");

                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "InHome");
            }

        }

        public async Task<ActionResult> Account()
        {
            try
            {
                
                string token = Session["Token"].ToString();
                var result = await Task.Run(() => ApiHelper<Customer>.Get("/api/customer", token));
                
                if (result != null)
                {
                    var customer = Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", Session["Token"].ToString()));
                    Session["customer"]= customer.Result;

                    return View(result);

                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "InHome");
                
                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "InHome");
            }
           
        }
        [HttpGet]
        public async Task<ActionResult> Deposit()
        {
            try
            {
                //Session["ErrMsg"] = "";
                string token = Session["Token"].ToString();
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                if (customer != null)
                {
                    Session["customer"] = customer;
                    return View(customer);
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "InHome");
                }
               
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "InHome");
                
            }
           
        }
        [HttpGet]
        public async Task<ActionResult> Draw()
        {

            try
            {
                //Session["ErrMsg"] = "";
                string token = Session["Token"].ToString();
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                if (customer != null)
                {
                    Session["customer"] = customer;
                    return View(customer);
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "InHome");
                }

            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "InHome");

            }
        }

    
    [HttpGet]
    public async Task<ActionResult> Transfer()
    {
        try
        {
                //Session["ErrMsg"] = "";
                string token = Session["Token"].ToString();
            var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
            if (customer != null)
            {
                    Session["customer"] = customer;
                    return View(customer);
            }
            else
            {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "InHome");
            }

        }
        catch (Exception e)
        {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "InHome");

        }

    }
        [HttpGet]
        public async Task<ActionResult> Virement()
        {
            try
            {
                //Session["ErrMsg"] = "";
                string token = Session["Token"].ToString();
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                if (customer != null)
                {
                    Session["customer"] = customer;
                    return View(customer);
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "InHome");
                }

            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "InHome");

            }

        }

        [HttpPost]
        public async Task<ActionResult> Deposit(int AccountNumber,decimal amount)
        {
            string token = Session["Token"].ToString();
            try
            {
                
                DepositDto deposit = new DepositDto();
                deposit.AccountNumber = AccountNumber;
                deposit.Amount = amount;
                var result = await Task.Run(() => ApiHelper<string>.Post(deposit, "/api/Transaction/deposit", token));

                if (result != null)
                {
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["customer"] = customer;
                    
                  
                    return RedirectToAction("Account", "InHome", customer);

                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    
                    return RedirectToAction("Deposit", "InHome", customer);
                    

                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
               
                return RedirectToAction("Deposit", "InHome", customer);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Draw(int AccountNumber, decimal amount)
        {
            string token = Session["Token"].ToString();
            try
            {
                
                DrawDto draw = new DrawDto();
                draw.AccountNumber = AccountNumber;
                draw.Amount = amount;
                var result = await Task.Run(() => ApiHelper<string>.Post(draw, "/api/Transaction/draw", token));

                if (result != null)
                {
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["customer"] = customer;
                    

                    return RedirectToAction("Account", "InHome", customer);

                }
                else
                {
                   
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    return RedirectToAction("Account", "InHome", customer);

                }
            }
            catch (Exception e)
            {

               
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                return RedirectToAction("Account", "InHome", customer);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Transfer(int targetAccount, int targetCustomer,decimal amount,int senderAccountNumber)
        {
            string token = Session["Token"].ToString();
            try
            {
                //Session["ErrMsg"] = "";
                Customer obj = Session["customer"] as Customer;
                if (obj == null)
                {
                    obj = new Customer();
                    Session["customer"] = obj;
                }
                
                TransferDto transfer = new TransferDto();
                transfer.Amount = amount;
                transfer.SenderAccountNumber = senderAccountNumber;
                transfer.SenderCustomerId = obj.CustomerDetails.Id;
                transfer.TargetAccountNumber = targetAccount;
                transfer.TargetCustomerId = targetCustomer;
                var result = await Task.Run(() => ApiHelper<string>.Post(transfer, "/api/Transaction/transfer", token));

                if (result!=null)
                {
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["customer"] = customer;
                   

                    return RedirectToAction("Account", "InHome", customer);
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                   
                    return RedirectToAction("Account", "InHome", customer);
                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
               
                return RedirectToAction("Account", "InHome", customer);
            }
           

           
        }

        [HttpPost]
        public async Task<ActionResult> Virement(int targetAccount, decimal amount, int senderAccountNumber)
        {
            string token = Session["Token"].ToString();
            try
            {
                //Session["ErrMsg"] = "";
                Customer obj = Session["customer"] as Customer;
                if (obj == null)
                {
                    obj = new Customer();
                    Session["customer"] = obj;
                }
                //Virement İsteğine dönüştürülecek

                VirementRequest virement = new VirementRequest();
                virement.Amount = amount;
                virement.TargetAccountNumber = targetAccount;
                virement.SenderAccountNumber = senderAccountNumber;

                
                var result = await Task.Run(() => ApiHelper<string>.Post(virement, "/api/Transaction/virement", token));

                if (result != null)
                {
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    Session["customer"] = customer;
                    

                    return RedirectToAction("Account", "InHome", customer);
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                    return RedirectToAction("Account", "InHome", customer);
                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", token));
                
                return RedirectToAction("Account", "InHome", customer);
            }



        }

        [HttpPost]
        public async Task<ActionResult> Bill( int senderAccountNumber,Bill x)
        {
            try
            {
                //Session["ErrMsg"] = "";
                Customer obj = Session["customer"] as Customer;
                if (obj == null)
                {
                    obj = new Customer();
                    Session["customer"] = obj;
                }

                PayBillDto faturaOdeme = new PayBillDto();
                faturaOdeme.AccountNumber = senderAccountNumber;
                faturaOdeme.Amount = x.Amount;
                             
               
                var result = await Task.Run(() => ApiHelper1<string>.Post(faturaOdeme,"/api/Bill/"+obj.CustomerDetails.Id+"/"+ x.Id+""));
                var result1 = await Task.Run(() => ApiHelper<string>.Get("/api/Support/clearcache", Session["Token"].ToString()));
                var customer = await Task.Run(() => ApiHelper<Customer>.Get("/api/Customer", Session["Token"].ToString()));
                Session["customer"] = customer;
                if (result != null)
                {
                    Session["ErrMsg"] = result;
                    return RedirectToAction("Bill","InHome");
                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "Home");
                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "Home");
            }



        }
        [HttpPost]
        public async Task<ActionResult> Credit(decimal amount,int age,string hashouse,int usedKredi, string hasphone)
        {
            try
            {
                //Session["ErrMsg"] = "";
                Customer obj = Session["customer"] as Customer;
                if (obj == null)
                {
                    obj = new Customer();
                    Session["customer"] = obj;
                }
                CreditRequestDto Krediİstek = new CreditRequestDto();
                Krediİstek.Amount = amount;
                Krediİstek.Age = age;

                if (hashouse=="true") {Krediİstek.HasHouse = true;}
                else { Krediİstek.HasHouse = false; }

                Krediİstek.UsedCredits = usedKredi;

                if (hasphone == "true") { Krediİstek.HasPhone = true; }
                else { Krediİstek.HasPhone = false; }

                string token = Session["Token"].ToString();
                var result = await Task.Run(() => ApiHelper<string>.Post(Krediİstek,"/api/Credit", token));

                if (result != null)
                {
                    
                    return RedirectToAction("Credit", "InHome");

                }
                else
                {
                    if (!ApiHelper<string>.ErrView.IsViewed)
                    {
                        Session["ErrMsg"] = ApiHelper<string>.ErrView;
                    }
                    return RedirectToAction("Account", "InHome");

                }
            }
            catch (Exception e)
            {
                if (!ApiHelper<string>.ErrView.IsViewed)
                {
                    Session["ErrMsg"] = ApiHelper<string>.ErrView;
                }
                return RedirectToAction("Account", "InHome");
            }

        }

    }
}