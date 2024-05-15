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
    public partial class VictoryMethodControl : UserControl
    {
        public VictoryMethodControl()
        {
            InitializeComponent();
            getData();
            dataGridView1.DataBindingComplete += DataGridView_DataBindingComplete;
        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название";



        }
        public void getData()
        {
            string response = ApiRequest.getJSON("/VictoryMethod/getList").Result;

            VictoryMethod[] victoryMethods = JsonConvert.DeserializeObject<VictoryMethod[]>(response);
            dataGridView1.DataSource = victoryMethods;

        }

        public DataGridView dataBatch1()
        {
            return dataGridView1;
        }
        public void ApplyFilter(string filterText)
        {

            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager.SuspendBinding();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool visible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(filterText))
                    {
                        visible = true;
                        break;
                    }
                }
                if (currencyManager.Position != row.Index)
                {
                    row.Visible = visible;
                }
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
