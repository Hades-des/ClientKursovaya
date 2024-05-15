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
    public partial class WeightCategoryControl : UserControl
    {
        
        public WeightCategoryControl()
        {
            InitializeComponent();
            getData();
            dataUsers.DataBindingComplete += DataGridView_DataBindingComplete;

            
        }
        private void DataGridView_DataBindingComplete(object sender,DataGridViewBindingCompleteEventArgs e)
        {
            dataUsers.Columns[0].Visible = false;
            dataUsers.Columns[1].HeaderText = "Название";
            dataUsers.Columns[2].HeaderText = "Вес";
        }


        
        public void getData()
        {
            string response = ApiRequest.getJSON("/WeightCategory/getList").Result;

            WeightCategory[] weightCategories = JsonConvert.DeserializeObject<WeightCategory[]>(response);
            dataUsers.DataSource = weightCategories;

        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
