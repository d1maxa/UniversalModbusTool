using System.Windows.Forms;

namespace UmtControls
{
    public class ComboBoxEx : ComboBox
    {
        public ComboBoxEx()
        {
            _textBox = new TextBox
            {
                ReadOnly = true,
                Visible = false
            };
        }

        private readonly TextBox _textBox;

        private bool _readOnly;

        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;

                if (_readOnly)
                {
                    Visible = false;
                    _textBox.Text = Text;
                    _textBox.Location = Location;
                    _textBox.Size = Size;
                    _textBox.Visible = true;

                    
                    _textBox.Dock = Dock;
                    _textBox.Anchor = Anchor;
                    _textBox.Enabled = Enabled;
                    _textBox.RightToLeft = RightToLeft;
                    _textBox.Font = Font;
                    _textBox.TabStop = TabStop;
                    _textBox.TabIndex = TabIndex;

                    if (_textBox.Parent == null)
                        Parent.Controls.Add(_textBox);
                }
                else
                {
                    Visible = true;
                    _textBox.Visible = false;
                }
            }
        }
    }
}