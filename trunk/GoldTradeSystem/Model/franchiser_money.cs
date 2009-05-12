using System;
namespace GoldTradeNaming.Model
{
    /// <summary>
    /// 实体类franchiser_money 。(属性说明自动提取数据库字段的描述信息)
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
        /// 标志该入账信息是否已经审核
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
        /// 经销商编号
        /// </summary>
        public int franchiser_code
        {
            set { _franchiser_code = value; }
            get { return _franchiser_code; }
        }
        /// <summary>
        /// 入帐金额
        /// </summary>
        public decimal franchiser_added_money
        {
            set { _franchiser_added_money = value; }
            get { return _franchiser_added_money; }
        }
        /// <summary>
        /// 入帐时间
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

