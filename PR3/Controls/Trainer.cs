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

namespace WinFormsAppKursovaya.Controls
{
    public partial class TrainerControl : UserControl
    {
        public TrainerControl()
        {
            InitializeComponent();
            getData();
            dataGridView1.DataBindingComplete += DataGridView_DataBindingComplete;
        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Звание";
            dataGridView1.Columns[3].HeaderText = "Возраст";


        }
        public void getData()
        {
            string response = ApiRequest.getJSON("/Trainer/getList").Result;

            Trainer[] trainer = JsonConvert.DeserializeObject<Trainer[]>(response);
            dataGridView1.DataSource = trainer;

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
