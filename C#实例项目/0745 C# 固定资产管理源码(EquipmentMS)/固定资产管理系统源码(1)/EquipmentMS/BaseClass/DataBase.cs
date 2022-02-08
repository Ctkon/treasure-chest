using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace EquipmentMS.BaseClass
{
    class DataBase:IDisposable
    {
        private SqlConnection con;  //�������Ӷ���
        #region   �����ݿ�����
        /// <summary>
        /// �����ݿ�����.
        /// </summary>
        private void Open()
        {
            // �����ݿ�����
            if (con == null)
            {

                con = new SqlConnection("Data Source=.;DataBase=db_EquipmentMS;Integrated Security=True;Uid=sa;Pwd=Abc123;");
                //con = new SqlConnection(" Data Source = .\\SqlExpress;DataBase = db_EquipmentMS;Integrated Security =True");
            }
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();

        }
        #endregion

        #region  �ر�����
        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public void Close()
        {
            if (con != null)
                con.Close();
        }
        #endregion

        #region �ͷ����ݿ�������Դ
        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        public void Dispose()
        {
            // ȷ�������Ƿ��Ѿ��ر�
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
        #endregion

        #region   �����������ת��ΪSqlParameter����
        /// <summary>
        /// ת������
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param></param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// ��ʼ������ֵ
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Direction">��������</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }
        #endregion

        #region   ִ�в��������ı�(�����ݿ������ݷ���)
        /// <summary>
        /// ִ������
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            //�õ�ִ�гɹ�����ֵ
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>
        /// ֱ��ִ��SQL���
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <returns></returns>
        public int RunProc(string procName)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.ExecuteNonQuery();
            this.Close();
            return 1;
        }

        #endregion

        #region   ִ�в��������ı�(�з���ֵ)
        /// <summary>
        /// ִ�в�ѯ�����ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns></returns>
        public DataSet RunProcReturn(string procName, SqlParameter[] prams, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //�õ�ִ�гɹ�����ֵ
            return ds;
        }

        /// <summary>
        /// ִ�������ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcReturn(string procName, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, null);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //�õ�ִ�гɹ�����ֵ
            return ds;
        }

        #endregion

        #region �������ı���ӵ�SqlDataAdapter
        /// <summary>
        /// ����һ��SqlDataAdapter�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        private SqlDataAdapter CreateDataAdaper(string procName, SqlParameter[] prams)
        {
            this.Open();
            SqlDataAdapter dap = new SqlDataAdapter(procName, con);
            dap.SelectCommand.CommandType = CommandType.Text;  //ִ�����ͣ������ı�
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    dap.SelectCommand.Parameters.Add(parameter);
            }
            //���뷵�ز���
            dap.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return dap;
        }
        #endregion

        #region   �������ı���ӵ�SqlCommand
        /// <summary>
        /// ����һ��SqlCommand�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams"�����ı��������</param>
        /// <returns>����SqlCommand����</returns>
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // ȷ�ϴ�����
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.Text;�������� //ִ�����ͣ������ı�

            // ���ΰѲ������������ı�
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            // ���뷵�ز���
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
        }
        #endregion
    }
}
