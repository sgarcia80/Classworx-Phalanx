using System;
using System.Diagnostics; 
using System.Net;
using System.IO; 

namespace phxLog
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	
	public class CLogger
	{
		public const uint TYPE_ERROR = 0;
		public const uint TYPE_WARNING = 1;
		public const uint TYPE_INFORMATION = 2;
		public const uint TYPE_AUDIT = 3;
		public uint levelToLog = 1;

		protected string strLogFilePath	= string.Empty;
		public string LogFilePath
		{
			set
			{
				strLogFilePath	= value;	
			}
			get
			{
				return strLogFilePath;
			}
		}

		public CLogger()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public CLogger(uint levelLog) 
		{
			//
			// TODO: Add constructor logic here
			//
			this.levelToLog= levelLog;
		}

		public bool registerLog(uint typeLog, uint errorCode, string errorTitle, string errorMsg, bool writeLogFile, bool writeLogEventViewer)
		{
			return registerLog(typeLog, 1, errorCode, errorTitle, errorMsg, writeLogFile, writeLogEventViewer);
		}
		
		public bool registerLog(uint typeLog, uint nivelLog, uint errorCode, string errorTitle, string errorMsg, bool writeLogFile, bool writeLogEventViewer)
		{
			bool bReturn = true;
			
			if (nivelLog <= this.levelToLog)
			{
				if (writeLogFile)
				{
					writeFile(typeLog, errorCode, errorTitle, errorMsg);
				}
				if (writeLogEventViewer)
				{
					writeEventViewer(typeLog, errorCode, errorTitle, errorMsg);
				}
			}
			return bReturn;
		}

		private bool writeFile(uint typeLog, uint errorCode, string errorTitle, string errorMsg)
		{
			string strPathName	= string.Empty;
			string strException	= string.Empty; 
			StreamWriter sw = null;
			bool bReturn = false;

			if (strLogFilePath.Equals(string.Empty))
			{
				//Get Default log file path "LogFile.txt"
				strPathName	= GetLogFilePath();
			}
			else
			{
				//If the log file path is not empty but the file is not available it will create it
				if (!File.Exists(strLogFilePath))
				{
					if (false == CheckDirectory(strLogFilePath))
						return false;
					FileStream fs = new FileStream(strLogFilePath,FileMode.OpenOrCreate, FileAccess.ReadWrite);
					fs.Close();
				}
				strPathName	= strLogFilePath;
			}

			switch (typeLog)
			{
				case TYPE_ERROR:
					strException= "ERROR";
					break;
				case TYPE_WARNING:
					strException= "WARNING";
					break;
				case TYPE_INFORMATION:
					strException= "INFORMATION";
					break;
				case TYPE_AUDIT:
					strException= "AUDIT";
					break;
				default:
					break;
			};
				
			try
			{
				sw = new StreamWriter(strPathName,true);
				sw.WriteLine(DateTime.Now.ToShortDateString() +" "+ DateTime.Now.ToLongTimeString() /*+ " CPU:" + Dns.GetHostName().ToString() */ + " Type: " + strException + " Code: " + errorCode.ToString().Trim());
				sw.WriteLine("Source: " + errorTitle);
				sw.WriteLine("Msg: " + errorMsg.Trim());  
				sw.WriteLine("------------------------------------------------------------- ");  
				sw.Flush();
				sw.Close();
				bReturn	= true;
			}
			catch(Exception)
			{
				bReturn	= false;
			}
			return bReturn;
		}

		
		private static string GetLogFilePath()
		{
			try
			{
				// get the base directory
				string baseDir =  AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.RelativeSearchPath;      

				// search the file below the current directory
				string retFilePath = baseDir + "//" + "phxLog.txt";

				// if exists, return the path
				if (File.Exists(retFilePath) == true)
					return retFilePath;
					//create a text file
				else
				{
					if (false == CheckDirectory(retFilePath))
						return  string.Empty;

					FileStream fs = new FileStream(retFilePath,FileMode.OpenOrCreate, FileAccess.ReadWrite);
					fs.Close();
				}

				return retFilePath;
			}
			catch(Exception)
			{
				return string.Empty; 
			}
		}

		private static bool CheckDirectory(string strLogPath)
		{
			try
			{
				int nFindSlashPos		= strLogPath.Trim().LastIndexOf("\\"); 
				string strDirectoryname	= strLogPath.Trim().Substring(0,nFindSlashPos);

				if (false == Directory.Exists(strDirectoryname))
					Directory.CreateDirectory(strDirectoryname); 

				return true;
			}
			catch(Exception)
			{
				return false;

			}
		}

		private bool writeEventViewer(uint typeLog, uint errorCode, string errorTitle, string errorMsg)
		{
			bool bReturn = false;
			// Create the custom object.
//			AppAlert appAlertData = new AppAlert(Int32.Parse(txtID.Text), txtName.Text);

			// Prepare the framework structures to save the strongly-typed data.
/*			MemoryStream   appAlertStream      = new MemoryStream();
			IFormatter     appAlertFormatter   = new BinaryFormatter();

			appAlertFormatter.Serialize(appAlertStream, appAlertData);
			byte[] serializedAppAlertData = appAlertStream.ToArray();
			appAlertStream.Close();
*/			// The data is serialized and can be written to the log.


			EventLogEntryType currEntryType = EventLogEntryType.Error;;
			switch (typeLog)
			{
				case TYPE_ERROR:
					currEntryType= EventLogEntryType.Error;
					break;
				case TYPE_WARNING:
					currEntryType= EventLogEntryType.Warning;
					break;
				case TYPE_INFORMATION:
					currEntryType= EventLogEntryType.Information;
					break;
				case TYPE_AUDIT:
					currEntryType= EventLogEntryType.SuccessAudit;
					break;
			};

			try
			{
				EventLog.WriteEntry("Phalanx Security Manager", // Source
					"Error Code ("+errorCode +") "+ (char)13 +  errorTitle + (char)13 + errorMsg, // Message
					currEntryType, // Event type
					0,    // Event ID
					0);   // Category
	  
				bReturn = true;
			}
			catch
			{
				bReturn = false;
			}
			return bReturn;
		}

	}
}
