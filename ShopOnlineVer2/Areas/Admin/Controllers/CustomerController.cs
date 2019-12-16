using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.Entities;

namespace ShopOnlineVer2.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCustomer()
        {
            ViewBag.ListCus = new CustomerDAO().GetAllCus();
            return View();
        }
        public ActionResult EditCustomer(int idCus)
        {
            var selectCus = CustomerDAO.SelectByIDCus(idCus);
            ViewBag.selectID = selectCus;
            return View();
        }

        public ActionResult UpdateCustomer(Customer customer)
        {
            if (CustomerDAO.UpdateCus(customer) == true)
            {
                return RedirectToAction("ListCustomer");
            }
            return RedirectToAction("ListCustomer");
        }

        public ActionResult DeleteCustomer(int idCus)
        {
            CustomerDAO.DeleteCus(idCus);
            return RedirectToAction("ListCustomer");
        }
    }
}