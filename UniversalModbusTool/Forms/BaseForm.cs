using System;
using System.Windows.Forms;
using UmtData.Data.Settings;
using UniversalModbusTool.Properties;

namespace UniversalModbusTool.Forms
{
    public class BaseForm : Form
    {
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