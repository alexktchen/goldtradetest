using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace GoldTradeNaming.Web.product_type
{
    public partial class Modify_index : System.Web.UI.Page
    {


        private readonly GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
        public GridViewRow row = null;


        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "修改产品";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    hid_id.Value = Request.QueryString["id"].ToString().Trim();
                }
                catch
                {
                    hid_id.Value = "";
                }

                try
                {
                    hid_name.Value = Request.QueryString["name"].ToString().Trim();
                }
                catch
                {
                    hid_name.Value = "";
                }
                try
                {
                    hid_weight.Value = Request.QueryString["kind"].ToString().Trim();
                }
                catch
                {
                    hid_weight.Value = "";
                }
                try
                {
                    hid_status.Value = Request.QueryString["status"].ToString().Trim();
                }
                catch
                {
                    hid_status.Value = "";
                }
                try
                {
                    hid_order.Value = Request.QueryString["order_add"].ToString().Trim();
                }
                catch
                {
                    hid_order.Value = "";
                }
                try
                {
                    hid_trade.Value = Request.QueryString["trade_add"].ToString().Trim();
                }
                catch
                {
                    hid_trade.Value = "";
                }
                try
                {
                    hid_type.Value = Request.QueryString["type"].ToString().Trim();
                }
                catch
                {
                    hid_type.Value = "";
                }






                if (Session["admin"] == null || Session["admin"].ToString() == ""
                     || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ChgProduct.ToString())
                    
                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }

                try { dataBind(); }
                catch {

                    Response.Write("<script defer>window.alert('加载失败');</script>");
                }


            }
        }

        public void dataBind() {

            try
            {
                string id = hid_id.Value;
                string name = hid_name.Value;
                string kind = hid_weight.Value;
                string status = hid_status.Value;
                string order_add = hid_order.Value;
                string trade_add = hid_trade.Value;
                string type = hid_type.Value;

                DataSet ds = bll.queryAction(id, name, kind, status, order_add, trade_add, type);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    //message.Text = "查无数据，请确定查询条件是否正确";
                    showData.DataSource = null;
                    showData.Visible = false;
                    Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row["product_state"].ToString().Trim() == "0")
                        {
                            row["product_state"] = "启用";
                        }
                        else
                        {
                            row["product_state"] = "禁用";
                        }



                        if (row["type"].ToString().Trim() == "0")
                        {
                            row["type"] = "升水";

                        }
                        else { row["type"] = "非升水"; }


                    }


                    Session["data"] = ds;
                    showData.Visible = true;
                    showData.DataSource = ds;
                    showData.DataBind();

                  
                    }
        }catch{
                    throw;
                    }
        
        }

        protected void query_Click(object sender, EventArgs e)
        {

            try
            {

                string id = type_ID.Text.Trim();
                string name = type_Name.Text.Trim();
                string kind = type_Kind.Text.Trim();
                string status = drptype_Status.Text.Trim();
                string order_add = txtorder_add_price.Text.Trim();
                string trade_add = txttrade_add_price.Text.Trim();
                string type = drptype.Text.Trim();
                hid_id.Value = id;
                hid_name.Value = name;
                hid_weight.Value = kind;
                hid_status.Value = status;
                hid_order.Value = order_add;
                hid_trade.Value = trade_add;
                hid_type.Value = type;
                dataBind();

           }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('查询失败');</script>");

            }






        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataSet ds = (DataSet)Session["data"];
                showData.PageIndex = e.NewPageIndex;
                showData.Visible = true;
                showData.DataSource = ds;
                showData.DataBind();
            }
            catch
            {

                Response.Write("<script type='text/javascript'>alert('翻页失败');</script>");
            }

        }


        protected void cancel_Click(object sender, EventArgs e)
        {
            type_ID.Text = "";
            type_Kind.Text = "";
            drptype_Status.SelectedIndex = 0;
            type_Name.Text = "";
            txtorder_add_price.Text = "";
            txttrade_add_price.Text = "";
            drptype.SelectedIndex = 0;
            showData.DataSource = null;
            showData.Visible = false;


        }

        protected void showData_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("Row_Edit"))
            {
                int tag = Convert.ToInt32(e.CommandArgument);
                row = showData.Rows[tag];
                Session["tmp_row"] = row;
                Response.Redirect("Modify.aspx?id=" + hid_id.Value + " &name=" + hid_name.Value + " &kind=" + hid_weight.Value + " &status=" + hid_status.Value + " &order_add=" + hid_order.Value + " &trade_add=" + hid_trade.Value + " &type=" + hid_type.Value);

            }


        }









    }
}
