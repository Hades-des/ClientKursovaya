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

namespace WinFormsAppKursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string lastClickedButton;
        private void AddCRUDFighterButtons()
        {


            Button editButton = new Button();
            editButton.Text = "Изменить";
            editButton.Click += btnAdd_Click;
            editButton.Height = 44;
            editButton.Width = 118;
            editButton.BackColor = Color.White;


            Button deleteButton = new Button();
            deleteButton.Text = "Удалить";
            deleteButton.Click += btnAdd_Click;
            deleteButton.Height = 44;
            deleteButton.Width = 118;
            deleteButton.BackColor = Color.White;

            flowLayoutPanelEdit.Controls.Add(deleteButton);
            flowLayoutPanelEdit.Controls.Add(editButton);
        }
        private void EditFighter_Click(object sender, EventArgs e)
        {
            foreach (Control control in grid.Controls)
            {
                if (control is UserControl)
                {
                    UserControl userControl = (UserControl)control;
                    if (userControl.Visible)
                    {
                        Type type;
                        FieldInfo[] fields;

                        //MessageBox.Show(userControl.Name);
                        switch (userControl.Name)
                        {
                            case "FighterControl":
                                FighterControl fighterControl = new FighterControl();
                                type = typeof(Models.Fighter);
                                fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                                AddForm addForm = new AddForm(fields.Length, type.Name);
                                addForm.Show();

                                break;
                            case "FightHistoryControl":
                                type = typeof(Models.FightHistory);
                                fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                                AddForm addForm1 = new AddForm(fields.Length, type.Name);
                                addForm1.Show();
                                break;
                            case "TrainerControl":
                                type = typeof(Models.Trainer);
                                fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                                AddForm addForm2 = new AddForm(fields.Length, type.Name);
                                addForm2.Show();
                                break;
                            case "MatchControl":
                                type = typeof(Models.Match);
                                fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                                AddForm addForm3 = new AddForm(fields.Length, type.Name);
                                addForm3.Show();
                                break;
                            case "TournamentControl":
                                type = typeof(Models.Tournament);
                                fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                                AddForm addForm4 = new AddForm(fields.Length, type.Name);
                                addForm4.Show();
                                break;
                            case "WeightCategoryControl":
                                type = typeof(Models.WeightCategory);
                                fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                                AddForm addForm5 = new AddForm(fields.Length, type.Name);
                                addForm5.Show();
                                break;
                            case "VictoryMethodControl":
                                type = typeof(Models.VictoryMethod);
                                fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                                AddForm addForm6 = new AddForm(fields.Length, type.Name);
                                addForm6.Show();
                                break;

                            default: break;
                        }

                    }
                }
            }

        }

        private void buttonWeight_Click(object sender, EventArgs e)
        {
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var userControl = new WeightCategoryControl();
            userControl.Dock = DockStyle.Fill;
            grid.Controls.Add(userControl, 1, 1);
        }

        private void buttonFighter_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnFighter";
            flowLayoutPanelEdit.Controls.Clear();
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var employeesControl = new FighterControl();
            employeesControl.Dock = DockStyle.Fill;
            grid.Controls.Add(employeesControl, 1, 1);
            AddCRUDFighterButtons();
        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnMatch";
            flowLayoutPanelEdit.Controls.Clear();
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var ordersControl = new MatchControl();
            ordersControl.Dock = DockStyle.Fill;
            grid.Controls.Add(ordersControl, 1, 1);
            AddCRUDFighterButtons();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnHistory";
            flowLayoutPanelEdit.Controls.Clear();
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var order_Item = new FightHistoryControl();
            order_Item.Dock = DockStyle.Fill;
            grid.Controls.Add(order_Item, 1, 1);
        }

        private void buttonTournament_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnTournament";
            flowLayoutPanelEdit.Controls.Clear();
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var position = new TournamentControl();
            position.Dock = DockStyle.Fill;
            grid.Controls.Add(position, 1, 1);
        }

        private void buttonTrainer_Click(object sender, EventArgs e)
        {
            lastClickedButton = "btnTainer";
            flowLayoutPanelEdit.Controls.Clear();
            grid.Controls.Remove(grid.GetControlFromPosition(1, 1));
            var product = new TrainerControl();
            product.Dock = DockStyle.Fill;
            grid.Controls.Add(product, 1, 1);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control control in grid.Controls)
            {
                if (control is UserControl)
                {
                    UserControl userControl = (UserControl)control;
                    if (userControl.Visible)
                    {
                        Type type;
                        FieldInfo[] fields;

                        if (lastClickedButton == "btnFighter")
                        {
                            FighterControl fighterControl = new FighterControl();
                            type = typeof(Models.Fighter);
                            fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                            FormFighterAdd addForm = new FormFighterAdd(fields.Length, type.Name);
                            addForm.Show();

                        }
                        else if (lastClickedButton == "btnMatch")
                        {
                            type = typeof(Models.Match);
                            fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                            AddForm addForm3 = new AddForm(fields.Length, type.Name);
                            addForm3.Show();
                        }
                        else if (lastClickedButton == "btnHistory")
                        {
                            type = typeof(Models.FightHistory);
                            fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                            AddForm addForm1 = new AddForm(fields.Length, type.Name);
                            addForm1.Show();

                        }
                        else if (lastClickedButton == "btnTournament")
                        {
                            type = typeof(Models.Tournament);
                            fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                            AddForm addForm4 = new AddForm(fields.Length, type.Name);
                            addForm4.Show();
                        }
                        else if (lastClickedButton == "btnTrainer")
                        {
                            type = typeof(Models.Trainer);
                            fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                            AddForm addForm2 = new AddForm(fields.Length, type.Name);
                            addForm2.Show();
                        }
                    }
                }
            }
        }

      /*  private async void btnDelete_Click(object sender, EventArgs e)
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
                            Id = Convert.ToInt32(selectRow.Cells["ID_employee"].Value);

                            // Show confirmation dialog
                            DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                response = ApiRequest.sendPostJSON($"Employee/Delete?Id={Id}", "").Result;
                                click = buttonFighter_Click;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку для удаления.");
                        }
                    }
                    //if (control is Type_Of_CheeseControl typeControl)
                    //{
                    //    if (typeControl.dataType1().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = typeControl.dataType1().SelectedCells[0].RowIndex;
                    //        var selectRow = typeControl.dataType1().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["ID_Type_of_cheese"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"Type_Of_Cheese/Delete?Id={Id}", "").Result;
                    //            click = btnTypeCheese_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}
                    //if (control is CheesesControl cheeseControl)
                    //{
                    //    if (cheeseControl.dataCh().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = cheeseControl.dataCh().SelectedCells[0].RowIndex;
                    //        var selectRow = cheeseControl.dataCh().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["ID_cheese"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"Cheese/Delete?Id={Id}", "").Result;
                    //            click = btnCheeses_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}
                    //if (control is Batch_Of_CheeseControl batchControl)
                    //{
                    //    if (batchControl.dataBatch1().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = batchControl.dataBatch1().SelectedCells[0].RowIndex;
                    //        var selectRow = batchControl.dataBatch1().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["ID_batch"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"BatchOfCheese/Delete?Id={Id}", "").Result;
                    //            click = btnBatch_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}
                    //if (control is ClientControl clientControl)
                    //{
                    //    if (clientControl.dataCl().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = clientControl.dataCl().SelectedCells[0].RowIndex;
                    //        var selectRow = clientControl.dataCl().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["ID_client"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"Client/Delete?Id={Id}", "").Result;
                    //            click = btnClient_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}
                    //if (control is Kameri_hraneniya kameraControl)
                    //{
                    //    if (kameraControl.dataKam().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = kameraControl.dataKam().SelectedCells[0].RowIndex;
                    //        var selectRow = kameraControl.dataKam().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["ID_Kameri_hraneniya"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"Kamera_Hraneniya/Delete?Id={Id}", "").Result;
                    //            click = btnKamera_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}
                    //if (control is PackingControl packControl)
                    //{
                    //    if (packControl.dataPack().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = packControl.dataPack().SelectedCells[0].RowIndex;
                    //        var selectRow = packControl.dataPack().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["ID_packaging"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"Packing_list/Delete?Id={Id}", "").Result;
                    //            click = btnPack_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}
                    //if (control is PositionControl posControl)
                    //{
                    //    if (posControl.dataPs().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = posControl.dataPs().SelectedCells[0].RowIndex;
                    //        var selectRow = posControl.dataPs().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["Position_code"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"Position/Delete?Id={Id}", "").Result;
                    //            click = btnPos_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}
                    //if (control is ShipmentControl shipControl)
                    //{
                    //    if (shipControl.dataShipment().SelectedRows.Count > 0)
                    //    {
                    //        int rowIndex = shipControl.dataShipment().SelectedCells[0].RowIndex;
                    //        var selectRow = shipControl.dataShipment().Rows[rowIndex];
                    //        Id = Convert.ToInt32(selectRow.Cells["ID_shipment"].Value);

                    //        // Show confirmation dialog
                    //        DialogResult result = MessageBox.Show("Точно удалить строку?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                    //        if (result == DialogResult.Yes)
                    //        {
                    //            response = ApiRequest.sendPostJSON($"Shipment/Delete?Id={Id}", "").Result;
                    //            click = btnShip_Click;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Выберите строку для удаления.");
                    //    }
                    //}

                }*/
            }
        }
 
