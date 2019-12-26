using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_Information
{
    public partial class Student : Form
    {
        List<string> ids = new List<string> { };
        List<string> names = new List<string> { };
        List<string> mobiles = new List<string> { };
        List<int> ages = new List<int> { };
        List<string> addresses = new List<string> { };
        List<double> gpas = new List<double> { };
        List<double> average = new List<double> { };
        List<double> total = new List<double> { };

        public Student()
        {
            InitializeComponent();
        }
        
        private void AddInformation(string id, string name, string mobile, int age, string address, double gpa)
        {
            ids.Add(id);
            names.Add(name);
            mobiles.Add(mobile);
            ages.Add(age);
            addresses.Add(address);
            gpas.Add(gpa);
        }

        private Boolean IsExists(string current_Id, string current_Mobile)
        {
            for(int i=0; i<ids.Count(); i++)
            {
                if (current_Id == ids[i] && current_Mobile == mobiles[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsExists(idTB.Text, mobileTB.Text) == true)
                {
                    MessageBox.Show("User id or mobile number already exists!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            try
            {
                if (String.IsNullOrEmpty(idTB.Text) || String.IsNullOrEmpty(nameTB.Text) || String.IsNullOrEmpty(mobileTB.Text))
                {
                    MessageBox.Show("You cannot keep it blank.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                if ((!String.IsNullOrEmpty(idTB.Text) && idTB.Text.Length == 4) && 
                    (!String.IsNullOrEmpty(nameTB.Text) && nameTB.Text.Length <= 30) && 
                    (!String.IsNullOrEmpty(mobileTB.Text) && mobileTB.Text.Length == 11) && 
                    (!String.IsNullOrEmpty(gpaPointTB.Text) && 
                    Convert.ToDouble(gpaPointTB.Text) >=0.0 && Convert.ToDouble(gpaPointTB.Text) <= 4.0))
                {
                    AddInformation(idTB.Text, nameTB.Text, mobileTB.Text, Convert.ToInt32(ageTB.Text), 
                        addressTB.Text, Convert.ToDouble(gpaPointTB.Text));
                }
                else
                {
                    MessageBox.Show("Please enter information correctly!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string message = " ";
            for (int i = 0; i < ids.Count(); i++)
            {
                message = "ID         : " + ids[i] + "\n" +
                          "Name       : " + names[i] + "\n" +
                          "Mobile     : " + mobiles[i] + "\n" +
                          "Age        : " + ages[i] + "\n" +
                          "Address    : " + addresses[i] + "\n" +
                          "GPA Point  : " + gpas[i] + "\n" + "\n";
            }

            showRichTextBox.Text = message;
            
            idTB.Text = "";
            nameTB.Text = "";
            mobileTB.Text = "";
            addressTB.Text = "";
            ageTB.Text = "";
            gpaPointTB.Text = "";

        }

        private void ShowAllInformation()
        {
            string message = "";

            for(int i=0; i<ids.Count(); i++)
            {
                message += "ID        : " + ids[i] + "\n" +
                           "Name      : " + names[i] + "\n" +
                           "Mobile    : " + mobiles[i] + "\n" +
                           "Age       : " + ages[i] + "\n" +
                           "Address   : " + addresses[i] + "\n" +
                           "GPA Point : " + gpas[i] + "\n" + "\n";
            }
            
            showRichTextBox.Text = message;

            idTB.Text = "";
            nameTB.Text = "";
            mobileTB.Text = "";
            addressTB.Text = "";
            ageTB.Text = "";
            gpaPointTB.Text = "";
        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            ShowAllInformation();
            
            maxNumTB.Text = gpas.Max().ToString();
            minNumTB.Text = gpas.Min().ToString();
            averageNumTB.Text = gpas.Average().ToString();
            totalTB.Text = gpas.Sum().ToString();
            
            for (int i = 0; i < ids.Count(); i++)
            {
                if (gpas[i] == Convert.ToDouble(maxNumTB.Text))
                {
                    maxStuNameTB.Text = names[i];
                }

                if (gpas[i] == Convert.ToDouble(minNumTB.Text))
                {
                    minStuNameTB.Text = names[i];
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            maxNumTB.Text = "";
            maxStuNameTB.Text = "";
            minNumTB.Text = "";
            minStuNameTB.Text = "";
            averageNumTB.Text = "";
            totalTB.Text = "";

            try
            {
                showRichTextBox.Text = "";
                for (int j = 0; j < ids.Count(); j++)
                {
                    if (idRadioButton.Checked == true)
                    {
                        if (searchTB.Text == ids[j])
                        {
                            showRichTextBox.SelectedText = Environment.NewLine + "Id        : " + ids[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Name      : " + names[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Mobile    : " + mobiles[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Age       : " + ages[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Address   : " + addresses[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "GPA Point : " + gpas[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "";
                            
                        }
                    }
                }

                for (int j = 0; j < ids.Count(); j++)
                {
                    if (idRadioButton.Checked == true)
                    {
                        if (searchTB.Text == names[j])
                        {
                            showRichTextBox.SelectedText = Environment.NewLine + "Id        : " + ids[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Name      : " + names[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Mobile    : " + mobiles[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Age       : " + ages[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Address   : " + addresses[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "GPA Point : " + gpas[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "";
                            
                        }
                    }
                }

                for (int j = 0; j < ids.Count(); j++)
                {
                    if (idRadioButton.Checked == true)
                    {
                        if (searchTB.Text == mobiles[j])
                        {
                            showRichTextBox.SelectedText = Environment.NewLine + "Id        : " + ids[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Name      : " + names[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Mobile    : " + mobiles[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Age       : " + ages[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Address   : " + addresses[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "GPA Point : " + gpas[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "";
                            
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }
    }
}