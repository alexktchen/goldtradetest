namespace GoldTradeNaming.Web.franchiser_money
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        private readonly GoldTradeNaming.BLL.franchiser_money bll = new GoldTradeNaming.BLL.franchiser_money();
        protected DropDownList drpIsCheck;
        protected CalendarExtender dtTo_CalendarExtender;
        protected Button query;
        protected Button reset;
        protected ScriptManager ScriptManager1;
        protected GridView showDate;
        protected TextBox txtadd_money;
        protected TextBox txtfran_id;
        protected TextBox txttime_from;
        protected TextBox txtTime_to;
        protected CalendarExtender txtTimeTo0_CalendarExtender;

        protected void add_new_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script type='text/javascript'>window.open('Add.aspx')</script>");
        }

        public void databind(int tag)
        {
            this.showDate.DataSource = null;
            this.showDate.Visible = false;
            this.Session["data"] = null;
            string fran_id = this.txtfran_id.Text.Trim();
            string add_money = this.txtadd_money.Text.Trim();
            string time_from = this.txttime_from.Text.Trim();
            string time_to = this.txtTime_to.Text.Trim();
            string check = this.drpIsCheck.Text.Trim();
            string strErr = "";
            if (!(PageValidate.IsNumber(fran_id) || !(fran_id != "")))
            {
                strErr = strErr + @"franchiser_code不是数字！\n";
            }
            if (!(PageValidate.IsDecimal(add_money) || !(add_money != "")))
            {
                strErr = strErr + @"franchiser_added_money不是数字！\n";
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
                this.showDate.Visible = false;
            }
            else
            {
                try
                {
                    DataSet ds = this.bll.queryAction(fran_id, add_money, time_from, time_to, check, tag);
                    this.Session["data"] = ds;
                    if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                    {
                        base.Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                        this.showDate.Visible = false;
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
                        this.showDate.PageIndex = 0;
                        this.showDate.DataSource = ds;
                        this.showDate.DataBind();
                        this.showDate.DataKeyNames = new string[] { "id" };
                        this.showDate.Visible = true;
                    }
                }
                catch
                {
                    MessageBox.Show(this, "查询出错！");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewAddMoney.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.databind(0);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "查看入帐";
        }

        protected void query_Click(object sender, EventArgs e)
        {
            this.databind(1);
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.txttime_from.Text = "";
            this.txtTime_to.Text = "";
            this.txtadd_money.Text = "";
            this.showDate.Visible = false;
            this.showDate.DataSource = null;
            this.drpIsCheck.SelectedIndex = 0;
        }

        protected void showDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet) this.Session["data"];
            this.showDate.PageIndex = e.NewPageIndex;
            this.showDate.Visible = true;
            this.showDate.DataSource = ds;
            this.showDate.DataBind();
        }

        protected void showDate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = this.showDate.DataKeys[e.RowIndex].Value.ToString();
                GoldTradeNaming.Model.franchiser_money money = this.bll.GetModel(Convert.ToInt32(id));
                if (this.bll.Delete(Convert.ToInt32(id)) > 0)
                {
                    this.bll.update_franchiser_info(money.franchiser_code, money.franchiser_added_money, -1);
                    MessageBox.Show(this, "删除成功");
                    this.showDate.Rows[e.RowIndex].Visible = false;
                }
                else
                {
                    MessageBox.Show(this, "删除失败");
                }
            }
            catch
            {
                MessageBox.Show(this, "删除时发生错误！");
            }
        }
    }
}
