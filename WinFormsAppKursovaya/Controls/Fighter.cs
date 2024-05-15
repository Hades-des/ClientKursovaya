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
            Fighters.DataBindingComplete += DataGridView_DataBindingComplete;

        }
        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Fighters.Columns[0].Visible = false;
            Fighters.Columns[1].HeaderText = "Весовая категория";
            Fighters.Columns[2].HeaderText = "Тренер";
            Fighters.Columns[3].HeaderText = "ФИО";
            Fighters.Columns[4].HeaderText = "Возраст";

        }
        public void getData()
        {
            string fighterResponse = ApiRequest.getJSON("/Fighter/getList").Result;
            string trainerResponse = ApiRequest.getJSON("/Trainer/getList").Result;
            string weightCategoryResponse = ApiRequest.getJSON("/WeightCategory/getList").Result;

            Fighter[] fighters = JsonConvert.DeserializeObject<Fighter[]>(fighterResponse);
            Trainer[] trainers = JsonConvert.DeserializeObject<Trainer[]>(trainerResponse);
            WeightCategory[] weightCategories = JsonConvert.DeserializeObject<WeightCategory[]>(weightCategoryResponse);

            var joinedData = from fighter in fighters
                             join trainer in trainers on fighter.Coach equals trainer.Id
                             join weightCategory in weightCategories on fighter.Weight_Category equals weightCategory.Id
                             select new
                             {
                                 fighter.Id,
                                 WeightCategoryFullName = weightCategory.FullName,
                                 TrainerFullName = trainer.FullName,
                                 fighter.FullName,
                                 fighter.Age,
                             };

            Fighters.DataSource = joinedData.ToList();
        }

        public DataGridView dataFight()
        {
            return Fighters;
        }

        public void ApplyFilter(string filterText)
        {

            CurrencyManager currencyManager = (CurrencyManager)BindingContext[Fighters.DataSource];
            currencyManager.SuspendBinding();
            foreach (DataGridViewRow row in Fighters.Rows)
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

        private void Employess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}