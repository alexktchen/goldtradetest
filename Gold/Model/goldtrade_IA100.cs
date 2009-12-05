namespace GoldTradeNaming.Model
{
    using System;

    public class goldtrade_IA100
    {
        private Guid _ia100guid;
        private string _ia100key;
        private string _ia100state;
        private string _ia100superpswd;
        private string _statechangereason;

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

        public string IA100Key
        {
            get
            {
                return this._ia100key;
            }
            set
            {
                this._ia100key = value;
            }
        }

        public string IA100State
        {
            get
            {
                return this._ia100state;
            }
            set
            {
                this._ia100state = value;
            }
        }

        public string IA100SuperPswd
        {
            get
            {
                return this._ia100superpswd;
            }
            set
            {
                this._ia100superpswd = value;
            }
        }

        public string StateChangeReason
        {
            get
            {
                return this._statechangereason;
            }
            set
            {
                this._statechangereason = value;
            }
        }
    }
}
