namespace GoldTradeNaming.Model
{
    using System;

    public class stock_main
    {
        private decimal _changeMount;
        private string _franchiser_code;
        private string _franchiser_name;
        private int _id;
        private DateTime _ins_date;
        private string _ins_user;
        private int _product_id;
        private string _product_name;
        private decimal _product_spec_id;
        private decimal _stock_left;
        private decimal _stock_total;
        private DateTime _upd_date;
        private string _upd_user;

        public decimal changeMount
        {
            get
            {
                return this._changeMount;
            }
            set
            {
                this._changeMount = value;
            }
        }

        public string franchiser_code
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

        public string franchiser_name
        {
            get
            {
                return this._franchiser_name;
            }
            set
            {
                this._franchiser_name = value;
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

        public int product_id
        {
            get
            {
                return this._product_id;
            }
            set
            {
                this._product_id = value;
            }
        }

        public string product_name
        {
            get
            {
                return this._product_name;
            }
            set
            {
                this._product_name = value;
            }
        }

        public decimal product_spec_id
        {
            get
            {
                return this._product_spec_id;
            }
            set
            {
                this._product_spec_id = value;
            }
        }

        public decimal stock_left
        {
            get
            {
                return this._stock_left;
            }
            set
            {
                this._stock_left = value;
            }
        }

        public decimal stock_total
        {
            get
            {
                return this._stock_total;
            }
            set
            {
                this._stock_total = value;
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
