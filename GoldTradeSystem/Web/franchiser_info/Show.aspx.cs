using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using LTP.Common;

namespace GoldTradeNaming.Web.franchiser_info
{
    public partial class Show:System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();

        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "�޸ľ�����";
        }
        protected void Page_Load(object sender,EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "��û��Ȩ�޻��¼��ʱ��\\n�����µ�¼�������Ա��ϵ", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                   || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ChgFran.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "��û��Ȩ�޲����ù��ܣ�\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                Response.End();
                return;
            } 

            if(!Page.IsPostBack)
            {               
                DataSet ds = SearchFranchiserInfo();
                if(ds != null)
                {
                    gvList.DataSource = ds;
                    gvList.DataBind();
                    Session["gvList"] = ds;
                }

                plShow.Style.Add("display","none");
                plSource.Style.Add("display","block");
                btnSave.Style.Add("display","none");
                btSave.Attributes.Add("onclick","if(typeof(SaveCase)=='function') SaveCase();return false;");//����ǰ��C   
            }
        }


        protected void gvList_SelectedIndexChanged(object sender,EventArgs e)
        {
            plShow.Style.Add("display","block");
            plSource.Style.Add("display","none");
            franchiser_code.Enabled = false;
            GridViewRow gvw = this.gvList.SelectedRow;
            this.franchiser_code.Text = gvw.Cells[0].Text.Trim();
            this.IA100.Text = gvw.Cells[1].Text.Replace("-","").Trim();
            this.txtIA100.Text = gvw.Cells[1].Text.Replace("-","").Trim();
            this.franchiser_name.Text = gvw.Cells[2].Text.Trim();
            this.franchiser_asure_money.Text = gvw.Cells[4].Text.Trim();
            this.franchiser_tel.Text = gvw.Cells[5].Text.Trim();
            this.franchiser_cellphone.Text = gvw.Cells[6].Text.Trim();
            this.franchiser_address.Text = gvw.Cells[7].Text.Trim();
        }

        protected void btnSave_Click(object sender,EventArgs e)
        {
            if(!CheckTextValue())
                return;

            if(UpdateInfo())
            {
                MessageBox.ShowAndRedirect(this,"����ɹ�...","../franchiser_info/show.aspx");
            }
            else
            {
                MessageBox.Show(this,"����ʧ��");
            }
        }

        protected void btnCancel_Click(object sender,EventArgs e)
        {
            gvList.SelectedIndex = -1;
            plShow.Style.Add("display","none");
            plSource.Style.Add("display","block");
        }



        protected void btnReNew_Click(object sender,EventArgs e)
        {
            txtfranchiser_code.Text = "";
            txtfranchiser_name.Text = "";
            gvList.SelectedIndex = -1;
            lblQueryMsg.Text = "";
            // plShow.Style.Add("display","none");
        }

        protected void btnQuery_Click(object sender,EventArgs e)
        {
            DataSet ds = SearchFranchiserInfo();

            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblQueryMsg.Text = "��ѯ�ɹ�";
                //   MessageBox.Show(this,"��ѯ�ɹ�");
            }
            else
                lblQueryMsg.Text = "���޼�¼";
            //  MessageBox.Show(this,"���޼�¼");

            Session["gvList"] = ds;
            this.gvList.DataSource = ds;
            this.gvList.DataBind();
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <returns></returns>
        private DataSet SearchFranchiserInfo()
        {

            StringBuilder strWhere = new StringBuilder();

            if(this.txtfranchiser_code.Text.Trim() == "")
            {
                strWhere.Append("1=1");
            }
            else
            {
                strWhere.Append("franchiser_code like N'%");
                strWhere.Append(this.txtfranchiser_code.Text.Trim());
                strWhere.Append("%'");
            }
            if(this.txtfranchiser_name.Text.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND franchiser_name like N%'");
                strWhere.Append(this.txtfranchiser_name.Text.Trim());
                strWhere.Append("%'");
            }
            return bll.GetList(strWhere.ToString());
        }

        /// <summary>
        /// ���ҳ��ֵ 
        /// </summary>
        /// <returns></returns>
        private bool CheckTextValue()
        {
            string strErr = "";
            int iFranchiser_code;
            try
            {
                iFranchiser_code = Convert.ToInt32(franchiser_code.Text.Trim());
            }
            catch
            {
                iFranchiser_code = -1;
                strErr += "�����̱������";
            }
            if(this.franchiser_name.Text == "")
            {
                strErr += "���������ֲ���Ϊ�գ�";
            }
            else
            {
                if(bll.Exists(iFranchiser_code,franchiser_name.Text.Trim()))
                {
                    strErr += "�����������Ѵ��ڣ�";
                }
            }
            //if(!PageValidate.IsDecimal(franchiser_balance_money.Text))
            //{
            //    strErr += "�����������֣�";
            //}
            if(!PageValidate.IsDecimal(franchiser_asure_money.Text))
            {
                strErr += "����������֣�";
            }
            if(this.franchiser_tel.Text == "")
            {
                strErr += "��������������Ϊ�գ�";
            }
            if(this.franchiser_cellphone.Text == "")
            {
                strErr += "�������ֻ�����Ϊ�գ�";
            }
            if(this.franchiser_address.Text == "")
            {
                strErr += "�����̵�ַ����Ϊ�գ�";
            }
            Guid guid = new Guid();
            try
            {
                guid = new Guid(this.IA100.Text);

                if(bll.Exists(iFranchiser_code,guid))
                {
                    strErr += "����֤���ѱ�������ռ�ã�";
                }

            }
            catch
            {
                strErr += "��֤��ID�������";

            }
            if(!bll100.Exists(guid))
            {
                strErr += "��֤��IDδע�ᣡ";
            }

            lblMsg.Text = strErr;

            if(strErr == "")
                return true;
            else
                return false;
        }



        private bool UpdateInfo()
        {
            try
            {
                int franchiser_code = Convert.ToInt32(this.franchiser_code.Text);
                string franchiser_name = this.franchiser_name.Text;
                //    decimal franchiser_balance_money = decimal.Parse(this.franchiser_balance_money.Text);
                decimal franchiser_asure_money = decimal.Parse(this.franchiser_asure_money.Text);
                string franchiser_tel = this.franchiser_tel.Text;
                string franchiser_cellphone = this.franchiser_cellphone.Text;
                string franchiser_address = this.franchiser_address.Text;
                string IA100GUID = this.IA100.Text;
                GoldTradeNaming.Model.franchiser_info model = new GoldTradeNaming.Model.franchiser_info();
                model.franchiser_code = franchiser_code;
                model.franchiser_name = franchiser_name;
                //  model.franchiser_balance_money = franchiser_balance_money;
                model.franchiser_asure_money = franchiser_asure_money;
                model.franchiser_tel = franchiser_tel;
                model.franchiser_cellphone = franchiser_cellphone;
                model.franchiser_address = franchiser_address;

                model.IA100GUID = new Guid(IA100GUID);
                model.upd_user = Session["admin"].ToString();

                bll.Update(model);


                if(IA100.Text.ToLower().Trim() != txtIA100.Text.ToLower().Trim())
                {
                    Guid oldID = new Guid(txtIA100.Text.ToLower().Trim());
                    //ȥIA100�ı�������ID��״̬��Ϊ1  ԭ��� ���û���+�û�ID+��������֤����
                    string reason = "�û���" + franchiser_name + ",�û�ID��" + franchiser_code + "������֤��";
                    bll.DisableIA(oldID,reason);
                    txtIA100.Text = IA100.Text.Trim();
                }
                else
                {
                    //��ܣ� �Ȳ��ģ�������IA100���ˣ��������������ֱ�ӵ��ҵ������
                }

                DataSet ds = SearchFranchiserInfo();
                Session["gvList"] = ds;
                this.gvList.DataSource = ds;
                this.gvList.DataBind();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.ToString());
                return false;
            }
        }

        protected void gvList_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.gvList.PageIndex = e.NewPageIndex;

            if(Session["gvList"] != null)
            {
                this.gvList.DataSource = Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            else
            {
                Session["gvList"] = SearchFranchiserInfo();
                this.gvList.DataSource = Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            gvList.SelectedIndex = -1;
        }

    





    }
}
