using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// ʵ����franchiser_trade_desc ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class franchiser_trade_desc
	{
		public franchiser_trade_desc()
		{}
		#region Model
		private int _id;
		private int _trade_id;
		private int _product_id;
        private decimal _product_spec_id;
        private decimal _trade_weight;
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
		/// ���׵���
		/// </summary>
		public int trade_id
		{
			set{ _trade_id=value;}
			get{return _trade_id;}
		}
		/// <summary>
		/// ��Ʒ���ID
		/// </summary>
		public int product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// ��Ʒ���ID
		/// </summary>
        public decimal product_spec_id
		{
			set{ _product_spec_id=value;}
			get{return _product_spec_id;}
		}
		/// <summary>
		/// ��������
		/// </summary>
        public decimal trade_weight
		{
			set{ _trade_weight=value;}
			get{return _trade_weight;}
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

