using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleWebFrontend_NETFRAMEWORK48.Models;

namespace SimpleWebFrontend_NETFRAMEWORK48.Controllers
{
    public class HomeController : Controller
    {
        json_data json_data_getting = new json_data();
        public ActionResult Index()
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            ViewBag.LatestOrderLIST = json_data_getting.LatestOrder_list;
            ViewBag.HottestOrderLIST = json_data_getting.HotestOrder_list;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            return View();
        }
        public ActionResult Tracking()
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            return View();
        }
        [HttpGet]
        public ActionResult Order(string ModelType)
        {
            return Redirect("/Order/Index/?ModelType=" + ModelType);
        }
        [HttpPost]
        public ActionResult Search(string q)
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            ViewBag.Search = q;
            if (q == "")
            {
                return Redirect("/Home/NotFound");
            }
            else
            {
                Dictionary<string, Dictionary<string, string>> SearchOrder = new Dictionary<string, Dictionary<string, string>>();
                foreach (var tmp in json_data_getting.Order_list as Dictionary<string, Dictionary<string, string>>)
                {
                    if(tmp.Value["OrderName"].IndexOf(q) != -1)
                    {
                        SearchOrder.Add(tmp.Key, tmp.Value);
                    }
                }
                if(SearchOrder.Count == 0)
                {
                    return Redirect("/Home/NotFound");
                }
                ViewBag.SearchOrder = SearchOrder;
                return View();
            }
        }
        public ActionResult NotFound()
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            return View();
        }
        public ActionResult GetOrder(string OrderCode)
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            if (Request.HttpMethod == "GET")
            {
                if(Session.Keys.Count == 0)
                {
                    return Redirect("/Home/NoGetOrder");
                }
                else
                {
                    bool data_check = false;
                    for(int i = 0; i < Session.Keys.Count; i++)
                    {
                        if(Session.Keys.Get(i) == "OrderCode")
                        {
                            data_check = true;
                        }
                    }
                    if(data_check)
                    {
                        ViewBag.Order = json_data_getting.Order_list;
                        ViewBag.OrderCode = Session["OrderCode"].ToString();
                        return View();
                    }
                    else
                    {
                        return Redirect("/Home/NoGetOrder");
                    }
                }
            }
            else
            {
                ViewBag.Order = json_data_getting.Order_list;
                Session["OrderCode"] = OrderCode;
                ViewBag.OrderCode = Session["OrderCode"].ToString();
                return View();
            }
        }
        public ActionResult NoGetOrder()
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            return View();
        }
        public ActionResult Payment()
        {
            ViewBag.ModelTypeCode_LSIT = json_data_getting.ModelTypeCode_list;
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            ViewBag.PaymentLIST = json_data_getting.Payment_list;
            return View();
        }
    }
}