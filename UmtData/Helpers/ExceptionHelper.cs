using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UmtData.Data;

namespace UmtData.Helpers
{
    public static class ExceptionHelper
    {
        public static void ShowException(Exception ex, string additional = "")
        {
            MessageBox.Show(ex.Message + "\n" + additional, "Ошибка");
        }

        public static void ShowException(TextBox errorTextBox, Exception ex, bool addToExist = false, string additional = "", int limitTextSize = 0)
        {
            if (errorTextBox == null)
                ShowException(ex);
            else
            {
                if (addToExist)
                {
                    var s = new StringBuilder();
                    s.AppendLine();
                    if (!string.IsNullOrWhiteSpace(additional))
                        s.AppendLine(additional);
                    if (ex != null)
                        s.AppendLine(ex.Message);
                    if (limitTextSize > 0 && errorTextBox.Text.Length > limitTextSize)
                    {
                        errorTextBox.Text = errorTextBox.Text.RemoveLines(2);
                    }
                    errorTextBox.AppendText(s.ToString());
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(additional))
                        errorTextBox.Text = additional + "\n" + ex.Message;
                    else
                        errorTextBox.Text = ex.Message;
                }
            }
        }

        public static string RemoveLines(this string s, int countOfLines)
        {
            return string.Join(Environment.NewLine, 
                s.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(countOfLines)
                .ToArray());
        }
    }
}