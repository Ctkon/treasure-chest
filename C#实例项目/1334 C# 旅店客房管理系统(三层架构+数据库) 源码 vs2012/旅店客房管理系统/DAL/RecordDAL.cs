using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class RecordDAL
	{

		/// <summary>
		/// ��ȡ������Ϣ
		/// </summary>
		/// <param name="where">����</param>
		/// <returns>�����</returns>
		public static SqlDataReader GetRecordInfo(string where)
		{
			string sqlStr = "SELECT * FROM Record where ";
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
		public static List<RecordInfo> GetRecordInfoList(string where)
		{
			List<RecordInfo> infoList = new List<RecordInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetRecordInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				RecordInfo info = new RecordInfo();
				info.ID=int.Parse(reader["ID"].ToString());
				info.CustomerName=reader["CustomerName"].ToString();
				info.Sex=reader["Sex"].ToString();
				info.CredentialNumber=reader["CredentialNumber"].ToString();
				info.Phone=reader["Phone"].ToString();
				info.CheckInTime=reader["CheckInTime"].ToString();
				info.CheckOutTime=reader["CheckOutTime"].ToString();
				info.Days=int.Parse(reader["Days"].ToString());
				info.Spending=double.Parse(reader["Spending"].ToString());
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
		public static RecordInfo GetRecordInfoById(int ID)
		{
			string strWhere = "ID =" + ID;
			List<RecordInfo> list = GetRecordInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public static bool AddRecord(RecordInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Sex = info.Sex;
			string _CredentialNumber = info.CredentialNumber;
			string _Phone = info.Phone;
			string _CheckInTime = info.CheckInTime;
			string _CheckOutTime = info.CheckOutTime;
			int _Days = info.Days;
			double _Spending = info.Spending;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;

			string sql="INSERT INTO Record VALUES (@_CustomerName,@_Sex,@_CredentialNumber,@_Phone,@_CheckInTime,@_CheckOutTime,@_Days,@_Spending,@_RoomType,@_RoomNumber,@_Remarks)";
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Sex",_Sex),new SqlParameter("@_CredentialNumber",_CredentialNumber),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_CheckOutTime",_CheckOutTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_Spending",_Spending),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
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
		public static bool DeleteRecordInfo(RecordInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM Record WHERE ID=" + info.ID;
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
		public static bool UpdateRecordInfo(RecordInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Sex = info.Sex;
			string _CredentialNumber = info.CredentialNumber;
			string _Phone = info.Phone;
			string _CheckInTime = info.CheckInTime;
			string _CheckOutTime = info.CheckOutTime;
			int _Days = info.Days;
			double _Spending = info.Spending;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;
			string sql="UPDATE Record SET CustomerName=@_CustomerName, Sex=@_Sex, CredentialNumber=@_CredentialNumber, Phone=@_Phone, CheckInTime=@_CheckInTime, CheckOutTime=@_CheckOutTime, Days=@_Days, Spending=@_Spending, RoomType=@_RoomType, RoomNumber=@_RoomNumber, Remarks=@_Remarks  WHERE ID="+info.ID;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Sex",_Sex),new SqlParameter("@_CredentialNumber",_CredentialNumber),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_CheckOutTime",_CheckOutTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_Spending",_Spending),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
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
