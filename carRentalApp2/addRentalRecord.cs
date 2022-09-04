using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carRentalApp2
{
    public partial class addRentalRecord : Form
    {
        private readonly carRentalEntities1 carRentalEntities;
        public addRentalRecord()
        {
            InitializeComponent();
            carRentalEntities = new carRentalEntities1();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {


                string customerName = tbName.Text;
                var dateOut = dateRented.Value;
                var dateIn = dateReturned.Value;
                var carType = cbTypeOfCar.Text;
                double cost = Convert.ToDouble(tbCost.Text);

                var isValid = true;
                var errorMessage = "";

                if (string.IsNullOrWhiteSpace(customerName) || (string.IsNullOrWhiteSpace(carType)))
                {
                    isValid = false;
                    errorMessage += "Error: Please enter missing data. \n\r";

                }
                if (dateOut > dateIn)
                {
                    isValid = false;
                    errorMessage += "Error: Illegal Date Selection \n\r";
                }
                if (isValid)
                {
                    var rentalrecord = new carRentalRecord();
                    rentalrecord.customerName = customerName;
                    rentalrecord.dateRented = dateOut;
                    rentalrecord.cost = (decimal)cost;
                    rentalrecord.dateReturned = dateIn;
                    rentalrecord.typeOfCarId = (int)cbTypeOfCar.SelectedValue;

                    carRentalEntities.carRentalRecords.Add(rentalrecord);
                    carRentalEntities.SaveChanges();

                    MessageBox.Show($"Customer Name: {customerName}\n\r + " +
                        $"Date Rented: {dateOut}\n\r" +
                        $"Date Returned: {dateIn}\n\r" +
                        $"Cost: {cost}\n\r" +
                        $"Car Type: {carType}\n\r" +
                        $"THANK YOU FOR YOUR BUSINESS");
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cars = carRentalEntities.typeOfCars
                .Select(data => new {
                    ID = data.id, Name = data.make + " " + data.model
                })
                .ToList();
            cbTypeOfCar.DisplayMember = "Name";
            cbTypeOfCar.ValueMember = "id";
            cbTypeOfCar.DataSource = cars;
        }
    }
}
        
    

