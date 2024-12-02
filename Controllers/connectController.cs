using greenEnergy.BankMellatLibrary;
using greenEnergy.Model;
using greenEnergy.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace greenEnergy.Controllers
{
    //public class connectController : Controller
    //{
    //    // GET: connect
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //    public async Task<ActionResult> ReqestForPaymentMellat(Guid id)
    //    {
            
    //        try
    //        {
    //            string message = "";
    //            using (Context dbccontext = new Context())
    //            {
    //                paymentRecord record = await dbccontext.paymentRecords.SingleOrDefaultAsync(x => x.paymentRecordID == id);

    //                // شماره پیگیری ایتم ثبت شده برای بانک
    //                // دریافت قیمت از دیتا بیس
    //                double price = record.price;
    //                // تایم استمپ از دیتا بیس
    //                string txtDescription = "شماره پیگیری:" + record.peigiry;
    //                string timestamp =record.timestamp.ToString();
    //                long amount = Convert.ToInt64(price * 10); 
    //                string additionalData = txtDescription;
    //                // پیگیری از روی دیتا بیس
    //                long orderId = record.peigiry;

    //                string localDate = DateTime.Now.ToString("yyyyMMdd");
    //                string localTime = DateTime.Now.ToString("HHmmss");

    //                string callBackUrl = ConfigurationManager.AppSettings["domain"] + "/connect/VerifyMellat";
    //                long terminalId = Convert.ToInt64(ConfigurationManager.AppSettings["terminalId"]);
    //                string userName = ConfigurationManager.AppSettings["userName"];
    //                string userPassword = ConfigurationManager.AppSettings["userPassword"];
    //                string payerId = "0";

                    
    //                //banimo.bankMellat.PaymentGatewayImplService WebService = new bankMellat.PaymentGatewayImplService();
    //                //string callBackRefID = WebService.bpPayRequest(terminalId, userName, userPassword, orderId, amount, localDate, localTime,
    //                //                 additionalData, callBackUrl, "0");

                

    //                BankMellatImplement bankMellatImplement = new BankMellatImplement(callBackUrl, terminalId, userName, userPassword);

    //                string resultRequest = bankMellatImplement.bpPayRequest(orderId, amount, additionalData);
    //                string[] StatusSendRequest = resultRequest.Split(',');
    //                message = additionalData + "+"+ amount.ToString() + "+" + orderId.ToString() + "->" + StatusSendRequest[0];
                   
                    
                    
    //                if (int.Parse(StatusSendRequest[0]) == (int)BankMellatImplement.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
    //                {

    //                    return RedirectToAction("RedirectVPOS", "connect", new { id = StatusSendRequest[1] });
    //                }

    //                TempData["Message"] = bankMellatImplement.DesribtionStatusCode(int.Parse(StatusSendRequest[0].Replace("_", " ")));
    //                string srt = TempData["Message"].ToString();
    //                return RedirectToAction("verifyAtBase", "connect");
    //            }
                    
                
    //        }
    //        catch (Exception e)
    //        {
    //            string innmessage = e.Message;
    //            if (e.InnerException != null)
    //            {
    //                innmessage += e.InnerException.ToString();
    //            }
    //            return Content(innmessage);
    //        }
            
    //        //string json = "";
          


    //    }

    //    public ActionResult RedirectVPOS(string id)
    //    {
    //        try
    //        {
    //            if (id == null)
    //            {
    //                TempData["Message"] = "هیچ شماره پیگیری برای پرداخت از سمت بانک ارسال نشده است!";

    //                return RedirectToAction("verifyAtBase", "connect");
    //            }
    //            else
    //            {
    //                ViewBag.id = id;
    //                return View();
    //            }
    //        }
    //        catch (Exception error)
    //        {
    //            TempData["Message"] = error + "متاسفانه خطایی رخ داده است، لطفا مجددا عملیات خود را انجام دهید در صورت تکرار این مشکل را به بخش پشتیبانی اطلاع دهید";

    //            return RedirectToAction("verifyAtBase", "connect");
    //        }
    //    }
    //    [HttpPost]
    //    public async Task<ActionResult> VerifyMellat()
    //    {
    //        bool Run_bpReversalRequest = false;
    //        long saleReferenceId = -999;
    //        long saleOrderId = -999;
    //        string resultCode_bpPayRequest;

    //        string callBackUrl = ConfigurationManager.AppSettings["domain"] + "/connect/VerifyMellat";
    //        long terminalId = Convert.ToInt64(ConfigurationManager.AppSettings["terminalId"]);
    //        string userName = ConfigurationManager.AppSettings["userName"];
    //        string userPassword = ConfigurationManager.AppSettings["userPassword"];
            
           
          
    //        BankMellatImplement bankMellatImplement = new BankMellatImplement(callBackUrl, terminalId, userName, userPassword);
    //        try
    //        {

    //            string result2 = "";
    //            saleReferenceId = long.Parse(Request.Params["SaleReferenceId"].ToString());
    //            saleOrderId = long.Parse(Request.Params["SaleOrderId"].ToString());
              

    //            resultCode_bpPayRequest = Request.Params["ResCode"].ToString();

    //            TempData["saleOrderId"] = Request.Params["SaleOrderId"].ToString();



    //            //Result Code
    //            string resultCode_bpinquiryRequest = "-9999";
    //            string resultCode_bpSettleRequest = "-9999";
    //            string resultCode_bpVerifyRequest = "-9999";
    //            long orderID = 0;
    //            if (Session["orderID"] != null)
    //            {
    //                orderID = Int64.Parse(Session["orderID"].ToString());
    //            }

    //            if (int.Parse(resultCode_bpPayRequest) == (int)BankMellatImplement.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
    //            {
    //                #region Success

    //                resultCode_bpVerifyRequest = bankMellatImplement.VerifyRequest(saleOrderId, saleOrderId, saleReferenceId);




    //                if (string.IsNullOrEmpty(resultCode_bpVerifyRequest))
    //                {
    //                    #region Inquiry Request

    //                    resultCode_bpinquiryRequest = bankMellatImplement.InquiryRequest(saleOrderId, saleOrderId, saleReferenceId);
    //                    if (int.Parse(resultCode_bpinquiryRequest) != (int)BankMellatImplement.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
    //                    {
    //                        //the transactrion faild
    //                        TempData["Message"] = int.Parse(resultCode_bpinquiryRequest.Replace("_", " "));// bankMellatImplement.DesribtionStatusCode();
    //                        Run_bpReversalRequest = true;
    //                    }

    //                    #endregion
    //                }
    //                else
    //                {


    //                    if ((int.Parse(resultCode_bpVerifyRequest) == (int)BankMellatImplement.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
    //                    ||
    //                    (int.Parse(resultCode_bpinquiryRequest) == (int)BankMellatImplement.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ))
    //                    {

    //                        #region SettleRequest

    //                        resultCode_bpSettleRequest = bankMellatImplement.SettleRequest(saleOrderId, saleOrderId, saleReferenceId);
    //                        if ((int.Parse(resultCode_bpSettleRequest) == (int)BankMellatImplement.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ)
    //                            || (int.Parse(resultCode_bpSettleRequest) == (int)BankMellatImplement.MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_Settle_ﺷﺪه_اﺳﺖ))
    //                        {


    //                            string rr = "" + saleOrderId;
    //                            TempData["Message"] = "موفق";
    //                            TempData["Message2"] = "CH-" + saleOrderId;
    //                            TempData["Message3"] = " لطفا شماره پیگیری را یادداشت نمایید " + saleReferenceId;

                                
    //                            using (Context dbcontext = new Context())
    //                            {
    //                                // تراکنش بازیابی کنیم
    //                                paymentRecord record = await dbcontext.paymentRecords.SingleOrDefaultAsync(x => x.peigiry == saleOrderId);
    //                                // استتوس تراکنش رو عوض کنیم
    //                                record.status = 1;
    //                                flowRelation relation = await dbcontext.flowRelations.SingleOrDefaultAsync(x => x.flowRelationID == record.relationID);
    //                                relation.status = 1;
    //                                await dbcontext.SaveChangesAsync();
    //                                // ریلیشن مرتبط رو ایجاد کنیم

                                   
    //                            }








    //                        }
    //                        else
    //                        {


    //                            TempData["Message"] = int.Parse(resultCode_bpSettleRequest.Replace("_", " "));// bankMellatImplement.DesribtionStatusCode();
    //                            TempData["Message2"] = "" + saleOrderId;
    //                            Run_bpReversalRequest = true;
    //                        }

    //                        // Save information to Database...

    //                        #endregion
    //                    }
    //                    else
    //                    {
    //                        TempData["Message"] = int.Parse(resultCode_bpVerifyRequest.Replace("_", " "));// bankMellatImplement.DesribtionStatusCode();
    //                        TempData["Message2"] = "" + saleOrderId;
    //                        Run_bpReversalRequest = true;
    //                    }
    //                }



    //                #endregion
    //            }
    //            else
    //            {
    //                TempData["Message"] = int.Parse(resultCode_bpPayRequest);// bankMellatImplement.DesribtionStatusCode().Replace("_", " ");
    //                TempData["Message2"] = "" + saleOrderId;
    //                Run_bpReversalRequest = true;
    //            }
    //            return RedirectToAction("verifyAtBase", "connect");

    //        }
    //        catch (Exception Error)
    //        {
    //            TempData["Message"] = "خطا";
    //            TempData["Message2"] = "" + saleOrderId;
    //            // Save and send Error for admin user
    //            Run_bpReversalRequest = true;
    //            return RedirectToAction("verifyAtBase", "connect");
    //        }
    //        finally
    //        {
    //            if (Run_bpReversalRequest) //ReversalRequest
    //            {
    //                if (saleOrderId != -999 && saleReferenceId != -999)
    //                    bankMellatImplement.bpReversalRequest(saleOrderId, saleOrderId, saleReferenceId);
    //                // Save information to Database...
    //            }
    //        }





    //    }

    //    public ActionResult test()
    //    {
    //        TempData["Message"] = "خطا";
    //        TempData["Message2"] = "12356" ;
    //        return RedirectToAction("verifyAtBase", "connect");
    //    }
    //    public ActionResult verifyAtBase()
    //    {

    //        string result = TempData["message"] as string;
    //        if (result == "موفق")
    //        {

    //            //List<ProductDetail> data2 = new List<ViewModel.ProductDetail>();
    //            //SetCookie(JsonConvert.SerializeObject(data2), "cartModel");

    //            ViewBag.message = TempData["message"] as string;
    //            ViewBag.message3 = "200";
    //            ViewBag.message2 = TempData["message2"] as string;


    //        }
    //        else
    //        {
    //            ViewBag.message = TempData["message"] as string;
    //            ViewBag.message2 = TempData["message2"] as string;
    //            ViewBag.message3 = "500";

    //        }


    //        return View();
    //    }
    //}

   
}