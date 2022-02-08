using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class RecordInfo
	{
		private int _ID;
		/// <summary>
		/// ��ȡ������ ID ��ֵ
		/// </summary>
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _CustomerName;
		/// <summary>
		/// ��ȡ������ CustomerName ��ֵ
		/// </summary>
		public string CustomerName
		{
			get { return _CustomerName; }
			set { _CustomerName = value; }
		}

		private string _Sex;
		/// <summary>
		/// ��ȡ������ Sex ��ֵ
		/// </summary>
		public string Sex
		{
			get { return _Sex; }
			set { _Sex = value; }
		}

		private string _CredentialNumber;
		/// <summary>
		/// ��ȡ������ CredentialNumber ��ֵ
		/// </summary>
		public string CredentialNumber
		{
			get { return _CredentialNumber; }
			set { _CredentialNumber = value; }
		}

		private string _Phone;
		/// <summary>
		/// ��ȡ������ Phone ��ֵ
		/// </summary>
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		private string _CheckInTime;
		/// <summary>
		/// ��ȡ������ CheckInTime ��ֵ
		/// </summary>
		public string CheckInTime
		{
			get { return _CheckInTime; }
			set { _CheckInTime = value; }
		}

		private string _CheckOutTime;
		/// <summary>
		/// ��ȡ������ CheckOutTime ��ֵ
		/// </summary>
		public string CheckOutTime
		{
			get { return _CheckOutTime; }
			set { _CheckOutTime = value; }
		}

		private int _Days;
		/// <summary>
		/// ��ȡ������ Days ��ֵ
		/// </summary>
		public int Days
		{
			get { return _Days; }
			set { _Days = value; }
		}

		private double _Spending;
		/// <summary>
		/// ��ȡ������ Spending ��ֵ
		/// </summary>
		public double Spending
		{
			get { return _Spending; }
			set { _Spending = value; }
		}

		private string _RoomType;
		/// <summary>
		/// ��ȡ������ RoomType ��ֵ
		/// </summary>
		public string RoomType
		{
			get { return _RoomType; }
			set { _RoomType = value; }
		}

		private string _RoomNumber;
		/// <summary>
		/// ��ȡ������ RoomNumber ��ֵ
		/// </summary>
		public string RoomNumber
		{
			get { return _RoomNumber; }
			set { _RoomNumber = value; }
		}

		private string _Remarks;
		/// <summary>
		/// ��ȡ������ Remarks ��ֵ
		/// </summary>
		public string Remarks
		{
			get { return _Remarks; }
			set { _Remarks = value; }
		}

	}
}
