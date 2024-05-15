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
            string fighterResponse = ApiRequest.getJSON("/Fighter/getList").Result;
            string tournamentResponse = ApiRequest.getJSON("/Tournament/getList").Result;
            string matchResponse = ApiRequest.getJSON("/Match/getList").Result;
            string victoryMethodResponse = ApiRequest.getJSON("/VictoryMethod/getList").Result;

            Fighter[] fighters = JsonConvert.DeserializeObject<Fighter[]>(fighterResponse);
            Tournament[] tournaments = JsonConvert.DeserializeObject<Tournament[]>(tournamentResponse);
            Match[] matches = JsonConvert.DeserializeObject<Match[]>(matchResponse);
            VictoryMethod[] victoryMethods = JsonConvert.DeserializeObject<VictoryMethod[]>(victoryMethodResponse);

            var joinedData = from match in matches
                             join tournament in tournaments on match.Tournament equals tournament.Id
                             join fighter1 in fighters on match.Fighter_1 equals fighter1.Id
                             join fighter2 in fighters on match.Fighter_2 equals fighter2.Id
                             join victoryMethod in victoryMethods on match.Victory_method equals victoryMethod.Id
                             select new
                             {
                                 match.Id,
                                 TournamentArena = tournament.Arena,
                                 Fighter1FullName = fighter1.FullName,
                                 Fighter2FullName = fighter2.FullName,
                                 VictoryMethodName = victoryMethod.Name,
                                 match.Result
                             };

            dataGridView1.DataSource = joinedData.ToList();

        }

        public DataGridView dataMatch()
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
