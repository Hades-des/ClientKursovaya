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
    public partial class FightHistoryControl : UserControl
    {
        public FightHistoryControl()
        {
            InitializeComponent();
            getData();
            dataGridView1.DataBindingComplete += DataGridView_DataBindingComplete;

        }
        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Номер бойца";
            dataGridView1.Columns[2].HeaderText = "Турнир";
            dataGridView1.Columns[3].HeaderText = "Победы";
            dataGridView1.Columns[4].HeaderText = "Поражения";


        }
        public void getData()
        {
            string response = ApiRequest.getJSON("/FightHistory/getList").Result;

            FightHistory[] fightHistories = JsonConvert.DeserializeObject<FightHistory[]>(response);
            dataGridView1.DataSource = fightHistories;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
