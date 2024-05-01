using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationProject
{
    public partial class CheckInPage : Form
    {
        User activeUser;
        Reservation ticket;
        bool[] checkedIn;
        private PrintDocument printDocument = new PrintDocument();
        public CheckInPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnToCheckin_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text=="")
            {
                MessageBox.Show("Please fill in your full name!");
                return;
            }
            if (txtTicketNum.Text == "")
            {
                MessageBox.Show("Please fill in the e-ticket number!");
                return;
            }
            ticket = activeUser.CheckIn(txtTicketNum.Text, txtFullname.Text, aes);

            if (ticket == null)
            {
                MessageBox.Show("Full name or E-ticket number not found!");
            }
            else
            {
                startingPanel.Visible = false;
                lblAirline.Text = ticket.FlightChosen.Airline;
                lblFlightNum.Text = ticket.FlightChosen.FlightNumber;
                lblFrom.Text = ticket.FromCity.Name;
                lblTo.Text = ticket.ToCity.Name;
                lblDepart.Text = ticket.DateDepart.ToString("HH:mm");
                lblArriv.Text = ticket.DateArrival.ToString("HH:mm");
                lblDate.Text = ticket.DateDepart.ToString("dddd, dd MMMM yyyy");
                
                checkedIn = new bool[ticket.ListOfPassengers.Count];
                foreach(Passenger p in ticket.ListOfPassengers)
                {
                    p.Seat = BoardingPass.GenerateRandomSeat();
                    DisplayPassenger(p);
                }
                pnlCheckin.BringToFront();
            }
        }

        private void cbCheckedIn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                cb.Text = "Checked In";
                checkedIn[(int)(cb.Tag)] = true;
            }
            else
            {
                cb.Text = "Not Checked In";
                checkedIn[(int)(cb.Tag)] = false;
            }
        }
        private void DisplayPassenger(Passenger p)
        {
            Label lblName = new Label();
            CheckBox cbCheckedIn = new CheckBox();
            Label lblSeat = new Label();
            Panel pnlPassenger = new Panel();
            pnlPassengers.SuspendLayout();
            pnlPassenger.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPassenger
            // 
            pnlPassenger.Controls.Add(cbCheckedIn);
            pnlPassenger.Controls.Add(lblSeat);
            pnlPassenger.Controls.Add(lblName);
            pnlPassenger.Dock = System.Windows.Forms.DockStyle.Top;
            pnlPassenger.Location = new System.Drawing.Point(0, 0);
            pnlPassenger.Name = "pnlPassenger";
            pnlPassenger.Size = new System.Drawing.Size(547, 22);
            pnlPassenger.TabIndex = 172;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblName.Location = new System.Drawing.Point(4, 5);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(90, 22);
            lblName.TabIndex = 165;
            if (p.Title != "") lblName.Text = p.Title + ". " + p.FullName;
            else lblName.Text = p.FullName;
            // 
            // cbCheckedIn
            // 
            cbCheckedIn.AutoSize = true;
            cbCheckedIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            cbCheckedIn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            cbCheckedIn.Location = new System.Drawing.Point(159, 3);
            cbCheckedIn.Name = "cbCheckedIn";
            cbCheckedIn.Size = new System.Drawing.Size(159, 26);
            cbCheckedIn.TabIndex = 171;
            cbCheckedIn.Text = "Not Checked In";
            cbCheckedIn.UseVisualStyleBackColor = true;
            cbCheckedIn.Tag = int.Parse(p.Id) - 1;
            cbCheckedIn.CheckedChanged += new System.EventHandler(cbCheckedIn_CheckedChanged);
            if (Passenger.IsCheckedIn(p.Id, ticket.FlightChosen.FlightNumber))
            {
                cbCheckedIn.Checked = true;
                cbCheckedIn.Enabled = false;
            }
            else
            {
                cbCheckedIn.Checked = false;
                cbCheckedIn.Enabled = true;
            }
            // 
            // lblSeat
            // 
            lblSeat.AutoSize = true;
            lblSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSeat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblSeat.Location = new System.Drawing.Point(325, 4);
            lblSeat.Name = "lblSeat";
            lblSeat.Size = new System.Drawing.Size(42, 22);
            lblSeat.TabIndex = 168;
            lblSeat.Text = p.Seat;

            pnlPassengers.ResumeLayout(false);
            pnlPassenger.ResumeLayout(false);
            pnlPassenger.PerformLayout();
            ResumeLayout(false);
            pnlPassengers.Controls.Add(pnlPassenger);
            pnlPassengers.Controls.SetChildIndex(pnlPassenger, 0);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            pnlCheckedIns.Controls.Clear();
            lblInfo.Text = "Please print your document";
            pnlPrintBoardingPass.Visible = true;
            pnlPrintBoardingPass.Controls.Add(lblInfo);
            pnlPrintBoardingPass.Controls.Add(line);
            pnlPrintBoardingPass.Controls.Add(pnlTicket);
            pnlPrintBoardingPass.Controls.Add(lblPassName);
            pnlPrintBoardingPass.Controls.Add(lblCheckInStatus);
            pnlPrintBoardingPass.Controls.Add(lblClass);

            for (int i=0; i < checkedIn.Length; i++){
                if (checkedIn[i]) DisplayCheckedIn(ticket.ListOfPassengers[i]);
            }

            pnlPrintBoardingPass.BringToFront();
            pnlCheckin.Visible = false;
        }
        AES aes;
        private void CheckInPage_Load(object sender, EventArgs e)
        {
            DashboardPage p = (DashboardPage)this.Owner;
            this.activeUser = p.activeUser;
            this.aes = p.aes;
            startingPanel.BringToFront();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            pnlCheckin.Visible = true;
            lblInfo.Text = "Please check and confirm the information about passengers and flight ";
            pnlCheckin.Controls.Add(lblInfo);
            pnlCheckin.Controls.Add(line);
            pnlCheckin.Controls.Add(pnlTicket);
            pnlCheckin.Controls.Add(lblPassName);
            pnlCheckin.Controls.Add(lblCheckInStatus);
            pnlCheckin.Controls.Add(lblClass);
            pnlCheckin.BringToFront();
            pnlPrintBoardingPass.Visible = false;
        }

        private void DisplayCheckedIn(Passenger p)
        {
            if (Passenger.IsCheckedIn(p.Id, ticket.FlightChosen.FlightNumber))
            {
                return;
            }


            Panel pnlCheckedIn = new Panel();
            Label lblName = new Label();
            Button btnPrint = new Button();
            Label lblStatus = new Label();
            // 
            // pnlCheckedIn
            // 
            pnlCheckedIn.Controls.Add(btnPrint);
            pnlCheckedIn.Controls.Add(lblName);
            pnlCheckedIn.Controls.Add(lblStatus);
            pnlCheckedIn.Dock = System.Windows.Forms.DockStyle.Top;
            pnlCheckedIn.Location = new System.Drawing.Point(0, 0);
            pnlCheckedIn.Name = "pnlCheckedIn";
            pnlCheckedIn.Size = new System.Drawing.Size(546, 30);
            pnlCheckedIn.TabIndex = 177;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblName.Location = new System.Drawing.Point(0, 6);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(100, 24);
            lblName.TabIndex = 165;
            if (p.Title != "") lblName.Text = p.Title + ". " + p.FullName;
            else lblName.Text = p.FullName;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblStatus.Location = new System.Drawing.Point(155, 6);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(100, 24);
            lblStatus.TabIndex = 167;
            lblStatus.Text = "Checked In";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnPrint.ForeColor = System.Drawing.Color.White;
            btnPrint.Location = new System.Drawing.Point(465, 5);
            btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(65,25);
            btnPrint.TabIndex = 152;
            btnPrint.Text = "Print";
            btnPrint.Tag = int.Parse(p.Id)-1;
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += BtnPrint_Click;

            pnlCheckedIns.Controls.Add(pnlCheckedIn);
            pnlCheckedIns.Controls.SetChildIndex(pnlCheckedIn, 0);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int passengerId = int.Parse(b.Tag.ToString());

            BoardingPass pass = BoardingPass.GetBoardingPass(ticket.ListOfPassengers[passengerId], ticket.FlightChosen.FlightNumber, aes);
            if (pass == null)
            { 
                pass = new BoardingPass(ticket.FlightClass, ticket.FlightChosen.FlightNumber, ticket.ListOfPassengers[passengerId], aes);
            }// automatically store in db

            PrintBoardingPass p = new PrintBoardingPass();
            
            ticket = activeUser.CheckIn(txtTicketNum.Text, txtFullname.Text, aes);
            p.lblName.Text = ticket.ListOfPassengers[passengerId].FullName;
            p.passenger.Text = p.lblName.Text;
            p.lblSeat.Text = pass.Seat;
            p.seat.Text = pass.Seat;
            p.lblGate.Text = pass.Gate;
            p.airplane.Text = ticket.FlightChosen.Airline;
            p.lblFlightNum.Text = ticket.FlightChosen.FlightNumber;
            p.lblOrigin.Text = ticket.FromCity.Name;
            p.lblDestination.Text = ticket.ToCity.Name;
            p.lblDepartureTime.Text = ticket.DateDepart.ToString("HH:mm");
            DateTime boardingTime = ticket.DateDepart.AddMinutes(-30);
            p.lblBoardingTime.Text = boardingTime.ToString("HH:mm"); ;
            p.lblClass.Text = ticket.FlightClass.Name;
            p.lblDate.Text = ticket.DateDepart.ToString("dd MMMM yyyy");
            p.lblFrom.Text = ticket.FromCity.Name;
            p.lblTo.Text = ticket.ToCity.Name;
            p.flightNum.Text = ticket.FlightChosen.FlightNumber;
            p.date.Text = ticket.DateDepart.ToString("dd MMMM yyyy");
            p.arrival.Text = ticket.DateArrival.ToString("HH:mm");
            p.boardingTime.Text = boardingTime.ToString("HH:mm");
            p.boardingPassId.Text = ticket.TicketNum + passengerId;
            p.Show();
            p.Visible = false;
            PrintForm(p);
        }
        private void PrintForm(Form form)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    Bitmap bitmap = new Bitmap(form.Width, form.Height);
                    form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
                    printDocument.PrintPage += (s, ev) =>
                    {
                        ev.Graphics.DrawImage(bitmap, Point.Empty);
                    };
                    printDocument.Print();
                }
            }
        }
    }
}
