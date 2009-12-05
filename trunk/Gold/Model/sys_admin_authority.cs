namespace GoldTradeNaming.Model
{
    using System;

    public class sys_admin_authority
    {
        private int _sys_admin_id;
        private string _sys_module;

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

        public string sys_module
        {
            get
            {
                return this._sys_module;
            }
            set
            {
                this._sys_module = value;
            }
        }
    }
}
