using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleWebFrontend_NETFRAMEWORK48.Models;

namespace SimpleWebFrontend_NETFRAMEWORK48.Controllers
{
    public class OrderController : Controller
    {
        json_data json_data_getting = new json_data();
        public ActionResult Index(string ModelType, string ModelName)
        {
            if (ModelType == "" |  ModelType == null)
            {
                return Content("Error");
            }
            if (json_data_getting.ModelTypeCode_list[ModelType] == null)
            {
                return Content("Error");
            }
            ViewBag.ModelType = ModelType;
            ViewBag.ModelNameLIST = json_data_getting.ModelType_List_GROUP(ModelType);
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            ViewBag.ModelNameValueLIST = json_data_getting.ModelName_list;
            ViewBag.Order = json_data_getting.Order_list;
            if(ModelName == null)
            {
                return View();
            }
            else
            {
                return Redirect("/Order/ModelType/?ModelType=" + ModelType + "&ModelName=" + ModelName);
            }
        }
        [HttpGet]
        public ActionResult ModelType(string ModelType, string ModelName)
        {
            if(ModelName == "" | ModelType == "" | ModelName == null | ModelType == null)
            {
                return Content("Error");
            }
            if (json_data_getting.ModelTypeCode_list[ModelType] == null)
            {
                return Content("Error");
            }
            bool data_check = false;
            foreach (var tmp in json_data_getting.ModelType_List_GROUP(ModelType))
            {
                if(ModelName == tmp)
                {
                    data_check = true;
                }
            }
            ViewBag.ModelType = ModelType;
            ViewBag.ModelName = ModelName;
            ViewBag.ModelNameLIST = json_data_getting.ModelType_List_GROUP(ModelType);
            ViewBag.PhoneNumberLIST = json_data_getting.Phonenumber_list;
            ViewBag.SocialLIST = json_data_getting.Socail_list;
            ViewBag.ModelNameValueLIST = json_data_getting.ModelName_list;
            ViewBag.Order = json_data_getting.Order_list;

            if (data_check)
            {
                return View();
            }
            else
            {
                return Content("Error");
            }
        }
    }
}