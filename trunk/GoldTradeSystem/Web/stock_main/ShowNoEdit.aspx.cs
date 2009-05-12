using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;
using LTP.Common;
namespace GoldTradeNaming.Web.stock_main
{
    public partial class ShowNoEdit : System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "库存查询";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.StockView.ToString())

                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                showData.Visible = false;
                //if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                //{
                string franchiser_code = Request.Params["id"];
                DataSet ds = bll.getAllInfoAboutM("");
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    showData.Visible = false;

                }
                else
                {
                    Session["data"] = ds;
                    showData.DataSource = ds;
                    showData.DataBind();
                    showData.Visible = true;
                    txtFran_ID.Text = franchiser_code;
                }
                //}
            }
        }


        protected void query_Click(object sender, EventArgs e)
        {
            try
            {
                string Fran_id = txtFran_ID.Text.Trim();
                int temp = int.MinValue;
                if (Fran_id == "" || Fran_id == null)
                {
                    MessageBox.Show(this, "请先输入经销商编号");
                    txtFran_ID.Focus();
                    return;
                }
                if (!int.TryParse(Fran_id, out temp))
                {
                    MessageBox.Show(this, "经销商编号应为数字");
                    return;
                }

                DataSet ds = bll.getAllInfoAboutM(Fran_id);

                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script type='text/javascript'>alert('没有该经销商的库存信息');</script>");
                    showData.Visible = false;

                }
                else
                {
                    Session["data"] = ds;
                    showData.DataSource = ds;
                    showData.DataBind();
                    showData.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }

        }

        protected void reset_Click(object sender, EventArgs e)
        {
            showData.Visible = false;
            this.txtFran_ID.Text = string.Empty;
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Session["data"];
            showData.PageIndex = e.NewPageIndex;
            showData.Visible = true;
            showData.DataSource = ds;
            showData.DataBind();
        }

        protected void add_new_Click(object sender, EventArgs e)
        {

        }


    }
}
