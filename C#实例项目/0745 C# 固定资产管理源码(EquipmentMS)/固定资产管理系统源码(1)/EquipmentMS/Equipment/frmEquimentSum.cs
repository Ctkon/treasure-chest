using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Internal.Performance;

namespace EquipmentMS.Equipment
{
    public partial class frmEquimentSum : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public frmEquimentSum()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!oper.ExportDataGridview(dgvEquiment, true))
                MessageBox.Show("����Л]���Y�ϣ��o�������Y�ϣ�", "ϵ�y��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmEquimentSum_Load(object sender, EventArgs e)
        {
            this.SumZC();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEquimentSum_Resize(object sender, EventArgs e)
        {
            dgvEquiment.Height = this.Height - 80;
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            this.SumZC();
        }

        private void SumZC()
        {
            DataSet ds = oper.GetDataSetZcMainSum();
            dgvEquiment.DataSource = ds.Tables[0].DefaultView;
            DateTime rzrq = DateTime.Now;
            float zcyz = 0;
            float jczl = 0;
            int synx = 0;
            float yzjl = 0;
            TimeSpan ts = new TimeSpan();
            for (int i = 0; i < dgvEquiment.Rows.Count - 1; i++)
            {
                //����ֵ��
                jczl = Convert.ToSingle(Convert.ToSingle(dgvEquiment[7, i].Value) * 0.01);
                //�ʲ�ԭֵ
                zcyz = Convert.ToSingle(dgvEquiment[6, i].Value);
                //ʹ������
                synx = Convert.ToInt32(dgvEquiment[8, i].Value.ToString());
                //��������
                rzrq = Convert.ToDateTime(dgvEquiment[4, i].Value);
                yzjl = ((1 - jczl) / synx) / 12;
                //�������۾ɶ�
                dgvEquiment[9, i].Value = Convert.ToSingle(zcyz * yzjl);
                ts = dtpZjrq.Value - rzrq;
                //�����ۼ��۾�
                dgvEquiment[10, i].Value = Convert.ToSingle(zcyz * yzjl) * (ts.Days / 30);
                //���㾻ֵ
                try
                {
                    dgvEquiment[6, i].Value = Convert.ToSingle(dgvEquiment[5, i].Value) - Convert.ToSingle(dgvEquiment[10, i].Value);
                }
                catch { }
            }
        }
    }
}