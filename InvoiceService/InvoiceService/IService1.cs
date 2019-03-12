using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace InvoiceService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Login/{Username}/{Password}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Login(string UserName, string Password);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Login_Update/{IsActive}/{userid}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Login_update(string IsActive, string userid);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Company_Details/")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        DataTable Company_Details();


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Companydetails_Update/{companyname}/{mobile}/{email}/{gstno}/{pancard}/{cgst}/{sgst}/{mobile1}/{address}/{city}/{district}/{state}/{pincode}/{acname}/{acno}/{ifsc}/{branch}/{dob}/{year}/{mothername}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Companydetails_Update(string companyname, string mobile, string email, string gstno, string pancard, string cgst, string sgst, string mobile1, string address, string city, string district, string state, string pincode, string acname, string acno, string ifsc, string branch, string dob, string year, string mothername);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Stock_Details/")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        DataTable Stock_Details();



        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Stock_Select_indiv/{Stockid}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        DataTable Stock_Select_indiv(string Stockid);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Stock_Select_stock/{Stock}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        DataTable Stock_Select_stock(string Stock);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Insert_Stock/{product}/{quantity}/{unitprice}/{totalamount}/{description}/{gst}/{date}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Insert_Stock(string product, string quantity, string unitprice, string totalamount, string description, string gst, string date);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Update_Stock/{product}/{quantity}/{unitprice}/{totalamount}/{description}/{gst}/{date}/{stockid}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Update_Stock(string product, string quantity, string unitprice, string totalamount, string description, string gst, string date, string stockid);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Delete_Stock/{stockid}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Delete_Stock(string stockid);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get_invoicecount/")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        string Get_invoicecount();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Insert_Bill/{name}/{address}/{city}/{email}/{mobile}/{gstno}/{invoice}/{cgst}/{sgst}/{totalamountinvoice}/{pincode}/{igstvalue}/{igstamount}/{date}/{vehicleno}/{gstamount}/{labouramount}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Insert_Bill(string name, string address, string city, string email, string mobile, string gstno, string invoice, string cgst, string sgst, string totalamountinvoice, string pincode, string igstvalue, string igstamount, string date, string vehicleno, string gstamount, string labouramount);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Insert_Sale/{invoice}/{quantity}/{unitprice}/{totalamount}/{stockid}/{discount}/{hsncode}/{stock}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Insert_Sale(string invoice, string quantity, string unitprice, string totalamount, string stockid, string discount, string hsncode, string stock);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Insert_Invoice/{invoice}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        int Insert_Invoice(string invoice);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get_Invoice_Bill/{invoice}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        DataTable Get_Invoice_Bill(string invoice);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get_Invoice_Sale/{invoice}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        DataTable Get_Invoice_Sale(string invoice);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get_Invoice/{invoice}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Username}/{Password}")]
        DataTable Get_Invoice(string invoice);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get_Reports_Bill/{from_date}/{to_date}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Get_Reports_Bill}/{Password}")]
        DataTable Get_Reports_Bill(string from_date, string to_date);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get_Reports_Stock/{from_date}/{to_date}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Get_Reports_Bill}/{Password}")]
        DataTable Get_Reports_Stock(string from_date, string to_date);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get_Reports_Individual/{name}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Get_Reports_Bill}/{Password}")]
        DataTable Get_Reports_Individual(string name);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "forget_password_qustion/{question}/{answ}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Get_Reports_Bill}/{Password}")]
        DataTable forget_password_qustion(string question, string answ);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Check_mail/{email}")]
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "User_Login/{Get_Reports_Bill}/{Password}")]
        int Check_mail(string email);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
