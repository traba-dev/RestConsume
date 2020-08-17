using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestConsume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Action_Click(object sender, EventArgs e)
        {
            RestClient rest = new RestClient();
            Company company = new Company();

            rest.SetEndPoint(Input.Text);
            rest.SetHttpVerb("POST");

            company.name = txtName.Text;
            company.address = txtAddress.Text;
            company.phone = txtPhone.Text;
            company.lat = txtLat.Text;
            company.lon = txtLon.Text;
            company.email = txtEmail.Text;

            if (company.name.Equals("") || company.address.Equals("") || company.phone.Equals("") || company.lat.Equals("")
                || company.lon.Equals("") || company.email.Equals(""))
            {
                MessageBox.Show("All fields are Require");
                return;
            }


            string response = rest.RequestRequest<Company>(company);


            OutputApi(response);

        }

        private void OutputApi(string text)
        {
            Output.Text = Output.Text + text + Environment.NewLine;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            RestClient rest = new RestClient();
            Company company = new Company();

            rest.SetEndPoint(Input.Text);
            rest.SetHttpVerb("POST");

            string response = rest.RequestRequest<Company>(null);


            OutputApi(response);
        }
    }
}
