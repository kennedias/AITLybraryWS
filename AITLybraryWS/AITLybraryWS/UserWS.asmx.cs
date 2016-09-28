using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLogic;
using System.Data;
using SystemFramework;
using System.Web.Services.Protocols;

namespace AITLybraryWS
{
    /// <summary>
    /// Summary description for UserWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataTable UserLogin(string username, string password)
        {
           // try
      //      {
                UserLogic userLogic = new UserLogic();

                return userLogic.PerformLogin(username, password).ToDataTable();
        //    }
   //         catch (Exception ex)
     //       {
     /*           RaiseException("AddCategories",
          "http://tempuri.org/CategoriesService",
          builder.ToString(),
          "2000", "AddCategories", FaultCode.Client);


                SoapException soapException = HandleSoapException();
               // throw new SoapException(*/
       //     }
        }

        [WebMethod]
        public DataTable UserList()
        {
            UserLogic userLogic = new UserLogic();

            return userLogic.GetAllUser().ToDataTable();
        }
    }
}
