using Newtonsoft.Json;
using WinFormsAppKursovaya.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppKursovaya.Controls;

namespace WinFormsAppKursovaya.Controls
{
    public partial class TournamentControl : UserControl
    {
        public TournamentControl()
        {
            InitializeComponent();
            getData();
            dataGridView1.DataBindingComplete += DataGridView_DataBindingComplete;
        }
        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Арена";
            dataGridView1.Columns[2].HeaderText = "Дата проведения";
           


        }
        public void getData()
        {
            string response = ApiRequest.getJSON("/Tournament/getList").Result;

            Tournament[] tournaments = JsonConvert.DeserializeObject<Tournament[]>(response);
            dataGridView1.DataSource = tournaments;

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
