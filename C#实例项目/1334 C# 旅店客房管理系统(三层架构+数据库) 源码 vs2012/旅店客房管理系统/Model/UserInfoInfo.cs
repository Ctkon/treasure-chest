using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class UserInfoInfo
	{
		private string _UserName;
		/// <summary>
		/// ��ȡ������ UserName ��ֵ
		/// </summary>
		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}

		private string _UserPassword;
		/// <summary>
		/// ��ȡ������ UserPassword ��ֵ
		/// </summary>
		public string UserPassword
		{
			get { return _UserPassword; }
			set { _UserPassword = value; }
		}

		private string _UserType;
		/// <summary>
		/// ��ȡ������ UserType ��ֵ
		/// </summary>
		public string UserType
		{
			get { return _UserType; }
			set { _UserType = value; }
		}

	}
}
