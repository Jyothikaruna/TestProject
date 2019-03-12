using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;

namespace InvoiceService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int Login(string UserName, string Password)
        {
            int i = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "Login");
                cmd.Parameters.AddWithValue("@email", UserName);
                cmd.Parameters.AddWithValue("@password", Password);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    i = Convert.ToInt32(dt.Rows[0]["Isactive"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return i;
        }


        public int Login_update(string IsActive, string userid)
        {
            int i = 0;
            try
            {
                int value = Convert.ToInt32(IsActive);
                SqlCommand cmd = new SqlCommand("SP_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "update");
                cmd.Parameters.AddWithValue("@Isactive", value);
                cmd.Parameters.AddWithValue("@userid", userid);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public DataTable Company_Details()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Companyprofile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "select");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }


        public int Companydetails_Update(string companyname, string mobile, string email, string gstno, string pancard, string cgst, string sgst, string mobile1, string address, string city, string district, string state, string pincode, string acname, string acno, string ifsc, string branch, string dob, string year, string mothername)
        {
            int i = 0;
            try
            {
                // companyname = @companyname,email = @email,gstno = @gstno,mobileno = @mobileno, mobileno1 = @mobileno1, pancard = @pancard, 
                //city = @city,pincode = @pincode,district = @district,state = @state,cgst = @cgst,sgst = @sgst,address = @address,dob = @dob,
                //yearoforganisation = @yearoforganisation,mothername = @mothername,acname = @acname,acno = @acno,ifsc = @ifsc,branch = @branch

                SqlCommand cmd = new SqlCommand("SP_Companyprofile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "update");
                cmd.Parameters.AddWithValue("@companyname", companyname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gstno", gstno);
                cmd.Parameters.AddWithValue("@mobileno", mobile);
                cmd.Parameters.AddWithValue("@mobileno1", mobile1);
                cmd.Parameters.AddWithValue("@pancard", pancard);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@pincode", pincode);
                cmd.Parameters.AddWithValue("@district", district);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@cgst", cgst);
                cmd.Parameters.AddWithValue("@sgst", sgst);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@yearoforganisation", year);
                cmd.Parameters.AddWithValue("@mothername", mothername);
                cmd.Parameters.AddWithValue("@acname", acname);
                cmd.Parameters.AddWithValue("@acno", acno);
                cmd.Parameters.AddWithValue("@ifsc", ifsc);
                cmd.Parameters.AddWithValue("@branch", branch);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }


        public DataTable Stock_Details()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Stockentry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "selectall");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }


        public DataTable Stock_Select_indiv(string Stockid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Stockentry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "select");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }


        public DataTable Stock_Select_stock(string Stock)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Stockentry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "selectitem");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }


        public int Insert_Stock(string product, string quantity, string unitprice, string totalamount, string description, string gst, string date)
        {
            int i = 0;
            try
            {
                //(@itemname,@quantity,@unitprice,@totalamount,@description,@gst,@date)

                SqlCommand cmd = new SqlCommand("SP_Stockentry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "insert");
                cmd.Parameters.AddWithValue("@itemname", product);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@totalamount", totalamount);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@gst", gst);
                cmd.Parameters.AddWithValue("@date", date);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }


        public int Update_Stock(string product, string quantity, string unitprice, string totalamount, string description, string gst, string date, string stockid)
        {
            int i = 0;
            try
            {
                //(@itemname,@quantity,@unitprice,@totalamount,@description,@gst,@date)

                SqlCommand cmd = new SqlCommand("SP_Stockentry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "update");
                cmd.Parameters.AddWithValue("@itemname", product);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@totalamount", totalamount);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@gst", gst);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@stockid", stockid);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }


        public int Delete_Stock(string stockid)
        {
            int i = 0;
            try
            {
                //(@itemname,@quantity,@unitprice,@totalamount,@description,@gst,@date)

                SqlCommand cmd = new SqlCommand("SP_Stockentry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "delete");
                cmd.Parameters.AddWithValue("@stockid", stockid);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public string Get_invoicecount()
        {
            string invoice = "";
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Invoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "count");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                invoice = dt.Rows[0]["count"].ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return invoice;
        }

        public int Insert_Bill(string name, string address, string city, string email, string mobile, string gstno, string invoice, string cgst, string sgst, string totalamountinvoice, string pincode, string igstvalue, string igstamount, string date, string vehicleno, string gstamount, string labouramount)
        {
            int i = 0;
            try
            {
                //(@itemname,@quantity,@unitprice,@totalamount,@description,@gst,@date)

                SqlCommand cmd = new SqlCommand("SP_Billing", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "insert");
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@gstno", gstno);
                cmd.Parameters.AddWithValue("@invoice", invoice);
                cmd.Parameters.AddWithValue("@cgst", cgst);
                cmd.Parameters.AddWithValue("@sgst", sgst);
                cmd.Parameters.AddWithValue("@totalamountinvoice", totalamountinvoice);
                cmd.Parameters.AddWithValue("@pincode", pincode);
                cmd.Parameters.AddWithValue("@igstvalue", igstvalue);
                cmd.Parameters.AddWithValue("@igstamount", igstamount);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@vehicleno", vehicleno);
                cmd.Parameters.AddWithValue("@gstamount", gstamount);
                cmd.Parameters.AddWithValue("@labouramount", labouramount);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public int Insert_Sale(string invoice, string quantity, string unitprice, string totalamount, string stockid, string discount, string hsncode, string stock)
        {
            int i = 0;
            try
            {
                //(@itemname,@quantity,@unitprice,@totalamount,@description,@gst,@date)

                SqlCommand cmd = new SqlCommand("SP_Salesstock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "insert");
                cmd.Parameters.AddWithValue("@invoice", invoice);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@totalamount", totalamount);
                cmd.Parameters.AddWithValue("@stockid", stockid);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@hsncode", hsncode);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }
        public int Insert_Invoice(string invoice)
        {
            int i = 0;
            try
            {
                //(@itemname,@quantity,@unitprice,@totalamount,@description,@gst,@date)

                SqlCommand cmd = new SqlCommand("SP_Invoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "insert");
                cmd.Parameters.AddWithValue("@invoiceno", invoice);
                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public DataTable Get_Invoice_Bill(string invoice)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Billing", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "select");
                cmd.Parameters.AddWithValue("@invoice", invoice);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }

        public DataTable Get_Invoice_Sale(string invoice)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Get_Sales_Invoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "select");
                cmd.Parameters.AddWithValue("@invoice", invoice);

                //SqlCommand cmd = new SqlCommand("select * from tblsalesstock where invoice='"+invoice+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }

        public DataTable Get_Invoice(string invoice)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Invoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "select");
                cmd.Parameters.AddWithValue("@invoiceno", invoice);

                //SqlCommand cmd = new SqlCommand("select * from tblsalesstock where invoice='"+invoice+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }


        public DataTable Get_Reports_Bill(string from_date, string to_date)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Get_Reports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "date_wise_bill");
                cmd.Parameters.AddWithValue("@from_date", from_date);
                cmd.Parameters.AddWithValue("@to_date", to_date);
                //SqlCommand cmd = new SqlCommand("select * from tblsalesstock where invoice='"+invoice+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }

        public DataTable Get_Reports_Stock(string from_date, string to_date)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Get_Reports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "date_wise_stock");
                cmd.Parameters.AddWithValue("@from_date", from_date);
                cmd.Parameters.AddWithValue("@to_date", to_date);
                //SqlCommand cmd = new SqlCommand("select * from tblsalesstock where invoice='"+invoice+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }

        public DataTable Get_Reports_Individual(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Get_Reports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "indivual");
                cmd.Parameters.AddWithValue("@name", name);
                //SqlCommand cmd = new SqlCommand("select * from tblsalesstock where invoice='"+invoice+"'", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }


        public int Check_mail(string email)
        {
            int i = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "email_check");
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                i = dt.Rows.Count;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return i;
        }


        public DataTable forget_password_qustion(string question, string answ)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Forget", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "forget");
                cmd.Parameters.AddWithValue("@question", question);
                cmd.Parameters.AddWithValue("@answ", answ);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return dt;
        }
    }
}
