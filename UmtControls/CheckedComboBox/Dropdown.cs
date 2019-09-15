using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace UmtControls.CheckedComboBox
{
    /// <summary>
    /// Internal class to represent the dropdown list of the CheckedComboBox
    /// </summary>
    internal class Dropdown : Form
    {
        
        
        // --------------------------------------------------------------------------------------------------------

        // ********************************************* Data *********************************************

        private readonly CheckedComboBox _ccbParent;

        // Keeps track of whether checked item(s) changed, hence the value of the CheckedComboBox as a whole changed.
        // This is simply done via maintaining the old string-representation of the value(s) and the new one and comparing them!
        private string _oldStrValue = "";
        public bool ValueChanged
        {
            get
            {
                var newStrValue = _ccbParent.Text;
                if ((_oldStrValue.Length > 0) && (newStrValue.Length > 0))
                {
                    return (_oldStrValue.CompareTo(newStrValue) != 0);
                }
                else
                {
                    return (_oldStrValue.Length != newStrValue.Length);
                }
            }
        }

        // Array holding the checked states of the items. This will be used to reverse any changes if user cancels selection.
        bool[] _checkedStateArr;

        // Whether the dropdown is closed.
        private bool _dropdownClosed = true;

        public CustomCheckedListBox List { get; set; }

        // ********************************************* Construction *********************************************

        public Dropdown(CheckedComboBox ccbParent)
        {
            _ccbParent = ccbParent;
            InitializeComponent();
            ShowInTaskbar = false;
            // Add a handler to notify our parent of ItemCheck events.
            List.ItemCheck += cclb_ItemCheck;
        }

        // ********************************************* Methods *********************************************

        // Create a CustomCheckedListBox which fills up the entire form area.
        private void InitializeComponent()
        {
            List = new CustomCheckedListBox();
            SuspendLayout();
            // 
            // cclb
            // 
            List.BorderStyle = BorderStyle.None;
            List.Dock = DockStyle.Fill;
            List.FormattingEnabled = true;
            List.Location = new System.Drawing.Point(0, 0);
            List.Name = "List";
            List.Size = new System.Drawing.Size(47, 15);
            List.TabIndex = 0;
            // 
            // Dropdown
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Menu;
            ClientSize = new System.Drawing.Size(47, 16);
            ControlBox = false;
            Controls.Add(List);
            ForeColor = System.Drawing.SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            Name = "_ccbParent";
            StartPosition = FormStartPosition.Manual;
            ResumeLayout(false);
        }

        public string GetCheckedItemsStringValue()
        {
            var sb = new StringBuilder("");
            for (var i = 0; i < List.CheckedItems.Count; i++)
            {
                sb.Append(List.GetItemText(List.CheckedItems[i])).Append(_ccbParent.ValueSeparator);
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - _ccbParent.ValueSeparator.Length, _ccbParent.ValueSeparator.Length);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Closes the dropdown portion and enacts any changes according to the specified boolean parameter.
        /// NOTE: even though the caller might ask for changes to be enacted, this doesn't necessarily mean
        ///       that any changes have occurred as such. Caller should check the ValueChanged property of the
        ///       CheckedComboBox (after the dropdown has closed) to determine any actual value changes.
        /// </summary>
        /// <param name="enactChanges"></param>
        public void CloseDropdown(bool enactChanges)
        {
            if (_dropdownClosed)
            {
                return;
            }
            Debug.WriteLine("CloseDropdown");
            // Perform the actual selection and display of checked items.
            if (enactChanges)
            {
                _ccbParent.SelectedIndex = -1;
                // Set the text portion equal to the string comprising all checked items (if any, otherwise empty!).
                _ccbParent.Text = GetCheckedItemsStringValue();

            }
            else
            {
                // Caller cancelled selection - need to restore the checked items to their original state.
                for (var i = 0; i < List.Items.Count; i++)
                {
                    List.SetItemChecked(i, _checkedStateArr[i]);
                }
            }
            // From now on the dropdown is considered closed. We set the flag here to prevent OnDeactivate() calling
            // this method once again after hiding this window.
            _dropdownClosed = true;
            // Set the focus to our parent CheckedComboBox and hide the dropdown check list.
            _ccbParent.Focus();
            Hide();
            // Notify CheckedComboBox that its dropdown is closed. (NOTE: it does not matter which parameters we pass to
            // OnDropDownClosed() as long as the argument is CheckComboBoxEventArgs so that the method knows the notification has
            // come from our code and not from the framework).
            _ccbParent.OnDropDownClosedProxy(new CheckComboBoxEventArgs(null, false));
        }

        protected override void OnActivated(EventArgs e)
        {
            Debug.WriteLine("OnActivated");
            base.OnActivated(e);
            _dropdownClosed = false;
            // Assign the old string value to compare with the new value for any changes.
            _oldStrValue = _ccbParent.Text;
            // Make a copy of the checked state of each item, in cace caller cancels selection.
            _checkedStateArr = new bool[List.Items.Count];
            for (var i = 0; i < List.Items.Count; i++)
            {
                _checkedStateArr[i] = List.GetItemChecked(i);
            }
        }

        internal void OnDeactivateProxy(EventArgs e)
        {
            OnDeactivate(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            Debug.WriteLine("OnDeactivate");
            base.OnDeactivate(e);
            var ce = e as CheckComboBoxEventArgs;
            if (ce != null)
            {
                CloseDropdown(ce.AssignValues);
            }
            else
            {
                // If not custom event arguments passed, means that this method was called from the
                // framework. We assume that the checked values should be registered regardless.
                CloseDropdown(true);
            }
        }

        private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _ccbParent.OnItemCheck(sender, e);
        }
        
    } // end internal class Dropdown
}