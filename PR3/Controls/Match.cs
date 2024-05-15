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
    public partial class MatchControl : UserControl
    {
        public MatchControl()
        {
            InitializeComponent();
            getData();
            dataGridView1.DataBindingComplete += DataGridView_DataBindingComplete;
        }
        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Турнир";
            dataGridView1.Columns[2].HeaderText = "Боец1";
            dataGridView1.Columns[3].HeaderText = "Боец2";
            dataGridView1.Columns[4].HeaderText = "Способ победы";
            dataGridView1.Columns[5].HeaderText = "Результат";
        }
        public void getData()
        {
            string response = ApiRequest.getJSON("/Match/getList").Result;

            Match[] match = JsonConvert.DeserializeObject<Match[]>(response);
            dataGridView1.DataSource = match;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
