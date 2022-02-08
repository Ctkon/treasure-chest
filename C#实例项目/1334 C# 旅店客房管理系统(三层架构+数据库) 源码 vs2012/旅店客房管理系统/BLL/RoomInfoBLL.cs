using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class RoomInfoBLL
	{


		/// <summary>
		/// ��ȡ������Ϣ����
		/// </summary>
		/// <returns>List����</returns>
		public List<RoomInfoInfo> GetRoomInfoInfoList(string where)
		{
			try
			{
				return RoomInfoDAL.GetRoomInfoInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ���� ���� ��ȡһ��ʵ�����
		/// <param name="RoomNumber">����</param>
		/// </summary>
		public static RoomInfoInfo GetRoomInfoInfoById(string RoomNumber)
		{
			try
			{
				return RoomInfoDAL.GetRoomInfoInfoById(RoomNumber);
			}
			catch
			{
				throw;
			}
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public bool AddRoomInfo(RoomInfoInfo info)
		{
			try
			{
				return RoomInfoDAL.AddRoomInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ��������ɾ��һ������
		/// </summary>
		/// <param name="_RoomNumber">����</param>
		/// <returns></returns>
		public static bool DeleteRoomInfoInfo(RoomInfoInfo info)
		{
			try
			{
				return RoomInfoDAL.DeleteRoomInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// ��������
		/// </summary>
		/// <param name="info">���ݱ�ʵ��</param>
		public bool UpdateRoomInfoInfo(RoomInfoInfo info)
		{
			try
			{
				return RoomInfoDAL.UpdateRoomInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
