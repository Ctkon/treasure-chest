using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquipmentMS.BaseInfo
{
    public partial class frmBaseSort : Form
    {
        BaseClass.Operation oper = new EquipmentMS.BaseClass.Operation();
        int zclbID = 0;
        public frmBaseSort()
        {
            InitializeComponent();
        }

        private void frmBaseSort_Load(object sender, EventArgs e)
        {
            this.FillTreeView();
        }
        private void FillTreeView()
        {
            trvFile.Nodes.Clear();
            //����TreeView�ؼ��Ĳ˵���
            DataSet ds = null;
            ds = oper.TreeFill();
            TreeNode RootNode = null;
            DataTable dt = ds.Tables[0].Copy();     //���ʲ��б����һ��Ϊdt
            DataView dv = new DataView(dt);
            dv.RowFilter = "firstID = -1";
            //�����ݼ��е����м�¼�����������֮��Ĺ�ϵ��ӵ����α���ȥ
            if (dv.Count > 0)
            {
                foreach (DataRowView myRow in dv)
                {
                    //���ø��ڵ�,Ȼ��ú�����ݹ���������ӽڵ㡣
                    trvFile.Nodes.Add(RootNode = new TreeNode(myRow["zclb"].ToString()));
                    childTreeView(myRow["zclb"].ToString(), trvFile.Nodes[0], myRow);
                    trvFile.SelectedNode = trvFile.Nodes[0]; //ѡ�е�һ���ڵ� 
                }
            }
            trvFile.ExpandAll();
        }
        private void childTreeView(string childPart, TreeNode childNode, DataRowView childRow)
        {
            string strdeptName = "";
            DataSet ds = null;
            ds = oper.TreeFill();
            DataTable dt = ds.Tables[0].Copy();
            DataView dv = new DataView(dt);
            //ɸѡ��õ�ǰ���ݹ����Ľڵ�������������ӵ�����ͼ��
            //�жϷ����Ƿ�parentIndex���ڴ��ݹ����Ľڵ��absIndex�ģ����Ǹýڵ������
            dv.RowFilter = "firstID = '" + childRow["secondID"].ToString() + "'";
            //�ݹ�����ÿһ���ڵ�������ӽڵ�
            foreach (DataRowView myRow in dv)
            {
                strdeptName = myRow["zclb"].ToString();
                TreeNode myNode = new TreeNode(strdeptName);
                childNode.Nodes.Add(myNode);
                //�����ݹ���ã������нڵ㰴˳��������
                childTreeView(strdeptName, myNode, myRow);
            }
        }

        private void trvFile_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DataSet ds = oper.GetDataSetBaseZclb(e.Node.Text);
                zclbID = Convert.ToInt16(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            catch
            { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            DataSet ds = oper.GetDataSetBaseZclb(trvFile.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                trvFile.LabelEdit = true;������//������ǩ�༭
                trvFile.SelectedNode.BeginEdit();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataSetBaseZclb(trvFile.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                string firstID = ds.Tables[0].Rows[0]["firstID"].ToString();
                int d = oper.insertBaseZclb(firstID, "�½��Ŀ", (Convert.ToInt16(firstID) + 1).ToString());
                this.trvFile.SelectedNode.Parent.Nodes.Add("�½��Ŀ");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetDataSetBaseZclb(trvFile.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                oper.deleteBaseZclb(Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString()));
                MessageBox.Show("�h���ɹ���", "ϵ�y��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FillTreeView();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oper.UpdateBaseZclb(zclbID, trvFile.SelectedNode.Text);
            this.FillTreeView();
            trvFile.LabelEdit = false;����//�رձ�ǩ�༭
        }
    }
}