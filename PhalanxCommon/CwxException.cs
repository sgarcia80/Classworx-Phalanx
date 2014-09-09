using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon
{
    public class CwxException : Exception
    {
        protected string _message = "";
        protected string _friendly_message = "";

        public override string Message
        {
            get
            {
                return _message;
            }
        }
        public string FullMessage
        {
            get
            {
                if (_friendly_message == "")
                {
                    return "Mensaje: " + this.Message + "\n" + "Source: " + this.Source;
                }
                else
                {
                    return _friendly_message;
                }
            }  
        }
        // test2 ahora pasa al 3
        public CwxException(string FriendlyMessage)
        {
            _friendly_message = FriendlyMessage;
        }

        public CwxException(string Message, string Source)
        {
            _message = Message;
            base.Source = Source;
        }
    }
}
