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
    public partial class mainWIndow : Form
    {
        public mainWIndow()
        {
            InitializeComponent();
        }

        

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageVehicleListing = new manageVehicleListing(); 
            manageVehicleListing.MdiParent = this;
            manageVehicleListing.Show();
        }

        private void AddRenatalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new addRentalRecord();
            addRentalRecord.MdiParent = this;
            addRentalRecord.Show(); 
        }
    }
}
