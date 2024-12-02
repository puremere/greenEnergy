using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using greenEnergy.Model;
using System.Threading.Tasks;

namespace greenEnergy.Classes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null && actionContext.Request.Headers.Authorization.Parameter != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                 Convert.FromBase64String(authToken));

                // spliting decodeauthToken using ':'   
                var arrUserNameandPassword = decodeauthToken.Split(':');

                // decoding authToken we get decode value in 'Username:Password' format  
                string tokenUsername = TokenManager.ValidateToken(arrUserNameandPassword[0], arrUserNameandPassword[1]);
                if (tokenUsername == null)
                {
                    //actionContext.Response = actionContext.Request
                    //        .CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    actionContext.Request.Properties.Add(new KeyValuePair<string, object>("UserToken", tokenUsername.Split(':')[1]));
                    actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Userp", tokenUsername.Split(':')[0]));
                }

                //// at 0th postion of array we get username and at 1st we get password  
                //if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                //{
                //    // setting current principle  
                //    Thread.CurrentPrincipal = new GenericPrincipal(
                //           new GenericIdentity(arrUserNameandPassword[0]), null);
                //}
                //else
                //{
                //    actionContext.Response = actionContext.Request
                //        .CreateResponse(HttpStatusCode.Unauthorized);
                //}
            }
            else
            {
                //actionContext.Response = actionContext.Request
                //    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
        public static bool IsAuthorizedUser(string Username, string Password)
        {
            // In this method we can handle our database logic here...  
            return Username == "bhushan" && Password == "demo";
        }
    }



    public class spalshAuthenticationAttribute : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //tipax :#007449
            //health : #7360df
            // health//string SerializedString = "{\"code\":0,\"result\":{\"baseURL\":\"\",\"socketURL\":\"\",\"startPage\":\"startpagestring\",\"lang\":{\"code\":0,\"version\":1,\"direction\":1},\"theme\":{\"code\":0,\"version\":1,\"statusBarStyle\":0,\"dic\":{\"cBackground\":\"#F8F8F8\",\"cPrimary\":\"#7360df\",\"cTextBody\":\"#404649\",\"cTextBodyLight\":\"#404649aa\",\"cBackgorundTextView\":\"#DBE1E5\",\"cReverse\":\"#171B1E\",\"c\":\"#FAFAFA\",\"cBackgroundInner\":\"#FAFAFA\",\"cGray\":\"#B4B4B4\",\"cGreen\":\"#1BDE5C\",\"cGeen\":\"#03FC77\",\"cGrayLight\":\"#DBE1E5\",\"cRed\":\"#d63484\",\"cTabNormalItem\":\"#404649\",\"cTabSelectedItem\":\"#7360df\",\"cNavBarColor\":\"#F8F8F8\"}},\"tabBar\":null}}";
            string SerializedString = "{\"code\":0,\"result\":{\"baseURL\":\"\",\"socketURL\":\"\",\"endPoint\":\"getData\",\"startPage\":\"startpagestring\",\"lang\":{\"code\":0,\"version\":1,\"direction\":1},\"theme\":{\"code\":0,\"version\":1,\"statusBarStyle\":0,\"dic\":{\"cBackground\":\"#F8F8F8\",\"cPrimary\":\"#04736d\",\"cTextBody\":\"#404649\",\"cTextBodyLight\":\"#4d4d4d\",\"cBackgorundTextView\":\"#DBE1E5\",\"cReverse\":\"#171B1E\",\"c\":\"#FAFAFA\",\"cBackgroundInner\":\"#FAFAFA\",\"cGray\":\"#B4B4B4\",\"cGreen\":\"#1BDE5C\",\"cGeen\":\"#03FC77\",\"cGrayLight\":\"#DBE1E5\",\"cRed\":\"#d63484\",\"cTabNormalItem\":\"#404649\",\"cTabSelectedItem\":\"#04736d\",\"cNavBarColor\":\"#F8F8F8\"}},\"tabBar\":null}}";

            try
            {
                if (actionContext.Request.Headers.Authorization != null)
                {
                    var authToken = actionContext.Request.Headers
                        .Authorization.Parameter;

                    var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                    // spliting decodeauthToken using ':'   
                    var arrUserNameandPassword = decodeauthToken.Split(':');



                    string tokenUsername = TokenManager.ValidateToken(arrUserNameandPassword[0], arrUserNameandPassword[1]);
                    if (tokenUsername == null)
                    {
                        string replacedURL = "app/loginPage";
                        SerializedString = SerializedString.Replace("startpagestring", replacedURL);
                        actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Splash", SerializedString));

                    }
                    else
                    {

                        ViewModel.splashMain splashModel = setUserURL(tokenUsername.Split(':')[1], "");
                        SerializedString = SerializedString.Replace("startpagestring", splashModel.startPage);

                        if (string.IsNullOrEmpty(splashModel.startPage))
                        {
                            string tabstring = JsonConvert.SerializeObject(splashModel.tabs);
                            SerializedString = SerializedString.Replace("\"tabBar\":null", "\"tabBar\":{\"pages\": " + tabstring + "}");
                        }


                        actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Splash", SerializedString));

                    }

                }
                else
                {
                    string replacedURL = "app/loginPage";
                    SerializedString = SerializedString.Replace("startpagestring", replacedURL);
                    actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Splash", SerializedString));

                }
            }
            catch (Exception)
            {

                string replacedURL = "app/loginPage";
                SerializedString = SerializedString.Replace("startpagestring", replacedURL);
                actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Splash", SerializedString));
            }
            
        }
        public  static ViewModel.splashMain setUserURL(string userID,string roleName)
        {
            using (Context dbcontext = new Context())
            {
                Guid srtguid = new Guid(userID);
                user selectedUser = dbcontext.users.SingleOrDefault(x => x.userID == srtguid);
                
                if (selectedUser != null)
                {
                    if (!string.IsNullOrEmpty(roleName)) {
                        List<greenEnergy.ViewModel.splashTab> tabitems = dbcontext.roleNavURLs.Where(x=>x.roleName == roleName).OrderBy(x => x.priority).Select(x => new ViewModel.splashTab { icon = x.startPageIcon, startPage = x.startPageURL, title = x.startPagetitle }).ToList();
                        ViewModel.splashMain splashmodel = new ViewModel.splashMain()
                        {
                            startPage = "",
                            tabs = tabitems
                        };
                        return splashmodel;
                    }
                    else
                    {
                        roleStartPage roleStart = dbcontext.roleStartPages.SingleOrDefault(x => x.userType == selectedUser.userType);

                        List<roleStartPage> lst = dbcontext.roleStartPages.ToList();
                        List<greenEnergy.ViewModel.splashTab> tabitems = roleStart.RoleNavURLs.OrderBy(x => x.priority).Select(x => new ViewModel.splashTab { icon = x.startPageIcon, startPage = x.startPageURL, title = x.startPagetitle }).ToList();
                        ViewModel.splashMain splashmodel = new ViewModel.splashMain()
                        {
                            startPage = roleStart.startPage,
                            tabs = tabitems
                        };
                        return splashmodel;
                    }
                    
                }
                else
                {
                    ViewModel.splashMain splashmodel = new ViewModel.splashMain()
                    {
                        startPage = "app/login",
                    };
                    return splashmodel;
                }
            }
        }
    }
}