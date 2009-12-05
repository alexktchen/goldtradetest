namespace GoldTradeNaming.Model
{
    using System;

    public class send_main
    {
        private string _canceled_reason;
        private int _franchiser_order_id;
        private DateTime _ins_date;
        private string _ins_user;
        private decimal _send_amount_weight;
        private int _send_id;
        private string _send_state;
        private DateTime _send_time;
        private DateTime _upd_date;
        private string _upd_user;

        public string canceled_reason
        {
            get
            {
                return this._canceled_reason;
            }
            set
            {
                this._canceled_reason = value;
            }
        }

        public int franchiser_order_id
        {
            get
            {
                return this._franchiser_order_id;
            }
            set
            {
                this._franchiser_order_id = value;
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

        public decimal send_amount_weight
        {
            get
            {
                return this._send_amount_weight;
            }
            set
            {
                this._send_amount_weight = value;
            }
        }

        public int send_id
        {
            get
            {
                return this._send_id;
            }
            set
            {
                this._send_id = value;
            }
        }

        public string send_state
        {
            get
            {
                return this._send_state;
            }
            set
            {
                this._send_state = value;
            }
        }

        public DateTime send_time
        {
            get
            {
                return this._send_time;
            }
            set
            {
                this._send_time = value;
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
