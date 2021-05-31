using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication1.Models;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            /*object sender = new object();
            EventArgs e = new EventArgs();
            button1_Click(sender, e);*/
            Load += new EventHandler(button1_Click);
        }

        private void button6_Click(object sender, EventArgs e)
        {//Salary
            panel1.BringToFront();
            panel1.Controls.Clear();
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.633803F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(1, 20);
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(500, 0);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Name" }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Email ID" }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Type" }, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Salary" }, 3, 0);
            tableLayoutPanel1.GetControlFromPosition(0, 0).BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.GetControlFromPosition(1, 0).BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.GetControlFromPosition(2, 0).BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.GetControlFromPosition(3, 0).BackColor = SystemColors.ControlDark;

            List<Employee> emp = new List<Employee>();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee");
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<List<Employee>>(display.Result).ToList();

                }
            }

            // For Add New Row (Loop this code for add multiple rows)
            foreach (Employee temp in emp)
            {
                using (HttpClient hc = new HttpClient())
                {
                    hc.BaseAddress = new Uri("https://localhost:44320/api/");
                    var consume = hc.GetAsync("Employee?emailforsalary=" + temp.Email);
                    consume.Wait();
                    var test = consume.Result;
                    if (test.IsSuccessStatusCode)
                    {
                        var display = test.Content.ReadAsStringAsync();
                        Double salary = JsonConvert.DeserializeObject<Double>(display.Result);

                        tableLayoutPanel1.RowCount += 1;
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                        tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Name, ReadOnly = true, BorderStyle = BorderStyle.None }, 0, tableLayoutPanel1.RowCount);
                        tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Email, ReadOnly = true, BorderStyle = BorderStyle.None }, 1, tableLayoutPanel1.RowCount);
                        tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Type, ReadOnly = true, BorderStyle = BorderStyle.None }, 2, tableLayoutPanel1.RowCount);
                        tableLayoutPanel1.Controls.Add(new TextBox() { Text = salary.ToString(), ReadOnly = true, BorderStyle = BorderStyle.None }, 3, tableLayoutPanel1.RowCount);
                    }
                }
            }
            panel1.Controls.Add(tableLayoutPanel1);
        }

        private void button5_Click(object sender, EventArgs e)
        {//Get All Employee
            //panel2.BringToFront();
            panel1.Controls.Clear();
            panel1.Controls.Add(panel2);
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 6;
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.633803F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(1, 30);
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(500, 0);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Name" }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Email ID" }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Gender" }, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "DOB" }, 3, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Type" }, 4, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Salary" }, 5, 0);
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.GetControlFromPosition(i, 0).BackColor = SystemColors.ControlDark;
            }

            List<Employee> emp = new List<Employee>();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee");
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<List<Employee>>(display.Result).ToList();

                }
            }
            // For Add New Row (Loop this code for add multiple rows)
            foreach (Employee temp in emp)
            {
                tableLayoutPanel1.RowCount += 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Name, ReadOnly = true, BorderStyle = BorderStyle.None }, 0, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Email, ReadOnly = true, BorderStyle = BorderStyle.None }, 1, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Gender, ReadOnly = true, BorderStyle = BorderStyle.None }, 2, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.DOB.Date.ToString(), ReadOnly = true, BorderStyle = BorderStyle.None }, 3, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Type, ReadOnly = true, BorderStyle = BorderStyle.None }, 4, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Salary.ToString(), ReadOnly = true, BorderStyle = BorderStyle.None }, 5, tableLayoutPanel1.RowCount);
            }
            panel4.Controls.Clear();
            panel4.Controls.Add(tableLayoutPanel1);
            //panel4.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {//Attendence
            panel1.Controls.Clear();
            panel1.Controls.Add(panel9);
            panel9.Controls.Remove(panel10);
            textBox11.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 6;
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.633803F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(1, 30);
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(500, 0);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Name" }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Email ID" }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Gender" }, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "DOB" }, 3, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Type" }, 4, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Salary" }, 5, 0);
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.GetControlFromPosition(i, 0).BackColor = SystemColors.ControlDark;
            }

            string filter = comboBox1.Text;
            List<Employee> emp = new List<Employee>();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee?type=" + filter.ToString());
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<List<Employee>>(display.Result).ToList();

                }
            }

            // For Add New Row (Loop this code for add multiple rows)
            foreach (Employee temp in emp)
            {
                tableLayoutPanel1.RowCount += 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Name, ReadOnly = true, BorderStyle = BorderStyle.None }, 0, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Email, ReadOnly = true, BorderStyle = BorderStyle.None }, 1, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Gender, ReadOnly = true, BorderStyle = BorderStyle.None }, 2, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.DOB.Date.ToString(), ReadOnly = true, BorderStyle = BorderStyle.None }, 3, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Type, ReadOnly = true, BorderStyle = BorderStyle.None }, 4, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Salary.ToString(), ReadOnly = true, BorderStyle = BorderStyle.None }, 5, tableLayoutPanel1.RowCount);
            }
            panel4.Controls.Clear();
            panel4.Controls.Add(tableLayoutPanel1);
            panel4.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {//Edit Employee
            //panel5.BringToFront();
            panel1.Controls.Clear();
            panel1.Controls.Add(panel5);
            panel5.Controls.Remove(panel6);
            label10.Text = "";
            textBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {//fetch data
            //panel6.BringToFront();        
            label10.Text = "";
            if (textBox2.Text != "")
            {
                Employee emp = new Employee();
                using (HttpClient hc = new HttpClient())
                {
                    hc.BaseAddress = new Uri("https://localhost:44320/api/");
                    var consume = hc.GetAsync("Employee?email=" + textBox2.Text);
                    consume.Wait();
                    var test = consume.Result;
                    if (test.IsSuccessStatusCode)
                    {
                        var display = test.Content.ReadAsStringAsync();
                        emp = JsonConvert.DeserializeObject<Employee>(display.Result);

                    }
                }
                if (emp != null)
                {
                    panel5.Controls.Add(panel6);
                    textBox3.Text = emp.Name;
                    textBox4.Text = emp.Email;
                    textBox5.Text = emp.Type;
                    textBox6.Text = emp.Salary.ToString();
                    if (emp.Gender.Contains("Male"))
                    {
                        radioButton1.Select();
                    }
                    else if (emp.Gender.Contains("Female"))
                    {
                        radioButton2.Select();
                    }
                    else
                    {
                        radioButton3.Select();
                    }
                    dateTimePicker1.Value = emp.DOB;
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    label10.Text = "No Record Found";
                }
            }

        }
        private void button9_Click(object sender, EventArgs e)
        {//update record
            string gender;
            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else if (radioButton2.Checked)
            {
                gender = "Female";
            }
            else
            {
                gender = "Other";
            }
            Employee emp = new Employee();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee?email=" + textBox4.Text);
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<Employee>(display.Result);

                }
            }
            emp.Name = textBox3.Text;
            emp.Gender = gender;
            emp.DOB = dateTimePicker1.Value;
            emp.Type = textBox5.Text;
            emp.Salary = Convert.ToDouble(textBox6.Text);

            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var serializedProduct = JsonConvert.SerializeObject(emp);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var consume = hc.PutAsync("Employee", content);

                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    label10.ForeColor = Color.Green;
                    label10.Text = "Record Updated Successfully";
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    label10.Text = "Error while updating";
                }
            }

            panel5.Controls.Remove(panel6);
            button3.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {//delete record
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.DeleteAsync("Employee?email_id=" + textBox4.Text);

                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    label10.ForeColor = Color.Green;
                    label10.Text = "Record Deleted Successfully";
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    label10.Text = "Error while Deleting";
                }
            }

            panel5.Controls.Remove(panel6);
            button3.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {//register
            string gender;
            bool flag = true;
            string email = textBox1.Text;
            label16.Text = "";
            List<Employee> employees = new List<Employee>();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee");
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<Employee>>(display.Result).ToList();

                }
            }
            foreach (Employee employee in employees)
            {
                if (employee.Email.Equals(email))
                {
                    flag = false;
                    label16.ForeColor = Color.Red;
                    label16.Text = "Email already registered";
                }
            }
            if (flag)
            {
                if (radioButton4.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton5.Checked)
                {
                    gender = "Female";
                }
                else
                {
                    gender = "Other";
                }
                Employee emp = new Employee()
                {
                    Name = textBox7.Text,
                    Email = textBox1.Text,
                    DOB = dateTimePicker2.Value,
                    Gender = gender,
                    Salary = Convert.ToDouble(textBox9.Text),
                    Present = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                    Type = textBox8.Text
                };

                using (HttpClient hc = new HttpClient())
                {
                    hc.BaseAddress = new Uri("https://localhost:44320/api/");
                    var serializedProduct = JsonConvert.SerializeObject(emp);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var consume = hc.PostAsync("Employee", content);

                    consume.Wait();
                    var test = consume.Result;
                    if (test.IsSuccessStatusCode)
                    {
                        label16.ForeColor = Color.Green;
                        label16.Text = "Record Inserted Successfully";
                    }
                    else
                    {
                        label16.ForeColor = Color.Red;
                        label16.Text = "Error while inserting";
                    }
                }

            }
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox1.Text = "";
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button12_Click(object sender, EventArgs e)
        {//reset
            label16.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox1.Text = "";
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {//register employee button
            panel1.Controls.Clear();
            panel1.Controls.Add(panel3);
        }

        private void button1_Click(object sender, EventArgs e)
        {//Home
            panel1.Controls.Clear();
            panel1.Controls.Add(panel7);
            label18.Text = "";
            textBox10.Text = "";
            panel8.Controls.Clear();
            panel7.Controls.Add(panel8);
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.633803F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(1, 0);
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(290, 0);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Name" }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Email ID" }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Type" }, 2, 0);
            for (int i = 0; i < 3; i++)
            {
                tableLayoutPanel1.GetControlFromPosition(i, 0).BackColor = SystemColors.ControlDark;
            }

            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 3;
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.633803F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Location = new Point(330, 0);
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 0;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(290, 0);
            tableLayoutPanel2.TabIndex = 0;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
            tableLayoutPanel2.Controls.Add(new Label() { Text = "Name" }, 0, 0);
            tableLayoutPanel2.Controls.Add(new Label() { Text = "Email ID" }, 1, 0);
            tableLayoutPanel2.Controls.Add(new Label() { Text = "Type" }, 2, 0);
            for (int i = 0; i < 3; i++)
            {
                tableLayoutPanel2.GetControlFromPosition(i, 0).BackColor = SystemColors.ControlDark;
            }
            List<Employee> emp = new List<Employee>();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee");
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<List<Employee>>(display.Result).ToList();

                }
            }

            // For Add New Row (Loop this code for add multiple rows)
            foreach (Employee temp in emp)
            {
                if (temp.Present[DateTime.Now.Day - 1] == 'P')
                {
                    tableLayoutPanel1.RowCount += 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                    tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Name, ReadOnly = true, BorderStyle = BorderStyle.None }, 0, tableLayoutPanel1.RowCount);
                    tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Email, ReadOnly = true, BorderStyle = BorderStyle.None }, 1, tableLayoutPanel1.RowCount);
                    tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.Type, ReadOnly = true, BorderStyle = BorderStyle.None }, 2, tableLayoutPanel1.RowCount);
                }
                else
                {
                    tableLayoutPanel2.RowCount += 1;
                    tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                    tableLayoutPanel2.Controls.Add(new TextBox() { Text = temp.Name, ReadOnly = true, BorderStyle = BorderStyle.None }, 0, tableLayoutPanel2.RowCount);
                    tableLayoutPanel2.Controls.Add(new TextBox() { Text = temp.Email, ReadOnly = true, BorderStyle = BorderStyle.None }, 1, tableLayoutPanel2.RowCount);
                    tableLayoutPanel2.Controls.Add(new TextBox() { Text = temp.Type, ReadOnly = true, BorderStyle = BorderStyle.None }, 2, tableLayoutPanel2.RowCount);
                }
            }

            panel8.Controls.Add(tableLayoutPanel1);
            panel8.Controls.Add(tableLayoutPanel2);
        }

        private void button13_Click(object sender, EventArgs e)
        {//present
            label18.Text = "";
            Employee emp = new Employee();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee?email=" + textBox10.Text);
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<Employee>(display.Result);

                }
            }

            if (emp != null)
            {
                char[] temp = emp.Present.ToCharArray();
                temp[DateTime.Now.Day - 1] = 'P';
                emp.Present = string.Join("", temp);
            }
            else
            {
                label18.ForeColor = Color.Red;
                label18.Text = "Invalid Email!!";
            }
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var serializedProduct = JsonConvert.SerializeObject(emp);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var consume = hc.PutAsync("Employee", content);

                consume.Wait();
                var test = consume.Result;
            }

            button1_Click(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)
        {//Absent
            label18.Text = "";
            Employee emp = new Employee();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee?email=" + textBox10.Text);
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<Employee>(display.Result);

                }
            }
            if (emp != null)
            {
                char[] temp = emp.Present.ToCharArray();
                temp[DateTime.Now.Day - 1] = 'A';
                emp.Present = string.Join("", temp);
            }
            else
            {
                label18.ForeColor = Color.Red;
                label18.Text = "Invalid Email!!";
            }
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var serializedProduct = JsonConvert.SerializeObject(emp);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var consume = hc.PutAsync("Employee", content);

                consume.Wait();
                var test = consume.Result;

            }

            button1_Click(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)
        {//fetch attendence
            panel9.Controls.Remove(panel10);
            panel10.Controls.Clear();
            label22.Text = "";
            string email = textBox11.Text;
            Employee emp = new Employee();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee?email=" + email);
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<Employee>(display.Result);

                }
            }
            if (emp != null)
            {
                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                tableLayoutPanel1.AutoSize = true;
                tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                tableLayoutPanel1.ColumnCount = 7;
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                tableLayoutPanel1.Location = new Point(100, 20);
                tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                tableLayoutPanel1.Name = "tableLayoutPanel1";
                tableLayoutPanel1.RowCount = 7;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                tableLayoutPanel1.Size = new Size(10, 0);
                tableLayoutPanel1.TabIndex = 0;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Sunday" }, 0, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Monday" }, 1, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Tuesday" }, 2, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Wednesday" }, 3, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Thursday" }, 4, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Friday" }, 5, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Saturday" }, 6, 0);
                for (int i = 0; i < 7; i++)
                {
                    tableLayoutPanel1.GetControlFromPosition(i, 0).BackColor = SystemColors.ControlDark;
                }
                int k = 1, temp = 0, day = DateTime.Now.Day;
                string start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).DayOfWeek.ToString();
                switch (start)
                {
                    case "Sunday":
                        temp = 0;
                        break;
                    case "Monday":
                        temp = 1;
                        break;
                    case "Tuesday":
                        temp = 2;
                        break;
                    case "Wednesday":
                        temp = 3;
                        break;
                    case "Thursday":
                        temp = 4;
                        break;
                    case "Friday":
                        temp = 5;
                        break;
                    case "Saturday":
                        temp = 6;
                        break;
                }
                for (int i = 1; i < 7; i++)
                {
                    if (i == 1)
                    {
                        for (int j = temp; j < 7; j++)
                        {
                            tableLayoutPanel1.Controls.Add(new Label() { Text = k.ToString(), TextAlign = ContentAlignment.MiddleCenter }, j, i);
                            if (k <= day)
                            {
                                if (emp.Present[k - 1] == 'P')
                                {
                                    tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.Green;
                                }
                                else
                                {
                                    tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.Red;
                                }
                            }
                            k++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (k < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + 1)
                            {
                                tableLayoutPanel1.Controls.Add(new Label() { Text = k.ToString(), TextAlign = ContentAlignment.MiddleCenter }, j, i);
                                if (k <= day)
                                {
                                    if (emp.Present[k - 1] == 'P')
                                    {
                                        tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.Green;
                                    }
                                    else
                                    {
                                        tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.Red;
                                    }
                                }
                                k++;
                            }
                        }
                    }
                }
                panel10.Controls.Add(tableLayoutPanel1);
                panel9.Controls.Add(panel10);
            }
            else
            {
                label22.ForeColor = Color.Red;
                label22.Text = "Invalid Email!!";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Employee> emp = new List<Employee>();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44320/api/");
                var consume = hc.GetAsync("Employee");
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<List<Employee>>(display.Result).ToList();

                }
            }
            foreach (Employee temp in emp)
            {
                temp.Present = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
                using (HttpClient hc = new HttpClient())
                {
                    hc.BaseAddress = new Uri("https://localhost:44320/api/");
                    var serializedProduct = JsonConvert.SerializeObject(temp);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var consume = hc.PutAsync("Employee", content);

                    consume.Wait();
                    var test = consume.Result;
                }

            }
            button1_Click(sender, e);
        }
    }
}
