using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// 实体类franchiser_order_desc 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class franchiser_order_desc
	{
		public franchiser_order_desc()
		{}
		#region Model

        private decimal _realtime_base_price;
        private decimal _order_add_price;
        private decimal _order_appraise;
        private int _order_weight;
        /// <summary>
        /// 基础金价
        /// </summary>
        public decimal realtime_base_price
        {
            set { _realtime_base_price = value; }
            get { return _realtime_base_price; }
        }
        /// <summary>
        /// 订货加价
        /// </summary>
        public decimal order_add_price
        {
            set { _order_add_price = value; }
            get { return _order_add_price; }
        }
        /// <summary>
        /// 预估单价（=基础金价+订货加价）
        /// </summary>
        public decimal order_appraise
        {
            set { _order_appraise = value; }
            get { return _order_appraise; }
        }
        /// <summary>
        /// 重量小计（=订货数量*规格=未收到重量+已收到重量）
        /// </summary>
        public int order_weight
        {
            set { _order_weight = value; }
            get { return _order_weight; }
        }

		private int _id;
		private int _franchiser_order_id;
		private int _product_id;
		private int _product_spec_id;
		private int _order_product_amount;
		private int _product_received;
		private int _product_unreceived;
		private string _ins_user;
		private DateTime _ins_date;
		private string _upd_user;
		private DateTime _upd_date;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 产品类别ID
		/// </summary>
		public int product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 产品规格ID
		/// </summary>
		public int product_spec_id
		{
			set{ _product_spec_id=value;}
			get{return _product_spec_id;}
		}
		/// <summary>
		/// 订购数量
		/// </summary>
		public int order_product_amount
		{
			set{ _order_product_amount=value;}
			get{return _order_product_amount;}
		}
		/// <summary>
		/// 已收到重量
		/// </summary>
		public int product_received
		{
			set{ _product_received=value;}
			get{return _product_received;}
		}
		/// <summary>
		/// 未收到重量
		/// </summary>
		public int product_unreceived
		{
			set{ _product_unreceived=value;}
			get{return _product_unreceived;}
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

