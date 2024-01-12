using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExcelDataReader;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;

namespace ReadRfiFromExcel
{
    public partial class MainForm : Form
    {
        private readonly List<RFI> RfiList = new List<RFI>();
        private readonly List<Part> Parts = new List<Part>();
        private string InfoFileLocation;
        public MainForm()
        {
            this.InitializeComponent();
        }

        private void ButtonUpdateSelectedParts_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.TextBoxPath.Text))
            {
                this.LabelUpdateExcelFileMissing();
                return;
            }

            this.LabeUpdate("Creating a list of selected parts in the model ...", System.Drawing.Color.Firebrick);
            this.CollectPartsFromTheModel();
            this.SortCurrentRfis();
            this.PopulatePartsFields();
        }

        private void LabelUpdateExcelFileMissing()
        {
            this.LabeUpdate("Please, setup Excel file location ...", System.Drawing.Color.Firebrick);
            MessageBox.Show("Please, setup Excel file location ...", "Excel file location ...");
        }

        private void PopulatePartsFields()
        {
            var model = new Model();

            this.RedrawViews();

            this.LabeUpdate("Cleaning the old user fields ...", System.Drawing.Color.Firebrick);
            this.CleanUpOldFieldsFromTheParts();

            this.LabeUpdate("Updating the new user fields ...", System.Drawing.Color.Firebrick);
            this.UpdatePartsNewFields();

            this.LabeUpdate("Updating field Outstadning RFI's ...", System.Drawing.Color.Firebrick);
            this.UpdatePartsOutstadningFieldsOfTheparts();

            this.LabeUpdate("Update of the selected parts in the model is completed !!!", System.Drawing.Color.Black);

            model.CommitChanges();
        }

        private void RedrawViews()
        {
            var vissibleViews = ViewHandler.GetVisibleViews();
            while (vissibleViews.MoveNext())
            {
                var CurrentView = vissibleViews.Current;
                ViewHandler.RedrawView(CurrentView);
            }
        }

        private void UpdatePartsOutstadningFieldsOfTheparts()
        {
            foreach (var part in this.Parts)
            {
                var otstanding = new List<string>();

                this.CheckFieldStatus(part, otstanding, "RFI1");
                this.CheckFieldStatus(part, otstanding, "RFI2");
                this.CheckFieldStatus(part, otstanding, "RFI3");
                this.CheckFieldStatus(part, otstanding, "RFI4");
                this.CheckFieldStatus(part, otstanding, "RFI5");

                part.SetUserProperty("RFIcombined", string.Join(", ", otstanding));
                this.WriteLabelInMiddleOfPart(part, otstanding);
            }
        }

        private void WriteLabelInMiddleOfPart(Part part, List<string> otstanding)
        {
            var sx = 0.0;
            part.GetReportProperty("START_X_IN_WORK_PLANE", ref sx);
            var sy = 0.0;
            part.GetReportProperty("START_Y_IN_WORK_PLANE", ref sy);
            var sz = 0.0;
            part.GetReportProperty("START_Z_IN_WORK_PLANE", ref sz);

            var ex = 0.0;
            part.GetReportProperty("END_X_IN_WORK_PLANE", ref ex);
            var ey = 0.0;
            part.GetReportProperty("END_Y_IN_WORK_PLANE", ref ey);
            var ez = 0.0;
            part.GetReportProperty("END_Z_IN_WORK_PLANE", ref ez);

            var midPoint = new Tekla.Structures.Geometry3d.Point((sx + ex) / 2, (sy + ey) / 2, (sz + ez) / 2);

            var drawer = new GraphicsDrawer();
            var ass = part.GetAssembly();
            var mainPart = ass.GetMainPart() as Part;
            if (part.Equals(mainPart))
            {
                if (otstanding.Count == 0)
                {
                    return;
                }

                drawer.DrawText(midPoint, @"RFI No: " + string.Join(", ", otstanding), new Color(0.0, 0.0, 0.0));
            }
        }

        private void CheckFieldStatus(Part part, List<string> otstanding, string field)
        {
            var rfi1Closed = string.Empty;
            part.GetReportProperty(field + "Closed", ref rfi1Closed);
            if (rfi1Closed.ToUpper() != "YES" && rfi1Closed.ToUpper() != "")
            {
                var fieldValue = string.Empty;
                part.GetReportProperty(field, ref fieldValue);
                otstanding.Add(fieldValue);
            }
        }

        private void UpdatePartsNewFields()
        {
            foreach (var part in this.Parts)
            {
                this.SetFieldsAsPerRfiList(part, "RFI1");
                this.SetFieldsAsPerRfiList(part, "RFI2");
                this.SetFieldsAsPerRfiList(part, "RFI3");
                this.SetFieldsAsPerRfiList(part, "RFI4");
                this.SetFieldsAsPerRfiList(part, "RFI5");
            }
        }

        private void SetFieldsAsPerRfiList(Part part, string RfiField)
        {
            var fieldValue = string.Empty;
            part.GetReportProperty(RfiField, ref fieldValue);

            foreach (var rfi in this.RfiList)
            {
                if (rfi.Number == fieldValue)
                {
                    part.SetUserProperty(RfiField + "Subject", rfi.Subject);
                    part.SetUserProperty(RfiField + "Closed", rfi.Closed);
                }
            }
        }

        private void CleanUpOldFieldsFromTheParts()
        {
            foreach (var part in this.Parts)
            {
                CleanUpOldFiledValues(part, "RFI1");
                CleanUpOldFiledValues(part, "RFI2");
                CleanUpOldFiledValues(part, "RFI3");
                CleanUpOldFiledValues(part, "RFI4");
                CleanUpOldFiledValues(part, "RFI5");
            }
        }

        private static void CleanUpOldFiledValues(Part part, string field)
        {
            part.SetUserProperty(field + "Subject", string.Empty);
            part.SetUserProperty(field + "Closed", string.Empty);
        }

        private void CollectPartsFromTheModel()
        {
            this.LabeUpdate("Collecting parts from the model ...", System.Drawing.Color.Firebrick);

            this.Parts.Clear();
            var mos = new ModelObjectSelector();
            var moe = mos.GetSelectedObjects();

            while (moe.MoveNext())
            {
                var part = moe.Current as Part;
                if (part == null)
                {
                    continue;
                }
                this.Parts.Add(part);
            }
        }

        private void ReadExcelFile()
        {

            this.RfiList.Clear();

            if (!File.Exists(this.TextBoxPath.Text))
            {
                this.LabelUpdateExcelFileMissing();
                return;
            }

            this.LabeUpdate("Loading data from excel file ...", System.Drawing.Color.Firebrick);

            try
            {
                using (var stream = File.Open(this.TextBoxPath.Text, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var conf = new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = config => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = false
                            }
                        };

                        var dataSet = reader.AsDataSet(conf);
                        var dataTableCollection = dataSet.Tables;
                        var IrsSummaryDataTable = dataTableCollection["IRS_SUMMARY"];
                        var rfiColumn = "column" + (int.Parse(this.TextBoxRFIColumn.Text) - 1);
                        var subjectColumn = "column" + (int.Parse(this.TextBoxSubjectColumn.Text) - 1);
                        var closeOutColumn = "column" + (int.Parse(this.TextBoxClosedColumn.Text) - 1);
                        var columnsToExtract = new string[] { rfiColumn, subjectColumn, closeOutColumn };
                        var dataTable = IrsSummaryDataTable.DefaultView.ToTable(false, columnsToExtract);
                        dataTable.Columns[0].ColumnName = "RFI No";
                        dataTable.Columns[1].ColumnName = "Subject Summary";
                        dataTable.Columns[2].ColumnName = "Closed Out";

                        var numberOfRowsToRemove = int.Parse(this.TextBoxHeaderRow.Text);
                        for (var i = 0; i < numberOfRowsToRemove; i++)
                        {
                            dataTable.Rows.RemoveAt(0);
                            dataTable.AcceptChanges();
                        }

                        for (var i = 0; i < dataTable.Rows.Count; i++)
                        {
                            if (string.IsNullOrWhiteSpace(dataTable.Rows[i]["Subject Summary"].ToString()))
                            {
                                dataTable.Rows[i].Delete();
                            }
                        }
                        dataTable.AcceptChanges();

                        this.DataGridView.DataSource = dataTable;
                        this.DataGridView.RowHeadersVisible = false;
                        this.DataGridView.AllowUserToResizeRows = false;
                        this.DataGridView.ReadOnly = true;
                        this.DataGridView.Columns[0].Width = 90;
                        this.DataGridView.Columns[1].Width = 435;
                        this.DataGridView.Columns[2].Width = 90;

                        this.DataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        this.DataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        this.ButtonReload.ForeColor = System.Drawing.Color.Black;
                        this.TextBoxPath.ForeColor = System.Drawing.Color.Black;
                        this.TextBoxRFIColumn.ForeColor = System.Drawing.Color.Black;
                        this.TextBoxSubjectColumn.ForeColor = System.Drawing.Color.Black;
                        this.TextBoxClosedColumn.ForeColor = System.Drawing.Color.Black;
                        this.TextBoxHeaderRow.ForeColor = System.Drawing.Color.Black;

                        for (var i = 0; i < this.DataGridView.Rows.Count; i++)
                        {
                            if (this.DataGridView.Rows[i].Cells[2].Value.ToString().ToUpper() == "YES")
                            {
                                this.DataGridView.Rows[i].Cells[0].Style.SelectionBackColor = System.Drawing.Color.Silver;
                                this.DataGridView.Rows[i].Cells[0].Style.SelectionForeColor = System.Drawing.Color.Black;

                                this.DataGridView.Rows[i].Cells[1].Style.SelectionBackColor = System.Drawing.Color.Silver;
                                this.DataGridView.Rows[i].Cells[1].Style.SelectionForeColor = System.Drawing.Color.Black;

                                this.DataGridView.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Green;
                                this.DataGridView.Rows[i].Cells[2].Style.SelectionBackColor = System.Drawing.Color.DarkGreen;
                                this.DataGridView.Rows[i].Cells[2].Style.SelectionForeColor = System.Drawing.Color.Black;

                                continue;
                            }

                            if (this.DataGridView.Rows[i].Cells[2].Value.ToString().ToUpper() == "NO")
                            {
                                this.DataGridView.Rows[i].Cells[0].Style = new DataGridViewCellStyle { ForeColor = System.Drawing.Color.Red };
                                this.DataGridView.Rows[i].Cells[0].Style.Font = new System.Drawing.Font(this.DataGridView.DefaultCellStyle.Font, System.Drawing.FontStyle.Italic);
                                this.DataGridView.Rows[i].Cells[0].Style.SelectionBackColor = System.Drawing.Color.Silver;
                                this.DataGridView.Rows[i].Cells[0].Style.SelectionForeColor = System.Drawing.Color.DarkRed;

                                this.DataGridView.Rows[i].Cells[1].Style = new DataGridViewCellStyle { ForeColor = System.Drawing.Color.Red };
                                this.DataGridView.Rows[i].Cells[1].Style.Font = new System.Drawing.Font(this.DataGridView.DefaultCellStyle.Font, System.Drawing.FontStyle.Italic);
                                this.DataGridView.Rows[i].Cells[1].Style.SelectionBackColor = System.Drawing.Color.Silver;
                                this.DataGridView.Rows[i].Cells[1].Style.SelectionForeColor = System.Drawing.Color.DarkRed;

                                this.DataGridView.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                                this.DataGridView.Rows[i].Cells[2].Style.SelectionBackColor = System.Drawing.Color.DarkRed;
                                this.DataGridView.Rows[i].Cells[2].Style.SelectionForeColor = System.Drawing.Color.Black;

                                continue;
                            }

                            this.DataGridView.Rows[i].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
                            this.DataGridView.Rows[i].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                        }

                        foreach (System.Data.DataRow row in dataTable.Rows)
                        {
                            this.RfiList.Add(new RFI(row));
                        }
                    }
                }

                this.LabeUpdate("Loading data from excel file, completed. Total of " + this.RfiList.Count + " No. RFI's found !!!", System.Drawing.Color.Black);
                this.WriteExcelFileInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Excel file is opened, please close the file and try again ...", "Excel File Access ...");
                this.LabeUpdate("Excel file is opened, please close the file and try again ...", System.Drawing.Color.Firebrick);
                return;
            }
        }

        private void ButtonLoadFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsm;*.xlsx;*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.TextBoxPath.Text = openFileDialog.FileName;
                    this.ReadExcelFile();
                }
            }
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            if (this.TextBoxPath.Text == "")
            {
                this.LabelUpdateExcelFileMissing();
                return;
            }
            this.ReadExcelFile();
        }

        private void TextBoxPath_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxPath.Text = this.TextBoxPath.Text;
            this.TextBoxPath.ForeColor = System.Drawing.Color.Firebrick;
            this.LabeUpdate("Excel path location has been updated, please reload excel file ...", System.Drawing.Color.Firebrick);
            this.ButtonReload.ForeColor = System.Drawing.Color.Firebrick;
        }

        private void TextBoxHeaderRow_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxHeaderRow.Text = this.TextBoxHeaderRow.Text;
            this.TextBoxHeaderRow.ForeColor = System.Drawing.Color.Firebrick;
            this.LabeUpdate("Header column has been updated, please reload excel file ...", System.Drawing.Color.Firebrick);
            this.ButtonReload.ForeColor = System.Drawing.Color.Firebrick;
        }

        private void TextBoxRFIColumn_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxRFIColumn.Text = this.TextBoxRFIColumn.Text;
            this.TextBoxRFIColumn.ForeColor = System.Drawing.Color.Firebrick;
            this.LabeUpdate("RFI column has been updated, please reload excel file ...", System.Drawing.Color.Firebrick);
            this.ButtonReload.ForeColor = System.Drawing.Color.Firebrick;
        }

        private void TextBoxSubjectColumn_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxSubjectColumn.Text = this.TextBoxSubjectColumn.Text;
            this.TextBoxSubjectColumn.ForeColor = System.Drawing.Color.Firebrick;
            this.LabeUpdate("Subject column has been updated, please reload excel file ...", System.Drawing.Color.Firebrick);
            this.ButtonReload.ForeColor = System.Drawing.Color.Firebrick;
        }

        private void TextBoxClosedColumn_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxClosedColumn.Text = this.TextBoxClosedColumn.Text;
            this.TextBoxClosedColumn.ForeColor = System.Drawing.Color.Firebrick;
            this.LabeUpdate("Closed Out column has been updated, please reload excel file ...", System.Drawing.Color.Firebrick);
            this.ButtonReload.ForeColor = System.Drawing.Color.Firebrick;
        }

        private void LabeUpdate(string text, System.Drawing.Color color)
        {
            this.Label.Text = text;
            this.Label.ForeColor = color;
            this.Label.Update();
        }

        private void ButtonRepresentationRfiNo_Click(object sender, EventArgs e)
        {
            this.ChangeRepresentation("RFI No");
        }

        private void ButtonRepresentationClosedOut_Click(object sender, EventArgs e)
        {
            this.ChangeRepresentation("RFI Closed out");
        }

        private void ButtonRepresentationPhase_Click(object sender, EventArgs e)
        {
            this.ChangeRepresentation("Color by Phase");
        }

        private void ChangeRepresentation(string representation)
        {
            this.LabeUpdate("Updating representation to " + representation + " ...", System.Drawing.Color.Firebrick);

            var VisibleViews = ViewHandler.GetVisibleViews();
            while (VisibleViews.MoveNext())
            {
                var CurrentView = VisibleViews.Current;
                CurrentView.CurrentRepresentation = representation;
                CurrentView.Modify();
            }

            this.LabeUpdate("Representation changed to " + representation + " !!!", System.Drawing.Color.Black);
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            var model = new Model();
            var modelPath = model.GetInfo().ModelPath;
            this.InfoFileLocation = Path.Combine(modelPath, "RfiExcelFileInfo" + this.GetInitials() + ".info");

            if (File.Exists(this.InfoFileLocation))
            {
                this.ReadRfiExcelFileInfo();
            }

            if (File.Exists(this.TextBoxPath.Text))
            {
                this.ReadExcelFile();
            }

            this.Label1.Enabled = false;
            this.Label2.Enabled = false;
            this.Label3.Enabled = false;
            this.Label4.Enabled = false;
            this.TextBoxHeaderRow.Enabled = false;
            this.TextBoxRFIColumn.Enabled = false;
            this.TextBoxSubjectColumn.Enabled = false;
            this.TextBoxClosedColumn.Enabled = false;
        }

        private string GetInitials()
        {
            var userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var name = userName.Substring((userName.IndexOf("\\", StringComparison.CurrentCulture) + 1));
            var firstName = name.Split('.')[0];
            var secondName = name.Split('.')[1];
            var initials = char.ToUpper(firstName[0]).ToString() + char.ToUpper(secondName[0]).ToString();
            return initials;
        }

        private void ReadRfiExcelFileInfo()
        {
            TextReader streamReader = new StreamReader(this.InfoFileLocation);
            this.TextBoxPath.Text = streamReader.ReadLine();
            this.TextBoxHeaderRow.Text = streamReader.ReadLine();
            this.TextBoxRFIColumn.Text = streamReader.ReadLine();
            this.TextBoxSubjectColumn.Text = streamReader.ReadLine();
            this.TextBoxClosedColumn.Text = streamReader.ReadLine();
            streamReader.Close();
        }

        private void WriteExcelFileInfo()
        {
            TextWriter streamWriter = new StreamWriter(this.InfoFileLocation);
            streamWriter.WriteLine(this.TextBoxPath.Text);
            streamWriter.WriteLine(this.TextBoxHeaderRow.Text);
            streamWriter.WriteLine(this.TextBoxRFIColumn.Text);
            streamWriter.WriteLine(this.TextBoxSubjectColumn.Text);
            streamWriter.Write(this.TextBoxClosedColumn.Text);
            streamWriter.Close();
        }

        private void ButtonAssignValue_Click(object sender, EventArgs e)
        {
            var selectedRows = this.DataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                this.LabelUpdateExcelFileMissing();
                return;
            }

            this.CollectPartsFromTheModel();

            foreach (DataGridViewRow row in selectedRows)
            {
                var selectedRfiNumber = row.Cells[0].Value.ToString();
                var selectedRfiSubject = row.Cells[1].Value.ToString();
                this.AssignValues(selectedRfiNumber);
                this.LabeUpdate("RFI No. " + selectedRfiNumber + ", " + selectedRfiSubject + ", " + "assigned to the parts", System.Drawing.Color.DodgerBlue);
            }

            this.PopulatePartsFields();
        }
        private void ButtonRemoveValue_Click(object sender, EventArgs e)
        {
            var selectedRows = this.DataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                this.LabelUpdateExcelFileMissing();
                return;
            }

            this.CollectPartsFromTheModel();

            if (selectedRows.Count == this.RfiList.Count)
            {
                this.RemoveAllTheValues();
            }

            if (selectedRows.Count != this.RfiList.Count)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    var selectedRfiNumber = row.Cells[0].Value.ToString();
                    var selectedRfiSubject = row.Cells[1].Value.ToString();
                    this.RemoveValues(selectedRfiNumber);
                    this.LabeUpdate("RFI No. " + selectedRfiNumber + ", " + selectedRfiSubject + ", " + "removed from the parts", System.Drawing.Color.Firebrick);
                }
            }

            this.PopulatePartsFields();
        }

        private void RemoveAllTheValues()
        {
            foreach (var part in this.Parts)
            {
                part.SetUserProperty("RFI1", "");
                part.SetUserProperty("RFI2", "");
                part.SetUserProperty("RFI3", "");
                part.SetUserProperty("RFI4", "");
                part.SetUserProperty("RFI5", "");
            }
        }

        private void SortCurrentRfis()
        {
            foreach (var part in this.Parts)
            {
                var tempRfiList = new List<int>();

                var rfi1 = string.Empty;
                part.GetReportProperty("RFI1", ref rfi1);

                var rfi2 = string.Empty;
                part.GetReportProperty("RFI2", ref rfi2);

                var rfi3 = string.Empty;
                part.GetReportProperty("RFI3", ref rfi3);

                var rfi4 = string.Empty;
                part.GetReportProperty("RFI4", ref rfi4);

                var rfi5 = string.Empty;
                part.GetReportProperty("RFI5", ref rfi5);

                if (int.TryParse(rfi1, out var rfi1Number))
                {
                    tempRfiList.Add(rfi1Number);
                }

                if (int.TryParse(rfi2, out var rfi2Number))
                {
                    tempRfiList.Add(rfi2Number);
                }

                if (int.TryParse(rfi3, out var rfi3Number))
                {
                    tempRfiList.Add(rfi3Number);
                }

                if (int.TryParse(rfi4, out var rfi4Number))
                {
                    tempRfiList.Add(rfi4Number);
                }

                if (int.TryParse(rfi5, out var rfi5Number))
                {
                    tempRfiList.Add(rfi5Number);
                }

                tempRfiList = tempRfiList.Distinct().ToList();
                tempRfiList.Sort();

                part.SetUserProperty("RFI1", "");
                part.SetUserProperty("RFI2", "");
                part.SetUserProperty("RFI3", "");
                part.SetUserProperty("RFI4", "");
                part.SetUserProperty("RFI5", "");

                var count = 1;
                foreach (var tempRfi in tempRfiList)
                {
                    part.SetUserProperty("RFI" + count, tempRfi.ToString());
                    count++;
                }
            }
        }
        private void AssignValues(string selectedRfiString)
        {
            var maxRfiNumberRows = 5;
            foreach (var part in this.Parts)
            {
                var RfiNumbersList = new List<int>();

                for (var i = 1; i < maxRfiNumberRows + 1; i++)
                {
                    var field = "RFI" + i;
                    var value = string.Empty;
                    part.GetReportProperty(field, ref value);

                    if (int.TryParse(value, out var rfiNumber))
                    {
                        RfiNumbersList.Add(rfiNumber);
                    }
                }

                if (int.TryParse(selectedRfiString, out var selectedRfiNumber))
                {
                    RfiNumbersList.Add(selectedRfiNumber);
                }

                RfiNumbersList = RfiNumbersList.Distinct().ToList();
                RfiNumbersList.Sort();

                if (RfiNumbersList.Count > maxRfiNumberRows)
                {
                    this.LabeUpdate("Max RFI numbers reached for some of the parts ...", System.Drawing.Color.Firebrick);
                    continue;
                }

                var count = 1;
                foreach (var rfi in RfiNumbersList)
                {
                    part.SetUserProperty("RFI" + count, rfi.ToString());
                    count++;
                }
            }
        }
        private void RemoveValues(string selectedRfiString)
        {
            var maxRfiNumberRows = 5;

            foreach (var part in this.Parts)
            {
                var RfiNumbersList = new List<int>();

                for (var i = 1; i < maxRfiNumberRows + 1; i++)
                {
                    var field = "RFI" + i;
                    var value = string.Empty;
                    part.GetReportProperty(field, ref value);

                    if (int.TryParse(value, out var rfiNumber))
                    {
                        RfiNumbersList.Add(rfiNumber);
                    }
                }

                if (int.TryParse(selectedRfiString, out var selectedRfiNumber))
                {
                    RfiNumbersList.Remove(selectedRfiNumber);
                }

                RfiNumbersList = RfiNumbersList.Distinct().ToList();
                RfiNumbersList.Sort();

                if (RfiNumbersList.Count == 0)
                {
                    part.SetUserProperty("RFI1", "");
                    part.SetUserProperty("RFI2", "");
                    part.SetUserProperty("RFI3", "");
                    part.SetUserProperty("RFI4", "");
                    part.SetUserProperty("RFI5", "");
                }

                if (RfiNumbersList.Count == 1)
                {
                    part.SetUserProperty("RFI1", RfiNumbersList[0].ToString());
                    part.SetUserProperty("RFI2", "");
                    part.SetUserProperty("RFI3", "");
                    part.SetUserProperty("RFI4", "");
                    part.SetUserProperty("RFI5", "");
                }

                if (RfiNumbersList.Count == 2)
                {
                    part.SetUserProperty("RFI1", RfiNumbersList[0].ToString());
                    part.SetUserProperty("RFI2", RfiNumbersList[1].ToString());
                    part.SetUserProperty("RFI3", "");
                    part.SetUserProperty("RFI4", "");
                    part.SetUserProperty("RFI5", "");
                }

                if (RfiNumbersList.Count == 3)
                {
                    part.SetUserProperty("RFI1", RfiNumbersList[0].ToString());
                    part.SetUserProperty("RFI2", RfiNumbersList[1].ToString());
                    part.SetUserProperty("RFI3", RfiNumbersList[2].ToString());
                    part.SetUserProperty("RFI4", "");
                    part.SetUserProperty("RFI5", "");
                }

                if (RfiNumbersList.Count == 4)
                {
                    part.SetUserProperty("RFI1", RfiNumbersList[0].ToString());
                    part.SetUserProperty("RFI2", RfiNumbersList[1].ToString());
                    part.SetUserProperty("RFI3", RfiNumbersList[2].ToString());
                    part.SetUserProperty("RFI4", RfiNumbersList[3].ToString());
                    part.SetUserProperty("RFI5", "");
                }

                if (RfiNumbersList.Count == 5)
                {
                    part.SetUserProperty("RFI1", RfiNumbersList[0].ToString());
                    part.SetUserProperty("RFI2", RfiNumbersList[1].ToString());
                    part.SetUserProperty("RFI3", RfiNumbersList[2].ToString());
                    part.SetUserProperty("RFI4", RfiNumbersList[3].ToString());
                    part.SetUserProperty("RFI5", RfiNumbersList[4].ToString());
                }
            }
        }

        private void CheckBoxExcelNotDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxExcelNotDefault.CheckState == CheckState.Checked)
            {
                this.Label1.Enabled = true;
                this.Label2.Enabled = true;
                this.Label3.Enabled = true;
                this.Label4.Enabled = true;
                this.TextBoxHeaderRow.Enabled = true;
                this.TextBoxRFIColumn.Enabled = true;
                this.TextBoxSubjectColumn.Enabled = true;
                this.TextBoxClosedColumn.Enabled = true;
            }

            if (this.checkBoxExcelNotDefault.CheckState == CheckState.Unchecked)
            {
                this.Label1.Enabled = false;
                this.Label2.Enabled = false;
                this.Label3.Enabled = false;
                this.Label4.Enabled = false;
                this.TextBoxHeaderRow.Enabled = false;
                this.TextBoxRFIColumn.Enabled = false;
                this.TextBoxSubjectColumn.Enabled = false;
                this.TextBoxClosedColumn.Enabled = false;
            }
        }

        private void OpenExcelFile_Click(object sender, EventArgs e)
        {
            Process.Start(this.TextBoxPath.Text);
        }
    }
}