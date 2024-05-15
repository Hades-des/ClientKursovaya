using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppKursovaya.Models;
using System.Reflection;
using System.Net.Sockets;

namespace WinFormsAppKursovaya
{
    public partial class AddForm : Form
    {
        public string classFromN;

        private List<TextBox> textBoxesList = new List<TextBox>();
        public AddForm(int columnCount, string classFrom1)
        {
            InitializeComponent();

            classFromN = classFrom1;
            CustomizeButton(button1);
            List<string> placeHolders = new List<string>();
            switch (classFromN)
            {
                case "Fighter":
                    placeHolders.Add("Код");
                    placeHolders.Add("ФИО");
                    placeHolders.Add("Весовая категория");
                    placeHolders.Add("Тренер");
                    placeHolders.Add("Возраст");
                    break;
                case "FighterHistory":
                    placeHolders.Add("Код");
                    placeHolders.Add("Боец");
                    placeHolders.Add("Турнир");
                    placeHolders.Add("Победы");
                    placeHolders.Add("Поражения");
                      break;
                case "Match":
                    placeHolders.Add("Код");
                    placeHolders.Add("Туринр");
                    placeHolders.Add("Боец 1");
                    placeHolders.Add("Боец 2");
                    placeHolders.Add("Метод победы");
                    placeHolders.Add("Результат");
                    break;

                case "Tournament":
                    placeHolders.Add("Код");
                    placeHolders.Add("Арена");
                    placeHolders.Add("Дата");
                    break;

                case "Trainer":
                    placeHolders.Add("Код");
                    placeHolders.Add("ФИО");
                    placeHolders.Add("Звание");
                    placeHolders.Add("Возраст");
                    break;
                case "VictoryMethod":
                    placeHolders.Add("Код");
                    placeHolders.Add("Название");
                    break;
                case "WeightCategory":
                    placeHolders.Add("Код");
                    placeHolders.Add("Название");
                    placeHolders.Add("Вес");
                    break;
                default:
                    break;
            }
            CreateTextBoxes(columnCount, placeHolders);
        }
        private void CustomizeButton(Button button)
        {
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(93, 227, 156);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(93, 227, 156);
        }
        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateTextBoxes(int columnCount, List<string> str)
        {
            int leftMargin = 20;
            int topMargin = 50;
            int textBoxWidth = 200;
            int textBoxHeight = 32;

            for (int i = 0; i < columnCount; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Name = "textBox" + i;
                textBox.Location = new System.Drawing.Point(leftMargin, topMargin + i * (textBoxHeight + 5));
                textBox.Size = new System.Drawing.Size(textBoxWidth, textBoxHeight);
                textBox.Text = str[i];

                textBoxesList.Add(textBox);
                this.Controls.Add(textBox);
            }

        }
        public string GetTextFromTextBox(int index)
        {
            if (index >= 0 && index < textBoxesList.Count)
            {
                return textBoxesList[index].Text;
            }
            return string.Empty;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var jsonData = "";
            var response = "";
            switch (classFromN)
            {
                case "Fighter":
                    Fighter fighter = new Fighter
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        FullName = GetTextFromTextBox(1),
                        Age = Convert.ToInt32(GetTextFromTextBox(2)),
                        Coach = Convert.ToInt32(GetTextFromTextBox(3)),
                        Weight_Category = Convert.ToInt32(GetTextFromTextBox(4))
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(fighter);
                    response = ApiRequest.sendPostJSON("api/Fighter/FighterP", jsonData).Result;
                    break;
                case "FighterHistory":
                    FightHistory fight_history = new FightHistory
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Tournament = Convert.ToInt32(GetTextFromTextBox(1)),
                        Victories = Convert.ToInt32(GetTextFromTextBox(2)),
                        Defeats = Convert.ToInt32(GetTextFromTextBox(3)),
                        Fighter = Convert.ToInt32(GetTextFromTextBox(4)),
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(fight_history);
                    response = ApiRequest.sendPostJSON("api/FightHistory/FightHistoryP", jsonData).Result;

                    break;
                case "Match":
                    Match match = new Match
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Fighter_1 = Convert.ToInt32(GetTextFromTextBox(1)),
                        Fighter_2 = Convert.ToInt32(GetTextFromTextBox(2)),
                        Tournament = Convert.ToInt32(GetTextFromTextBox(3)),
                        Victory_method = Convert.ToInt32(GetTextFromTextBox(4)),
                        Result = GetTextFromTextBox(5)
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(match);
                    response = ApiRequest.sendPostJSON("api/Match/MatchP", jsonData).Result;
                    break;
                case "Tournament":
                    Tournament tournament = new Tournament
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Arena = GetTextFromTextBox(1),
                        Data_Held = Convert.ToDateTime(GetTextFromTextBox(2))
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(tournament);
                    response = ApiRequest.sendPostJSON("api/Tournament/TournamentP", jsonData).Result;
                    break;
                case "Trainer":
                    Trainer trainer = new Trainer
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Age = Convert.ToInt32(GetTextFromTextBox(1)),
                        FullName = GetTextFromTextBox(2),
                        Rank = GetTextFromTextBox(3)

                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(trainer);
                    response = ApiRequest.sendPostJSON("api/Trainer/TRainerFM", jsonData).Result;
                    break;
               
                default: break;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var jsonData = "";
            var response = "";
            switch (classFromN)
            {
                case "Fighter":
                    Fighter fighter = new Fighter
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        FullName = GetTextFromTextBox(1),
                        Age = Convert.ToInt32(GetTextFromTextBox(2)),
                        Coach = Convert.ToInt32(GetTextFromTextBox(3)),
                        Weight_Category = Convert.ToInt32(GetTextFromTextBox(4))
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(fighter);
                    response = ApiRequest.sendPostJSON("api/Client/ClientU", jsonData).Result;
                    break;
                case "FighterHistory":
                    FightHistory fight_history = new FightHistory
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Tournament = Convert.ToInt32(GetTextFromTextBox(1)),
                        Victories = Convert.ToInt32(GetTextFromTextBox(2)),
                        Defeats = Convert.ToInt32(GetTextFromTextBox(3)),
                        Fighter = Convert.ToInt32(GetTextFromTextBox(4)),
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(fight_history);
                    response = ApiRequest.sendPostJSON("api/ClientOrder/ClientOrderU", jsonData).Result;

                    break;
                case "Match":
                    Match match = new Match
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Fighter_1 = Convert.ToInt32(GetTextFromTextBox(1)),
                        Fighter_2 = Convert.ToInt32(GetTextFromTextBox(2)),
                        Tournament = Convert.ToInt32(GetTextFromTextBox(3)),
                        Victory_method = Convert.ToInt32(GetTextFromTextBox(4)),
                        Result = GetTextFromTextBox(5)
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(match);
                    response = ApiRequest.sendPostJSON("api/employee/EmployeeU", jsonData).Result;
                    break;
                case "Tournament":
                    Tournament tournament = new Tournament
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Arena = GetTextFromTextBox(1),
                        Data_Held = Convert.ToDateTime(GetTextFromTextBox(2))
                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(tournament);
                    response = ApiRequest.sendPostJSON("api/Accessories/AccessoriesU", jsonData).Result;
                    break;
                case "Trainer":
                    Trainer trainer = new Trainer
                    {
                        Id = Convert.ToInt32(GetTextFromTextBox(0)),
                        Age = Convert.ToInt32(GetTextFromTextBox(1)),
                        FullName = GetTextFromTextBox(2),
                        Rank = GetTextFromTextBox(3)

                    };
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(trainer);
                    response = ApiRequest.sendPostJSON("api/Accessories_For_Model/AccessoriesFMU", jsonData).Result;
                    break;
                
                default: break;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var jsonData = "";
            var response = "";
            var data = new
            {
                Id = Convert.ToInt32(GetTextFromTextBox(0))
            };
            switch (classFromN)
            {
                case "fighter":
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    response = ApiRequest.sendPostJSON("api/Fighter/FighterD", jsonData).Result;
                    break;
                case "FightHistory":
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    response = ApiRequest.sendPostJSON("api/FightHistory/FightHistoryD", jsonData).Result;

                    break;
                case "Match":

                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    response = ApiRequest.sendPostJSON("api/Match/MatchD", jsonData).Result;
                    break;
                case "Tournament":

                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    response = ApiRequest.sendPostJSON("api/Tournament/TournamentD", jsonData).Result;
                    break;
                case "Trainer":

                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    response = ApiRequest.sendPostJSON("api/Trainer/TreainerFMD", jsonData).Result;
                    break;
                               default:
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
