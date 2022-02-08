using System.Collections.Generic;
using Model;
using DAL;

namespace BLL
{

    public class BookInfoBLL
	{


		/// <summary>
		/// ��ȡ������Ϣ����
		/// </summary>
		/// <returns>List����</returns>
		public  List<BookInfoInfo> GetBookInfoInfoList(string where)
		{
			try
			{
				return BookInfoDAL.GetBookInfoInfoList(where);
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
		public static BookInfoInfo GetBookInfoInfoById(int ID)
		{
			try
			{
				return BookInfoDAL.GetBookInfoInfoById(ID);
			}
			catch
			{
				throw;
			}
		}

		/// �������
		/// </summary>
		/// <param name="info">���ݱ�ʵ�����</param>
		public bool AddBookInfo(BookInfoInfo info)
		{
			try
			{
				return BookInfoDAL.AddBookInfo(info);
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
		public bool DeleteBookInfoInfo(BookInfoInfo info)
		{
			try
			{
				return BookInfoDAL.DeleteBookInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// ��������
		/// </summary>
		/// <param name="info">���ݱ�ʵ��</param>
		public static bool UpdateBookInfoInfo(BookInfoInfo info)
		{
			try
			{
				return BookInfoDAL.UpdateBookInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
