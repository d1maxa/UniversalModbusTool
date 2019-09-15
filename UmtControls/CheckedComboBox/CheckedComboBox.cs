using System;
using System.Drawing;
using System.Windows.Forms;

namespace UmtControls.CheckedComboBox
{
    public class CheckedComboBox : ComboBox
    {
        // ******************************** Data ********************************
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.IContainer components = null;
        // A form-derived object representing the drop-down list of the checked combo box.
        private readonly Dropdown _dropdown;

        // The valueSeparator character(s) between the ticked elements as they appear in the 
        // text portion of the CheckedComboBox.
        public string ValueSeparator { get; set; }

        public bool CheckOnClick
        {
            get { return _dropdown.List.CheckOnClick; }
            set { _dropdown.List.CheckOnClick = value; }
        }

        public new string DisplayMember
        {
            get { return _dropdown.List.DisplayMember; }
            set { _dropdown.List.DisplayMember = value; }
        }

        public new CheckedListBox.ObjectCollection Items => _dropdown.List.Items;

        public CheckedListBox.CheckedItemCollection CheckedItems => _dropdown.List.CheckedItems;

        public CheckedListBox.CheckedIndexCollection CheckedIndices => _dropdown.List.CheckedIndices;

        public bool ValueChanged => _dropdown.ValueChanged;

        // Event handler for when an item check state changes.
        public event ItemCheckEventHandler ItemCheck;

        internal void OnItemCheck(object sender, ItemCheckEventArgs e)
        {
            ItemCheck?.Invoke(sender, e);
        }

        // ******************************** Construction ********************************

        public CheckedComboBox()
        {
            // We want to do the drawing of the dropdown.
            DrawMode = DrawMode.OwnerDrawVariable;
            // Default value separator.
            ValueSeparator = ", ";
            // This prevents the actual ComboBox dropdown to show, although it's not strickly-speaking necessary.
            // But including this remove a slight flickering just before our dropdown appears (which is caused by
            // the empty-dropdown list of the ComboBox which is displayed for fractions of a second).
            DropDownHeight = 1;
            // This is the default setting - text portion is editable and user must click the arrow button
            // to see the list portion. Although we don't want to allow the user to edit the text portion
            // the DropDownList style is not being used because for some reason it wouldn't allow the text
            // portion to be programmatically set. Hence we set it as editable but disable keyboard input (see below).
            DropDownStyle = ComboBoxStyle.DropDown;
            _dropdown = new Dropdown(this);
            // CheckOnClick style for the dropdown (NOTE: must be set after dropdown is created).
            CheckOnClick = true;
        }

        // ******************************** Operations ********************************

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            DoDropDown();
        }

        private void DoDropDown()
        {
            if (!_dropdown.Visible)
            {
                var rect = RectangleToScreen(ClientRectangle);
                _dropdown.Location = new Point(rect.X, rect.Y + Size.Height);
                var count = _dropdown.List.Items.Count;
                if (count > MaxDropDownItems)
                {
                    count = MaxDropDownItems;
                }
                else if (count == 0)
                {
                    count = 1;
                }
                _dropdown.Size = new Size(Size.Width, (_dropdown.List.ItemHeight) * count + 2);
                _dropdown.Show(this);
            }
        }

        internal void OnDropDownClosedProxy(EventArgs e)
        {
            OnDropDownClosed(e);
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            // Call the handlers for this event only if the call comes from our code - NOT the framework's!
            // NOTE: that is because the events were being fired in a wrong order, due to the actual dropdown list
            //       of the ComboBox which lies underneath our dropdown and gets involved every time.
            if (e is CheckComboBoxEventArgs)
            {
                base.OnDropDownClosed(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Signal that the dropdown is "down". This is required so that the behaviour of the dropdown is the same
                // when it is a result of user pressing the Down_Arrow (which we handle and the framework wouldn't know that
                // the list portion is down unless we tell it so).
                // NOTE: all that so the DropDownClosed event fires correctly!                
                OnDropDown(null);
            }
            // Make sure that certain keys or combinations are not blocked.
            e.Handled = !e.Alt && e.KeyCode != Keys.Tab &&
                !((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Home) || (e.KeyCode == Keys.End));

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        public bool GetItemChecked(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "value out of range");
            }
            else
            {
                return _dropdown.List.GetItemChecked(index);
            }
        }

        public void SetItemChecked(int index, bool isChecked)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "value out of range");
            }
            else
            {
                _dropdown.List.SetItemChecked(index, isChecked);
                // Need to update the Text.
                Text = _dropdown.GetCheckedItemsStringValue();
            }
        }

        public CheckState GetItemCheckState(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "value out of range");
            }
            else
            {
                return _dropdown.List.GetItemCheckState(index);
            }
        }

        public void SetItemCheckState(int index, CheckState state)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "value out of range");
            }
            else
            {
                _dropdown.List.SetItemCheckState(index, state);
                // Need to update the Text.
                Text = _dropdown.GetCheckedItemsStringValue();
            }
        }

    }
}