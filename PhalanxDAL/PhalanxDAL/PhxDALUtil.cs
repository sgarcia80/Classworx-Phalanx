using System;

namespace Phalanx.Util
{
	/// <summary>
	/// Summary description for PhxDALUtil.
	/// </summary>
	public class PhxDALUtil
	{
		public PhxDALUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public enum RequestStates
        {
            Pending = 1,
            Authorized = 2,
            NotAuthorized = 3,
            Visualized = 4,
            DelFailed = 5,
            DelDone = 6,
            DelReverseDone = 7,
            ReturnedByUser = 8,
            ReturnedByAdmin = 9,
            Expired = 10,
            Closed = 11
        }

        public enum UserTypes
        {
            Windows = 1,
            DataBase = 2,
            Application = 3,
            Unix = 4,
            AS400 = 5,
            CommunicationDevice = 6,
            ATM = 7
        }
        public const uint SUCCESS = 0;
		public const uint ERROR = 1;
		public const uint NO_DATA_FOUND = 2;
	}
}
