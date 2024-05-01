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
        public BankAccountPage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccNum.Text!="" && txtCVV.Text!="" && txtExpiredDate.Text!="")
            {
                int month = int.Parse(txtExpiredDate.Text.Split('/')[0]);
                int year = int.Parse(txtExpiredDate.Text.Split('/')[1]);
                BankAccount b = new BankAccount(txtAccNum.Text, txtCVV.Text, new DateTime(), activeUser);
                b.AddToDB(aes);
            }
        }
        AES aes;
        User activeUser;
        private void BankAccountPage_Load(object sender, EventArgs e)
        {
            ReservationPage p = (ReservationPage)this.Owner;
            this.aes = p.aes;
            activeUser = p.activeUser;
        }
    }
}
