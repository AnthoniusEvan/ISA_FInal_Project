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
    public partial class ReservationPage : Form
    {
        PlaneFlight flight;
        Reservation order;
        private Timer messageTimer;
        Passenger[] passengers;
        string[] ageTypes;
        int currIndex;
        public User activeUser;
        public ReservationPage(PlaneFlight flight, Reservation order)
        {
            this.order = order;
            this.flight = flight;
            InitializeComponent();

            messageTimer = new Timer();
            messageTimer.Interval = 3000;
            messageTimer.Tick += MessageTimer_Tick;
        }
        public AES aes;
        private void ReservationPage_Load(object sender, EventArgs e)
        {
            FlightPage p = (FlightPage)this.Owner;
            this.aes = p.aes;
            activeUser = p.activeUser;
            lblAirline.Text = flight.Airline;
            lblFlightCode.Text = flight.FlightNumber;
            lblClass.Text = order.FlightClass.Name;
            lblFrom.Text = flight.FromCity.Name;
            lblTo.Text = flight.ToCity.Name;
            lblTimeDepart.Text = flight.Depart.ToString("HH:mm");
            lblTimeArrival.Text = flight.Arrival.ToString("HH:mm");
            lblDate.Text = flight.Depart.ToString("dddd, dd MMMM yyyy");

            if (order.getTotalPassengers() == 1) lblNext.Visible = false;
            passengers = new Passenger[order.getTotalPassengers()];
            ageTypes = new string[order.getTotalPassengers()];

            for (int i = 0; i < order.Adult; i++)
            {
                ageTypes[i] = "Adult";
            }
            for (int i = order.Adult; i < order.Child+order.Adult; i++)
            {
                ageTypes[i] = "Child";
            }
            for (int i = order.Adult+order.Child; i < order.getTotalPassengers(); i++)
            {
                ageTypes[i] = "Baby";
            }

            cbBornIn.DataSource = Country.GetCountries();
            cbBornIn.DisplayMember = "Name";
            cbBornIn.ValueMember = "Id";
            cbBornIn.SelectedIndex = -1;
            currIndex = 0;

            pnlInformation.BringToFront();
        }
        List<BankAccount> accounts;
        public void btnTransfer_Click(object sender, EventArgs e)
        {
            UnselectControl();
            btnTransfer.BackColor = Color.LightGray;
            btnTransfer.TextColor = Color.Black;
            pnlTransferbank.BringToFront();

            accounts = BankAccount.GetBankAccounts(activeUser, aes);
            if (accounts == null) return;
            pnlAccounts.Controls.Clear();
            for (int i=0;i<accounts.Count;i++)
            {
                DisplayBankAccount(accounts[i],i);
            }
        }
        private void DisplayBankAccount(BankAccount b, int index)
        {
            Panel pnlAcc = new Panel();
            PictureBox btnEdit = new PictureBox();
            Label lblBankNum = new Label();
            // 
            // pnlAcc
            // 
            pnlAcc.Controls.Add(btnEdit);
            pnlAcc.Controls.Add(lblBankNum);
            pnlAcc.Dock = System.Windows.Forms.DockStyle.Top;
            pnlAcc.Location = new System.Drawing.Point(0, 0);
            pnlAcc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnlAcc.Name = "pnlAcc";
            pnlAcc.Size = new System.Drawing.Size(149, 24);
            pnlAcc.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.Image = global::FlightReservationProject.Properties.Resources.image_removebg_preview___2024_05_02T005020_720;
            btnEdit.Location = new System.Drawing.Point(110, 4);
            btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(15,15);
            btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            btnEdit.TabIndex = 107;
            btnEdit.TabStop = false;
            btnEdit.Tag = index;
            btnEdit.Click += new System.EventHandler(btnEdit_Click);
            // 
            // lblBankNum
            // 
            lblBankNum.AutoSize = true;
            lblBankNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblBankNum.Location = new System.Drawing.Point(7, 7);
            lblBankNum.Name = "lblBankNum";
            lblBankNum.Size = new System.Drawing.Size(148, 18);
            lblBankNum.TabIndex = 106;
            string num = b.GetNumberFromToken(aes);
            lblBankNum.Text = "xxxx xxxx xxxx x" + num.Substring(num.Length-3);

            pnlAccounts.Controls.Add(pnlAcc);
            pnlAccounts.Controls.SetChildIndex(pnlAcc, 0);
        }

        private void btnOnlineBank_Click(object sender, EventArgs e)
        {
            UnselectControl();

            btnOnlineBank.BackColor = Color.LightGray;
            btnOnlineBank.TextColor = Color.Black;
            pnlOnlineBanking.BringToFront();
        }
        private void UnselectControl()
        {
            btnOnlineBank.BackColor = Color.White;
            btnTransfer.BackColor = Color.White;
            btnOnlineBank.TextColor = Color.DimGray;
            btnTransfer.TextColor = Color.DimGray;
        }

        private void CopyIcon_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblAccNum.Text);
            lblMessage.Text = "Text has been copied!";
            messageTimer.Start();
        }
        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            messageTimer.Stop();
            lblMessage.Text = "";
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (order.getTotalPassengers() > 1)
                index = order.getTotalPassengers()-1;

            string error = "";
            Passenger pass = SavePassengerInformation(out error);
            if (error == "")
                passengers[index] = pass;
            else
            {
                MessageBox.Show(error, "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            bool canContinue = true;
            foreach (Passenger p in passengers)
            {
                if (p == null) canContinue = false;
            }

            if (canContinue)
            {
                pnlInformation.Visible = false;

                lblDepartureDate.Text = order.DateDepart.ToString("dddd, dd MMMM yyyy");
                lblAirlineName.Text = flight.Airline;
                lblFlightNum.Text = flight.FlightNumber;
                lblClassPayment.Text = order.FlightClass.Name;
                lblOri.Text = flight.FromCity.Name;
                lblDes.Text = flight.ToCity.Name;
                lblTimeFrom.Text = flight.Depart.ToString("HH:mm");
                lblTimeTo.Text = flight.Arrival.ToString("HH:mm");
                lblAdult.Text = order.Adult + "x Adult";
                if (order.Adult > 1) lblAdult.Text += "s";

                if (order.Child > 1) lblChild.Text = order.Child + "x Children";
                else if (order.Child == 1) lblChild.Text = "1x Child";
                else lblChild.Text = "";

                if (order.Baby > 1) lblBaby.Text = order.Baby + "x Babies";
                else if (order.Baby == 1) lblBaby.Text = "1x Baby";
                else lblBaby.Text = "";

                int adultPrice = flight.Price * order.Adult;
                int childPrice = (int)(flight.Price * 0.8 * order.Child);
                int babyPrice = (int)(flight.Price * 0.5 * order.Baby);


                lblAdultPrice.Text = "IDR " + adultPrice.ToString("C2");
                if (childPrice != 0) lblChildPrice.Text = "IDR " + childPrice.ToString("C2");
                else lblChildPrice.Text = "";
                if (babyPrice != 0) lblBabyPrice.Text = "IDR " + babyPrice.ToString("C2");
                else lblBabyPrice.Text = "";

                int total = adultPrice + childPrice + babyPrice;
                lblTotal.Text = "IDR " + total.ToString("C2");
                pnlDetail.Visible = true;
            }
            else
            {
                MessageBox.Show("Please finish filling up the passenger's details!", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblBackToInfo_Click(object sender, EventArgs e)
        {
            pnlInformation.Visible = true;
            pnlDetail.Visible = false;
        }
        private Passenger SavePassengerInformation(out string error)
        {
            if (ageTypes[currIndex] == "Adult" && txtFullname.Text != "" && txtMobileNumber.Text != "" && cbBornIn.SelectedIndex != -1)
            {
                Passenger p = new Passenger(txtFullname.Text, flight, order.User, "Adult", cbTitle.Text, lblCode.Text + "-" + txtMobileNumber.Text, (Country)cbBornIn.SelectedItem, dtpDob.Value);
                error = "";
                return p;
            }
            else if (ageTypes[currIndex] != "Adult" && txtFullname.Text != "" && cbBornIn.SelectedIndex != -1)
            {
                Passenger p = new Passenger(txtFullname.Text, flight, order.User, ageTypes[currIndex], cbTitle.Text, (Country)cbBornIn.SelectedItem, dtpDob.Value);
                error = "";
                return p;
            }
            else
            {
                if (txtFullname.Text == "") error = "Please fill in the passenger's name!";
                else if (cbBornIn.SelectedValue == null) error = "Please select the passenger's nationality based on the available options!";
                else if (ageTypes[currIndex] == "Adult" && txtMobileNumber.Text == "") error = "Pleaser provide the mobile number owned by " + txtFullname.Text + "!";
                else error = "An error occured!";
                return null;
            }
        }
        private void lblNext_Click(object sender, EventArgs e)
        {
            string error="";
            passengers[currIndex] = SavePassengerInformation(out error);
            if (error!="")
            {
                MessageBox.Show(error, "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (currIndex<ageTypes.Length-1)currIndex += 1;
            UpdatePassengerField();
        }
        private void UpdatePassengerField()
        {
            string info = "";
            
            if (ageTypes[currIndex] == "Adult")
            {
                info = "Enter " + ageTypes[currIndex] + " " + (currIndex + 1) + " Information";
            }
            else if (ageTypes[currIndex] == "Child")
            {
                info = "Enter " + ageTypes[currIndex] + " " + (currIndex + 1 - order.Adult) + " Information";
            }
            else if (ageTypes[currIndex] == "Baby")
            {
                info = "Enter " + ageTypes[currIndex] + " " + (currIndex + 1 - order.Adult - order.Child) + " Information";
            }

            lblInformation.Text = info;
            if (ageTypes[currIndex]=="Adult")
            {
                lblCode.Visible = true;
                txtMobileNumber.Visible = true;
                lblPhoneNumber.Visible = true;
            }
            else
            {
                lblCode.Visible = false;
                txtMobileNumber.Visible = false;
                lblPhoneNumber.Visible = false;
            }


            if (currIndex == 0) lblBack.Visible = false;
            else if (currIndex == ageTypes.Length - 1) lblNext.Visible = false;
            else
            {
                lblBack.Visible = true;
                lblNext.Visible = true;
            }

            Passenger currPass = passengers[currIndex];
            if (currPass != null)
            {
                cbTitle.SelectedIndex = cbTitle.FindStringExact(currPass.Title);
                txtFullname.Text = currPass.FullName;
                cbBornIn.SelectedValue = currPass.BornIn.Id;
                dtpDob.Value = currPass.Dob;
                if (ageTypes[currIndex]=="Adult"&&currPass.PhoneNumber != "") txtMobileNumber.Text = currPass.PhoneNumber.Split('-')[1];
            }
            else
            {
                cbTitle.Text= "";
                cbTitle.SelectedIndex = -1;
                txtFullname.Text = "";
                dtpDob.Value = dtpDob.MaxDate;
                txtMobileNumber.Text = "";
            }
        }
        private void lblBack_Click(object sender, EventArgs e)
        {
            string error = "";
            passengers[currIndex] = SavePassengerInformation(out error);
            if (error != "")
            {
                MessageBox.Show(error, "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (currIndex>0) currIndex -= 1;
            UpdatePassengerField();
        }

        private void lblFill_Click(object sender, EventArgs e)
        {
            cbTitle.SelectedIndex = 0;
            txtFullname.Text = order.User.FullName;
            cbBornIn.SelectedValue = order.User.FromCity.FromCountry.Id;
            dtpDob.Value = order.User.BirthDate;
            txtMobileNumber.Text = order.User.MobileNumber.Split('-')[1];
            lblFill.Visible = false;
        }

        private void cbBornIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBornIn.SelectedIndex == -1)
            {
                lblCode.Text = "+__";
                return;
            }
            lblCode.Text = "+" + ((Country)cbBornIn.SelectedItem).DialingCode;
            txtMobileNumber.Left = lblCode.Right + 5;
            txtMobileNumber.Width = txtFullname.Right - txtMobileNumber.Left;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int rowsAffected = order.AddReservation(passengers.ToList(), aes);
            if (rowsAffected > 0)
            {
                ConfirmarionPage p = new ConfirmarionPage();
                p.Owner = this;
                p.Show();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }

        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            BankAccountPage p = new BankAccountPage(null, false);
            p.Owner = this;
            p.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PictureBox b = (PictureBox)sender;
            int i = int.Parse(b.Tag.ToString());
            BankAccountPage p = new BankAccountPage(accounts[i], true);
            p.Owner = this;
            p.Show();
        }
    }
}
