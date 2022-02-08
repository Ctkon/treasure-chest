using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class BookInfoDAL
	{

		/// <summary>
		/// ��ȡ������Ϣ
		/// </summary>
		/// <param name="where">����</param>
		/// <returns>�����</returns>
		public static SqlDataReader GetBookInfoInfo(string where)
		{
			string sqlStr = "SELECT * FROM BookInfo where ";
			if (String.IsNullOrEmpty(where))
			{
				sqlStr += "1=1";
			}
			else
			{
				sqlStr += where;
			}
			SqlDataReader reader = null;
			try
			{
				reader = DBManager.ExecuteQuery(sqlStr);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return reader;
		}

		/// <summary>
		/// ��ȡ������Ϣ����
		/// </summary>
		/// <returns>List����</returns>
		public static List<BookInfoInfo> GetBookInfoInfoList(string where)
		{
			List<BookInfoInfo> infoList = new List<BookInfoInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetBookInfoInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				BookInfoInfo info = new BookInfoInfo();
				info.ID=int.Parse(reader["ID"].ToString());
				info.CustomerName=reader["CustomerName"].ToString();
				info.Phone=reader["Phone"].ToString();
				info.Deposit=int.Parse(reader["Deposit"].ToString());
				info.CheckInTime=reader["CheckInTime"].ToString();
				info.Days=int.Parse(reader["Days"].ToString());
				info.RoomPrice=double.Parse(reader["RoomPrice"].ToString());
				info.RoomType=reader["RoomType"].ToString();
				info.RoomNumber=reader["RoomNumber"].ToString();
				info.Remarks=reader["Remarks"].ToString();
				infoList.Add(info);
			}
			reader.Close();
			return infoList;
		}

		/// <summary>
		/// ���� ���� ��ȡһ��ʵ�����
		/// <param name="ID">����</param>
		/// </summary>
		public static BookInfoInfo GetBookInfoInfoById(int ID)
		{
			string strWhere = "ID =" + ID;
			List<BookInfoInfo> list = GetBookInfoInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public static bool AddBookInfo(BookInfoInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Phone = info.Phone;
			int _Deposit = info.Deposit;
			string _CheckInTime = info.CheckInTime;
			int _Days = info.Days;
			double _RoomPrice = info.RoomPrice;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;

			string sql="INSERT INTO BookInfo VALUES (@_CustomerName,@_Phone,@_Deposit,@_CheckInTime,@_Days,@_RoomPrice,@_RoomType,@_RoomNumber,@_Remarks)";
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_Deposit",_Deposit),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_RoomPrice",_RoomPrice),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
			if(rst>0)
			{ 
				return true;
			}
			else
			{ 
				return false;
			}
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		/// <param name="ID">����</param>
		/// <returns></returns>
		public static bool DeleteBookInfoInfo(BookInfoInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM BookInfo WHERE ID=" + info.ID;
			int rows = DBManager.ExecuteUpdate(sqlStr);
			if (rows>0)
			{
				rst = true;
			}
			return rst;
		}

		/// ��������
		/// </summary>
		/// <param name="info">���ݱ�ʵ��</param>
		public static bool UpdateBookInfoInfo(BookInfoInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Phone = info.Phone;
			int _Deposit = info.Deposit;
			string _CheckInTime = info.CheckInTime;
			int _Days = info.Days;
			double _RoomPrice = info.RoomPrice;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;
			string sql="UPDATE BookInfo SET CustomerName=@_CustomerName, Phone=@_Phone, Deposit=@_Deposit, CheckInTime=@_CheckInTime, Days=@_Days, RoomPrice=@_RoomPrice, RoomType=@_RoomType, RoomNumber=@_RoomNumber, Remarks=@_Remarks  WHERE ID="+info.ID;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_Deposit",_Deposit),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_RoomPrice",_RoomPrice),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
			if(rst>0)
			{ 
				return true;
			}
			else
			{ 
				return false;
			}
		}
	}
}
