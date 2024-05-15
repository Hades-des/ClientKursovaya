using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppKursovaya.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsAppKursovaya.AddForms
{
    public partial class FormTrainerAdd : Form
    {
        Trainer trainer;

        public FormTrainerAdd()
        {
            InitializeComponent();
            this.Text = "Добавление тренера";
            button1.Text = "Добавить";
            button1.Click += bActionAddClick;
            string response3 = ApiRequest.getJSON("/Trainer/GetList").Result;
            Trainer[] records = JsonConvert.DeserializeObject<Trainer[]>(response3);
            textBox1.Visible = false;
            label1.Visible = false;
            loadData();
        }
        public FormTrainerAdd(Trainer trainer)
        {
            InitializeComponent();
            this.Text = "Редактирование тренера";
            button1.Text = "Редактировать";
            button1.Click += bActionUpdateClick;
            loadData();
            this.trainer = trainer;
            SetData(trainer);

            textBox1.Visible = true;
            label1.Visible = true;
        }

        public void SetData(Models.Trainer Trainer)
        {
            if (Trainer != null)
            {
                textBox1.Text = Trainer.Id.ToString();
                textBox2.Text = Trainer.FullName.ToString();
                textBox3.Text = Trainer.Rank.ToString();
                textBox4.Text = Trainer.Age.ToString();
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

                Models.Trainer trainer = new Models.Trainer()
                {
                    //Id = Convert.ToInt32(textBox1.Text),
                    FullName = Convert.ToString(textBox2.Text),
                    Rank = Convert.ToString(textBox3.Text),
                    Age = Convert.ToInt32(textBox4.Text)
                };

                var json = JsonConvert.SerializeObject(trainer);
                var response = await ApiRequest.sendPostJSON("Trainer/Add", json);


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

                Models.Trainer trainer = new Models.Trainer()
                {
                    Id = Convert.ToInt32(textBox1.Text),
                    FullName = Convert.ToString(textBox2.Text),
                    Rank = Convert.ToString(textBox3.Text),
                    Age = Convert.ToInt32(textBox4.Text)
                };

                var json = JsonConvert.SerializeObject(trainer);
                var response = await ApiRequest.sendPutJSON($"Trainer/Update/{trainer.Id}", json);



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

        private void FormTrainerAdd_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

