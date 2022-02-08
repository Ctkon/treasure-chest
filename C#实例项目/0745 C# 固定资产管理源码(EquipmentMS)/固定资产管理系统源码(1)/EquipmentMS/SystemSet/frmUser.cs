using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.SystemSet
{
    public partial class frmUser : Form
    {
        EquipmentMS.BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public frmUser()
        {
            InitializeComponent();
        }

        private void tlbtnAdd_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPwd.Text = "";
            groupBox1.Enabled = true;
            tlbtnAdd.Enabled = true;
            tlbtnUpdate.Enabled = false;
            tlbtnDelete.Enabled = false;
            tlbtnSave.Enabled = true;
            tlbtnCancle.Enabled = true;
        }

        private void tlbtnCancle_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            tlbtnAdd.Enabled = true;
            tlbtnUpdate.Enabled = true;
            tlbtnDelete.Enabled = true;
            tlbtnSave.Enabled = true;
            tlbtnCancle.Enabled = false;
        }

        private void tlbtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("��ѡ�����Ա��Ϣ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                groupBox1.Enabled = true;
                tlbtnAdd.Enabled = false;
                tlbtnUpdate.Enabled = true;
                tlbtnDelete.Enabled = false;
                tlbtnSave.Enabled = true;
                tlbtnCancle.Enabled = true;
            }
        }

        private void tlbtnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("ϵͳ����Ա����Ϊ�գ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }
            if (tlbtnAdd.Enabled && groupBox1.Enabled)
            {
                oper.InsertUser(txtUserName.Text, txtPwd.Text);
                MessageBox.Show("�²���Ա��ӳɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (tlbtnUpdate.Enabled && groupBox1.Enabled)
            {
                oper.UpdateUser(dgvUser.SelectedCells[0].Value.ToString(), txtUserName.Text, txtPwd.Text);
                MessageBox.Show("�޸Ĳ�����Ϣ�ɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            groupBox1.Enabled = false;
            tlbtnAdd.Enabled = true;
            tlbtnUpdate.Enabled = true;
            tlbtnDelete.Enabled = true;
            tlbtnSave.Enabled = true;
            tlbtnCancle.Enabled = false;
            txtUserName.Text = "";
            txtPwd.Text = "";
            dgvUser.DataSource = oper.GetDataSetUser().Tables[0].DefaultView;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            dgvUser.DataSource = oper.GetDataSetUser().Tables[0].DefaultView ;
        }

        private void dgvUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtUserName.Text = dgvUser[1, e.RowIndex].Value.ToString();
            txtPwd.Text = dgvUser[2, e.RowIndex].Value.ToString();
        }

        private void tlbtnDelete_Click(object sender, EventArgs e)
        {
            int i = oper.DeleteUser(dgvUser.SelectedCells[0].Value.ToString());
            MessageBox.Show("�����û�ɾ���ɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvUser.DataSource = oper.GetDataSetUser().Tables[0].DefaultView;
        }
    }
}