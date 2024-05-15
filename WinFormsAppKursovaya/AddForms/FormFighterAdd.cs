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
using System.Reflection.PortableExecutable;
using Newtonsoft.Json;
using System.Data.Common;

namespace WinFormsAppKursovaya.AddForms
{
    public partial class FormFighterAdd : Form
    {
        Fighter fighter;

        public FormFighterAdd()
        {
            InitializeComponent();
            this.Text = "Добавление бойца";
            button1.Text = "Добавить";
            button1.Click += bActionAddClick;
            string response3 = ApiRequest.getJSON("/Fighter/GetList").Result;
            Fighter[] records = JsonConvert.DeserializeObject<Fighter[]>(response3);
            textBox1.Visible = false;
            label1.Visible = false;
            loadData();
            // dateTimePicker1.Value = DateTimePicker.MinimumDateTime;
        }
        public FormFighterAdd(Fighter fighter)
        {
            InitializeComponent();
            this.Text = "Редактирование бойца";
            button1.Text = "Редактировать";
            button1.Click += bActionUpdateClick;
            loadData();
            this.fighter = fighter;
            SetData(fighter);
 
            textBox1.Visible = true;
            label1.Visible = true;
        }

        public void SetData(Models.Fighter Fighter)
        {
            if (Fighter != null)
            {
                textBox1.Text = Fighter.Id.ToString();
                if ( comboBox2 != null)
                {
                    comboBox2.SelectedValue = Fighter.Weight_Category;
                }
                if ( comboBox1!= null)
                {
                    comboBox1.SelectedValue = Fighter.Coach;
                }
                textBox4.Text = Fighter.FullName;
                textBox5.Text = Fighter.Age.ToString();
            }
            else
            {
                MessageBox.Show("Значения  = null");
            }

        }
        public async void loadData()
        {
            string response = ApiRequest.getJSON("/Trainer/getList").Result;
            if (!string.IsNullOrEmpty(response))
            {
                List<Trainer> trainers = JsonConvert.DeserializeObject<List<Trainer>>(response);
                if (trainers.Count > 0)
                {
                    comboBox1.DataSource = trainers;
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "FullName";
                    comboBox1.SelectedValue = 0;
                }
                else
                {
                    MessageBox.Show($"Список пуст");
                }
            }
            string response1 = ApiRequest.getJSON("/WeightCategory/getList").Result;
            if (!string.IsNullOrEmpty(response1))
            {
                List<WeightCategory> categories = JsonConvert.DeserializeObject<List<WeightCategory>>(response1);
                if (categories.Count > 0)
                {
                    comboBox2.DataSource = categories;
                    comboBox2.ValueMember = "Id";
                    comboBox2.DisplayMember = "FullName";
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

                Models.Fighter fighter = new Models.Fighter()
                {
                    //Id = Convert.ToInt32(textBox1.Text),
                    Weight_Category = (int)comboBox2.SelectedValue,
                    Coach = (int)comboBox1.SelectedValue,
                    FullName = textBox4.Text,
                    Age = Convert.ToInt32(textBox5.Text),
                    //Date_of_birth = Convert.ToDateTime(textBox6.Text),
                };

                var json = JsonConvert.SerializeObject(fighter);
                var response = await ApiRequest.sendPostJSON("Fighter/Add", json);

                if (string.IsNullOrEmpty(response))
                {
                    MessageBox.Show("Данные добавлены");
                }
               

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
 
                Models.Fighter fighters = new Models.Fighter()
                {
                    Id = Convert.ToInt32(textBox1.Text),
                    Weight_Category = (int)comboBox2.SelectedValue,
                    Coach = (int)comboBox1.SelectedValue,
                    FullName = textBox4.Text,
                    Age = Convert.ToInt32(textBox5.Text),
                    //Date_of_birth = Convert.ToDateTime(textBox6.Text),
                };

                var json = JsonConvert.SerializeObject(fighters);
                var response = await ApiRequest.sendPutJSON($"Fighter/Update/{fighters.Id}", json);
               
                    
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
           /* if (string.IsNullOrWhiteSpace(textBox1.Text))
                error += "\nВведите код спортсмена";*/
           // if (string.IsNullOrWhiteSpace(textBox2.Text))
           //     error += "\nВведите код весовой категории ";
            //if (string.IsNullOrWhiteSpace(textBox3.Text))
            //    error += "\nВведите код тренера";       
            if (string.IsNullOrWhiteSpace(textBox4.Text))
                error += "\nВведите имя спортсмена";
            if (int.Parse(textBox5.Text) > 1000 && int.Parse(textBox5.Text) < 7)
                error += "\nВозраст не должен превышать 100 и быть меньше 7";
            if (error != "")
                error = error.Remove(error.Length - 1);
            return error;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


}

