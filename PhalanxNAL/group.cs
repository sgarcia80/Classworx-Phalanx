using System;

namespace PhalanxNAL
{
	/// <summary>
	/// Summary description for pc.
	/// </summary>
	public class CGroup
	{
		public string group_name;
		public int attributes;
		public uint group_id;
		public string comment;

		public CGroup()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public CGroup(string name)
		{
			group_name= name;
		}



	}
}
