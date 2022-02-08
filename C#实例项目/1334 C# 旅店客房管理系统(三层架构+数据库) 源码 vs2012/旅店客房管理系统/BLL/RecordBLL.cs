using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class RecordBLL
	{


		/// <summary>
		/// ��ȡ������Ϣ����
		/// </summary>
		/// <returns>List����</returns>
		public static List<RecordInfo> GetRecordInfoList(string where)
		{
			try
			{
				return RecordDAL.GetRecordInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ���� ���� ��ȡһ��ʵ�����
		/// <param name="ID">����</param>
		/// </summary>
		public static RecordInfo GetRecordInfoById(int ID)
		{
			try
			{
				return RecordDAL.GetRecordInfoById(ID);
			}
			catch
			{
				throw;
			}
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public static bool AddRecord(RecordInfo info)
		{
			try
			{
				return RecordDAL.AddRecord(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ��������ɾ��һ������
		/// </summary>
		/// <param name="_ID">����</param>
		/// <returns></returns>
		public static bool DeleteRecordInfo(RecordInfo info)
		{
			try
			{
				return RecordDAL.DeleteRecordInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// ��������
		/// </summary>
		/// <param name="info">���ݱ�ʵ��</param>
		public static bool UpdateRecordInfo(RecordInfo info)
		{
			try
			{
				return RecordDAL.UpdateRecordInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
