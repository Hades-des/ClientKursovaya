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
            dataGridView1.Columns[1].HeaderText = "Боец";
            dataGridView1.Columns[2].HeaderText = "Турнир";
            dataGridView1.Columns[3].HeaderText = "Победы";
            dataGridView1.Columns[4].HeaderText = "Поражения";


        }
        public void getData()
        {
           
            string fighterResponse = ApiRequest.getJSON("/Fighter/getList").Result;
            string tournamentResponse = ApiRequest.getJSON("/Tournament/getList").Result;
            string fightHistoryResponse = ApiRequest.getJSON("/FightHistory/getList").Result;

            Fighter[] fighters = JsonConvert.DeserializeObject<Fighter[]>(fighterResponse);
            Tournament[] tournaments = JsonConvert.DeserializeObject<Tournament[]>(tournamentResponse);
            FightHistory[] fightHistory = JsonConvert.DeserializeObject<FightHistory[]>(fightHistoryResponse);

            var joinedData = from fight in fightHistory
                             join fighter in fighters on fight.Fighter equals fighter.Id
                             join tournament in tournaments on fight.Tournament equals tournament.Id
                             select new
                             {
                                 fight.Id,
                                 FighterFullName = fighter.FullName,
                                 TournamentArena = tournament.Arena,
                                 fight.Victories,
                                 fight.Defeats
                             };
            dataGridView1.DataSource = joinedData.ToList();
        }

        public DataGridView dataFH()
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
