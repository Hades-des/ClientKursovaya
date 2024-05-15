using System;
using WinFormsAppKursovaya.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace WinFormsAppKursovaya.AddForms
{

    public partial class FormMatchAdd : Form
    {
        Match match;
        public FormMatchAdd()
        {
            InitializeComponent();
            this.Text = "Добавление поединка";
            button1.Text = "Добавить";
            button1.Click += bActionAddClick;
            string response3 = ApiRequest.getJSON("/Match/GetList").Result;
            Match[] records = JsonConvert.DeserializeObject<Match[]>(response3);
            textBox1.Visible = false;
            label1.Visible = false;
            loadData();
        }
        public FormMatchAdd(Match match)
        {
            InitializeComponent();
            this.Text = "Редактирование поединка";
            button1.Text = "Редактировать";
            button1.Click += bActionUpdateClick;
            loadData();
            this.match = match;
            SetData(match);

            textBox1.Visible = true;
            label1.Visible = true;
        }

        public void SetData(Models.Match Match)
        {
            if (Match != null)
            {
                textBox1.Text = Match.Id.ToString();
                if (comboBox1 != null)
                {
                    comboBox1.SelectedValue = Match.Tournament;
                }
                if (comboBox2 != null)
                {
                    comboBox2.SelectedValue = Match.Fighter_1;
                }
                if (comboBox3 != null)
                {
                    comboBox3.SelectedValue = Match.Fighter_2;
                }
                if (comboBox4 != null)
                {
                    comboBox4.SelectedValue = Match.Victory_method;
                }
                textBox6.Text = Match.Result.ToString();
            }
            else
            {
                MessageBox.Show("Значения  = null");
            }

        }
        public void loadData()
        {
            string response = ApiRequest.getJSON("/Tournament/getList").Result;
            if (!string.IsNullOrEmpty(response))
            {
                List<Tournament> tournament = JsonConvert.DeserializeObject<List<Tournament>>(response);
                if (tournament.Count > 0)
                {
                    comboBox1.DataSource = tournament;
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "Arena";
                    comboBox1.SelectedValue = 0;
                }
                else
                {
                    MessageBox.Show($"Список пуст");
                }
            }
            string response1 = ApiRequest.getJSON("/Fighter/getList").Result;
            if (!string.IsNullOrEmpty(response1))
            {
                List<Fighter> fighter = JsonConvert.DeserializeObject<List<Fighter>>(response1);
                if (fighter.Count > 0)
                {
                    comboBox2.DataSource = fighter;
                    comboBox2.ValueMember = "Id";
                    comboBox2.DisplayMember = "FullName";
                    comboBox2.SelectedValue = 0;
                }
                else
                {
                    MessageBox.Show($"Список пуст");
                }
            }
            
            if (!string.IsNullOrEmpty(response))
            {
                List<Fighter> fighter = JsonConvert.DeserializeObject<List<Fighter>>(response1);
                if (fighter.Count > 0)
                {
                    comboBox3.DataSource = fighter;
                    comboBox3.ValueMember = "Id";
                    comboBox3.DisplayMember = "FullName";
                    comboBox3.SelectedValue = 0;
                }
                else
                {
                    MessageBox.Show($"Список пуст");
                }
            }
            string response2 = ApiRequest.getJSON("/VictoryMethod/getList").Result;
            if (!string.IsNullOrEmpty(response1))
            {
                List<VictoryMethod> method = JsonConvert.DeserializeObject<List<VictoryMethod>>(response2);
                if (method.Count > 0)
                {
                    comboBox4.DataSource = method;
                    comboBox4.ValueMember = "Id";
                    comboBox4.DisplayMember = "Name";
                    comboBox4.SelectedValue = 0;
                }
                else
                {
                    MessageBox.Show($"Список пуст");
                }
            }

        }
        private async void bActionAddClick(object sender, EventArgs e)
        {
            try
            {
                var error = checkData();
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Исправьте ошибки " + error);
                    return;
                }
                if (!checkBox1.Checked && !checkBox2.Checked)
                {
                    MessageBox.Show("Выберите победителя.");
                    return;
                }
                if (comboBox2.SelectedValue == comboBox3.SelectedValue)
                {
                    MessageBox.Show("Боец не может сражаться сам с собой.");
                    return;
                }

                int winnerId;
                int loserId;
                if (checkBox1.Checked)
                {
                    textBox6.Text = $"Победил {comboBox2.Text}";
                    winnerId = (int)comboBox2.SelectedValue;
                    loserId = (int)comboBox3.SelectedValue;
                }
                else
                {
                    textBox6.Text = $"Победил {comboBox3.Text}";
                    winnerId = (int)comboBox3.SelectedValue;
                    loserId = (int)comboBox2.SelectedValue;
                }

                Models.Match match = new Models.Match()
                {
                    //Id = Convert.ToInt32(textBox1.Text),
                    Tournament = (int)comboBox1.SelectedValue,
                    Fighter_1 = (int)comboBox2.SelectedValue,
                    Fighter_2 = (int)comboBox3.SelectedValue,
                    Victory_method = (int)comboBox4.SelectedValue,
                    Result = Convert.ToString(textBox6.Text)
                };

                var json = JsonConvert.SerializeObject(match);
                var response = await ApiRequest.sendPostJSON("Match/Add", json);

                
                var winnerHistory = new FightHistory
                {
                    Fighter = winnerId,
                    Tournament = match.Tournament,
                    Victories = 1,
                    Defeats = 0
                };
                var winnerJson = JsonConvert.SerializeObject(winnerHistory);
                await ApiRequest.sendPostJSON("FightHistory/Add", winnerJson);


                var loserHistory = new FightHistory
                {
                    Fighter = loserId,
                    Tournament = match.Tournament,
                    Victories = 0,
                    Defeats = 1
                };
                var loserJson = JsonConvert.SerializeObject(loserHistory);
                await ApiRequest.sendPostJSON("FightHistory/Add", loserJson);



                MessageBox.Show("Данные добавлены");


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private async void bActionUpdateClick(object sender, EventArgs e)
        {
            try
            {
                var error = checkData();
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Исправьте ошибки " + error);
                    return;
                }

                Models.Match match = new Models.Match()
                {
                    Id = Convert.ToInt32(textBox1.Text),
                    Tournament = (int)comboBox1.SelectedValue,
                    Fighter_1 = (int)comboBox2.SelectedValue,
                    Fighter_2 = (int)comboBox3.SelectedValue,
                    Victory_method = (int)comboBox4.SelectedValue,
                    Result = Convert.ToString(textBox6.Text)
                };

                var json = JsonConvert.SerializeObject(match);
                var response = await ApiRequest.sendPutJSON($"Match/Update/{match.Id}", json);



                MessageBox.Show("Данные изменены");


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        public string checkData()
        {
            string error = string.Empty;
           // if (string.IsNullOrWhiteSpace(textBox3.Text))
            //    error += "\nВведите название арены";
            if (error != "")
                error = error.Remove(error.Length - 1);
            return error;
        }
    }
}
    

