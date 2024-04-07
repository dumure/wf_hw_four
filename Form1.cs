namespace wf_hw_four
{
    public partial class Form1 : Form
    {
        private Dictionary<string, decimal> petrols = new Dictionary<string, decimal>();
        public Form1()
        {
            InitializeComponent();
            petrols["92"] = 0.55m;
            petrols["95"] = 1.05m;
            petrols["98"] = 1.63m;
            petrols["Дизель"] = 0.72m;
            Clear();
        }

        private void Clear()
        {
            comboBox1.Text = string.Empty;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            groupBox5.Text = "К оплате";
            label3.Text = "AZN";
            label1.Text = "0";
            label9.Text = "0";
            label5.Text = "0";
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            textBox1.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            textBox6.Enabled = true;
            textBox7.Text = string.Empty;
            textBox7.Enabled = false;
            label9.Text = "0";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            textBox7.Enabled = true;
            textBox6.Text = string.Empty;
            textBox6.Enabled = false;
            label9.Text = "0";
        }

        private void maskedTextBox1_ControlAdded(object sender, ControlEventArgs e)
        {
            timer1.Stop();
            label9.Text = Math.Round(decimal.Parse(textBox6.Text) * petrols[comboBox1.Text], 2).ToString();
            groupBox5.Text = "К оплате";
            label3.Text = "AZN";
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            timer1.Stop();
            label9.Text = Math.Round(decimal.Parse(textBox6.Text) * petrols[comboBox1.Text], 2).ToString();
            groupBox5.Text = "К выдаче";
            label3.Text = "л.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (radioButton1.Checked)
            {
                label1.Text = (decimal.Parse(label9.Text) + decimal.Parse(label5.Text)).ToString();
            }
            else
            {
                label1.Text = ((string.IsNullOrEmpty(textBox7.Text) ? 0 : decimal.Parse(textBox7.Text)) + decimal.Parse(label5.Text)).ToString();
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            var result = MessageBox.Show("Очистить поля?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Clear();
            }
            else if (result == DialogResult.No)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (decimal.TryParse(textBox6.Text, out decimal count))
            {
                label9.Text = Math.Round(count * petrols[comboBox1.Text], 2).ToString();
                groupBox5.Text = "К оплате";
                label3.Text = "AZN";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (decimal.TryParse(textBox7.Text, out decimal price))
            {
                label9.Text = Math.Round(price / petrols[comboBox1.Text], 2).ToString();
                groupBox5.Text = "К выдаче";
                label3.Text = "л.";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (checkBox1.Checked == true)
            {
                numericUpDown1.Enabled = true;
            }
            else
            {
                numericUpDown1.Value = 0;
                numericUpDown1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (checkBox2.Checked == true)
            {
                numericUpDown2.Enabled = true;
            }
            else
            {
                numericUpDown2.Value = 0;
                numericUpDown2.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (checkBox3.Checked == true)
            {
                numericUpDown3.Enabled = true;
            }
            else
            {
                numericUpDown3.Value = 0;
                numericUpDown3.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (checkBox4.Checked == true)
            {
                numericUpDown4.Enabled = true;
            }
            else
            {
                numericUpDown4.Value = 0;
                numericUpDown4.Enabled = false;
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            label5.Text = ((int)numericUpDown1.Value * decimal.Parse(textBox2.Text) + (int)numericUpDown2.Value * decimal.Parse(textBox3.Text) + (int)numericUpDown3.Value * decimal.Parse(textBox4.Text) + (int)numericUpDown4.Value * decimal.Parse(textBox5.Text)).ToString();
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            timer1.Stop();
            if (petrols.Keys.Any(p => p == comboBox1.Text))
            {
                comboBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                groupBox4.Enabled = false;
                textBox1.Text = string.Empty;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            groupBox4.Enabled = true;
            textBox1.Text = petrols[comboBox1.Text].ToString();
        }
    }
}