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
namespace GoldTradeNaming.Web.franchiser_money
{
    public partial class Show : System.Web.UI.Page
    {

        private readonly GoldTradeNaming.BLL.franchiser_money bll = new GoldTradeNaming.BLL.franchiser_money();
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "查看入帐";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //Session["admin"] = "f3221177";
            //Session["MoneyM"] = "f3221177";
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewAddMoney.ToString()))
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }


                databind();
            }
          
        }

        protected void query_Click(object sender, EventArgs e)
        {

            databind();


        }

        public void databind() {


            showDate.DataSource = null;
            showDate.Visible = false;
            Session["data"] = null;
            string fran_id = txtfran_id.Text.Trim();
            string add_money = txtadd_money.Text.Trim();
            string time_from = txttime_from.Text.Trim();
            string time_to = txtTime_to.Text.Trim();
            string check = drpIsCheck.Text.Trim();
            string strErr = "";
            if (!PageValidate.IsNumber(fran_id) && fran_id != "")
            {
                strErr += "franchiser_code不是数字！\\n";
            }
            if (!PageValidate.IsDecimal(add_money) && add_money != "")
            {
                strErr += "franchiser_added_money不是数字！\\n";
            }
            if (!PageValidate.IsDateTime(time_from) && time_from != "")
            {
                strErr += "added_time起始时间不是时间格式！\\n";
            }
            if (!PageValidate.IsDateTime(time_to) && time_to != "")
            {
                strErr += "added_time终止时间不是时间格式！\\n";
            }


            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                showDate.Visible = false;
                return;
            }

            try
            {
                DataSet ds = bll.queryAction(fran_id, add_money, time_from, time_to, check);
                Session["data"] = ds;
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                    showDate.Visible = false;
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row["checked"].ToString().Trim() == "0")
                        {
                            row["checked"] = "已审核";
                        }
                        else
                        {
                            row["checked"] = "未审核";
                        }
                    }
                    showDate.PageIndex = 0;
                    showDate.DataSource = ds;
                    showDate.DataBind();
                    showDate.DataKeyNames = new string[] { "id" };
                    showDate.Visible = true;

                }



            }
            catch
            {
                MessageBox.Show(this, "查询出错！");
            }
        }


        protected void reset_Click(object sender, EventArgs e)
        {

            txttime_from.Text = "";
            txtTime_to.Text = "";
            txtadd_money.Text = "";
            showDate.Visible = false;
            showDate.DataSource = null;
            drpIsCheck.SelectedIndex = 0;
        }

        protected void add_new_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'>window.open('Add.aspx')</script>");
        }

        protected void showDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Session["data"];
            showDate.PageIndex = e.NewPageIndex;
            showDate.Visible = true;
            showDate.DataSource = ds;
            showDate.DataBind();
        }

        protected void showDate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = showDate.DataKeys[e.RowIndex].Value.ToString();
                GoldTradeNaming.Model.franchiser_money money = bll.GetModel(Convert.ToInt32(id));
                int tag = bll.Delete(Convert.ToInt32(id));
                if (tag > 0)
                {//同事更新franchiser_info里入账余额

                    bll.update_franchiser_info(money.franchiser_code, money.franchiser_added_money, -1);
                    MessageBox.Show(this, "删除成功");

                    showDate.Rows[e.RowIndex].Visible = false;
                }
                else
                {
                    MessageBox.Show(this, "删除失败");
                }
            }
            catch
            {
                MessageBox.Show(this,"删除时发生错误！");
            }
        }
    }
}
