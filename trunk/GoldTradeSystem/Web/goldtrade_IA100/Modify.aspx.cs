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
namespace GoldTradeNaming.Web.goldtrade_IA100
{
    public partial class Modify : System.Web.UI.Page
    {

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "�޸���֤��";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == ""
                     || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.SearchIA.ToString())
                    
                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "��û��Ȩ�޵�¼��ϵͳ��\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                
                btnAdd.Attributes.Add("onclick", "return confirm('" + "�_��Ҫ�ύ?" + "')");
                //Modify.aspx?guid={0}&amp;key={1}&amp;spwsd={2}&amp;state={3}&amp;rsn={4}"
                this.lblIA100GUID.Text = Request.QueryString["guid"].ToString();
                this.txtIA100Key.Text = Request.QueryString["key"].ToString();
                //this.txtIA100State.Text = Request.QueryString["state"].ToString();
                this.txtIA100SuperPswd.Text = Request.QueryString["spwsd"].ToString();
                this.txtStateChangeReason.Text = Request.QueryString["rsn"].ToString();
            }
        }

        private void ShowInfo(Guid IA100GUID)
        {
            GoldTradeNaming.BLL.goldtrade_IA100 bll = new GoldTradeNaming.BLL.goldtrade_IA100();
            GoldTradeNaming.Model.goldtrade_IA100 model = bll.GetModel(IA100GUID);
            this.lblIA100GUID.Text = model.IA100GUID.ToString();
            this.txtIA100Key.Text = model.IA100Key;
            this.txtIA100SuperPswd.Text = model.IA100SuperPswd;
            //this.txtIA100State.Text = model.IA100State;
            this.txtStateChangeReason.Text = model.StateChangeReason;

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
            if (this.txtStateChangeReason.Text == "")
            {
                strErr += "StateChangeReason����Ϊ�գ�\\n";
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
            string IA100Key = this.txtIA100Key.Text;
            string IA100SuperPswd = this.txtIA100SuperPswd.Text;
            string IA100State = this.lstIA100_State.SelectedValue;
            string StateChangeReason = this.txtStateChangeReason.Text;

            try
            {
                GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.Model.goldtrade_IA100();
                model.IA100GUID = new Guid(this.lblIA100GUID.Text.Trim());
                model.IA100Key = IA100Key;
                model.IA100SuperPswd = IA100SuperPswd;
                model.IA100State = IA100State;
                model.StateChangeReason = StateChangeReason;

                GoldTradeNaming.BLL.goldtrade_IA100 bll = new GoldTradeNaming.BLL.goldtrade_IA100();
                bll.Update(model);
                MessageBox.ShowAndRedirect(this, "�޸ĳɹ���", "Show.aspx");
                //MessageBox.Show(this,"�޸ĳɹ���");
            }
            catch
            {
                MessageBox.Show(this, "�޸Ĺ��̳���");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
           // MessageBox.ShowConfirm(this, "ȷ�ϲ�����͹ر���");
        }

    }
}
