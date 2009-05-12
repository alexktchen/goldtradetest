using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// ʵ����send_main ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class send_main
	{
		public send_main()
		{}
		#region Model
		private int _send_id;
		private int _franchiser_order_id;
		private DateTime _send_time;
        private decimal _send_amount_weight;
		private string _send_state;
		private string _ins_user;
		private DateTime _ins_date;
		private string _upd_user;
		private DateTime _upd_date;
		private string _canceled_reason;
		/// <summary>
		/// ��������
		/// </summary>
		public int send_id
		{
			set{ _send_id=value;}
			get{return _send_id;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int franchiser_order_id
		{
			set{ _franchiser_order_id=value;}
			get{return _franchiser_order_id;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime send_time
		{
			set{ _send_time=value;}
			get{return _send_time;}
		}
		/// <summary>
		/// ����������
		/// </summary>
        public decimal send_amount_weight
		{
			set{ _send_amount_weight=value;}
			get{return _send_amount_weight;}
		}
		/// <summary>
		/// ������״̬
		/// </summary>
		public string send_state
		{
			set{ _send_state=value;}
			get{return _send_state;}
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
		/// <summary>
		/// 
		/// </summary>
		public string canceled_reason
		{
			set{ _canceled_reason=value;}
			get{return _canceled_reason;}
		}
		#endregion Model

	}
}

