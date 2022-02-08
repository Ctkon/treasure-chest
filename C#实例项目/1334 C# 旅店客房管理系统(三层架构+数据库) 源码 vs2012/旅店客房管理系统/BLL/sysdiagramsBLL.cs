using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// sysdiagramsBLL��
    /// BY�����˴��������� V1.0
    /// ���ߣ���������
    /// ���ڣ�2019��06��03�� 06:47:09
    /// </summary>
    public class sysdiagramsBLL
	{


		/// <summary>
		/// ��ȡ������Ϣ����
		/// </summary>
		/// <returns>List����</returns>
		public static List<sysdiagramsInfo> GetsysdiagramsInfoList(string where)
		{
			try
			{
				return sysdiagramsDAL.GetsysdiagramsInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ���� ���� ��ȡһ��ʵ�����
		/// <param name="diagramid">����</param>
		/// </summary>
		public static sysdiagramsInfo GetsysdiagramsInfoById(int diagramid)
		{
			try
			{
				return sysdiagramsDAL.GetsysdiagramsInfoById(diagramid);
			}
			catch
			{
				throw;
			}
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public static bool Addsysdiagrams(sysdiagramsInfo info)
		{
			try
			{
				return sysdiagramsDAL.Addsysdiagrams(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ��������ɾ��һ������
		/// </summary>
		/// <param name="_diagram_id">����</param>
		/// <returns></returns>
		public static bool DeletesysdiagramsInfo(sysdiagramsInfo info)
		{
			try
			{
				return sysdiagramsDAL.DeletesysdiagramsInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// ��������
		/// </summary>
		/// <param name="info">���ݱ�ʵ��</param>
		public static bool UpdatesysdiagramsInfo(sysdiagramsInfo info)
		{
			try
			{
				return sysdiagramsDAL.UpdatesysdiagramsInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
