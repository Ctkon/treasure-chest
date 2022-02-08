using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class RoomInfoDAL
	{

		/// <summary>
		/// ��ȡ������Ϣ
		/// </summary>
		/// <param name="where">����</param>
		/// <returns>�����</returns>
		public static SqlDataReader GetRoomInfoInfo(string where)
		{
			string sqlStr = "SELECT * FROM RoomInfo where ";
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
		public static List<RoomInfoInfo> GetRoomInfoInfoList(string where)
		{
			List<RoomInfoInfo> infoList = new List<RoomInfoInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetRoomInfoInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				RoomInfoInfo info = new RoomInfoInfo();
				info.RoomNumber=reader["RoomNumber"].ToString();
				info.RoomType=reader["RoomType"].ToString();
				info.RoomPrice=double.Parse(reader["RoomPrice"].ToString());
				info.RoomStatus=reader["RoomStatus"].ToString();
				info.Remarks=reader["Remarks"].ToString();
				infoList.Add(info);
			}
			reader.Close();
			return infoList;
		}

		/// <summary>
		/// ���� ���� ��ȡһ��ʵ�����
		/// <param name="RoomNumber">����</param>
		/// </summary>
		public static RoomInfoInfo GetRoomInfoInfoById(string RoomNumber)
		{
			string strWhere = "RoomNumber =" + RoomNumber;
			List<RoomInfoInfo> list = GetRoomInfoInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public static bool AddRoomInfo(RoomInfoInfo info)
		{
            string _RoomNumber = info.RoomNumber;
            string _RoomType = info.RoomType;
            double _RoomPrice = info.RoomPrice;
            string _RoomStatus = info.RoomStatus;
            string _Remarks = info.Remarks;

            string sql = "INSERT INTO RoomInfo VALUES (@_RoomNumber,@_RoomType,@_RoomPrice,@_RoomStatus,@_Remarks)";
            int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_RoomNumber", _RoomNumber), new SqlParameter("@_RoomType", _RoomType), new SqlParameter("@_RoomPrice", _RoomPrice), new SqlParameter("@_RoomStatus", _RoomStatus), new SqlParameter("@_Remarks", _Remarks) });
            if (rst > 0)
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
		/// <param name="RoomNumber">����</param>
		/// <returns></returns>
		public static bool DeleteRoomInfoInfo(RoomInfoInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM RoomInfo WHERE RoomNumber=" + info.RoomNumber;
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
		public static bool UpdateRoomInfoInfo(RoomInfoInfo info)
		{
			string _RoomType = info.RoomType;
			double _RoomPrice = info.RoomPrice;
			string _RoomStatus = info.RoomStatus;
			string _Remarks = info.Remarks;
			string sql="UPDATE RoomInfo SET RoomType=@_RoomType, RoomPrice=@_RoomPrice, RoomStatus=@_RoomStatus, Remarks=@_Remarks  WHERE RoomNumber="+info.RoomNumber;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomPrice",_RoomPrice),new SqlParameter("@_RoomStatus",_RoomStatus),new SqlParameter("@_Remarks",_Remarks) });
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
