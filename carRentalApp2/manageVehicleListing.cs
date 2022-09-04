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
    public partial class manageVehicleListing : Form
    {
        private readonly carRentalEntities1 carRentalEntities1;
        public manageVehicleListing()
        {
            InitializeComponent();
            carRentalEntities1 = new carRentalEntities1();
        }

        private void manageVehicleListing_Load(object sender, EventArgs e)
        {
            var cars = carRentalEntities1.typeOfCars
                .Select(data => new 
                {
                    Make = data.make, 
                    Model = data.model, 
                    VIN = data.VIN, 
                    Year = data.year, 
                    LiecensePlateNumber = data.licensePlateNumber,
                    ID = data.id
                } )
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns[5].Visible = false;
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            addEditVehicle  addEditVehicle = new addEditVehicle();
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            var id = (int)gvVehicleList.SelectedRows[0].Cells["id"].Value;
            var car = carRentalEntities1.typeOfCars.FirstOrDefault(data => data.id == id);
            addEditVehicle addEditVehicle = new addEditVehicle(car);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            var id = (int)gvVehicleList.SelectedRows[0].Cells["id"].Value;
            var car = carRentalEntities1.typeOfCars.FirstOrDefault(data => data.id == id);
            carRentalEntities1.typeOfCars.Remove(car);
            carRentalEntities1.SaveChanges();

            gvVehicleList.Refresh();
        }

        private void btRefesh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        public void PopulateGrid()
        {
            
            var cars = carRentalEntities1.typeOfCars
                .Select(q => new
                {
                    Make = q.make,
                    Model = q.model,
                    VIN = q.VIN,
                    Year = q.year,
                    LicensePlateNumber = q.licensePlateNumber,
                    q.id
                })
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns["Id"].Visible = false;
        }
    }
}
