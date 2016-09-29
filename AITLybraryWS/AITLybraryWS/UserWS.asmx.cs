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
            try
            {
                UserLogic userLogic = new UserLogic();

                return userLogic.PerformLogin(username, password).ToDataTable();
            }
            catch (BusinessLogicException ex)
            {
                HandleSoapException handleSoapExceptionnew = new HandleSoapException();

            /*    CreateSoapException(string uri,
                                    string webServiceNamespace,
                                    string errorMessage,
                                    string errorNumber,
                                    string errorSource,
                                    AppEnum.FaultSourceWS faultSource)
             * **/
                SoapException soapException = new SoapException();

                soapException = handleSoapExceptionnew.CreateSoapException("http://tempuri.org/CategoriesService",
                                                                                         "PerformLogin",
                                                                                         ex.Message, 
                                                                                         AppEnum.FaultSourceWS.BusinessError.ToString(),
                                                                                         "Business",
                                                                                         AppEnum.FaultSourceWS.BusinessError);
                throw soapException;
               // return AppUtil.ThrowExceptionTable(ex);
            }
            catch (Exception ex)
            {
                HandleSoapException handleSoapExceptionnew = new HandleSoapException();
                SoapException soapException = new SoapException();

                soapException = handleSoapExceptionnew.CreateSoapException("http://tempuri.org/CategoriesService",
                                                                                         "PerformLogin",
                                                                                         ex.Message,
                                                                                         AppEnum.FaultSourceWS.AplicationError.ToString(),
                                                                                         "Business",
                                                                                         AppEnum.FaultSourceWS.AplicationError);
                throw soapException;
                //return AppUtil.ThrowExceptionTable(ex);
            }
        }

        [WebMethod]
        public DataTable UserList()
        {
            UserLogic userLogic = new UserLogic();

            return userLogic.GetAllUser().ToDataTable();
        }

  /*      [WebMethod]
        public DataTable InsertUser(string userName, string userLevelDescription)
        {
            try
            {
                UserLogic userLogic = new UserLogic();
              //  return userLogic.insertUser(userName, userLevelDescription);
             }
            catch (BusinessLogicException ex)
            {
                HandleSoapException handleSoapExceptionnew = new HandleSoapException();

                /*    CreateSoapException(string uri,
                                        string webServiceNamespace,
                                        string errorMessage,
                                        string errorNumber,
                                        string errorSource,
                                        AppEnum.FaultSourceWS faultSource)
                
                SoapException soapException = new SoapException();

                soapException = handleSoapExceptionnew.CreateSoapException("http://tempuri.org/CategoriesService",
                                                                                         "PerformLogin",
                                                                                         ex.Message,
                                                                                         AppEnum.FaultSourceWS.BusinessError.ToString(),
                                                                                         "Business",
                                                                                         AppEnum.FaultSourceWS.BusinessError);
                throw soapException;
                // return AppUtil.ThrowExceptionTable(ex);
            }
            catch (Exception ex)
            {
                HandleSoapException handleSoapExceptionnew = new HandleSoapException();
                SoapException soapException = new SoapException();

                soapException = handleSoapExceptionnew.CreateSoapException("http://tempuri.org/CategoriesService",
                                                                                         "PerformLogin",
                                                                                         ex.Message,
                                                                                         AppEnum.FaultSourceWS.AplicationError.ToString(),
                                                                                         "Business",
                                                                                         AppEnum.FaultSourceWS.AplicationError);
                throw soapException;
                //return AppUtil.ThrowExceptionTable(ex);
            }
        }*/
    } 
}
