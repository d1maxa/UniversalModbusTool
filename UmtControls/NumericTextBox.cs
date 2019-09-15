using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace UmtControls
{
    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            DataBindings.CollectionChanged += DataBindings_CollectionChanged;
        }

        private void DataBindings_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            var db = DataBindings["Text"];
            if (db != null)
            {
                db.Parse -= DbOnParse;
                db.Parse += DbOnParse;
            }
        }

        private void DbOnParse(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString().Length == 0)
            {
                if (e.DesiredType.IsGenericType &&
                    e.DesiredType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    e.Value = null;
            }
        }

        // Restricts the entry of characters to digits (including hex), the negative sign,
        // the decimal point, and editing keystrokes (backspace).
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            var numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            var decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            var groupSeparator = numberFormatInfo.NumberGroupSeparator;
            var negativeSign = numberFormatInfo.NegativeSign;

            var keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (!OnlyPositiveInt &&
                (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
             keyInput.Equals(negativeSign)))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            //    {
            //     // Let the edit control handle control and alt key combinations
            //    }
            else if (AllowSpace && e.KeyChar == ' ')
            {

            }
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }

        public int IntValue => Int32.Parse(Text);

        public decimal DecimalValue => Decimal.Parse(Text);

        public bool AllowSpace { set; get; }

        public bool OnlyPositiveInt { get; set; }
    }
}