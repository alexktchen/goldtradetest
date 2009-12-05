namespace GoldTradeNaming.Model
{
    using System;

    public class goldtrade_db_admin
    {
        private Guid _ia100guid;
        private DateTime _ins_date;
        private string _ins_user;
        private string _sys_admin_cellphone;
        private int _sys_admin_id;
        private string _sys_admin_name;
        private string _sys_admin_tel;
        private DateTime _upd_date;
        private string _upd_user;

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

        public string sys_admin_cellphone
        {
            get
            {
                return this._sys_admin_cellphone;
            }
            set
            {
                this._sys_admin_cellphone = value;
            }
        }

        public int sys_admin_id
        {
            get
            {
                return this._sys_admin_id;
            }
            set
            {
                this._sys_admin_id = value;
            }
        }

        public string sys_admin_name
        {
            get
            {
                return this._sys_admin_name;
            }
            set
            {
                this._sys_admin_name = value;
            }
        }

        public string sys_admin_tel
        {
            get
            {
                return this._sys_admin_tel;
            }
            set
            {
                this._sys_admin_tel = value;
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
