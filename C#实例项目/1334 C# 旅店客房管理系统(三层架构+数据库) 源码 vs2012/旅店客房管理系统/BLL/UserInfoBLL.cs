using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class UserInfoBLL
	{


		/// <summary>
		/// ��ȡ������Ϣ����
		/// </summary>
		/// <returns>List����</returns>
		public List<UserInfoInfo> GetUserInfoInfoList(string where)
		{
			try
			{
				return UserInfoDAL.GetUserInfoInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ���� ���� ��ȡһ��ʵ�����
		/// <param name="UserName">����</param>
		/// </summary>
		public static UserInfoInfo GetUserInfoInfoById(string UserName)
		{
			try
			{
				return UserInfoDAL.GetUserInfoInfoById(UserName);
			}
			catch
			{
				throw;
			}
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public  bool AddUserInfo(UserInfoInfo info)
		{
			try
			{
				return UserInfoDAL.AddUserInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ��������ɾ��һ������
		/// </summary>
		/// <param name="_UserName">����</param>
		/// <returns></returns>
		public static bool DeleteUserInfoInfo(UserInfoInfo info)
		{
			try
			{
				return UserInfoDAL.DeleteUserInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// ��������
		/// </summary>
		/// <param name="info">���ݱ�ʵ��</param>
		public static bool UpdateUserInfoInfo(UserInfoInfo info)
		{
			try
			{
				return UserInfoDAL.UpdateUserInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
