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
using WinFormsAppKursovaya.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsAppKursovaya.AddForms
{
    public partial class FormTournamentAdd : Form
    {
        Tournament tournament;

        public FormTournamentAdd()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.Text = "Добавление турнира";
            button1.Text = "Добавить";
            button1.Click += bActionAddClick;
            string response3 = ApiRequest.getJSON("/Tournament/GetList").Result;
            Tournament[] records = JsonConvert.DeserializeObject<Tournament[]>(response3);
            textBox1.Visible = false;
            label1.Visible = false;
            loadData();
        }
        public FormTournamentAdd(Tournament tournament)
        {
            InitializeComponent();
            this.Text = "Редактирование бойца";
            button1.Text = "Редактировать";
            button1.Click += bActionUpdateClick;
            loadData();
            this.tournament = tournament;
            SetData(tournament);

            textBox1.Visible = true;
            label1.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
        public void SetData(Models.Tournament Tournament)
        {
            if (Tournament != null)
            {
                textBox1.Text = Tournament.Id.ToString();
                dateTimePicker1.Value = Tournament.Data_Held;
                textBox3.Text = Tournament.Arena.ToString();
              
            }
            else
            {
                MessageBox.Show("Значения  = null");
            }

        }
        public void loadData()
        {
            /* textBox5.TextChanged += (sender, e) =>
             {
                 if (textBox5.Text.Length > 11)
                 {
                     MessageBox.Show("Превышено максимальное количество символов (11)");
                 }

             };*/
            /* textBox5.KeyPress += (sender, e) =>
             {
                 if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                 {
                     e.Handled = true;
                 }
             };*/
            /*string response = ApiRequest.getJSON("/Materials_/getList").Result;
            if (string.IsNullOrWhiteSpace(response))
            {
                MessageBox.Show("aaa");
                return;
            }*/

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

                Models.Tournament tournament = new Models.Tournament()
                {
                    //Id = Convert.ToInt32(textBox1.Text),
                    Data_Held = dateTimePicker1.Value,
                    Arena = textBox3.Text,
                    //Date_of_birth = Convert.ToDateTime(textBox6.Text),
                };

                var json = JsonConvert.SerializeObject(tournament);
                var response = await ApiRequest.sendPostJSON("Tournament/Add", json);

              
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

                Models.Tournament tournament = new Models.Tournament()
                {
                    Id = Convert.ToInt32(textBox1.Text),
                    Data_Held = dateTimePicker1.Value,
                    Arena = textBox3.Text
                    //Date_of_birth = Convert.ToDateTime(textBox6.Text),
                };

                var json = JsonConvert.SerializeObject(tournament);
                var response = await ApiRequest.sendPutJSON($"Tournament/Update/{tournament.Id}", json);


                //MessageBox.Show(json);
                //MessageBox.Show(response);
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
            if (string.IsNullOrWhiteSpace(textBox3.Text))
                error += "\nВведите название арены";
            if (error != "")
                error = error.Remove(error.Length - 1);
            return error;
        }
    }
   
}
