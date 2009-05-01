using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// 实体类franchiser_order 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
	public class franchiser_order
	{
		public franchiser_order()
		{}
		#region Model
		private int _franchiser_order_id;
		private int _franchiser_code;
		private string _franchiser_order_trans_type;
		private string _franchiser_order_address;
		private string _franchiser_order_postcode;
		private string _franchiser_order_handle_man;
		private string _franchiser_order_handle_tel;
		private string _franchiser_order_handle_phone;
		private decimal _franchiser_order_price;
		private decimal _franchiser_order_add_price;
		private decimal _franchiser_order_appraise;
		private DateTime _franchiser_order_time;
		private string _franchiser_order_state;
		private decimal _franchiser_order_amount_money;
		private string _canceled_reason;
		private string _ins_user;
		private DateTime _ins_date;
		private string _upd_user;
		private DateTime _upd_date;

        private string _franchiser_name;

        public string Franchiser_name
        {
            get { return _franchiser_name; }
            set { _franchiser_name = value; }
        }

        private string _product_type;

        public string Product_type
        {
            get { return _product_type; }
            set { _product_type = value; }
        }

        private string _product_type_name;

        public string Product_type_name
        {
            get { return _product_type_name; }
            set { _product_type_name = value; }
        }

		/// <summary>
		/// 订单号
		/// </summary>
		public int franchiser_order_id
		{
			set{ _franchiser_order_id=value;}
			get{return _franchiser_order_id;}
		}
		/// <summary>
		/// 经销商编号
		/// </summary>
		public int franchiser_code
		{
			set{ _franchiser_code=value;}
			get{return _franchiser_code;}
		}
		/// <summary>
		/// 运输方式
		/// </summary>
		public string franchiser_order_trans_type
		{
			set{ _franchiser_order_trans_type=value;}
			get{return _franchiser_order_trans_type;}
		}
		/// <summary>
		/// 收获地址
		/// </summary>
		public string franchiser_order_address
		{
			set{ _franchiser_order_address=value;}
			get{return _franchiser_order_address;}
		}
		/// <summary>
		/// 邮编
		/// </summary>
		public string franchiser_order_postcode
		{
			set{ _franchiser_order_postcode=value;}
			get{return _franchiser_order_postcode;}
		}
		/// <summary>
		/// 收获人
		/// </summary>
		public string franchiser_order_handle_man
		{
			set{ _franchiser_order_handle_man=value;}
			get{return _franchiser_order_handle_man;}
		}
		/// <summary>
		/// 收获人电话（座机）
		/// </summary>
		public string franchiser_order_handle_tel
		{
			set{ _franchiser_order_handle_tel=value;}
			get{return _franchiser_order_handle_tel;}
		}
		/// <summary>
		/// 收获人手机
		/// </summary>
		public string franchiser_order_handle_phone
		{
			set{ _franchiser_order_handle_phone=value;}
			get{return _franchiser_order_handle_phone;}
		}
		/// <summary>
		/// 黄金实时价格
		/// </summary>
		public decimal franchiser_order_price
		{
			set{ _franchiser_order_price=value;}
			get{return _franchiser_order_price;}
		}
		/// <summary>
		/// 订单加价
		/// </summary>
		public decimal franchiser_order_add_price
		{
			set{ _franchiser_order_add_price=value;}
			get{return _franchiser_order_add_price;}
		}
		/// <summary>
		/// 预估单价
		/// </summary>
		public decimal franchiser_order_appraise
		{
			set{ _franchiser_order_appraise=value;}
			get{return _franchiser_order_appraise;}
		}
		/// <summary>
		/// 订货时间
		/// </summary>
		public DateTime franchiser_order_time
		{
			set{ _franchiser_order_time=value;}
			get{return _franchiser_order_time;}
		}
		/// <summary>
		/// 订单状态
		/// </summary>
		public string franchiser_order_state
		{
			set{ _franchiser_order_state=value;}
			get{return _franchiser_order_state;}
		}
		/// <summary>
		/// 订单总额
		/// </summary>
		public decimal franchiser_order_amount_money
		{
			set{ _franchiser_order_amount_money=value;}
			get{return _franchiser_order_amount_money;}
		}
		/// <summary>
		/// 取消原因
		/// </summary>
		public string canceled_reason
		{
			set{ _canceled_reason=value;}
			get{return _canceled_reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ins_user
		{
			set{ _ins_user=value;}
			get{return _ins_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ins_date
		{
			set{ _ins_date=value;}
			get{return _ins_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upd_user
		{
			set{ _upd_user=value;}
			get{return _upd_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime upd_date
		{
			set{ _upd_date=value;}
			get{return _upd_date;}
		}
		#endregion Model

	}
}

