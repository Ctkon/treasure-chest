using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class sysdiagramsInfo
	{
		private string _name;
		/// <summary>
		/// ��ȡ������ name ��ֵ
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private int _principal_id;
		/// <summary>
		/// ��ȡ������ principal_id ��ֵ
		/// </summary>
		public int Principal_id
		{
			get { return _principal_id; }
			set { _principal_id = value; }
		}

		private int _diagram_id;
		/// <summary>
		/// ��ȡ������ diagram_id ��ֵ
		/// </summary>
		public int Diagram_id
		{
			get { return _diagram_id; }
			set { _diagram_id = value; }
		}

		private int _version;
		/// <summary>
		/// ��ȡ������ version ��ֵ
		/// </summary>
		public int Version
		{
			get { return _version; }
			set { _version = value; }
		}

		private string _definition;
		/// <summary>
		/// ��ȡ������ definition ��ֵ
		/// </summary>
		public string Definition
		{
			get { return _definition; }
			set { _definition = value; }
		}

	}
}
