using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

public class ConnectDialog : Form
{
    public string Host => txtHost.Text;
    public int Port => int.TryParse(txtPort.Text, out var p) ? p : 80;
    public string Username => txtUser.Text;
    public string Password => txtPass.Text;

    private TextBox txtHost, txtPort, txtUser, txtPass;

    public ConnectDialog()
    {
        this.Text = "Подключение к ONVIF";
        this.Size = new System.Drawing.Size(300, 200);
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 5, ColumnCount = 2 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

        layout.Controls.Add(new Label { Text = "Host:" }, 0, 0);
        layout.Controls.Add(txtHost = new TextBox { Text = "192.168.1.100" }, 1, 0);

        layout.Controls.Add(new Label { Text = "Port:" }, 0, 1);
        layout.Controls.Add(txtPort = new TextBox { Text = "80" }, 1, 1);

        layout.Controls.Add(new Label { Text = "User:" }, 0, 2);
        layout.Controls.Add(txtUser = new TextBox { Text = "admin" }, 1, 2);

        layout.Controls.Add(new Label { Text = "Password:" }, 0, 3);
        layout.Controls.Add(txtPass = new TextBox { UseSystemPasswordChar = true }, 1, 3);

        var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK };
        layout.Controls.Add(btnOK, 1, 4);

        this.Controls.Add(layout);
        this.AcceptButton = btnOK;
    }
}
