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
using WinFormsAppKursovaya;


namespace WinFormsAppKursovaya.Controls
{
    public partial class FighterControl : UserControl
    {
        public FighterControl()
        {
            InitializeComponent();
            getData();
            Employess.DataBindingComplete += DataGridView_DataBindingComplete;

        }
        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Employess.Columns[0].Visible = false;
            Employess.Columns[1].HeaderText = "Весовая категория";
            Employess.Columns[2].HeaderText = "Тренер";
            Employess.Columns[3].HeaderText = "ФИО";
            Employess.Columns[4].HeaderText = "Возраст";

        }
         public void getData()
         {
                string response = ApiRequest.getJSON("/Fighter/getList").Result;

                Fighter[] fighters = JsonConvert.DeserializeObject<Fighter[]>(response);
                Employess.DataSource = fighters;

         }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}