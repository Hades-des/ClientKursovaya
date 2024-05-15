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
using Newtonsoft.Json;

namespace WinFormsAppKursovaya.AddForms
{
    public partial class FormFighterHistoryAdd : Form
    {
        FightHistory history;
        public FormFighterHistoryAdd()
        {
            InitializeComponent();
            this.Text = "Добавление тренера";
            button1.Text = "Добавить";
            button1.Click += bActionAddClick;
            string response3 = ApiRequest.getJSON("/FightHistory/GetList").Result;
            FightHistory[] records = JsonConvert.DeserializeObject<FightHistory[]>(response3);
            textBox1.Visible = false;
            label1.Visible = false;
            loadData();
        }
        public FormFighterHistoryAdd(FightHistory history)
        {
            InitializeComponent();
            this.Text = "Редактирование тренера";
            button1.Text = "Редактировать";
            button1.Click += bActionUpdateClick;
            loadData();
            this.history = history;
            SetData(history);

            textBox1.Visible = true;
            label1.Visible = true;
        }

        public void SetData(Models.FightHistory FightHistory)
        {
            if (FightHistory != null)
            {
                textBox1.Text = FightHistory.Id.ToString();
                if (comboBox2 != null)
                {
                    comboBox2.SelectedValue = FightHistory.Fighter;
                }
                if (comboBox1 != null)
                {
                    comboBox1.SelectedValue = FightHistory.Tournament;
                }
                textBox4.Text = FightHistory.Victories.ToString();
                textBox5.Text = FightHistory.Defeats.ToString();
            }
            else
            {
                MessageBox.Show("Значения  = null");
            }

        }
        public void loadData()
        {
            string response = ApiRequest.getJSON("/Fighter/getList").Result;
            if (!string.IsNullOrEmpty(response))
            {
                List<Fighter> fighters = JsonConvert.DeserializeObject<List<Fighter>>(response);
                if (fighters.Count > 0)
                {
                    comboBox1.DataSource = fighters;
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "FullName";
                    comboBox1.SelectedValue = 0;
                }
                else
                {
                    MessageBox.Show($"Список пуст");
                }
            }
            string response1 = ApiRequest.getJSON("/Tournament/getList").Result;
            if (!string.IsNullOrEmpty(response1))
            {
                List<Tournament> tournaments = JsonConvert.DeserializeObject<List<Tournament>>(response1);
                if (tournaments.Count > 0)
                {
                    comboBox2.DataSource = tournaments;
                    comboBox2.ValueMember = "Id";
                    comboBox2.DisplayMember = "Arena";
                    comboBox2.SelectedValue = 0;
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

                Models.FightHistory history = new Models.FightHistory()
                {
                    //Id = Convert.ToInt32(textBox1.Text),
                    Fighter = (int)comboBox1.SelectedValue,
                    Tournament = (int)comboBox2.SelectedValue,
                    Victories = Convert.ToInt32(textBox4.Text),
                    Defeats = Convert.ToInt32(textBox5.Text)
                };

                var json = JsonConvert.SerializeObject(history);
                var response = await ApiRequest.sendPostJSON("FightHistory/Add", json);


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

                Models.FightHistory history = new Models.FightHistory()
                {
                    Id = Convert.ToInt32(textBox1.Text),
                    Fighter = (int)comboBox1.SelectedValue,
                    Tournament = (int)comboBox2.SelectedValue,
                    Victories = Convert.ToInt32(textBox4.Text),
                    Defeats = Convert.ToInt32(textBox5.Text)
                };

                var json = JsonConvert.SerializeObject(history);
                var response = await ApiRequest.sendPutJSON($"FightHistory/Update/{history.Id}", json);



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
            //if (string.IsNullOrWhiteSpace(textBox3.Text))
            //    error += "\nВведите название арены";
            if (error != "")
                error = error.Remove(error.Length - 1);
            return error;
        }

    }
 }

