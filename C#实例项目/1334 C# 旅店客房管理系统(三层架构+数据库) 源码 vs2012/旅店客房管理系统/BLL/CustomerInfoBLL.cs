using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class CustomerInfoBLL
	{


		/// <summary>
		/// ��ȡ������Ϣ����
		/// </summary>
		/// <returns>List����</returns>
		public List<CustomerInfoInfo> GetCustomerInfoInfoList(string where)
		{
			try
			{
				return CustomerInfoDAL.GetCustomerInfoInfoList(where);
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
		public static CustomerInfoInfo GetCustomerInfoInfoById(int ID)
		{
			try
			{
				return CustomerInfoDAL.GetCustomerInfoInfoById(ID);
			}
			catch
			{
				throw;
			}
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public bool AddCustomerInfo(CustomerInfoInfo info)
		{
			try
			{
				return CustomerInfoDAL.AddCustomerInfo(info);
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
		public static bool DeleteCustomerInfoInfo(CustomerInfoInfo info)
		{
			try
			{
				return CustomerInfoDAL.DeleteCustomerInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// ��������
		/// </summary>
		/// <param name="info">���ݱ�ʵ��</param>
		public bool UpdateCustomerInfoInfo(CustomerInfoInfo info)
		{
			try
			{
				return CustomerInfoDAL.UpdateCustomerInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
