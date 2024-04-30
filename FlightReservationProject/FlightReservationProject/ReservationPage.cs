﻿using System;
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
        public ReservationPage(PlaneFlight flight, Reservation order)
        {
            this.order = order;
            this.flight = flight;
            InitializeComponent();

            messageTimer = new Timer();
            messageTimer.Interval = 3000;
            messageTimer.Tick += MessageTimer_Tick;
        }

        private void ReservationPage_Load(object sender, EventArgs e)
        {
            lblAirline.Text = flight.Airline;
            lblFlightCode.Text = flight.FlightNumber;
            lblClass.Text = order.FlightClass.Name;
            lblFrom.Text = flight.FromCity.Name;
            lblTo.Text = flight.ToCity.Name;
            lblTimeDepart.Text = flight.Depart.ToString("HH:mm");
            lblTimeArrival.Text = flight.Arrival.ToString("HH:mm");
            lblDate.Text = flight.Depart.ToString("dddd, dd MMMM yyyy");

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
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            UnselectControl();
            btnTransfer.BackColor = Color.LightGray;
            btnTransfer.TextColor = Color.Black;
            label29.Text = "1. Choose Other transaction go to";
        }

        private void btnOnlineBank_Click(object sender, EventArgs e)
        {
            UnselectControl();
            btnOnlineBank.BackColor = Color.LightGray;
            btnOnlineBank.TextColor = Color.Black;
            label29.Text = "1. Choose m-Transfer go to";
            lblAccNum.Text = "122209876";
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
            lblChildPrice.Text = "IDR " + childPrice.ToString("C2");
            lblBabyPrice.Text = "IDR " + babyPrice.ToString("C2");

            int total = adultPrice + childPrice + babyPrice;
            lblTotal.Text = "IDR " + total.ToString("C2");
            pnlDetail.Visible = true;
        }

        private void lblBackToInfo_Click(object sender, EventArgs e)
        {
            pnlInformation.Visible = true;
            pnlDetail.Visible = false;
        }
        private Passenger SavePassengerInformation()
        {
            if (txtFullname.Text != "" && cbTitle.Text != "" && txtMobileNumber.Text != "")
            {
                Passenger p = new Passenger(txtFullname.Text, flight, order.User, "adult", cbTitle.Text, lblCode.Text + "-" + txtMobileNumber.Text, (Country)cbBornIn.SelectedItem, dtpDob.Value);
                return p;
            }
            else return null;
        }
        private void lblNext_Click(object sender, EventArgs e)
        {
            passengers[currIndex] = SavePassengerInformation();
            
            if (currIndex<ageTypes.Length-1)currIndex += 1;
            UpdatePassengerField();
        }
        private void UpdatePassengerField()
        {
            string info = "";
            if (ageTypes[currIndex] == "Adult") info = "Enter " + ageTypes[currIndex] + " " + (currIndex+1) + " Information";
            else if (ageTypes[currIndex] == "Child") info = "Enter " + ageTypes[currIndex] + " " + (currIndex+1 - order.Adult) + " Information";
            else if (ageTypes[currIndex] == "Baby") info = "Enter " + ageTypes[currIndex] + " " + (currIndex+1 - order.Adult - order.Child) + " Information";

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
                if (currPass.PhoneNumber != "") txtMobileNumber.Text = currPass.PhoneNumber.Split('-')[1];
            }
            else
            {
                cbTitle.Text= "";
                cbTitle.SelectedIndex = -1;
                txtFullname.Text = "";
                dtpDob.Value = DateTime.Now;
                txtMobileNumber.Text = "";
            }
        }
        private void lblBack_Click(object sender, EventArgs e)
        {
            passengers[currIndex] = SavePassengerInformation();

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
    }
}
