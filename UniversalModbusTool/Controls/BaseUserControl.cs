using System;
using System.Windows.Forms;
using UmtData.Data;
using UmtData.Data.Settings;
using UniversalModbusTool.Properties;

namespace UniversalModbusTool.Controls
{
    public class BaseUserControl : UserControl
    {
        public virtual void Initialize()
        {}

        public Options Options => Options.Instance;

        public Settings Settings => Settings.Default;

        protected void Invoke(Action action)
        {
            if (!IsHandleCreated)
                return;

            if (InvokeRequired)
            {
                try
                {
                    base.Invoke(action);
                }
                catch (ObjectDisposedException)
                {
                    
                }
            }
            else
                action();
        }
    }
}