namespace GoldTradeNaming.Model
{
    using System;

    public class franchiser_money
    {
        private DateTime _added_time;
        private string _check;
        private decimal _franchiser_added_money;
        private int _franchiser_code;
        private int _id;
        private DateTime _ins_date;
        private string _ins_user;
        private DateTime _upd_date;
        private string _upd_user;

        public DateTime added_time
        {
            get
            {
                return this._added_time;
            }
            set
            {
                this._added_time = value;
            }
        }

        public string check
        {
            get
            {
                return this._check;
            }
            set
            {
                this._check = value;
            }
        }

        public decimal franchiser_added_money
        {
            get
            {
                return this._franchiser_added_money;
            }
            set
            {
                this._franchiser_added_money = value;
            }
        }

        public int franchiser_code
        {
            get
            {
                return this._franchiser_code;
            }
            set
            {
                this._franchiser_code = value;
            }
        }

        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public DateTime ins_date
        {
            get
            {
                return this._ins_date;
            }
            set
            {
                this._ins_date = value;
            }
        }

        public string ins_user
        {
            get
            {
                return this._ins_user;
            }
            set
            {
                this._ins_user = value;
            }
        }

        public DateTime upd_date
        {
            get
            {
                return this._upd_date;
            }
            set
            {
                this._upd_date = value;
            }
        }

        public string upd_user
        {
            get
            {
                return this._upd_user;
            }
            set
            {
                this._upd_user = value;
            }
        }
    }
}
