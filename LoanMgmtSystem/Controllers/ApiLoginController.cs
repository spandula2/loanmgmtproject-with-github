using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System.Data;
using LoanMgmtSystem.Models;

namespace LoanMgmtSystem.Controllers
{
    public class ApiLoginController : ApiController
    {
        string myConnectionString = "server=localhost;uid=root;" + "database=db_LOAN_MGMT_SYSTEM; SslMode = none";
        public RegistrationDetails Login(Login obj)
        {
            RegistrationDetails Cust = new RegistrationDetails();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Customer_details o where o.Name= @userName and o.Password= @password", conn);
                da.SelectCommand.Parameters.AddWithValue("@userName", obj.userName);
                da.SelectCommand.Parameters.AddWithValue("@password", obj.password);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    FormsAuthentication.SetAuthCookie(ds.Tables[0].Rows[0]["ROLES"].ToString(), false);
                    Cust.CustId = ds.Tables[0].Rows[0]["CustId"].ToString(); 
                    Cust.Roles = ds.Tables[0].Rows[0]["ROLES"].ToString();
                }

            }
            return Cust;
        }

        public String SaveUserDetail(RegistrationDetails obj)
        {
            int count = 0;
            string Out = "";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select Count(*) from tbl_Customer_details o where o.Name = @username and Password = @password", conn);
                cmd.Parameters.AddWithValue("@username", obj.Name);
                cmd.Parameters.AddWithValue("@password", obj.Password);
                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count > 0)
                {
                    Out = "User Already Exist.";
                }
                else
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("insert into tbl_Customer_details(Name,FirstName,LastName,CompanyName,Designation,Salary,Email,Phone,Password,Roles) values(@Name,@FirstName,@LastName,@CompanyName,@Designation,@Salary,@Email,@Phone,@Password,@Roles)", conn);
                    cmd1.Parameters.AddWithValue("@Name", obj.Name);
                    cmd1.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd1.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd1.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
                    cmd1.Parameters.AddWithValue("@Designation", obj.Designation);
                    cmd1.Parameters.AddWithValue("@Salary", obj.Salary);
                    cmd1.Parameters.AddWithValue("@Email", obj.Email);
                    cmd1.Parameters.AddWithValue("@Phone", obj.Phone);
                    cmd1.Parameters.AddWithValue("@Password", obj.Password);
                    cmd1.Parameters.AddWithValue("@Roles", obj.Roles);
                    conn.Open();
                    count = cmd1.ExecuteNonQuery();
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
        }

    }
}
