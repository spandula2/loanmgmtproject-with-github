using LoanMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanMgmtSystem.Controllers
{
    public class ApiLoanController : ApiController
    {
        string myConnectionString = "server=localhost;uid=root;" + "database=db_LOAN_MGMT_SYSTEM; SslMode = none";

        public List<RegistrationDetails> GetCustomerDetail()
        {
            List<RegistrationDetails> lstCust = new List<RegistrationDetails>();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Customer_details o", conn);// WHERE o.Roles='Customer'
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                { 
                    RegistrationDetails CustDetail = new RegistrationDetails();
                    CustDetail.CustId = dr["CustId"].ToString();
                    CustDetail.FirstName = dr["FirstName"].ToString();
                    CustDetail.LastName = dr["LastName"].ToString();
                    CustDetail.Email = dr["Email"].ToString();
                    CustDetail.Phone = dr["Phone"].ToString();
                    CustDetail.Designation = dr["Designation"].ToString(); 
                    CustDetail.Salary = dr["Salary"].ToString();
                    lstCust.Add(CustDetail);
                }
            }
            return lstCust;
        }


        public RegistrationDetails GetIndividualCustDetail(String ID)
        {
            RegistrationDetails Reg = new RegistrationDetails();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Customer_details o where o.CustId= " + ID, conn);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                { 
                    Reg.CustId = ds.Tables[0].Rows[0]["CustId"].ToString();
                    Reg.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    Reg.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    Reg.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    Reg.Designation = ds.Tables[0].Rows[0]["Designation"].ToString();
                    Reg.Salary = ds.Tables[0].Rows[0]["Salary"].ToString();
                    Reg.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    Reg.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
            }
            return Reg;
        }

        public List<LoanOffers> GetOfferDetail()
        {
            List<LoanOffers> lstOffers = new List<LoanOffers>();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Offer_details o", conn);// WHERE o.Roles='Customer'
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    LoanOffers LoanOffers = new LoanOffers();
                    LoanOffers.OfferId = dr["OfferId"].ToString();
                    LoanOffers.OfferName = dr["OfferName"].ToString();
                    lstOffers.Add(LoanOffers);
                }
            }
            return lstOffers;
        }

        public String InsertOffer(LoanOffers obj)
        {
            int count = 0;
            string Out = "";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            { 
                 MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into tbl_Offer_details(OfferName) values(@OfferName)", conn);
                 cmd.Parameters.AddWithValue("@OfferName", obj.OfferName); 
                 conn.Open();
                 count = cmd.ExecuteNonQuery();
                 conn.Close();
                 if (count == 0)
                 {
                     Out = "Error While inserting Data.";
                 }
                 else
                 {
                     Out = "Y";
                 } 
                 return Out;
            }
        }

        public String DeleteOffer(String ID)
        {
            int count = 0;
            string Out = "";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM tbl_Offer_details WHERE OfferId=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(ID));
                conn.Open();
                count = cmd.ExecuteNonQuery();
                conn.Close();
                if (count == 0)
                {
                    Out = "Error While inserting Data.";
                }
                else
                {
                    Out = "Y";
                }
            }
            return Out;
        }

        public LoanOffers GetUpdateOffer(String ID)
        {
            LoanOffers LoanOffers = new LoanOffers();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Offer_details o where o.OfferId= " + ID, conn);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    LoanOffers.OfferId = ds.Tables[0].Rows[0]["OfferId"].ToString();
                    LoanOffers.OfferName = ds.Tables[0].Rows[0]["OfferName"].ToString();
                }
            }
            return LoanOffers;
        }

        public String UpdateOffer(LoanOffers obj)
        {
            int count = 0;
            string Out = "";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("Update tbl_Offer_details set OfferName= @OfferName WHERE OfferId= @OfferId", conn);
                cmd.Parameters.AddWithValue("@OfferId", obj.OfferId);
                cmd.Parameters.AddWithValue("@OfferName", obj.OfferName); 
                conn.Open();
                count = cmd.ExecuteNonQuery();
                conn.Close();
                if (count == 0)
                {
                    Out = "Error While Updating Data.";
                }
                else
                {
                    Out = "Y";
                }
            }
            return Out;
        }
    }
}
