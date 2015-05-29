using System;
using System.Collections.Generic;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3;

using System.Xml;
using System.Configuration;

namespace WSE3.CustomAssertion.RemoveAddressingHeaders
{
    /// <summary>
    /// Summary description for RemoveAddressingHeadersAssertion
    /// </summary>
    public class RemoveAddressingHeadersAssertion : PolicyAssertion
    {
        public RemoveAddressingHeadersAssertion()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override Microsoft.Web.Services3.SoapFilter CreateClientInputFilter(FilterCreationContext context)
        {
            return new ClientInputFilter();
        }

        public override Microsoft.Web.Services3.SoapFilter CreateClientOutputFilter(FilterCreationContext context)
        {


            return new ClientOutputFilter();

        }

        public override Microsoft.Web.Services3.SoapFilter CreateServiceInputFilter(FilterCreationContext context)
        {
            return new ServiceInputFilter();
        }

        public override Microsoft.Web.Services3.SoapFilter CreateServiceOutputFilter(FilterCreationContext context)
        {
            return new ServiceOutputFilter();
        }
        public override System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Type>> GetExtensions()
        {

            return new KeyValuePair<string, Type>[] { new KeyValuePair<string, Type>("RemoveAddressingHeadersAssertion", this.GetType()) };

        }



        public override void ReadXml(XmlReader reader, IDictionary<string, Type> extensions)
        {

            reader.ReadStartElement("RemoveAddressingHeadersAssertion");

        }

    }
    public class ClientInputFilter : SoapFilter
    {

        public override SoapFilterResult ProcessMessage(SoapEnvelope envelope)
        {

            return SoapFilterResult.Continue;

        }

    }



    //provide implementation for only the ClientOutOutputFilter as we are trying to modify an outgoing soap request

    public class ClientOutputFilter : SoapFilter
    {



        public ClientOutputFilter()

            : base()

        { }



        public override SoapFilterResult ProcessMessage(SoapEnvelope envelope)
        {
             //creating the <wsse:Security> element in the outgoing message
            envelope.Envelope.Attributes.RemoveNamedItem("xmlns:wsa");


            XmlAttribute soapenc = envelope.CreateAttribute("xmlns", "soapenc", "http://www.w3.org/2000/xmlns/");
            soapenc.Value = "http://schemas.xmlsoap.org/soap/encoding/";
            envelope.Envelope.Attributes.Append(soapenc);

            XmlNode securityNode = envelope.CreateNode(XmlNodeType.Element, "wsse:Security","http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            XmlElement MustUnderstandElement = securityNode as XmlElement;
            

            XmlAttribute securityAttr = envelope.CreateAttribute("soap","mustUnderstand","http://schemas.xmlsoap.org/soap/envelope/");
            securityAttr.Prefix = "soap";
            //XmlAttribute securityAttr = MustUnderstandElement.SetAttribute("soap:mustUnderstand");
            //MustUnderstandElement
            securityAttr.Value = "1";
            MustUnderstandElement.Attributes.Append(securityAttr);


            //creating the <wsse:usernameToken> element
            XmlNode usernameTokenNode = envelope.CreateNode(XmlNodeType.Element, "wsse:UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

            //XmlElement userElement = usernameTokenNode as XmlElement;

            //userElement.SetAttribute("xmlns:wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");

 

            //creating the <wsse:Username> element

            XmlNode userNameNode = envelope.CreateNode(XmlNodeType.Element, "wsse:Username", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

            userNameNode.InnerXml = ConfigurationManager.AppSettings["COBISWSSUser"];

 

            //creating the <wsse:password> element

            XmlNode pwdNode = envelope.CreateNode(XmlNodeType.Element, "wsse:Password", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

            XmlElement pwdElement = pwdNode as XmlElement;

            pwdElement.SetAttribute("Type", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText");

            //pwdNode.InnerXml = "test password";

 

            usernameTokenNode.AppendChild(userNameNode);

            usernameTokenNode.AppendChild(pwdNode);

 

            securityNode.AppendChild(usernameTokenNode);

 

            envelope.ImportNode(securityNode, true);                

 

            XmlNode node = envelope.Header;

 

            node.AppendChild(securityNode);

 

            //removing Addressing headers from the outgoing request

 

            XmlNode actionNode = envelope.Header["wsa:Action"];

            envelope.Header.RemoveChild(actionNode);

 

            XmlNode messageNode = envelope.Header["wsa:MessageID"];

            envelope.Header.RemoveChild(messageNode);

 

            XmlNode replyToNode = envelope.Header["wsa:ReplyTo"];

            envelope.Header.RemoveChild(replyToNode);

 

            XmlNode toNode = envelope.Header["wsa:To"];

            envelope.Header.RemoveChild(toNode);

            //include similar code inside this method as pasted earlier inside the WSE 2.0 output filter's ProcessMessage() method

            return SoapFilterResult.Continue;
            //return SoapFilterResult.Terminate;

        }

    }



    public class ServiceInputFilter : SoapFilter
    {

        public override SoapFilterResult ProcessMessage(SoapEnvelope envelope)
        {

            return SoapFilterResult.Continue;

        }

    }



    public class ServiceOutputFilter : SoapFilter
    {

        public override SoapFilterResult ProcessMessage(SoapEnvelope envelope)
        {

            return SoapFilterResult.Continue;

        }

    }
}