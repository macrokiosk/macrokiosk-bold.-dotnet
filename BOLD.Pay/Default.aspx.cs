using BOLD.Pay.Agents;
using BOLD.Pay.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BOLD.Pay
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Browser redirect URL which receives payment response from BOLD.Pay API when transaction is completed
                ProcessCallback();

                //Server-to-server URL as an additional link to merchant’s website to be informed of transaction status
                ProcessNotification();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            CheckoutFields();
            PaymentRequest();
        }

        private void CheckoutFields()
        {
            lblPaymentResult.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                txtFirstName.Text = "Jone";
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                txtLastName.Text = "Smith";
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                txtEmail.Text = "jone@mail.com";
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                txtPhoneNumber.Text = "0123456789";
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                txtAddress.Text = "No. 123, Street 9/3, Section 9";
            if (string.IsNullOrWhiteSpace(txtState.Text))
                txtState.Text = "Selangor";
            if (string.IsNullOrWhiteSpace(txtCity.Text))
                txtCity.Text = "Petaling Jaya";
            if (string.IsNullOrWhiteSpace(txtPostcode.Text))
                txtPostcode.Text = "46000";
        }

        private void PaymentRequest()
        {
            try
            {
                string ApiKey = "apikey"; //BOLD.Pay Bussiness ApiKey
                string Username = "username"; //BOLD.Pay Administrator Username
                string CustIp = "1.2.3.4"; //Get customer devices IP address
                string PymtMethod = "4"; //1: Online Banking, 2: Credit Card, 3: E-Wallet, 4: All payment methods available in BOLD.Pay, 5: Over-The-Counter
                string CurrencyCode = "1"; //1: MYR
                string Amount = lblTotal.Text; //Payment Amount
                string Description = "Product 1, 2, 3 and 4"; //Order Description
                string CustName = txtFirstName.Text + " " + txtLastName.Text; //Customer's name
                string CustEmail = txtEmail.Text.Trim(); //Email address (format: name@mail.com)
                string CustPhone = txtPhoneNumber.Text.Trim(); //Customer Phone Number
                string OrderNumber = "ON00001"; //Reference number / Invoice number for this order.
                string PayId = DateTime.Now.ToFileTime().ToString(); //Unique PayID per transaction
                string CallBackUrl = "http://callbackurl.aspx"; //Browser redirect URL which receives payment response from BOLD.Pay API when transaction is completed
                string NotificationUrl = "http://notificationurl.aspx"; //Server-to-server URL as an additional link to merchant’s website to be informed of transaction status

                string AccessToken = Username + PymtMethod + Amount + CustIp + PayId + CallBackUrl + NotificationUrl + ApiKey;
                AccessToken = AccessToken.ToUpper().MD5Hash();

                string boldPayUrl = "https://pay.etracker.cc/BoldPayApi/PaymentRequest";

                StringBuilder param = new StringBuilder();
                param.Append("?AccessToken=").Append(AccessToken);
                param.Append("&APIKey=").Append(ApiKey);
                param.Append("&Username=").Append(Username);
                param.Append("&CustIP=").Append(CustIp);
                param.Append("&PymtMethod=").Append(PymtMethod);
                param.Append("&CurrencyCode=").Append(CurrencyCode);
                param.Append("&Amount=").Append(Amount);
                param.Append("&Description=").Append(Description);
                param.Append("&CustName=").Append(CustName);
                param.Append("&CustEmail=").Append(CustEmail);
                param.Append("&CustPhone=").Append(CustPhone);
                param.Append("&OrderNumber=").Append(OrderNumber);
                param.Append("&PayID=").Append(PayId);
                param.Append("&CallBackUrl=").Append(CallBackUrl);
                param.Append("&NotificationUrl=").Append(NotificationUrl);
                boldPayUrl = boldPayUrl + param;

                Response.Redirect(WebRequestAgent.HttpGet(boldPayUrl, false));
            }
            catch (Exception ex)
            {
            }
        }

        private void ProcessCallback()
        {
            pResult.Attributes.CssStyle.Remove("background");
            if (!string.IsNullOrEmpty(Request.QueryString["AccessToken"]) &&
                !string.IsNullOrEmpty(Request.QueryString["TransactionID"]) &&
                !string.IsNullOrEmpty(Request.QueryString["OrderNumber"]) &&
                !string.IsNullOrEmpty(Request.QueryString["PayID"]) &&
                !string.IsNullOrEmpty(Request.QueryString["Status"]))
            {
                //Note: Please validate AccessToken before process payment status update
                //Process payment transaction checking here
                switch (Request.QueryString["Status"].ToUpper())
                {
                    case "SUCCESS":
                        pResult.Attributes.CssStyle.Add("background", "green");
                        lblPaymentResult.Text = "Payment Successful";
                        break;

                    case "FAIL":
                        pResult.Attributes.CssStyle.Add("background", "red");
                        lblPaymentResult.Text = "Payment Failed";
                        break;
                    default:
                        break;
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["Status"]) &&
                     !string.IsNullOrEmpty(Request.QueryString["PayID"]) &&
                     !string.IsNullOrEmpty(Request.QueryString["OrderNumber"]))
            {
                pResult.Attributes.CssStyle.Add("background", "red");
                lblPaymentResult.Text = "Response Code: " + Request.QueryString["Status"];
            }
        }

        private void ProcessNotification()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AccessToken"]) &&
                !string.IsNullOrEmpty(Request.QueryString["TransactionID"]) &&
                !string.IsNullOrEmpty(Request.QueryString["OrderNumber"]) &&
                !string.IsNullOrEmpty(Request.QueryString["PayID"]) &&
                !string.IsNullOrEmpty(Request.QueryString["Status"]))
            {
                //Note: Please validate AccessToken before process payment status update
                //Process payment transaction checking here
                switch (Request.QueryString["Status"].ToUpper())
                {
                    case "SUCCESS":
                        //Update payment transaction success status in database
                        break;

                    case "FAIL":
                        //Update payment transaction failed status in database
                        break;
                    default:
                        break;
                }
            }
        }
    }
}