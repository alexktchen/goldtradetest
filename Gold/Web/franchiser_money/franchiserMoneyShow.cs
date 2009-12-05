namespace GoldTradeNaming.Web.franchiser_money
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class franchiserMoneyShow : Page
    {
        private readonly franchiser_money bll = new franchiser_money();
        protected CalendarExtender dtTo_CalendarExtender;
        protected Label Label1;
        protected Button query;
        protected ScriptManager ScriptManager1;
        protected GridView showData;
        protected TextBox txtfran_id;
        protected TextBox txttime_from;
        protected TextBox txtTime_to;
        protected CalendarExtender txtTimeTo0_CalendarExtender;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!this.Page.IsPostBack)
            {
                string fran_id = this.Session["fran"].ToString();
                this.txtfran_id.Text = fran_id;
                this.showInformation(fran_id, "", "", "");
            }
        }

        protected void query_Click(object sender, EventArgs e)
        {
            this.showData.DataSource = null;
            this.showData.Visible = false;
            this.Session["data"] = null;
            string fran_id = this.txtfran_id.Text.Trim();
            string time_from = this.txttime_from.Text.Trim();
            string time_to = this.txtTime_to.Text.Trim();
            string strErr = "";
            if (!(PageValidate.IsNumber(fran_id) || !(fran_id != "")))
            {
                strErr = strErr + @"franchiser_code不是数字！\n";
            }
            if (!(PageValidate.IsDateTime(time_from) || !(time_from != "")))
            {
                strErr = strErr + @"added_time起始时间不是时间格式！\n";
            }
            if (!(PageValidate.IsDateTime(time_to) || !(time_to != "")))
            {
                strErr = strErr + @"added_time终止时间不是时间格式！\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                this.showData.Visible = false;
            }
            else
            {
                this.showInformation(fran_id, "", time_from, time_to);
            }
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet) this.Session["data"];
            this.showData.PageIndex = e.NewPageIndex;
            this.showData.Visible = true;
            this.showData.DataSource = ds;
            this.showData.DataBind();
        }

        protected void showData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void showData_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void showInformation(string fran_id, string add_money, string time_from, string time_to)
        {
            try
            {
                DataSet ds = this.bll.queryAction(fran_id, add_money, time_from, time_to);
                this.Session["data"] = ds;
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    base.Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                    this.showData.Visible = false;
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
                    this.showData.PageIndex = 0;
                    this.showData.DataSource = ds;
                    this.showData.DataBind();
                    this.showData.DataKeyNames = new string[] { "id" };
                    this.showData.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show(this, "查询出错！");
            }
        }
    }
}
