using System.Diagnostics;
using System.Windows.Forms;

namespace UmtControls.CheckedComboBox
{
    // ---------------------------------- internal class CustomCheckedListBox --------------------------------------------

    /// <summary>
    /// A custom CheckedListBox being shown within the dropdown form representing the dropdown list of the CheckedComboBox.
    /// </summary>
    internal class CustomCheckedListBox : CheckedListBox
    {
        private int _curSelIndex = -1;

        public CustomCheckedListBox()
        {
            SelectionMode = SelectionMode.One;
            HorizontalScrollbar = true;
        }

        /// <summary>
        /// Intercepts the keyboard input, [Enter] confirms a selection and [Esc] cancels it.
        /// </summary>
        /// <param name="e">The Key event arguments</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enact selection.
                ((Dropdown)Parent).OnDeactivateProxy(new CheckComboBoxEventArgs(null, true));
                e.Handled = true;

            }
            else if (e.KeyCode == Keys.Escape)
            {
                // Cancel selection.
                ((Dropdown)Parent).OnDeactivateProxy(new CheckComboBoxEventArgs(null, false));
                e.Handled = true;

            }
            else if (e.KeyCode == Keys.Delete)
            {
                // Delete unckecks all, [Shift + Delete] checks all.
                for (var i = 0; i < Items.Count; i++)
                {
                    SetItemChecked(i, e.Shift);
                }
                e.Handled = true;
            }
            // If no Enter or Esc keys presses, let the base class handle it.
            base.OnKeyDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var index = IndexFromPoint(e.Location);
            Debug.WriteLine("Mouse over item: " + (index >= 0 ? GetItemText(Items[index]) : "None"));
            if ((index >= 0) && (index != _curSelIndex))
            {
                _curSelIndex = index;
                SetSelected(index, true);
            }
        }

    } // end internal class CustomCheckedListBox
}