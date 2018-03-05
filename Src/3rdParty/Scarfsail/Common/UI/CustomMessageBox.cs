using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scarfsail.Common.UI
{
    public partial class CustomMessageBox : Form
    {
        private CustomMessageBox()
        {
            InitializeComponent();
        }

        public static void Show(string html, string caption, MessageBoxIcon icon)
        {
            Show(html, caption, icon, new Size(490,275));
        }

        public static void Show(string html, string caption, MessageBoxIcon icon, Size size)
        {
            using (CustomMessageBox dlg = new CustomMessageBox())
            {
                Form mainForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
                dlg.textBox1.Text = html;
                dlg.Text = caption;
                switch (icon)
                {
                    case MessageBoxIcon.Information:
                        dlg.iconImage.Image = SystemIcons.Information.ToBitmap();
                        break;
                    case MessageBoxIcon.Error:
                        dlg.iconImage.Image = SystemIcons.Error.ToBitmap();
                        break;
                    case MessageBoxIcon.Question:
                        dlg.iconImage.Image = SystemIcons.Question.ToBitmap();
                        break;
                    case MessageBoxIcon.Warning:
                        dlg.iconImage.Image = SystemIcons.Warning.ToBitmap();
                        break;
                    case MessageBoxIcon.None:                        
                        break;
                    default:
                        break;
                }
                if (size.Width > Screen.PrimaryScreen.WorkingArea.Width)
                    size = new Size(Screen.PrimaryScreen.WorkingArea.Width, size.Height);

                if (size.Height > Screen.PrimaryScreen.WorkingArea.Height)
                    size = new Size(size.Width, Screen.PrimaryScreen.WorkingArea.Height);

                dlg.Size = size;

                dlg.ShowDialog(mainForm);

            }
        }
    }
}
