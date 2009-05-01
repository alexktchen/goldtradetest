using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// ʵ����franchiser_trade ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class franchiser_trade
	{
		public franchiser_trade()
		{}
		#region Model
		private int _trade_id;
		private int _franchiser_code;
		private DateTime _trade_time;
		private decimal _realtime_base_price;
		private decimal _gold_trade_price;
		private decimal _trade_add_price;
		private int _trade_total_weight;
		private decimal _trade_total_money;
		private string _canceled_reason;
		private string _trade_state;
		private string _ins_user;
		private DateTime _ins_date;
		private string _upd_user;
		private DateTime _upd_date;
		/// <summary>
		/// ���׵����
		/// </summary>
		public int trade_id
		{
			set{ _trade_id=value;}
			get{return _trade_id;}
		}
		/// <summary>
		/// �����̱��
		/// </summary>
		public int franchiser_code
		{
			set{ _franchiser_code=value;}
			get{return _franchiser_code;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime trade_time
		{
			set{ _trade_time=value;}
			get{return _trade_time;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public decimal realtime_base_price
		{
			set{ _realtime_base_price=value;}
			get{return _realtime_base_price;}
		}
		/// <summary>
		/// ���㵥��
		/// </summary>
		public decimal gold_trade_price
		{
			set{ _gold_trade_price=value;}
			get{return _gold_trade_price;}
		}
		/// <summary>
		/// ���ۼӼ�
		/// </summary>
		public decimal trade_add_price
		{
			set{ _trade_add_price=value;}
			get{return _trade_add_price;}
		}
		/// <summary>
		/// ����������
		/// </summary>
		public int trade_total_weight
		{
			set{ _trade_total_weight=value;}
			get{return _trade_total_weight;}
		}
		/// <summary>
		/// �����ܽ��
		/// </summary>
		public decimal trade_total_money
		{
			set{ _trade_total_money=value;}
			get{return _trade_total_money;}
		}
		/// <summary>
		/// ȡ��ԭ��
		/// </summary>
		public string canceled_reason
		{
			set{ _canceled_reason=value;}
			get{return _canceled_reason;}
		}
		/// <summary>
		/// ����״̬
		/// </summary>
		public string trade_state
		{
			set{ _trade_state=value;}
			get{return _trade_state;}
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

