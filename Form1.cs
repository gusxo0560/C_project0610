using C_project0610ML.Model;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_project0610
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String[] chbnum = new String[6] { checkBox1.Checked ? "PM10" : "",
                                            checkBox2.Checked ? "PM25" : "",
                                            checkBox3.Checked ? "ozone" : "",
                                            checkBox4.Checked ? "nitrogen_dioxide" : "",
                                            checkBox5.Checked ? "carbon_dioxide" : "",
                                            checkBox6.Checked ? "sulfur_dioxide" : ""};
            
            listView1.Items.Clear();
            listView1.Columns.Clear();
            List<string> arr = new List<String>();
            for (int i = 0; i < 6; i++)
            {
                if (chbnum[i] != "")
                {
                    listView1.Columns.Add(chbnum[i]);
                    ModelInput input = new ModelInput()
                    {
                        Data = chbnum[i],
                        Week = (comboBox1.SelectedIndex * 5) + (comboBox2.SelectedIndex + 1)
                        
                    };
                    var result = ConsumeModel.Predict(input);
                    arr.Add(Convert.ToString(result.Score));
                    //MessageBox.Show(Convert.ToString(result.Score));
                }
            }
            ListViewItem lvi = new ListViewItem(arr.ToArray());
            listView1.Items.Add(lvi);
        }
    }
}
