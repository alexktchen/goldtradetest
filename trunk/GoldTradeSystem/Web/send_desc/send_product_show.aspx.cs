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
namespace GoldTradeNaming.Web.send_desc
{
    public partial class send_product_show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["fran"] == null || Session["fran"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                SetBind();
            }
        }

        private void SetBind()
        {
            try
            {
                #region 订单主表信息绑定

                this.txtfranchiser_code.Text = Request.QueryString["fnm"].ToString();
                // this.mFranID = Convert.ToInt32(Request.QueryString["fid"].ToString());
                // this.mOrderID = Convert.ToInt32(Request.QueryString["id"].ToString());
                this.orderid.Value = Request.QueryString["sendid"].ToString();
                StringBuilder strWhere = new StringBuilder();

                strWhere.Append(" AND franchiser_order.franchiser_order_id = '");
                strWhere.Append(this.orderid.Value);
                strWhere.Append("'");

                GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
                DataSet dsOrder = bll.GetOrderInfo(strWhere.ToString());

                if (dsOrder.Tables.Count > 0 && dsOrder.Tables[0].Rows.Count > 0)
                {
                    DataRow drOrder = dsOrder.Tables[0].Rows[0];
                    //this.transway.SelectedIndex = Convert.ToInt32(drOrder["franchiser_order_trans_type"].ToString());
                    this.lbltrans.Text = drOrder["franchiser_order_trans_type"].ToString();
                    this.txtfranchiser_order_address.Text = drOrder["franchiser_order_address"].ToString();
                    this.txtfranchiser_order_postcode.Text = drOrder["franchiser_order_postcode"].ToString();
                    this.txtfranchiser_order_handle_man.Text = drOrder["franchiser_order_handle_man"].ToString();
                    this.txtfranchiser_order_handle_tel.Text = drOrder["franchiser_order_handle_tel"].ToString();
                    this.txtfranchiser_order_handle_phone.Text = drOrder["franchiser_order_handle_phone"].ToString();
                    this.txtfranchiser_order_price.Text = drOrder["franchiser_order_price"].ToString();
                    this.txtOrderTime.Text = drOrder["franchiser_order_time"].ToString();
                    // this.txtfranchiser_order_add_price.Text = drOrder["franchiser_order_add_price"].ToString();
                    // this.txtfranchiser_order_appraise.Text = drOrder["franchiser_order_appraise"].ToString();
                    this.txtfranchiser_order_amount_money.Text = drOrder["franchiser_order_amount_money"].ToString();
                }
                #endregion

                #region 订单产品信息绑定

                strWhere = new StringBuilder();
                strWhere.Append(" franchiser_order_id = '");
                strWhere.Append(this.orderid.Value + "'");
                GoldTradeNaming.BLL.send_main orderdscBll = new GoldTradeNaming.BLL.send_main();
                DataSet ds = orderdscBll.GetOrderedProductList(strWhere.ToString());
                GridView1.DataSource = ds;
                GridView1.DataBind();

                #endregion
            }
            catch
            {
                MessageBox.Show(this, "信息读取有误！");
            }
        }
    }
}
