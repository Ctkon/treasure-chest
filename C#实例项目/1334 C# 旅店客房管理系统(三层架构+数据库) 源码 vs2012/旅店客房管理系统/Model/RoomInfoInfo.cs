using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class RoomInfoInfo
	{
		private string _RoomNumber;
		/// <summary>
		/// ��ȡ������ RoomNumber ��ֵ
		/// </summary>
		public string RoomNumber
		{
			get { return _RoomNumber; }
			set { _RoomNumber = value; }
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

		private double _RoomPrice;
		/// <summary>
		/// ��ȡ������ RoomPrice ��ֵ
		/// </summary>
		public double RoomPrice
		{
			get { return _RoomPrice; }
			set { _RoomPrice = value; }
		}

		private string _RoomStatus;
		/// <summary>
		/// ��ȡ������ RoomStatus ��ֵ
		/// </summary>
		public string RoomStatus
		{
			get { return _RoomStatus; }
			set { _RoomStatus = value; }
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
