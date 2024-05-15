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
using Newtonsoft.Json;

namespace WinFormsAppKursovaya
{
    public partial class FormAutorisation : Form
    {
        bool isImage1Shown = true;
        public FormAutorisation()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            button2.BackgroundImage = Properties.Resources.glazSkrit; 
            button2.BackgroundImageLayout = ImageLayout.Zoom; 
            button2.BackColor = Color.FromArgb(254, 246, 233);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool logintrue = false;
            string response = ApiRequest.getJSON("/Autorisation/getList").Result;
            Autorisation[] autorisations = JsonConvert.DeserializeObject<Autorisation[]>(response);
            foreach (var aut in autorisations)
            {

                if (textBox1.Text == aut.Login.Trim())
                {
                    if (textBox2.Text == aut.Password.Trim())
                    {
                        Form1 form = new Form1();
                        this.Hide();
                       
                        form.ShowDialog();
                        logintrue = true;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Неправильно набран пароль");
                        logintrue = true;
                    }
                }

            }
            if (!logintrue)
            {
                MessageBox.Show("Вы не зарегистрированы в системе");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                textBox2.PasswordChar = '*';
            }
            else { textBox2.PasswordChar = '\0'; }
            if (isImage1Shown) 
            {
                button2.BackgroundImage = Properties.Resources.glazOtkrit; 
                isImage1Shown = false; 
            }
            else
            {
                button2.BackgroundImage = Properties.Resources.glazSkrit;
                isImage1Shown = true; 
            }
            button2.BackgroundImageLayout = ImageLayout.Zoom; 
        }
    }
}

