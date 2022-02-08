using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class BookInfoInfo
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

		private string _Phone;
		/// <summary>
		/// ��ȡ������ Phone ��ֵ
		/// </summary>
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		private int _Deposit;
		/// <summary>
		/// ��ȡ������ Deposit ��ֵ
		/// </summary>
		public int Deposit
		{
			get { return _Deposit; }
			set { _Deposit = value; }
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

		private int _Days;
		/// <summary>
		/// ��ȡ������ Days ��ֵ
		/// </summary>
		public int Days
		{
			get { return _Days; }
			set { _Days = value; }
		}

		private double _RoomPrice;
		/// <summary>
		/// ��ȡ������ RoomPrice ��ֵ
		/// </summary>
		public double RoomPrice
		{
			get { return _RoomPrice; }
			set { _RoomPrice = value; }
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
