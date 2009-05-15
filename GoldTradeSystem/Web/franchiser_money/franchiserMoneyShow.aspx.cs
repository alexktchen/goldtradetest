using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LTP.Common;

namespace GoldTradeNaming.Web.franchiser_money
{
    public partial class franchiserMoneyShow : System.Web.UI.Page
    {
        private readonly GoldTradeNaming.BLL.franchiser_money bll = new GoldTradeNaming.BLL.franchiser_money();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                string fran_id = Session["fran"].ToString();
                txtfran_id.Text = fran_id;
                showInformation(fran_id, "", "", "");
            }
        }
        private void showInformation(string fran_id, string add_money, string time_from, string time_to)
        {
            try
            {
                DataSet ds = bll.queryAction(fran_id, add_money, time_from, time_to);
                Session["data"] = ds;
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                    showData.Visible = false;
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
                    showData.PageIndex = 0;
                    showData.DataSource = ds;
                    showData.DataBind();
                    showData.DataKeyNames = new string[] { "id" };
                    showData.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show(this, "查询出错！");
            }

        }

        protected void query_Click(object sender, EventArgs e)
        {
            showData.DataSource = null;
            showData.Visible = false;
            Session["data"] = null;
            string fran_id = txtfran_id.Text.Trim();
            string time_from = txttime_from.Text.Trim();
            string time_to = txtTime_to.Text.Trim();
            string strErr = "";
            if (!PageValidate.IsNumber(fran_id) && fran_id != "")
            {
                strErr += "franchiser_code不是数字！\\n";
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
                showData.Visible = false;
                return;
            }
            showInformation(fran_id, "", time_from, time_to);
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Session["data"];
            showData.PageIndex = e.NewPageIndex;
            showData.Visible = true;
            showData.DataSource = ds;
            showData.DataBind();
        }

        protected void showData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void showData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
