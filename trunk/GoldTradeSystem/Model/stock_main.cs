using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// ʵ����stock_main ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class stock_main
	{
		public stock_main()
		{}
		#region Model
		private int _id;
		private string _franchiser_code;
		private int _product_id;
		private int _product_spec_id;
		private int _stock_total;
		private int _stock_left;
		private string _ins_user;
		private DateTime _ins_date;
		private string _upd_user;
		private DateTime _upd_date;
        private string _product_name;   //add by yiyong 20090418
        private string _franchiser_name;
        private int _changeMount;
        public int changeMount
        {
            set { _changeMount = value; }
            get { return _changeMount; }
        }


		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �����̱��
		/// </summary>
		public string franchiser_code
		{
			set{ _franchiser_code=value;}
			get{return _franchiser_code;}
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
		public int product_spec_id
		{
			set{ _product_spec_id=value;}
			get{return _product_spec_id;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int stock_total
		{
			set{ _stock_total=value;}
			get{return _stock_total;}
		}
		/// <summary>
		/// ���ÿ��
		/// </summary>
		public int stock_left
		{
			set{ _stock_left=value;}
			get{return _stock_left;}
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
        /// ��Ʒ����
        /// </summary>
        public string product_name
        {
            set { _product_name = value;}
            get { return _product_name; }
        }
        public string franchiser_name
        {
            set {_franchiser_name = value; }
            get{ return _franchiser_name;}
        }
		#endregion Model

	}
}

