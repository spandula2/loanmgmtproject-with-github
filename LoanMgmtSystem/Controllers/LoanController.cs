using LoanMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace LoanMgmtSystem.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            List<LoanOffers> lst = new List<LoanOffers>();
            lst = APILoanDetail.GetOfferDetail();
            return View(lst);
            //return View();
        }

        public ActionResult CustomerDetail()
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            List<RegistrationDetails> lst = new List<RegistrationDetails>();
            lst = APILoanDetail.GetCustomerDetail();
            return View(lst);
        }

        public ActionResult IndividualCustDetail(string id)
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            RegistrationDetails Reg = new RegistrationDetails();
            Reg = APILoanDetail.GetIndividualCustDetail(id);
            return View(Reg);
        }

        public ActionResult LoanOffers()
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            List<LoanOffers> lst = new List<LoanOffers>();
            lst = APILoanDetail.GetOfferDetail();
            return View(lst); 
        }

        public ActionResult InsertOffers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertOffers(LoanOffers obj)
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            string Out = APILoanDetail.InsertOffer(obj);
            if (Out == "Y")
            {
                 return RedirectToAction("LoanOffers");
            }
            return View();
        }

        public ActionResult DeleteOffers(string id)
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            string Out = APILoanDetail.DeleteOffer(id);
            if (Out == "Y")
            {
                return RedirectToAction("LoanOffers");
            }
            return View();
        }

        public ActionResult UpdateOffers(string ID)
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            LoanOffers LoanOffers = new LoanOffers();
            LoanOffers = APILoanDetail.GetUpdateOffer(ID);
            if (LoanOffers != null)
            {
                Session["OfferId"] = LoanOffers.OfferId;
            }
            return View(LoanOffers);
        }

        [HttpPost]
        public ActionResult UpdateOffers(LoanOffers obj)
        {
            ApiLoanController APILoanDetail = new ApiLoanController();
            obj.OfferId = Session["OfferId"].ToString();
            string Out = APILoanDetail.UpdateOffer(obj);
            if (Out == "Y")
            {
                return RedirectToAction("LoanOffers");
            }
            return View();
        }

    }
}