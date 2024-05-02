using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationProject
{
    public partial class BankAccountPage : Form
    {
        bool isUpdate = false;
        BankAccount acc;
        public BankAccountPage(BankAccount acc, bool isUpdate)
        {
            this.isUpdate = isUpdate;
            this.acc = acc;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccNum.Text!="" && txtCVV.Text!="" && txtExpiredDate.Text!="")
            {
                int month = int.Parse(txtExpiredDate.Text.Split('/')[0]);
                int year = int.Parse(txtExpiredDate.Text.Split('/')[1]);
                BankAccount b = new BankAccount(txtAccNum.Text, txtCVV.Text, new DateTime(year,month,1), activeUser);

                int rowsAffected = 0;
                if (isUpdate) rowsAffected = b.UpdateAccount(aes);
                else rowsAffected = b.AddToDB(aes);

                if (rowsAffected > 0)
                {
                    string info = "saved";
                    if (isUpdate) info = "updated";
                    MessageBox.Show("Succesfully " + info + " the bank account details!");
                }
                else
                {
                    MessageBox.Show("Unknown error occured!");
                }
                ReservationPage p = (ReservationPage)this.Owner;
                p.btnTransfer_Click(sender, e);
                this.Owner.Show();
                this.Close();
            }
        }
        AES aes;
        User activeUser;
        private void BankAccountPage_Load(object sender, EventArgs e)
        {
            ReservationPage p = (ReservationPage)this.Owner;
            this.aes = p.aes;
            activeUser = p.activeUser;

            if (isUpdate)
            {
                txtAccNum.Enabled = false;
                btnSave.Text = "UPDATE";
                string num = acc.GetNumberFromToken(aes);
                txtAccNum.Text = "xxxx xxxx xxx" + num.Substring(num.Length - 3); ;
                txtCVV.Text = acc.Cvv;
                txtExpiredDate.Text = acc.DateExpire.ToString("MM/yy");
            }
            else 
            {
                txtAccNum.Enabled = true;
                btnSave.Text = "SAVE";
                txtAccNum.Text = "";
                txtCVV.Text = "";
                txtExpiredDate.Text = "";
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            pbOpen.BringToFront();
            txtCVV.PasswordChar = '\0';
        }

        private void pbOpen_Click(object sender, EventArgs e)
        {
            txtCVV.PasswordChar = '•';
            pbClose.BringToFront();
        }
    }
}
