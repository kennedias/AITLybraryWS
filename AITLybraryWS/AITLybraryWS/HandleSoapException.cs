using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using SystemFramework;
using System.Xml.Serialization;
using System.Xml;

namespace AITLybraryWS
{
    public class HandleSoapException
    {
        public SoapException CreateSoapException(string uri,
                                    string webServiceNamespace,
                                    string errorMessage,
                                    string errorNumber,
                                    string errorSource,
                                    AppEnum.FaultSourceWS faultSource)
        {
            XmlQualifiedName faultCodeSource = null;

            //Identify the location of the FaultCode
            switch (faultSource)
            {
                case AppEnum.FaultSourceWS.BusinessError:
                    faultCodeSource = SoapException.ClientFaultCode;
                    break;
                case AppEnum.FaultSourceWS.AplicationError:
                    faultCodeSource = SoapException.ServerFaultCode;
                    break;
            }

            XmlDocument xmlDoc = new XmlDocument();
            //Create the Detail node
            XmlNode rootNode = xmlDoc.CreateNode(XmlNodeType.Element,
                               SoapException.DetailElementName.Name,
                               SoapException.DetailElementName.Namespace);

            //Build specific details for the SoapException
            //Add first child of detail XML element.
            XmlNode errorNode = xmlDoc.CreateNode(XmlNodeType.Element, "Error",
                                                  webServiceNamespace);

            //Create and set the value for the ErrorNumber node
            XmlNode errorNumberNode =
              xmlDoc.CreateNode(XmlNodeType.Element, "ErrorNumber",
                                webServiceNamespace);
            errorNumberNode.InnerText = errorNumber;

            //Create and set the value for the ErrorMessage node
            XmlNode errorMessageNode = xmlDoc.CreateNode(XmlNodeType.Element,
                                                        "ErrorMessage",
                                                        webServiceNamespace);

            errorMessageNode.InnerText = errorMessage;

            //Create and set the value for the ErrorSource node
            XmlNode errorSourceNode =
              xmlDoc.CreateNode(XmlNodeType.Element, "ErrorSource",
                                webServiceNamespace);
            errorSourceNode.InnerText = errorSource;

            //Append the Error child element nodes to the root detail node.
            errorNode.AppendChild(errorNumberNode);
            errorNode.AppendChild(errorMessageNode);
            errorNode.AppendChild(errorSourceNode);

            //Append the Detail node to the root node
            rootNode.AppendChild(errorNode);
            //Construct the exception
            SoapException soapException = new SoapException(errorMessage,
                                                     faultCodeSource, uri,
                                                     rootNode);
            //Raise the exception  back to the caller
            return soapException;
        }
    }
}