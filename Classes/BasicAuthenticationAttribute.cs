﻿using Newtonsoft.Json;
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
            if (actionContext.Request.Headers.Authorization != null)
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
                    actionContext.Response = actionContext.Request
                            .CreateResponse(HttpStatusCode.Unauthorized);
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
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
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
            string SerializedString = "{\"code\":0,\"result\":{\"baseURL\":\"\",\"socketURL\":\"\",\"startPage\":\"startpagestring\",\"lang\":{\"code\":1,\"version\":1,\"direction\":1},\"theme\":{\"code\":0,\"version\":1,\"statusBarStyle\":0,\"dic\":{\"cBackground\":\"#F8F8F8\",\"cPrimary\":\"#322975\",\"cTextBody\":\"#404649\",\"cTextBodyLight\":\"#404649aa\",\"cBackgorundTextView\":\"#DBE1E5\",\"cReverse\":\"#171B1E\",\"c\":\"#FAFAFA\",\"cBackgroundInner\":\"#FAFAFA\",\"cGray\":\"#B4B4B4\",\"cGrayLight\":\"#DBE1E5\",\"cRed\":\"#f73636\",\"cTabNormalItem\":\"#404649\",\"cTabSelectedItem\":\"#322975\",\"cNavBarColor\":\"#F8F8F8\"}},\"tabBar\":null}}";

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

                    ViewModel.splashMain  splashModel  = setUserURL(tokenUsername.Split(':')[1]);
                    SerializedString = SerializedString.Replace("startpagestring", splashModel.startPage);
                    if (splashModel.tabs.Count() > 0)
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
        public  static ViewModel.splashMain setUserURL(string userID)
        {
            using (Context dbcontext = new Context())
            {
                Guid srtguid = new Guid(userID);
                user selectedUser = dbcontext.users.SingleOrDefault(x => x.userID == srtguid);
                
                if (selectedUser != null)
                {
                    roleStartPage roleStart = dbcontext.roleStartPages.SingleOrDefault(x => x.userType == selectedUser.userType);

                    List<roleStartPage> lst = dbcontext.roleStartPages.ToList();
                    List<greenEnergy.ViewModel.splashTab> tabitems = roleStart.RoleNavURLs.Select(x => new ViewModel.splashTab { icon = x.startPageIcon, startPage = x.startPageURL, title = x.startPagetitle }).ToList();
                    ViewModel.splashMain splashmodel = new ViewModel.splashMain()
                    {
                        startPage = roleStart.startPage,
                        tabs = tabitems
                    };
                    return splashmodel;
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