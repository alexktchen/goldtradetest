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
using GoldTradeNaming.Web.Controls;
using GoldTradeNaming.Web.goldtrade_db_admin;
namespace GoldTradeNaming.Web.goldtrade_IA100
{
    public partial class Add : System.Web.UI.Page
    {
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
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.AddIA.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "��û��Ȩ�޲����ù��ܣ�\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "�����֤��";
            //(Master.FindControl("CheckRight1") as CheckRight).Visible = false;
            //(Master.FindControl("CopyRight1") as CopyRight1).Visible = false;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtIA100Key.Text == "")
            {
                strErr += "IA100Key����Ϊ�գ�\\n";
            }
            if (this.txtIA100SuperPswd.Text == "")
            {
                strErr += "IA100SuperPswd����Ϊ�գ�\\n";
            }
            if (this.txtIA100Key.Text.Length != 32)
            {
                strErr += "��֤����Կ����ȷ��\\n";
            }
            if (this.txtIA100SuperPswd.Text.Length != 32)
            {
                strErr += "��֤���������벻��ȷ������\\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string IA100Guid = this.txtIA100GUID.Text;
            string IA100Key = this.txtIA100Key.Text;
            string IA100SuperPswd = this.txtIA100SuperPswd.Text;
            string IA100State = "0";
            string StateChangeReason = "������";

            GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.Model.goldtrade_IA100();
            try
            {
                model.IA100GUID = new Guid(IA100Guid);
            }
            catch
            {
                MessageBox.Show(this, "IA100GUID����ȷ������");
                return;
            }
            model.IA100Key = IA100Key;
            model.IA100SuperPswd = IA100SuperPswd;
            model.IA100State = IA100State;
            model.StateChangeReason = StateChangeReason;
            try
            {

                GoldTradeNaming.BLL.goldtrade_IA100 bll = new GoldTradeNaming.BLL.goldtrade_IA100();
                if (bll.Exists(model.IA100GUID))
                {
                    MessageBox.Show(this, "��¼�Ѵ��ڣ�");
                    return;
                }
                bll.Add(model);
                MessageBox.ShowAndRedirect(this, goldtrade_db_adminRes.strAddSuccess, "Show.aspx");
                //Response.Write("<script language=\"javascript\"> alert('" + goldtrade_db_adminRes.strAddSuccess + "');</script>");

            }
            catch
            {
                //if(ex.Number==2601)
                MessageBox.Show(this, "���ʱ����");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtIA100GUID.Text = "";
            this.txtIA100Key.Text = "";
            this.txtIA100SuperPswd.Text = "";
        }

    }
}
