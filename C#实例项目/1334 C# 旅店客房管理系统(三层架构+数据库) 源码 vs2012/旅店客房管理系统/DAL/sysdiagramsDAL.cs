using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class sysdiagramsDAL
	{

		/// <summary>
		/// ��ȡ������Ϣ
		/// </summary>
		/// <param name="where">����</param>
		/// <returns>�����</returns>
		public static SqlDataReader GetsysdiagramsInfo(string where)
		{
			string sqlStr = "SELECT * FROM sysdiagrams where ";
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
		public static List<sysdiagramsInfo> GetsysdiagramsInfoList(string where)
		{
			List<sysdiagramsInfo> infoList = new List<sysdiagramsInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetsysdiagramsInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				sysdiagramsInfo info = new sysdiagramsInfo();
				info.Name=reader["Name"].ToString();
				info.Principal_id=int.Parse(reader["Principal_id"].ToString());
				info.Diagram_id=int.Parse(reader["Diagram_id"].ToString());
				info.Version=int.Parse(reader["Version"].ToString());
				info.Definition=reader["Definition"].ToString();
				infoList.Add(info);
			}
			reader.Close();
			return infoList;
		}

		/// <summary>
		/// ���� ���� ��ȡһ��ʵ�����
		/// <param name="Diagram_id">����</param>
		/// </summary>
		public static sysdiagramsInfo GetsysdiagramsInfoById(int Diagram_id)
		{
			string strWhere = "diagramid =" + Diagram_id;
			List<sysdiagramsInfo> list = GetsysdiagramsInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public static bool Addsysdiagrams(sysdiagramsInfo info)
		{
			string _name = info.Name;
			int _principal_id = info.Principal_id;
			int _version = info.Version;
			string _definition = info.Definition;

			string sql="INSERT INTO sysdiagrams VALUES (@_name,@_principal_id,@_version,@_definition)";
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_name",_name),new SqlParameter("@_principal_id",_principal_id),new SqlParameter("@_version",_version),new SqlParameter("@_definition",_definition) });
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
		/// <param name="Diagram_id">����</param>
		/// <returns></returns>
		public static bool DeletesysdiagramsInfo(sysdiagramsInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM sysdiagrams WHERE diagram_id=" + info.Diagram_id;
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
		public static bool UpdatesysdiagramsInfo(sysdiagramsInfo info)
		{
			string _name = info.Name;
			int _principal_id = info.Principal_id;
			int _version = info.Version;
			string _definition = info.Definition;
			string sql="UPDATE sysdiagrams SET name=@_name, principalid=@_principal_id, version=@_version, definition=@_definition  WHERE diagram_id="+info.Diagram_id;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_name",_name),new SqlParameter("@_principal_id",_principal_id),new SqlParameter("@_version",_version),new SqlParameter("@_definition",_definition) });
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
