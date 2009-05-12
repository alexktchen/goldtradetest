using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// ʵ����send_desc ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class send_desc
	{
		public send_desc()
		{}
		#region Model
		private int _id;
		private int _send_id;
		private int _product_id;
        private decimal _product_spec_id;
        private decimal _send_amount_weight;
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
		/// ���������
		/// </summary>
		public int send_id
		{
			set{ _send_id=value;}
			get{return _send_id;}
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
        public decimal send_amount_weight
		{
			set{ _send_amount_weight=value;}
			get{return _send_amount_weight;}
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

