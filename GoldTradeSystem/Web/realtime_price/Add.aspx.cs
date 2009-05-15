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
using System.Drawing;
namespace GoldTradeNaming.Web.realtime_price
{
    public partial class Add:System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.realtime_price bll = new GoldTradeNaming.BLL.realtime_price();
        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "更改实时金价";
        }

        protected void Page_Load(object sender,EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ChgPrice.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if(!Page.IsPostBack)
            {
                getPrice();
            }
        }


        protected void btnAdd_Click(object sender,EventArgs e)
        {
            try
            {
                string strErr = "";
                if(!PageValidate.IsDecimal(txtrealtime_base_price.Text))
                {
                    strErr += "实时价格不是数字！\\n";
                }


                if(Session["admin"] == null || !PageValidate.IsNumber(Session["admin"].ToString().Trim()))
                {
                    strErr += "管理员帐号异常！\\n";
                }

                if(strErr != "")
                {
                    MessageBox.Show(this,strErr);
                    return;
                }
                decimal realtime_base_price = decimal.Parse(this.txtrealtime_base_price.Text);

                int sys_admin_id = int.Parse(Session["admin"].ToString().Trim());

                string ins_user = Session["admin"].ToString().Trim();
                string upd_user = "";

                GoldTradeNaming.Model.realtime_price model = new GoldTradeNaming.Model.realtime_price();
                model.realtime_base_price = realtime_base_price;
                model.sys_admin_id = sys_admin_id;
                model.ins_user = ins_user;
                model.upd_user = upd_user;

                GoldTradeNaming.BLL.realtime_price bll = new GoldTradeNaming.BLL.realtime_price();
                bll.Add(model);
                MessageBox.ShowAndRedirect(this,"修改成功...","../realtime_price/Show.aspx");
            }
            catch
            {
                MessageBox.Show(this,"修改过程出错！");
            }
        }

        private void getPrice()
        {
            try
            {
                DataSet ds = bll.getCurrentPrice();
                if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtrealtime_base_price.Text = ds.Tables[0].Rows[0]["realtime_base_price"].ToString().Trim();
                }
            }
            catch
            {
                MessageBox.Show(this,"读取最新价格错误");
            }

        }
    }
}
