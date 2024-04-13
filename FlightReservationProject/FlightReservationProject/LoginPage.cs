using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationProject
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            // for database connection purposes

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Kalau mau pake hapus "//" yang ada di bawah 

            config.AppSettings.Settings["DbPassword"].Value = "";
            //config.AppSettings.Settings["DbPassword"].Value = "root";


            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = User.ValidateLogin(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                DashboardPage dp = new DashboardPage();
                dp.Owner = this;
                dp.Show();
                this.Hide();
            }
            else
            {
                txtPassword.Text = "";
                lblWrong.Visible = true;
            }
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked) txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '•';
        }

        private void lblCreateAcc_Click(object sender, EventArgs e)
        {
            RegisterPage p = new RegisterPage();
            p.Owner = this;
            p.Show();
            this.Hide();
        }

        private void cbShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            cbShowPass.Checked = false;
        }

        private void cbShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            cbShowPass.Checked = true;
        }
    }
}
