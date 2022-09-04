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
    public partial class addEditVehicle : Form
    {
        private readonly carRentalEntities1 carRentalEntities1;
        private bool isEditMode;
        public addEditVehicle()
        {
            InitializeComponent();
            isEditMode = false;
            lblTitle.Text = "Add New Vehicle";
            carRentalEntities1 = new carRentalEntities1();
        }
        public addEditVehicle(typeOfCar carToEdit)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            isEditMode = true;
            carRentalEntities1 = new carRentalEntities1();
            PopulateFields(carToEdit);

        }

        private void PopulateFields(typeOfCar carToEdit)
        {
            lbId.Text = carToEdit.id.ToString();
            tbMake.Text = carToEdit.make;
            tbModel.Text = carToEdit.model;
            tbVIN.Text = carToEdit.VIN;
            tbYear.Text = carToEdit.year.ToString();
            tbLpn.Text = carToEdit.licensePlateNumber;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                var id = int.Parse(lbId.Text);
                var car = carRentalEntities1.typeOfCars.FirstOrDefault(data => data.id == id);
                car.model = tbModel.Text;
                car.make = tbMake.Text;
                car.VIN = tbVIN.Text;
                car.year = int.Parse(tbYear.Text);
                car.licensePlateNumber = tbLpn.Text;

                carRentalEntities1.SaveChanges();

            } 
            else
            {
                var newcar = new typeOfCar
                {
                    licensePlateNumber = tbLpn.Text,
                    model = tbModel.Text,
                    make = tbMake.Text,
                    VIN = tbVIN.Text,
                    year = int.Parse(tbYear.Text)
                };

                carRentalEntities1.typeOfCars.Add(newcar);
                carRentalEntities1.SaveChanges();
            }
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
