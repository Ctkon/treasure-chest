using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Office.Interop;
//using Microsoft.Internal.Performance;

namespace EquipmentMS.BaseClass
{
    class Operation
    {
        DataBase data = new DataBase();

        #region ��֤�Ϸ����루0123456789.��
        /// <summary>
        /// ��֤�Ϸ����루0123456789.��
        /// </summary>
        /// <param name="strCode">��֤�ַ�</param>
        /// <returns></returns>
        public bool IsNumeric(string strCode)
        {
            if (strCode == null || strCode.Length == 0)
                return false;
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteStr = ascii.GetBytes(strCode);
            foreach (byte code in byteStr)
            {
                if (code == 190||code==110)
                if (code < 48 || code > 57)
                    return false;
            }
            return true;
        }
        #endregion
        
        #region ��DataGridView�ؼ������ݵ�����Excel
        /// <summary>
        /// ��DataGridView�ؼ������ݵ�����Excel
        /// </summary>
        /// <param name="gridView">DataGridView����</param>
        /// <param name="isShowExcle">�Ƿ���ʾExcel����</param>
        /// <returns></returns>
        public bool ExportDataGridview(DataGridView gridView,bool isShowExcle)
        {
            if (gridView.Rows.Count == 0)
                return false;
            //����Excel����

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;
            //�����ֶ�����
            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText;
            }
            //�������
            for (int i = 0; i < gridView.RowCount-1; i++)
            {
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    if (gridView[j, i].ValueType == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "'" + gridView[j, i].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
                    }
                }
            }
            return true;
        }
        #endregion

        #region  ����������DataGridView��Width��Visble���ԡ�
        public int DataGridViewSetWidth(int place, int DataGridView_width)
        {
            return data.RunProc("update tb_DataGridViewList set width=" + DataGridView_width + " where place=" + place + "");
        }
        public int DataGridViewSetVisible(int place, bool check)
        {
            return data.RunProc("update tb_DataGridViewList set Visible=" + Convert.ToInt16(check) + " where place=" + place + "");
        }
        #endregion

        #region  ���ñ���λ��Ϣ

        public int InsertUnits(string units, string linkman, string address, string tel, string memo)
        {
            return data.RunProc("insert into tb_units (units,linkman,address,tel,memo) values ('" + units + "','" + linkman + "','" + address + "','" + tel + "','" + memo + "')");
        }

        public int UpdateUnits(string units, string linkman, string address, string tel, string memo)
        {
            return data.RunProc("update tb_units set units='" + units + "',linkman='" + linkman + "',address='" + address + "',tel='" + tel + "',memo='" + memo + "'");
        }

        public DataSet GetDataSetUnits()
        {
            return data.RunProcReturn("select * from tb_units","tb_units");
        }

        #endregion

        #region  ϵͳ��ʼ��
        public int DeleteBaseTable()
        {
            return data.RunProc("delete from tb_units "+
                "delete from tb_BaseBgry " +
                "delete from tb_BaseCfdd " +
                "delete from tb_BaseDefaultNO " +
                "delete from tb_BaseJldw " +
                "delete from tb_BaseQlfs " +
                "delete from tb_BaseSybm " +
                "delete from tb_BaseSyqk " +
                "delete from tb_BaseZcmc " +
                "delete from tb_BaseZjfs " +
                "delete from tb_User");
        }

        public int DeleteOperationTable()
        {
            return data.RunProc("delete from tb_zcMain delete from tb_zcClear");
        }
        #endregion

        #region  ����������TreeView�˵���
        /// <summary>
        /// ��ȡTreeView�˵���
        /// </summary>
        /// <returns></returns>
        public DataSet TreeFill()
        {
            return data.RunProcReturn("select * from tb_BaseZclb select * from tb_BaseZjfs select * from tb_BaseSybm select * from tb_BaseSyqk select * from tb_BaseCfdd select * from tb_BaseBgry", "tb_zclb");
        }
        /// <summary>
        /// ��ȡ������DataGridView�ؼ�����������
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataGridViewList()
        {
            return data.RunProcReturn("select * from tb_DataGridViewList", "tb_DataGridViewList");
        }
        /// <summary>
        /// ��ȡ���й̶��ʲ���Ϣ
        /// </summary>
        /// <returns></returns>
        #endregion

        #region���ʲ���ѯ
        /// <summary>
        /// ��������ʲ�
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetZC()
        {
            return data.RunProcReturn("select * from tb_zcMain ORDER BY ID", "tb_zcMain");
        }
        public DataSet GetDataSetZC(string findTitle,string findContent)
        {
            return data.RunProcReturn("select * from tb_zcMain where " + findTitle + "='" + findContent + "' ORDER BY ID", "tb_zcMain");
        }
        #endregion

        #region �����ʲ�����
        /// <summary>
        /// ��ѯ�����ʲ������б�
        /// </summary>
        /// <param name="zcName">�ʲ�����</param>
        /// <returns></returns>
        public DataSet GetDataSetBaseZclb(string zcName)
        {
            return data.RunProcReturn("select * from tb_BaseZclb where zclb='" + zcName + "'","tb_BaseZclb");
        }
        public DataSet GetDataSetBaseZclb()
        {
            return data.RunProcReturn("select * from tb_BaseZclb where firstID=1", "tb_BaseZclb");
        }
        /// <summary>
        /// ����ʲ�����
        /// </summary>
        /// <param name="firstID"></param>
        /// <param name="zclb"></param>
        /// <param name="secondID"></param>
        /// <returns></returns>
        public int insertBaseZclb(string firstID,string zclb,string secondID)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@firstID",  SqlDbType.VarChar, 10, firstID),
                						data.MakeInParam("@zclb",  SqlDbType.VarChar, 10, zclb),
                						data.MakeInParam("@secondID",  SqlDbType.VarChar, 10, secondID),
			};
            return (data.RunProc("INSERT INTO tb_BaseZclb (firstID,zclb,secondID) VALUES (@firstID,@zclb,@secondID)", prams));
        }
        /// <summary>
        /// ɾ��ָ���ɣĵ��ʲ�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteBaseZclb(int id)
        {
            return data.RunProc("delete from tb_BaseZclb where id='" + id + "'");
        }
        /// <summary>
        /// �޸�ָ���ɣĵ��ʲ�����
        /// </summary>
        /// <param name="zclb"></param>
        /// <returns></returns>
        public int UpdateBaseZclb(int ID, string zclb)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",SqlDbType.Int,4,ID),
                						data.MakeInParam("@zclb",  SqlDbType.VarChar, 10, zclb),
			};
            return (data.RunProc("UPdate tb_BaseZclb set zclb=@zclb where id='" + ID + "'", prams));
        }
        #endregion

        #region  �������Ϲ���---��ѯ
        public DataSet GetDataSetBaseZcmc()
        {
            return data.RunProcReturn("select * from tb_BaseZcmc", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZjfs()
        {
            return data.RunProcReturn("select * from tb_BaseZjfs", "tb_BaseZjfs");
        }
        public DataSet GetDataSetBaseSybm()
        {
            return data.RunProcReturn("select * from tb_BaseSybm", "tb_BaseSybm");
        }
        public DataSet GetDataSetBaseSyqk()
        {
            return data.RunProcReturn("select * FROM tb_BaseSyqk", "tb_BaseSyqk");
        }
        public DataSet GetDataSetBaseCfdd()
        {
            return data.RunProcReturn("select * from tb_BaseCfdd", "tb_BaseCfdd");
        }
        public DataSet GetDataSetBaseBgry()
        {
            return data.RunProcReturn("select * from tb_BaseBgry","tb_BaseBgry");
        }
        public DataSet GetDataSetBaseJldw()
        {
            return data.RunProcReturn("select * from tb_BaseJldw", "tb_BaseJldw");
        }
        public DataSet GetDataSetBaseQlfs()
        {
            return data.RunProcReturn("select * from tb_BaseQlfs", "tb_BaseQlfs");
            
        }
        public DataSet GetDataSetBaseBrand()
        {            
            return data.RunProcReturn("select * from tb_BaseBrand", "tb_BaseBrand");
        }

        #endregion

        #region  �������Ϲ���----ɾ��
        public int DeleteBaseZcmc(string id)
        {
            return data.RunProc("delete from tb_BaseZcmc where id='" + id + "'");
        }
        public int DeleteBaseZjfs(string id)
        {
            return data.RunProc("delete from tb_BaseZjfs where id='" + id + "'");
        }
        public int DeleteBaseSybm(string id)
        {
            return data.RunProc("delete from tb_BaseSybm where id='" + id + "'");
        }
        public int DeleteBaseSyqk(string id)
        {
            return data.RunProc("delete from tb_BaseSyqk where id='" + id + "'");
        }
        public int DeleteBaseCfdd(string id)
        {
            return data.RunProc("delete from tb_BaseCfdd where id='" + id + "'");
        }
        public int DeleteBaseBgry(string id)
        {
            return data.RunProc("delete from tb_BaseBgry where id='" + id + "'");
        }
        public int DeleteBaseJldw(string id)
        {
            return data.RunProc("delete from tb_BaseJldw where id='" + id + "'");
        }
        public int DeleteBaseQlfs(string id)
        {
            return data.RunProc("delete from tb_BaseQlfs where id='" + id + "'");
           
        }
        public int DeleteBaseBrand(string id)
        {
            
            return data.RunProc("delete from tb_BaseBrand where id = '" + id + "'");
        }
        #endregion

        #region  �������Ϲ����������
        public int InsertBaseZcmc(string zcmc)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@zcmc",  SqlDbType.VarChar, 50, zcmc),
			};
            return (data.RunProc("INSERT INTO tb_BaseZcmc (zcmc) VALUES (@zcmc)", prams));
        }
        public int InsertBaseZjfs(string zjfs)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@zjfs",  SqlDbType.VarChar, 50, zjfs),
			};
            return (data.RunProc("INSERT INTO tb_BaseZjfs (zjfs) VALUES (@zjfs)", prams));
        }
        public int InsertBaseSybm(string sybm)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, sybm),
			};
            return (data.RunProc("INSERT INTO tb_BaseSybm (sybm) VALUES (@sybm)", prams));
        }
        public int InsertBaseSyqk(string syqk)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, syqk),
			};
            return (data.RunProc("INSERT INTO tb_BaseSyqk (syqk) VALUES (@syqk)", prams));
        }
        public int InsertBaseCfdd(string cfdd,string departMent)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, cfdd),
                                        data.MakeInParam("@departMent",SqlDbType.VarChar,50,departMent),
			};
            return (data.RunProc("INSERT INTO tb_BaseCfdd (cfdd,DepartMent) VALUES (@cfdd,@departMent)", prams));
        }
        public int InsertBaseBgry(string bgry, string departMent)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, bgry),
                                         data.MakeInParam("@departMent",SqlDbType.VarChar,50,departMent),
			};
            return (data.RunProc("INSERT INTO tb_BaseBgry (bgry,DepartMent) VALUES (@bgry,@departMent)", prams));
        }
        public int InsertBaseJldw(string jldw)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@jldw",  SqlDbType.VarChar, 50, jldw),
			};
            return (data.RunProc("INSERT INTO tb_BaseJldw (jldw) VALUES (@jldw)", prams));
        }
        public int InsertBaseQlfs(string qlfs)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@qlfs",  SqlDbType.VarChar, 50, qlfs),
            };
            return (data.RunProc("INSERT INTO tb_BaseQlfs (qlfs) VALUES (@qlfs)", prams));
        
        }

        public int InsertBaseBrand(string brandName)
        {
           
            SqlParameter[] prams = {
                						data.MakeInParam("@BrandName",  SqlDbType.VarChar, 50, brandName),
			};
            return (data.RunProc("INSERT INTO tb_BaseBrand (BrandName) VALUES (@BrandName)", prams));
        }
        #endregion

        #region   �̶��ʲ��������
        /// <summary>
        /// ��ѯ�Ƿ����Ĭ�Ϲ̶��ʲ����
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetBaseDefaultNO()
        {
            return data.RunProcReturn("select * from tb_BaseDefaultNO", "tb_BaseDefaultNO");
        }
        /// <summary>
        /// ����Ĭ�Ϲ̶��ʲ����
        /// </summary>
        /// <param name="firstNO"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        public int InsertBaseDefaultNO(string firstNO, int defaultNo)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@firstNO",  SqlDbType.VarChar, 50, firstNO),
                                        data.MakeInParam("@defaultNO",  SqlDbType.Int, 4, defaultNo),
			};
            return (data.RunProc("INSERT INTO tb_BaseDefaultNO (firstNO,defaultNO) VALUES (@firstNO,@defaultNO)", prams));
        }
        /// <summary>
        /// �޸�Ĭ�Ϲ̶��ʲ����
        /// </summary>
        /// <param name="firstNO"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        public int UpdateBaseDefaultNO(string firstNO, int defaultNo)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@firstNO",  SqlDbType.VarChar, 50, firstNO),
                                        data.MakeInParam("@defaultNO",  SqlDbType.Int, 4, defaultNo),
			};
            return (data.RunProc("Update tb_BaseDefaultNO Set firstNO=@firstNO,defaultNO=@defaultNO where id=1", prams));
        }
        #endregion

        #region   �̶��ʲ�����
        public int InsertZcMain(cZcMain zcMain)
        {
            SqlParameter[] prams = {
                				data.MakeInParam("@bh",  SqlDbType.VarChar, 50, zcMain.BH),
                                data.MakeInParam("@mc",  SqlDbType.VarChar, 50, zcMain.MC),
                    			data.MakeInParam("@xh",  SqlDbType.VarChar, 50, zcMain.XH),
                        		data.MakeInParam("@zclb",  SqlDbType.VarChar, 50, zcMain.Zclb),
                        		data.MakeInParam("@xxpz",  SqlDbType.VarChar, 200, zcMain.Xxpz),
                        		data.MakeInParam("@gjbh",  SqlDbType.VarChar, 50, zcMain.Gjbh),
                        		data.MakeInParam("@sccj",  SqlDbType.VarChar, 50, zcMain.Sccj),
                        		data.MakeInParam("@ccrq",  SqlDbType.DateTime, 8, zcMain.Ccrq),

                        		data.MakeInParam("@zjfs",  SqlDbType.VarChar, 50, zcMain.Zjfs),
                        		data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, zcMain.Sybm),
                        		data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, zcMain.Syqk),
                        		data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, zcMain.Cfdd),
                        		data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, zcMain.Bgry),
                        		data.MakeInParam("@rzrq",  SqlDbType.DateTime, 8, zcMain.Rzrq),

                        		data.MakeInParam("@sl",  SqlDbType.Int, 4, zcMain.SL),
                        		data.MakeInParam("@dw",  SqlDbType.VarChar, 20, zcMain.DW),
                        		data.MakeInParam("@dj",  SqlDbType.Float, 8, zcMain.DJ),
                        		data.MakeInParam("@yz",  SqlDbType.Float, 8, zcMain.YZ),
                        		data.MakeInParam("@ljzj",  SqlDbType.Float, 8, zcMain.Ljzj),
                        		data.MakeInParam("@jz",  SqlDbType.Float, 8, zcMain.JZ),
                        		data.MakeInParam("@jczl",  SqlDbType.Float, 8, zcMain.Jczl),
                        		data.MakeInParam("@zjff",  SqlDbType.VarChar, 20, zcMain.Zjff),
                        		data.MakeInParam("@nx",  SqlDbType.Int, 4, zcMain.Nx),
                        		data.MakeInParam("@login",  SqlDbType.DateTime, 20, zcMain.Login),
                        		data.MakeInParam("@loginer",  SqlDbType.VarChar, 8, zcMain.Loginer),
                                   data.MakeInParam("@gxrq",SqlDbType.DateTime,20,zcMain.Gxrq),
                                data.MakeInParam("@tm",SqlDbType.VarChar,20,zcMain.Tm),
                                  data.MakeInParam("@xlh",SqlDbType.VarChar,20,zcMain.Xlh),
                              data.MakeInParam("@Brand",SqlDbType.VarChar,20,zcMain.Brand),

			};
            return (data.RunProc("INSERT INTO tb_zcMain (bh,mc,xh,zclb,xxpz,gbbh,sccj,ccrq," +
            "zjfs,sybm,syqk,cfdd,bgry,rzrq,sl,dw,dj,zcyz,ljzj,zcjz,jczl,zjff,nx,djrq,djr,gxrq,tm,xlh,Brand)" +
            "VALUES (@bh,@mc,@xh,@zclb,@xxpz,@gjbh,@sccj,@ccrq" +
            ",@zjfs,@sybm,@syqk,@cfdd,@bgry,@rzrq," +
            "@sl,@dw,@dj,@yz,@ljzj,@jz,@jczl,@zjff,@nx,@login,@loginer,@gxrq,@tm,@xlh,@Brand)", prams));
        }

        public int UpdateZcMain(cZcMain zcMain)
        {
            SqlParameter[] prams = {
                				data.MakeInParam("@bh",  SqlDbType.VarChar, 50, zcMain.BH),
                                data.MakeInParam("@mc",  SqlDbType.VarChar, 50, zcMain.MC),
                    			data.MakeInParam("@xh",  SqlDbType.VarChar, 50, zcMain.XH),
                        		data.MakeInParam("@zclb",  SqlDbType.VarChar, 50, zcMain.Zclb),
                        		data.MakeInParam("@xxpz",  SqlDbType.VarChar, 200, zcMain.Xxpz),
                        		data.MakeInParam("@gjbh",  SqlDbType.VarChar, 50, zcMain.Gjbh),
                        		data.MakeInParam("@sccj",  SqlDbType.VarChar, 50, zcMain.Sccj),
                        		data.MakeInParam("@ccrq",  SqlDbType.DateTime, 8, zcMain.Ccrq),

                        		data.MakeInParam("@zjfs",  SqlDbType.VarChar, 50, zcMain.Zjfs),
                        		data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, zcMain.Sybm),
                        		data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, zcMain.Syqk),
                        		data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, zcMain.Cfdd),
                        		data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, zcMain.Bgry),
                        		data.MakeInParam("@rzrq",  SqlDbType.DateTime, 8, zcMain.Rzrq),

                        		data.MakeInParam("@sl",  SqlDbType.Int, 4, zcMain.SL),
                        		data.MakeInParam("@dw",  SqlDbType.VarChar, 20, zcMain.DW),
                        		data.MakeInParam("@dj",  SqlDbType.Float, 8, zcMain.DJ),
                        		data.MakeInParam("@yz",  SqlDbType.Float, 8, zcMain.YZ),
                        		data.MakeInParam("@ljzj",  SqlDbType.Float, 8, zcMain.Ljzj),
                        		data.MakeInParam("@jz",  SqlDbType.Float, 8, zcMain.JZ),
                        		data.MakeInParam("@jczl",  SqlDbType.Float, 8, zcMain.Jczl),
                        		data.MakeInParam("@zjff",  SqlDbType.VarChar, 20, zcMain.Zjff),
                        		data.MakeInParam("@nx",  SqlDbType.Int, 4, zcMain.Nx),
                        		data.MakeInParam("@login",  SqlDbType.DateTime, 20, zcMain.Login),
                        		data.MakeInParam("@loginer",  SqlDbType.VarChar, 8, zcMain.Loginer),
                                
                                data.MakeInParam("@gxrq",SqlDbType.DateTime,20,zcMain.Gxrq),
                                data.MakeInParam("@tm",SqlDbType.VarChar,20,zcMain.Tm),
            data.MakeInParam("xlh",SqlDbType.VarChar,20,zcMain.Xlh),
            data.MakeInParam("Brand",SqlDbType.VarChar,20,zcMain.Brand),

			};
            return (data.RunProc("Update tb_zcMain Set mc=@mc,xh=@xh," +
                "zclb=@zclb,xxpz=@xxpz,gbbh=@gjbh,sccj=@sccj,ccrq=@ccrq,zjfs=@zjfs," +
                "sybm=@sybm,syqk=@syqk,cfdd=@cfdd,bgry=@bgry,rzrq=@rzrq,sl=@sl,dw=@dw," +
                "dj=@dj,zcyz=@yz,ljzj=@ljzj,zcjz=@jz,jczl=@jczl,zjff=@zjff," +
                "nx=@nx,djrq=@login,djr=@loginer,gxrq=@gxrq ,tm = @tm,xlh = @xlh,Brand = @brand" +
           " where bh=@bh", prams));
        }
        /// <summary>
        /// ɾ���̶��ʲ�
        /// </summary>
        /// <param name="BH"></param>
        /// <returns></returns>
        public int DeleteZcMain(string BH)
        {
            return data.RunProc("delete from tb_zcMain where bh='" + BH + "'");
        }
        /// <summary>
        /// ��ȡָ���Ĺ̶��ʲ�
        /// </summary>
        /// <param name="BH"></param>
        /// <returns></returns>
        public DataSet GetDataSetZC(string BH)
        {
            return data.RunProcReturn("select * from tb_zcMain where bh='" + BH + "'","tb_zcMain");
        }
        /// <summary>
        /// ����̶��ʲ�������tb_zcClear�У�
        /// </summary>
        /// <param name="zcMain"></param>
        /// <returns></returns>
        public int ClearZcMain(cZcMain zcMain)
        {
            SqlParameter[] prams = {
                				data.MakeInParam("@bh",  SqlDbType.VarChar, 50, zcMain.BH),
                                data.MakeInParam("@mc",  SqlDbType.VarChar, 50, zcMain.MC),
                    			data.MakeInParam("@xh",  SqlDbType.VarChar, 50, zcMain.XH),
                        		data.MakeInParam("@xxpz",  SqlDbType.VarChar, 200, zcMain.Xxpz),

                        		data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, zcMain.Syqk),
                        		data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, zcMain.Sybm),
                        		data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, zcMain.Bgry),
                        		data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, zcMain.Cfdd),

                        		data.MakeInParam("@qlr",  SqlDbType.VarChar, 8, zcMain.Qlr),
                                data.MakeInParam("@qlfs",  SqlDbType.VarChar, 50, zcMain.Qlfs),
                                data.MakeInParam("@qlrq",  SqlDbType.DateTime, 8, zcMain.Qlrq),
                                data.MakeInParam("@pzr",  SqlDbType.VarChar, 20, zcMain.Pzr),
                                data.MakeInParam("@memo",  SqlDbType.VarChar, 255, zcMain.Memo),
			};
            return (data.RunProc("INSERT INTO tb_zcClear (bh,mc,xh,xxpz,syqk,sybm,bgry,cfdd,qlr,qlfs,qlrq,pzr,memo)" +
            "VALUES (@bh,@mc,@xh,@xxpz,@syqk,@sybm,@bgry,@cfdd,@qlr,@qlfs,@qlrq,@pzr,@memo)", prams));
        }
        #endregion

        #region  �����壭���̶��ʲ���ѯ
        public DataSet GetDataSetBaseZcMain_mc(string mc)
        {
            return data.RunProcReturn("select * from tb_zcMain where mc='" + mc + "'", "tb_BaseZcmc");
        }

        public DataSet GetDataSetBaseZcMain_zclb(string zclb)
        {
            return data.RunProcReturn("select * from tb_zcMain where zclb='" + zclb + "'", "tb_BaseZcmc");
        }

        public DataSet GetDataSetBaseZcMain_zjfs(string zjfs)
        {
            return data.RunProcReturn("select * from tb_zcMain where zjfs='" + zjfs + "'", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZcMain_sybm(string sybm)
        {
            return data.RunProcReturn("select * from tb_zcMain where sybm='" + sybm + "'", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZcMain_syqk(string syqk)
        {
            return data.RunProcReturn("select * from tb_zcMain where syqk='" + syqk + "'", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZcMain_cfdd(string cfdd)
        {
            return data.RunProcReturn("select * from tb_zcMain where cfdd='" + cfdd + "'", "tb_BaseZcmc");
        }

        public DataSet GetDataSetBaseZcMain_bgry(string bgry)
        {
            return data.RunProcReturn("select * from tb_zcMain where bgry='" + bgry + "'", "tb_BaseZcmc");
        }
        #endregion

        #region �̶��ʲ������ѯ
        /// <summary>
        /// ������й̶��ʲ�
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetzcClear()
        {
            return data.RunProcReturn("select bh as �ʲ����,mc as �ʲ�����,xh as �ʲ��ͺ�, xxpz as ��ϸ����,syqk as ʹ�����,sybm as ʹ�ò���,bgry as ������Ա,cfdd as ��ŵص�,qlr as ������,qlfs as ����ʽ,qlrq as ��������,pzr as ��׼��,memo as ��ע from tb_zcClear","tb_zcClear");
        }
        /// <summary>
        /// ��ѯ�̶��ʲ�������
        /// </summary>
        /// <param name="findType"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public DataSet GetDataSetzcClear(string findType,string content)
        {
            return data.RunProcReturn("select bh as �ʲ����,mc as �ʲ�����,xh as �ʲ��ͺ�, xxpz as ��ϸ����,syqk as ʹ�����,sybm as ʹ�ò���,bgry as ������Ա,cfdd as ��ŵص�,qlr as ������,qlfs as ����ʽ,qlrq as ��������,pzr as ��׼��,memo as ��ע from tb_zcClear where " + findType + " like '%" + content + "%'", "tb_zcClear");
        }
        /// <summary>
        /// ���ݱ��ɾ��ɾ���̶��ʲ�
        /// </summary>
        /// <param name="BH"></param>
        /// <returns></returns>
        public int DeletezcClear(string BH)
        {
            return data.RunProc("delete from tb_zcClear where bh='" + BH + "'");
        }
        #endregion

        #region  �ʲ��۾�
        /// <summary>
        /// ����ʲ�������Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetZcMainSum()
        {
            return data.RunProcReturn("select bh as �ʲ����,mc as �ʲ�����,xh as �ʲ��ͺ�,zjff as �۾ɷ���,rzrq as ��������, sl*dj as �ʲ�ԭֵ, zcjz �ʲ���ֵ,jczl as ����ֵ��,nx as ʹ������,Convert(float(8),null) as �����۾�,null as �ۼ��۾� from tb_zcMain", "tab");
        }
        #endregion

        #region ����Ա����
        /// <summary>
        /// ��ӹ���Ա
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int InsertUser(string userName,string pwd)
        {
            SqlParameter[] prams = { 
                data.MakeInParam("@userName",SqlDbType.VarChar,50,userName),
                data.MakeInParam("@userPwd",SqlDbType.VarChar,50,pwd),
            };
            return data.RunProc("insert into tb_User (username,userpwd) values(@userName,@userPwd)", prams);
        }
        /// <summary>
        /// �޸Ĺ���Ա
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int UpdateUser(string id,string userName, string pwd)
        {
            SqlParameter[] prams = { 
                data.MakeInParam("@userName",SqlDbType.VarChar,50,userName),
                data.MakeInParam("@userPwd",SqlDbType.VarChar,50,pwd),
            };
            return data.RunProc("update tb_User set userName=@userName,userPwd=@userPwd where id=" + id + "", prams);
        }
        /// <summary>
        /// ɾ������Ա
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUser(string id)
        {
            return data.RunProc("delete from tb_user where id=" + id + "");
        }
        /// <summary>
        /// ������й���Ա��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetUser()
        {
            return data.RunProcReturn("select ID as �û�ID,username as �û�����,userpwd as �û����� from tb_user", "tb_user");
        }
        /// <summary>
        /// ����ָ���ģɣĻ�ù���Ա��Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet GetDataSetUser(string id)
        {
            return data.RunProcReturn("select * from tb_user where id='" + id + "'", "tb_user");
        }
        #endregion

        #region  ϵͳ��¼

        public DataSet LoginSystem(string userName,string pwd)
        {
            return data.RunProcReturn("select * from tb_user where userName='" + userName + "'and userpwd='" + pwd + "'","tb_user");
        }

        #endregion

        #region  ���ݿⱸ����ָ�--ϵͳ����
        /// <summary>
        /// ���ݿⱸ��
        /// </summary>
        /// <param name="bakUpName">����·��</param>
        /// <param name="format">�Ƿ��ʽ��</param>
        public void BackUp(string bakUpName,bool format)
        {
            if(format)
                data.RunProc("BACKUP DATABASE db_EquipmentMS TO DISK ='" + bakUpName + "' with format");
            else
                data.RunProc("BACKUP DATABASE db_EquipmentMS TO DISK ='" + bakUpName + "' with noformat");
        }
        /// <summary>
        /// �ָ����ݿ�
        /// </summary>
        /// <param name="reStoreName">ָ���ָ����ݿ�·��</param>
        /// <param name="bakFile">ָ���ָ��ļ�</param>
        public void ReStore(string reStoreName,int  bakFile)
        {
            data.RunProc("use master RESTORE DATABASE db_EquipmentMS from disk='" + reStoreName + "'WITH file = " + bakFile + "");
        }
        /// <summary>
        /// ��ñ���������־
        /// </summary>
        /// <param name="strPath">ָ�������ļ�·��</param>
        /// <returns></returns>
        public DataSet GetBakUp(string strPath)
        {
            return data.RunProcReturn("restore headeronly from disk='" + strPath + "'", "headeronly");
        }
        #endregion
    }

    #region���̶��ʲ�ʵ����
    public class cZcMain
    {
        private string bh="";
        private string mc="";
        private string xh="";
        private string zclb="";
        private string xxpz = "";
        private string gjbh = "";
        private string sccj = "";
        private DateTime ccrq = DateTime.Now;
        private string zjfs = "";
        private string sybm = "";
        private string syqk = "";
        private string cfdd = "";
        private string bgry = "";
        private DateTime rzrq = DateTime.Now;
        private int sl = 0;
        private string dw = "";
        private float dj = 0;
        private float yz = 0;
        private float ljzj = 0;
        private float jz = 0;
        private float jczl = 0;
        private string zjff = "";
        private int nx = 0;
        private DateTime login = DateTime.Now;
        private DateTime gxrq = DateTime.Now;
        private string loginer = "";
        private string tm = "";
        private string xlh = "";
        private string brand = "";
        /// <summary>
        /// ID
        /// </summary>
        public string BH
        {
            get { return bh; }
            set { bh = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string MC
        {
            get { return mc; }
            set { mc = value; }
        }
        ///<summary>
        /// �l�a
        /// </summary>
        public string Tm
        {
            get
            {
                return tm;
            }
            set
            {
                tm = value;
            }
        }
        ///<summary>
        /// ����̖
        /// </summary>
        public string Xlh
        {
            get
            {
                return xlh;
            }
            set
            {
                xlh = value;
            }
        }
        ///<summary>
        /// Ʒ��
        /// </summary>
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        /// <summary>
        /// �ͺ�
        /// </summary>
        public string XH
        {
            get { return xh; }
            set { xh = value; }
        }
        /// <summary>
        /// �ʲ��б�
        /// </summary>
        public string Zclb
        {
            get { return zclb; }
            set { zclb = value; }
        }
        /// <summary>
        /// ��ϸ����
        /// </summary>
        public string Xxpz
        {
            get { return xxpz; }
            set { xxpz = value; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public string Gjbh
        {
            get { return gjbh; }
            set { gjbh = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime Ccrq
        {
            get { return ccrq; }
            set { ccrq = value; }
        }
        ///<summary>
        /// ��������
        /// </summary>
        public DateTime Gxrq
        {
            get { return gxrq; }
            set { gxrq = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Sccj
        {
            get { return sccj; }
            set { sccj = value; }
        }
        /// <summary>
        /// ���ӷ�ʽ
        /// </summary>
        public string Zjfs
        {
            get { return zjfs; }
            set { zjfs = value; }
        }
        /// <summary>
        /// ʹ�ò���
        /// </summary>
        public string Sybm
        {
            get { return sybm; }
            set { sybm = value; }
        }
        /// <summary>
        /// ʹ�����
        /// </summary>
        public string Syqk
        {
            get { return syqk; }
            set { syqk = value; }
        }
        /// <summary>
        /// ��ŵص�
        /// </summary>
        public string Cfdd
        {
            get { return cfdd; }
            set { cfdd = value; }
        }
        /// <summary>
        /// ������Ա
        /// </summary>
        public string Bgry
        {
            get { return bgry; }
            set { bgry = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime Rzrq
        {
            get { return rzrq; }
            set { rzrq = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int SL
        {
            get { return sl; }
            set { sl = value; }
        }
        /// <summary>
        /// ��λ
        /// </summary>
        public string DW
        {
            get { return dw; }
            set { dw = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public float DJ
        {
            get { return dj; }
            set { dj = value; }
        }
        /// <summary>
        /// ԭֵ
        /// </summary>
        public float YZ
        {
            get { return yz; }
            set { yz = value; }
        }
        /// <summary>
        /// �ۼ��۾�
        /// </summary>
        public float Ljzj
        {
            get { return ljzj; }
            set { ljzj = value; }
        }
        /// <summary>
        /// ��ֵ
        /// </summary>
        public float JZ
        {
            get { return jz; }
            set { jz = value; }
        }
        /// <summary>
        /// ����ֵ��
        /// </summary>
        public float Jczl
        {
            get { return jczl; }
            set { jczl = value; }
        }
        /// <summary>
        /// �۾ɷ���
        /// </summary>
        public string Zjff
        {
            get { return zjff; }
            set { zjff = value; }
        }
        /// <summary>
        /// ʹ������
        /// </summary>
        public int Nx
        {
            get { return nx; }
            set { nx = value; }
        }
        /// <summary>
        /// �Ǽ�����
        /// </summary>
        public DateTime Login
        {
            get { return login; }
            set { login = value; }
        }
       
        /// <summary>
        /// �Ǽ���
        /// </summary>
        public string Loginer
        {
            get { return loginer; }
            set { loginer = value; }
        }
        private string qlr = "";
        private string qlfs = "";
        private DateTime qlrq = DateTime.Now;
        private string memo = "";
        private string pzr = "";
        /// <summary>
        /// ������
        /// </summary>
        public string Qlr
        {
            get { return qlr; }
            set { qlr = value; }
        }
        /// <summary>
        /// ����ʽ
        /// </summary>
        public string Qlfs
        {
            get { return qlfs; }
            set { qlfs = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime Qlrq
        {
            get { return qlrq; }
            set { qlrq = value; }
        }
        /// <summary>
        /// ��׼��
        /// </summary>
        public string Pzr
        {
            get { return pzr; }
            set { pzr = value; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }
    #endregion
}
