using WinFormsAppKursovaya.Controls;
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
using WinFormsAppKursovaya.Models;
using System.Net.Http;
using System.Reflection;
using WinFormsAppKursovaya.AddForms;
using System.Data.Common;
using System.Net.Sockets;
using System.Security.AccessControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;

namespace WinFormsAppKursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form  in Application.OpenForms)
            {
                if (form != this)
                {
                    form.Close();
                    form.Dispose();
                }
            }
        }

        private string lastClickedButton;

        private void AddCRUDButtons()
        {
            System.Windows.Forms.Button editButton = new System.Windows.Forms.Button();
            editButton.Text = "Изменить";
            editButton.Click += Update_Click;
            editButton.Height = 44;
            editButton.Width = 118;
            editButton.BackColor = Color.White;

            System.Windows.Forms.Button addButton = new System.Windows.Forms.Button();
            addButton.Text = "Добавить";
            addButton.Click += btnAdd_Click;
            addButton.Height = 44;
            addButton.Width = 118;
            addButton.BackColor = Color.White;


            System.Windows.Forms.Button deleteButton = new System.Windows.Forms.Button();
            deleteButton.Text = "Удалить";
            deleteButton.Click += btnDelete_Click;
            deleteButton.Height = 44;
            deleteButton.Width = 118;
            deleteButton.BackColor = Color.White;

            flowLayoutPanelEdit.Controls.Add(deleteButton);
            flowLayoutPanelEdit.Controls.Add(editButton);
            flowLayoutPanelEdit.Controls.Add(addButton);
        }

        private void buttonWeight_Click(object sender, EventArgs e)
        {
            flowLayoutPanelEdit.Controls.Clear();
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var weightControl = new WeightCategoryControl();
            weightControl.Dock = DockStyle.Fill;
            grid.Controls.Add(weightControl, 1, 1);
        }

        private void buttonFighter_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnFighter";

            flowLayoutPanelEdit.Controls.Clear();
            AddCRUDButtons();

            Control control = grid.GetControlFromPosition(1, 1);
            if (control != null)
            {
                grid.Controls.Remove(control);
            }
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            var fighterControl = new FighterControl();
            fighterControl.Dock = DockStyle.Fill;

            panel.Controls.Add(fighterControl);
            grid.Controls.Add(panel, 1, 1);

        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnMatch";
            flowLayoutPanelEdit.Controls.Clear();
            AddCRUDButtons();

            Control control = grid.GetControlFromPosition(1, 1);
            if (control != null)
            {
                grid.Controls.Remove(control);
            }

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            var matchControl = new MatchControl();
            matchControl.Dock = DockStyle.Fill;

            panel.Controls.Add(matchControl);
            grid.Controls.Add(panel, 1, 1);
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnHistory";
            flowLayoutPanelEdit.Controls.Clear();
            AddCRUDButtons();

            Control control = grid.GetControlFromPosition(1, 1);
            if (control != null)
            {
                grid.Controls.Remove(control);
            }

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            var historyControl = new FightHistoryControl();
            historyControl.Dock = DockStyle.Fill;

            panel.Controls.Add(historyControl);
            grid.Controls.Add(panel, 1, 1);
        }

        private void buttonTournament_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnTournament";
            flowLayoutPanelEdit.Controls.Clear();
            AddCRUDButtons();

            Control control = grid.GetControlFromPosition(1, 1);
            if (control != null)
            {
                grid.Controls.Remove(control);
            }

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            var tournamentControl = new TournamentControl();
            tournamentControl.Dock = DockStyle.Fill;

            panel.Controls.Add(tournamentControl);
            grid.Controls.Add(panel, 1, 1);
        }

        private void buttonTrainer_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnTrainer";
            flowLayoutPanelEdit.Controls.Clear();
            AddCRUDButtons();

            Control control = grid.GetControlFromPosition(1, 1);
            if (control != null)
            {
                grid.Controls.Remove(control);
            }

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            var trainerControl = new TrainerControl();
            trainerControl.Dock = DockStyle.Fill;

            panel.Controls.Add(trainerControl);
            grid.Controls.Add(panel, 1, 1);

        }

        private void buttonVictory_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnVictory";
            flowLayoutPanelEdit.Controls.Clear();
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var product_Characteristics = new VictoryMethodControl();
            product_Characteristics.Dock = DockStyle.Fill;
            grid.Controls.Add(product_Characteristics, 1, 1);
        }

    

        private DataGridView GetCurrentDataGridView()
        {
            Panel panel = grid.GetControlFromPosition(1, 1) as Panel;
            if (panel != null)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is DataGridView dataGridView)
                    {
                        return dataGridView;
                    }
                }
            }
            return null;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (lastClickedButton)
            {
                case "btnFighter":
                    FormFighterAdd addFighterForm = new FormFighterAdd();
                    addFighterForm.ShowDialog();
                    buttonFighter_Click(sender, e);
                    break;
                case "btnHistory":
                    FormFighterHistoryAdd addHistoryForm = new FormFighterHistoryAdd();
                    addHistoryForm.ShowDialog();
                    buttonFighter_Click(sender, e);
                    break;
                case "btnMatch":
                    FormMatchAdd addMatchForm = new FormMatchAdd();
                    addMatchForm.ShowDialog();
                    buttonFighter_Click(sender, e);
                    break;
                case "btnTrainer":
                    FormTrainerAdd addTrainerForm = new FormTrainerAdd();
                    addTrainerForm.ShowDialog();
                    buttonFighter_Click(sender, e);
                    break;
                case "btnTournament":
                    FormTournamentAdd addTournamentForm = new FormTournamentAdd();
                    addTournamentForm.ShowDialog();
                    buttonFighter_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var jsonData = "";
            var response = "";

            int Id = 0;
            var click = buttonFighter_Click;
            Panel panel = grid.GetControlFromPosition(1, 1) as Panel;
            if (panel != null)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is FighterControl fightercontrol)
                    {
                        if (fightercontrol.dataFight().SelectedRows.Count > 0)
                        {
                            int rowIndex = fightercontrol.dataFight().SelectedCells[0].RowIndex;
                            var selectRow = fightercontrol.dataFight().Rows[rowIndex];
                            Id = Convert.ToInt32(selectRow.Cells[0].Value);

                            // Show confirmation dialog
                            DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                try
                                {
                                    response = await ApiRequest.sendDelete($"Fighter/Delete/{Id}");
                                    MessageBox.Show($"{response}");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ошибка при удалении бойца: {ex.Message}");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для удаления.");
                        }
                    }
                    if (control is FightHistoryControl historycontrol)
                    {
                        if (historycontrol.dataFH().SelectedRows.Count > 0)
                        {
                            int rowIndex = historycontrol.dataFH().SelectedCells[0].RowIndex;
                            var selectRow = historycontrol.dataFH().Rows[rowIndex];
                            Id = Convert.ToInt32(selectRow.Cells[0].Value);

                            // Show confirmation dialog
                            DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                response = ApiRequest.sendDelete($"FightHistory/Delete/{Id}").Result;
                                click = buttonHistory_Click;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для удаления.");
                        }
                    }
                    if (control is MatchControl matchControl)
                    {
                        if (matchControl.dataMatch().SelectedRows.Count > 0)
                        {
                            int rowIndex = matchControl.dataMatch().SelectedCells[0].RowIndex;
                            var selectRow = matchControl.dataMatch().Rows[rowIndex];
                            Id = Convert.ToInt32(selectRow.Cells[0].Value);


                            DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                response = ApiRequest.sendDelete($"Match/Delete/{Id}").Result;
                                click = buttonMatch_Click;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для удаления.");
                        }
                    }
                    if (control is TournamentControl tournamentControl)
                    {
                        if (tournamentControl.dataTournament().SelectedRows.Count > 0)
                        {
                            int rowIndex = tournamentControl.dataTournament().SelectedCells[0].RowIndex;
                            var selectRow = tournamentControl.dataTournament().Rows[rowIndex];
                            Id = Convert.ToInt32(selectRow.Cells[0].Value);

                            DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                response = ApiRequest.sendDelete($"Tournament/Delete/{Id}").Result;
                                click = buttonTournament_Click;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для удаления.");
                        }
                    }
                    if (control is TrainerControl trainerControl)
                    {
                        if (trainerControl.dataTrainer().SelectedRows.Count > 0)
                        {
                            int rowIndex = trainerControl.dataTrainer().SelectedCells[0].RowIndex;
                            var selectRow = trainerControl.dataTrainer().Rows[rowIndex];
                            Id = Convert.ToInt32(selectRow.Cells[0].Value);


                            DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                response = ApiRequest.sendDelete($"Trainer/Delete/{Id}").Result;
                                click = buttonTrainer_Click;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для удаления.");
                        }
                    }

                }
            }

        }
        private void Update_Click(object sender, EventArgs e)
        {

            Panel panel = grid.GetControlFromPosition(1, 1) as Panel;
            if (panel != null)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is FighterControl fighterControl)
                    {
                        if (fighterControl.dataFight().SelectedRows.Count > 0)
                        {
                            int rowIndex = fighterControl.dataFight().SelectedCells[0].RowIndex;
                            var selectedRow = fighterControl.dataFight().Rows[rowIndex];
                            Fighter fighter = new Fighter
                            {
                                Id = Convert.ToInt32(selectedRow.Cells[0].Value),
                              //  Weight_Category = Convert.ToInt32(selectedRow.Cells[1].Value),
                              //  Coach = Convert.ToInt32(selectedRow.Cells[2].Value),
                                FullName = Convert.ToString(selectedRow.Cells[3].Value),
                                Age = Convert.ToInt32(selectedRow.Cells[4].Value)
                            };
                            FormFighterAdd formFighter = new FormFighterAdd(fighter);
                            formFighter.ShowDialog();

                            buttonFighter_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для редактирования.");
                        }
                    }

                    if (control is TournamentControl tournamentControl)
                    {
                        if (tournamentControl.dataTournament().SelectedRows.Count > 0)
                        {
                            int rowIndex = tournamentControl.dataTournament().SelectedCells[0].RowIndex;
                            var selectedRow = tournamentControl.dataTournament().Rows[rowIndex];
                            Tournament tournament = new Tournament
                            {
                                Id = Convert.ToInt32(selectedRow.Cells[0].Value),
                                Data_Held = Convert.ToDateTime(selectedRow.Cells[1].Value),
                                Arena = Convert.ToString(selectedRow.Cells[2].Value)
                            };
                            FormTournamentAdd formTournament = new FormTournamentAdd(tournament);
                            formTournament.ShowDialog();

                            buttonTournament_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для редактирования.");
                        }

                    }

                    if (control is TrainerControl trainerControl)
                    {
                        if (trainerControl.dataTrainer().SelectedRows.Count > 0)
                        {
                            int rowIndex = trainerControl.dataTrainer().SelectedCells[0].RowIndex;
                            var selectedRow = trainerControl.dataTrainer().Rows[rowIndex];
                            Trainer trainer = new Trainer
                            {
                                Id = Convert.ToInt32(selectedRow.Cells[0].Value),
                                FullName = Convert.ToString(selectedRow.Cells[1].Value),
                                Rank = Convert.ToString(selectedRow.Cells[2].Value),
                                Age = Convert.ToInt32(selectedRow.Cells[3].Value)
                            };
                            FormTrainerAdd formTournament = new FormTrainerAdd(trainer);
                            formTournament.ShowDialog();

                            buttonTrainer_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для редактирования.");
                        }

                    }

                    if (control is FightHistoryControl fightHistoryControl)
                    {
                        if (fightHistoryControl.dataFH().SelectedRows.Count > 0)
                        {
                            int rowIndex = fightHistoryControl.dataFH().SelectedCells[0].RowIndex;
                            var selectedRow = fightHistoryControl.dataFH().Rows[rowIndex];
                            FightHistory fightHistory = new FightHistory
                            {
                                Id = Convert.ToInt32(selectedRow.Cells[0].Value),
                               // Fighter = Convert.ToInt32(selectedRow.Cells[1].Value),
                               // Tournament = Convert.ToInt32(selectedRow.Cells[2].Value),
                                Victories = Convert.ToInt32(selectedRow.Cells[3].Value),
                                Defeats = Convert.ToInt32(selectedRow.Cells[4].Value)
                            };
                            FormFighterHistoryAdd formHistory = new FormFighterHistoryAdd(fightHistory);
                            formHistory.ShowDialog();

                            buttonHistory_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для редактирования.");
                        }

                    }

                    if (control is MatchControl matchControl)
                    {
                        if (matchControl.dataMatch().SelectedRows.Count > 0)
                        {
                            int rowIndex = matchControl.dataMatch().SelectedCells[0].RowIndex;
                            var selectedRow = matchControl.dataMatch().Rows[rowIndex];
                            Match match = new Match
                            {
                                Id = Convert.ToInt32(selectedRow.Cells[0].Value),
                               // Tournament = Convert.ToInt32(selectedRow.Cells[1].Value),
                               // Fighter_1 = Convert.ToInt32(selectedRow.Cells[2].Value),
                               // Fighter_2 = Convert.ToInt32(selectedRow.Cells[3].Value),
                               // Victory_method = Convert.ToInt32(selectedRow.Cells[4].Value),
                                Result = Convert.ToString(selectedRow.Cells[5].Value)
                            };
                            FormMatchAdd formMatch = new FormMatchAdd(match);
                            formMatch.ShowDialog();

                            buttonMatch_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для редактирования.");
                        }

                    }
                }
            }
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox2.Text.ToLower();


            foreach (Control control in grid.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control innerControl in panel.Controls)
                    {
                        if (innerControl is FighterControl typeOfCheeseControl)
                        {

                            typeOfCheeseControl.ApplyFilter(filterText);

                        }
                        else if (innerControl is FightHistoryControl batchControl)
                        {

                            batchControl.ApplyFilter(filterText);

                        }
                        else if (innerControl is MatchControl kameraControl)
                        {

                            kameraControl.ApplyFilter(filterText);

                        }
                        else if (innerControl is TournamentControl cheeseControl)
                        {

                            cheeseControl.ApplyFilter(filterText);

                        }
                        else if (innerControl is TrainerControl clientControl)
                        {

                            clientControl.ApplyFilter(filterText);

                        }
                        else if (innerControl is VictoryMethodControl employeeControl)
                        {

                            employeeControl.ApplyFilter(filterText);

                        }
                        else if (innerControl is WeightCategoryControl packControl)
                        {

                            packControl.ApplyFilter(filterText);

                        }

                    }
                }
            }
        }

        private void SortTableAlphabetically(DataGridView dataGridView)
        {
            if (dataGridView != null && dataGridView.DataSource != null && dataGridView.Columns.Count > 0)
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataGridView.DataSource;
                dataGridView.DataSource = bindingSource;

                PropertyDescriptor property = TypeDescriptor.GetProperties(bindingSource.DataSource.GetType())[dataGridView.Columns[0].DataPropertyName];
                bindingSource.Sort = property.Name;
            }
            else
            {
                MessageBox.Show("Невозможно выполнить сортировку. Проверьте таблицу на наличие данных и столбцов.");
            }
        }

        private void Sort_Click(object sender, EventArgs e)
        {

            switch (lastClickedButton)
            {
                case "btnFighter":
                    foreach (Control control in grid.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is FighterControl fighterControl)
                                {
                                    SortTableAlphabetically(fighterControl.dataFight());
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case "btnHistory":
                    foreach (Control control in grid.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is FightHistoryControl historyControl)
                                {
                                    SortTableAlphabetically(historyControl.dataFH());
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case "btnMatch":
                    foreach (Control control in grid.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is MatchControl matchControl)
                                {
                                    SortTableAlphabetically(matchControl.dataMatch());
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case "btnTrainer":
                    foreach (Control control in grid.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is TrainerControl trainerControl)
                                {
                                    SortTableAlphabetically(trainerControl.dataTrainer());
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case "btnTournament":
                    foreach (Control control in grid.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is TournamentControl tournamentControl)
                                {
                                    SortTableAlphabetically(tournamentControl.dataTournament());
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case "btnVictory":
                    foreach (Control control in grid.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is VictoryMethodControl methodControl)
                                {
                                    SortTableAlphabetically(methodControl.dataBatch1());
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case "btnWeight":
                    foreach (Control control in grid.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is WeightCategoryControl weightControl)
                                {
                                    SortTableAlphabetically(weightControl.dataBatch1());
                                    return;
                                }
                            }
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Активная таблица не найдена.");
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormAutorisation autorisation = new FormAutorisation();
            autorisation.Show();
            this.Hide();
        }
    }
}
