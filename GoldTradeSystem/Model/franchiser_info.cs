namespace GoldTradeNaming.Model
{
    using System;

    public class franchiser_info
    {
        private string _franchiser_address;
        private decimal _franchiser_asure_money;
        private decimal _franchiser_balance_money;
        private string _franchiser_cellphone;
        private int _franchiser_code;
        private string _franchiser_name;
        private string _franchiser_tel;
        private Guid _ia100guid;
        private DateTime _ins_date;
        private string _ins_user;
        private DateTime _upd_date;
        private string _upd_user;

        public string franchiser_address
        {
            get
            {
                return this._franchiser_address;
            }
            set
            {
                this._franchiser_address = value;
            }
        }

        public decimal franchiser_asure_money
        {
            get
            {
                return this._franchiser_asure_money;
            }
            set
            {
                this._franchiser_asure_money = value;
            }
        }

        public decimal franchiser_balance_money
        {
            get
            {
                return this._franchiser_balance_money;
            }
            set
            {
                this._franchiser_balance_money = value;
            }
        }

        public string franchiser_cellphone
        {
            get
            {
                return this._franchiser_cellphone;
            }
            set
            {
                this._franchiser_cellphone = value;
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

        public string franchiser_tel
        {
            get
            {
                return this._franchiser_tel;
            }
            set
            {
                this._franchiser_tel = value;
            }
        }

        public Guid IA100GUID
        {
            get
            {
                return this._ia100guid;
            }
            set
            {
                this._ia100guid = value;
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
