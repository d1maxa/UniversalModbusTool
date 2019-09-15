using System;

namespace UmtControls.CheckedComboBox
{
    // ---------------------------------- internal class CheckComboBoxEventArgs --------------------------------------------
    /// <summary>
    /// Custom EventArgs encapsulating value as to whether the combo box value(s) should be assignd to or not.
    /// </summary>
    internal class CheckComboBoxEventArgs : EventArgs
    {
        public bool AssignValues { get; set; }

        public EventArgs EventArgs { get; set; }

        public CheckComboBoxEventArgs(EventArgs e, bool assignValues)
        {
            EventArgs = e;
            AssignValues = assignValues;
        }
    }
}