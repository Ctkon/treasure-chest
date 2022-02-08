using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.BaseInfo
{
    public partial class frmBaseInfo : Form
    {
        BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        public frmBaseInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZCMC_Click(object sender, EventArgs e)
        {
            lbName.DataSource = oper.GetDataSetBaseZcmc().Tables[0].DefaultView;
            lbName.DisplayMember = "zcmc";
            lbName.ValueMember = "id";
            labTitle.Text = btnZCMC.Text;
            departVisible(false);
        }
        private void departVisible(bool con)
        {
            this.DepartComboBox.Visible = con;
            this.Departlabel.Visible = con;
            
        }
        private void btnZJFS_Click(object sender, EventArgs e)
        {
            lbName.DataSource = oper.GetDataSetBaseZjfs().Tables[0].DefaultView;
            lbName.DisplayMember = "zjfs";
            lbName.ValueMember = "id";
            labTitle.Text = btnZJFS.Text;
            departVisible(false);
        }

        private void btnSYBM_Click(object sender, EventArgs e)
        {
            lbName.DataSource = oper.GetDataSetBaseSybm().Tables[0].DefaultView;
            lbName.DisplayMember = "sybm";
            lbName.ValueMember = "id";
            labTitle.Text = btnSYBM.Text;
            departVisible(false);
        }

        private void btnSYQK_Click(object sender, EventArgs e)
        {
            lbName.DataSource = oper.GetDataSetBaseSyqk().Tables[0].DefaultView;
            lbName.DisplayMember = "syqk";
            lbName.ValueMember = "id";
            labTitle.Text = btnSYQK.Text;
            departVisible(false);
        }

        private void btnCFDD_Click(object sender, EventArgs e)
        {
            
            this.BindComboBox();
            lbName.DataSource = oper.GetDataSetBaseCfdd().Tables[0].DefaultView;
            lbName.DisplayMember = "cfdd";
            lbName.ValueMember = "id";
            labTitle.Text = btnCFDD.Text;
            departVisible(true);
        }

        private void btnBGRY_Click(object sender, EventArgs e)
        {
            departVisible(true);
            this.BindComboBox();
            lbName.DataSource = oper.GetDataSetBaseBgry().Tables[0].DefaultView;
            lbName.DisplayMember = "bgry";
            lbName.ValueMember = "id";
            labTitle.Text = btnBGRY.Text;
        }

        private void frmBaseInfo_Load(object sender, EventArgs e)
        {
            this.btnZCMC_Click(sender, e);
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }
        private void BindComboBox()
        {
            DepartComboBox.DataSource = oper.GetDataSetBaseSybm().Tables[0].DefaultView;
            DepartComboBox.ValueMember = "sybm";

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Focus();
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text == "")
            {
                MessageBox.Show("�����헲��ܞ�գ�", "ϵ�y��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            else
            {
                switch (labTitle.Text)
                {
                    case "�Y�a���Q":
                        int u = oper.InsertBaseZcmc(txtName.Text);
                        this.btnZCMC_Click(sender, e);
                        break;
                    case "�ʲ�����":
                        int cu = oper.InsertBaseZcmc(txtName.Text);
                        this.btnZCMC_Click(sender, e);
                        break;
                    case "���ӷ�ʽ":
                        int i = oper.InsertBaseZjfs(txtName.Text);
                        this.btnZJFS_Click(sender, e);
                        break;
                    case "ʹ�ò���":
                        int j = oper.InsertBaseSybm(txtName.Text);
                        this.btnSYBM_Click(sender, e);
                        break;
                    case "ʹ�ò��T":
                        int cj = oper.InsertBaseSybm(txtName.Text);
                        this.btnSYBM_Click(sender, e);
                        break;
                    case "ʹ����r":
                        int k = oper.InsertBaseSyqk(txtName.Text);
                        this.btnSYQK_Click(sender, e);
                        break;
                    case "ʹ�����":
                        int ck = oper.InsertBaseSyqk(txtName.Text);
                        this.btnSYQK_Click(sender, e);
                        break;
                    case "��ŵ��c":
                        if (this.DepartComboBox.SelectedItem.ToString() == "")
                        {
                            MessageBox.Show("Ո�x�����ٲ��T!", "ϵ�y��ʾ");
                            this.DepartComboBox.Focus();
                            return;
                        }
                        int p = oper.InsertBaseCfdd(txtName.Text,this.DepartComboBox.SelectedValue.ToString());
                        this.btnCFDD_Click(sender, e);
                        break;
                    case "��ŵص�":
                        if (this.DepartComboBox.SelectedItem.ToString() == "")
                        {
                            MessageBox.Show("��ѡ����������!", "ϵͳ��ʾ");
                            this.DepartComboBox.Focus();
                            return;
                        }
                        int cp = oper.InsertBaseCfdd(txtName.Text, this.DepartComboBox.SelectedValue.ToString());
                        this.btnCFDD_Click(sender, e);
                        break;
                    case "�����ˆT":
                        if (this.DepartComboBox.SelectedItem.ToString() == "")
                        {
                            MessageBox.Show("Ո�x�����ٲ��T!", "ϵ�y��ʾ");
                            this.DepartComboBox.Focus();
                            return;
                        }
                        int o = oper.InsertBaseBgry(txtName.Text,this.DepartComboBox.SelectedValue.ToString());
                        this.btnBGRY_Click(sender, e);
                        break;
                    case "������Ա":
                        if (this.DepartComboBox.SelectedItem.ToString() == "")
                        {
                            MessageBox.Show("��ѡ����������!", "ϵͳ��ʾ");
                            this.DepartComboBox.Focus();
                            return;
                        }
                        int co = oper.InsertBaseBgry(txtName.Text, this.DepartComboBox.SelectedValue.ToString());
                        this.btnBGRY_Click(sender, e);
                        break;
                    case "Ӌ����λ":
                        int m = oper.InsertBaseJldw(txtName.Text);
                        this.btnJLDW_Click(sender, e);
                        break;
                    case "������λ":
                        int cm = oper.InsertBaseJldw(txtName.Text);
                        this.btnJLDW_Click(sender, e);
                        break;
                    //case "����ʽ":
                    case "Ʒ�ƹ���":
                        int l = oper.InsertBaseBrand(txtName.Text);
                        this.btnQLFS_Click(sender, e);
                        break;
                   
                }
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            switch (labTitle.Text)
                {
                    case "�Y�a���Q":
                        int u = oper.DeleteBaseZcmc(lbName.SelectedValue.ToString());
                        this.btnZCMC_Click(sender, e);
                        break;
                    case "�ʲ�����":
                        int cu = oper.DeleteBaseZcmc(lbName.SelectedValue.ToString());
                        this.btnZCMC_Click(sender, e);
                        break;
                    case "���ӷ�ʽ":
                        int i = oper.DeleteBaseZjfs(lbName.SelectedValue.ToString());
                        this.btnZJFS_Click(sender, e);
                        break;
                    case "ʹ�ò��T":
                        int j = oper.DeleteBaseSybm(lbName.SelectedValue.ToString());
                        this.btnSYBM_Click(sender, e);
                        break;
                    case "ʹ�ò���":
                        int cj = oper.DeleteBaseSybm(lbName.SelectedValue.ToString());
                        this.btnSYBM_Click(sender, e);
                        break;
                    case "ʹ����r":
                        int k = oper.DeleteBaseSyqk(lbName.SelectedValue.ToString());
                        this.btnSYQK_Click(sender, e);
                        break;
                    case "ʹ�����":
                        int ck = oper.DeleteBaseSyqk(lbName.SelectedValue.ToString());
                        this.btnSYQK_Click(sender, e);
                        break;
                    case "��ŵ��c":
                        int cp = oper.DeleteBaseCfdd(lbName.SelectedValue.ToString());
                        this.btnCFDD_Click(sender, e);
                        break;
                    case "��ŵص�":
                        int p = oper.DeleteBaseCfdd(lbName.SelectedValue.ToString());
                        this.btnCFDD_Click(sender, e);
                        break;
                    case "�����ˆT":
                        int o = oper.DeleteBaseBgry(lbName.SelectedValue.ToString());
                        this.btnBGRY_Click(sender, e);
                        break;
                    case "������Ա":
                        int co = oper.DeleteBaseBgry(lbName.SelectedValue.ToString());
                        this.btnBGRY_Click(sender, e);
                        break;
                    case "Ӌ����λ":
                        int l = oper.DeleteBaseJldw(lbName.SelectedValue.ToString());
                        this.btnJLDW_Click(sender, e);
                        break;
                    case "������λ":
                        int cl = oper.DeleteBaseJldw(lbName.SelectedValue.ToString());
                        this.btnJLDW_Click(sender, e);
                        break;
                    case "Ʒ�ƹ���":
                        if (lbName.SelectedValue.ToString() != "")
                        {
                            DialogResult dialog = MessageBox.Show("�_�Jɾ��Ʒ��" + lbName.Text.ToString() + "��?", "��ʾ", MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.Yes)
                            {
                                int m = oper.DeleteBaseBrand(lbName.SelectedValue.ToString());
                                this.btnQLFS_Click(sender, e);
                                
                            }
                            else
                            {
                                MessageBox.Show("��ȡ��" + lbName.Text.ToString() + "��ɾ������!", "��ʾ");
                                
                            }
                        }
                        break;
                                           
                }
        }

        private void btnJLDW_Click(object sender, EventArgs e)
        {
            lbName.DataSource = oper.GetDataSetBaseJldw().Tables[0].DefaultView;
            lbName.DisplayMember = "jldw";
            lbName.ValueMember = "id";
            labTitle.Text = btnJLDW.Text;
            this.departVisible(false);
        }

        private void btnQLFS_Click(object sender, EventArgs e)
        {
            lbName.DataSource = oper.GetDataSetBaseBrand().Tables[0].DefaultView;
            lbName.DisplayMember = "BrandName";
            lbName.ValueMember = "id";
            labTitle.Text = btnQLFS.Text;
            this.departVisible(false);
        }
      
    }
}