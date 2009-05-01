using System;
namespace GoldTradeNaming.Model
{
    /// <summary>
    /// ʵ����product_type ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class product_type
    {
        public product_type()
        { }
        #region Model
        private int _product_type_id;
        private string _product_type_name;
        private int _product_spec_weight;
        private string _product_state;
        private string _ins_user;
        private DateTime _ins_date;
        private string _upd_user;
        private DateTime _upd_date;
        private decimal _order_add_price;
        private decimal _trade_add_price;
        private string _type;

        /// <summary>
        /// ��� 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }

        /// <summary>
        /// ���ۼӼ�
        /// </summary>
        public decimal trade_add_price
        {
            set { _trade_add_price = value; }
            get { return _trade_add_price; }
        }
        /// <summary>
        /// �����Ӽ�
        /// </summary>
        public decimal order_add_price
        {
            set { _order_add_price = value; }
            get { return _order_add_price; }
        }

        /// <summary>
        /// ��Ʒ���ID
        /// </summary>
        public int product_type_id
        {
            set { _product_type_id = value; }
            get { return _product_type_id; }
        }
        /// <summary>
        /// ��Ʒ�������
        /// </summary>
        public string product_type_name
        {
            set { _product_type_name = value; }
            get { return _product_type_name; }
        }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public int product_spec_weight
        {
            set { _product_spec_weight = value; }
            get { return _product_spec_weight; }
        }
        /// <summary>
        /// ��Ʒ״̬(ͣ����ɾ��)
        /// </summary>
        public string product_state
        {
            set { _product_state = value; }
            get { return _product_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ins_user
        {
            set { _ins_user = value; }
            get { return _ins_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ins_date
        {
            set { _ins_date = value; }
            get { return _ins_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string upd_user
        {
            set { _upd_user = value; }
            get { return _upd_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime upd_date
        {
            set { _upd_date = value; }
            get { return _upd_date; }
        }
        #endregion Model

    }
}

