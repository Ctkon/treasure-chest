using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{

	public static class DBManager
	{

		/// <summary>
		/// �����ַ���
		/// </summary>
		private static string connStr= @"Server=.;Integrated Security=SSPI;database=Hotel";

		/// <summary>
		/// ��ȡһ���µ�����
		/// </summary>
		/// <param name="connStr">�����ַ���</param>
		/// <returns></returns>
		public static SqlConnection Conn
		{
			get
			{
				return new SqlConnection(connStr);
			}
		}

		/// <summary>
		/// ִ������ɾ���� SQL���
		/// </summary>
		/// <param name="sqlStr">SQL���</param>
		/// <param name="param">�����б�</param>
		/// <returns>Ӱ�������</returns>
		public static int ExecuteUpdate(string sqlStr,params object[] param)
		{
			SqlCommand cmd = new SqlCommand(sqlStr, Conn);
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			int rows = 0;
			try
			{
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				cmd.Connection.Close();
			}
			return rows;
		}

		/// <summary>
		/// ִ�в�ѯSQL���
		/// </summary>
		/// <param name="sqlStr">SQL���</param>
		/// <param name="param">�����б�</param>
		/// <returns></returns>
		public static SqlDataReader ExecuteQuery(string sqlStr,params object[] param)
		{
			SqlCommand cmd = new SqlCommand(sqlStr, Conn);
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			try
			{
				return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection) ;
			}
			catch (Exception)
			{
				cmd.Connection.Close();
				throw;
			}
		}
		/// <summary>
		/// ִ�д洢���� - �޽����
		/// </summary>
		/// <param name="paroName">�洢��������</param>
		/// <param name="param">�����б�</param>
		/// <returns></returns>
		public static int ExecuteProc(string procName, params object[] param)
		{
			SqlCommand cmd = new SqlCommand(procName, Conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			try
			{
				return cmd.ExecuteNonQuery();
			}
			finally
			{
				cmd.Connection.Close();
			}
		}
		/// <summary>
		/// ִ�д洢���� - �н����
		/// </summary>
		/// <param name="paroName">�洢��������</param>
		/// <param name="param">�����б�</param>
		/// <returns></returns>
		public static SqlDataReader ExecuteProcByReader(string procName, params object[] param)
		{
			SqlCommand cmd = new SqlCommand(procName, Conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			try
			{
				return cmd.ExecuteReader();
			}
			catch
			{
				cmd.Connection.Close();
				throw;
			}
		}
	}
}
