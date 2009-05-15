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
namespace GoldTradeNaming.Web.goldtrade_db_admin
{
    public partial class Show : System.Web.UI.Page
    {
        private GridViewRow editrow = null;

        public GridViewRow Editrow
        {
            get { return editrow; }
            set { editrow = value; }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "�鿴����Ա";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "��û��Ȩ�޻��¼��ʱ��\\n�����µ�¼�������Ա��ϵ", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewAdmin.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "��û��Ȩ�޲����ù��ܣ�\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                //������ͼȡ�ñ����״̬�����Ϊ�ս���ҳ�棬����Ϊ����
                try
                {
                    this.hdnAdminID.Value = Request.QueryString["admin_id"].ToString();
                }
                catch
                {
                    this.hdnAdminID.Value = "";
                }
                try
                {
                    this.hdnAdminNm.Value = Request.QueryString["admin_name"].ToString();
                }
                catch
                {
                    this.hdnAdminNm.Value = "";
                }
                this.txt_sysadmin_id.Attributes.Add("onkeypress", "this.value   =   this.value.replace(/[^0-9]/,'')");

                LoadData();
            }
        }

        private void LoadData()
        {
            StringBuilder strWhere = new StringBuilder();

            //������ݱ����״ֵ̬��ѯ
            if (this.hdnAdminID.Value == "")
            {
                strWhere.Append("1=1");
            }
            else
            {
                strWhere.Append("sys_admin_id = '");
                strWhere.Append(this.hdnAdminID.Value);
                strWhere.Append("'");
            }
            if (this.hdnAdminNm.Value == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND sys_admin_name = '");
                strWhere.Append(this.hdnAdminNm.Value);
                strWhere.Append("'");
            }

            try
            {
                GoldTradeNaming.BLL.goldtrade_db_admin bll = new GoldTradeNaming.BLL.goldtrade_db_admin();
                Session["grd_Data"] = bll.GetList(strWhere.ToString());
                this.grd_AdminInfo.DataSource = Session["grd_Data"] as DataSet;
                this.grd_AdminInfo.DataBind();
            }
            catch
            {
                MessageBox.Show(this, "��ѯ����");
            }
        }

        protected void btnQry_Click(object sender, EventArgs e)
        {
            //�����ѯ����
            this.hdnAdminID.Value = this.txt_sysadmin_id.Text.Trim();
            this.hdnAdminNm.Value = this.txtsys_admin_name.Text.Trim();
            LoadData();
        }

        protected void grd_AdminInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grd_AdminInfo.PageIndex = e.NewPageIndex;
            this.grd_AdminInfo.DataSource = Session["grd_Data"] as DataSet ;
            this.grd_AdminInfo.DataBind();
        }

        protected void Reset1_Click1(object sender, EventArgs e)
        {
            this.txt_sysadmin_id.Text = "";
            this.txtsys_admin_name.Text = "";
        }

        //������������ʱ���Ѳ�ѯ��������ȥ
        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/goldtrade_db_admin/Add2.aspx?admin_id=" + this.hdnAdminID.Value +"&admin_name="+this.hdnAdminNm.Value);
        }
    }
}
