using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cachero_Group___Document_Request_System_Project
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 320,
                Height = 170,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblText = new Label()
            {
                Left = 20,
                Top = 20,
                Text = text,
                Width = 260
            };

            TextBox txtInput = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 260,
                UseSystemPasswordChar = true
            };

            Button btnOk = new Button()
            {
                Text = "OK",
                Left = 110,
                Width = 80,
                Top = 85,
                DialogResult = DialogResult.OK
            };

            prompt.Controls.Add(lblText);
            prompt.Controls.Add(txtInput);
            prompt.Controls.Add(btnOk);

            prompt.AcceptButton = btnOk;

            return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : "";
        }
    }
}
