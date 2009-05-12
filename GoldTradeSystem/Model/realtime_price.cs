using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// 实体类realtime_price 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class realtime_price
	{
		public realtime_price()
		{}
		#region Model
		private int _id;
		private decimal _realtime_base_price;
		private decimal _order_add_price;
		private decimal _trade_add_price;
		private DateTime _realtime_time;
		private int _sys_admin_id;
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
		/// 实时价格
		/// </summary>
		public decimal realtime_base_price
		{
			set{ _realtime_base_price=value;}
			get{return _realtime_base_price;}
		}
		/// <summary>
		/// 订货加价
		/// </summary>
		public decimal order_add_price
		{
			set{ _order_add_price=value;}
			get{return _order_add_price;}
		}
		/// <summary>
		/// 销售加价
		/// </summary>
		public decimal trade_add_price
		{
			set{ _trade_add_price=value;}
			get{return _trade_add_price;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime realtime_time
		{
			set{ _realtime_time=value;}
			get{return _realtime_time;}
		}
		/// <summary>
		/// 系统管理员号
		/// </summary>
		public int sys_admin_id
		{
			set{ _sys_admin_id=value;}
			get{return _sys_admin_id;}
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

