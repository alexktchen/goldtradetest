using System;
namespace GoldTradeNaming.Model
{
    /// <summary>
    /// ʵ����franchiser_money ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class franchiser_money
    {
        public franchiser_money()
        { }
        #region Model
        private int _id;
        private int _franchiser_code;
        private decimal _franchiser_added_money;
        private DateTime _added_time;
        private string _ins_user;
        private DateTime _ins_date;
        private string _upd_user;
        private DateTime _upd_date;
        private string _check;

        /// <summary>
        /// ��־��������Ϣ�Ƿ��Ѿ����
        /// </summary>
        public string check
        {
            set { _check = value; }
            get { return _check;   }

        }



        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �����̱��
        /// </summary>
        public int franchiser_code
        {
            set { _franchiser_code = value; }
            get { return _franchiser_code; }
        }
        /// <summary>
        /// ���ʽ��
        /// </summary>
        public decimal franchiser_added_money
        {
            set { _franchiser_added_money = value; }
            get { return _franchiser_added_money; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime added_time
        {
            set { _added_time = value; }
            get { return _added_time; }
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

