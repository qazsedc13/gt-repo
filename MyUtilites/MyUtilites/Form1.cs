using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtilites
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;
        Char[] spec_chars = new char[] {'%', '*', ')', '#', '&', '?', '$', '^', '~'};
        Dictionary<string, double> metrica;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            metrica = new Dictionary<string, double>();
            metrica.Add("Миллиметры", 1);
            metrica.Add("Сантиметры", 10);
            metrica.Add("Дециметры", 100);
            metrica.Add("Метры", 1000);
            metrica.Add("Километры", 1000000);
            metrica.Add("Мили", 1609344);
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSMIAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа мои утилиты, содержит ряд небольших программ, которые могут пригодиться в жизни. \nА главное научить меня основам программирования на C#.\nАвтор Ковалёв Н.И.","О программе");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCount.Text = Convert.ToString(count);
        }

        private void btnRundom_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32( numericUpDown2.Value)+1);
            lblRandom.Text = n.ToString();
            if (cbRandom.Checked)
            {
                int i = 0;
                while (tbRandom.Text.IndexOf(n.ToString()) != -1)
                {
                    n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) + 1);
                    i++;
                    if (i > 1000) break;
                }
                if (i<=1000) tbRandom.AppendText(n + "\n");
            }
            else tbRandom.AppendText(n + "\n");
        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void btnRandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }

        private void tsniInsertDate_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortDateString()+"\n");
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotepad.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении");
            }
        }

        void LoadNotepad()
        {
            try
            {
                rtbNotepad.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке");
            }
        }

        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            LoadNotepad(); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNotepad();
            clbPassword.SetItemChecked(0, true);
            clbPassword.SetItemChecked(1, true);
            clbPassword.SetItemChecked(2, true);
        }

        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) return;
            string password = "";
            for (int i = 0; i < nudPassLength.Value; i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string s = clbPassword.CheckedItems[n].ToString();
                switch (s)
                {
                    case "Цифры": password += rnd.Next(10).ToString();
                        break;
                    case "Прописные буквы": password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    case "Строчные буквы": password += Convert.ToChar(rnd.Next(97, 122));
                        break;
                    default:
                        password += spec_chars[rnd.Next(spec_chars.Length)];
                            break;
                }
                tbPassword.Text = password;
                Clipboard.SetText(password);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double m1 = metrica[cbFrom.Text];
            double m2 = metrica[cbTo.Text];
            double n = Convert.ToDouble(tbFrom.Text);
            tbTo.Text = (n * m1 / m2).ToString();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string t = cbFrom.Text;
            cbFrom.Text = cbTo.Text;
            cbTo.Text = t;
        }

        private void cbMetrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMetrics.Text)
            {
                case "Длина":
                    metrica.Clear();
                    metrica.Add("Миллиметры", 1);
                    metrica.Add("Сантиметры", 10);
                    metrica.Add("Дециметры", 100);
                    metrica.Add("Метры", 1000);
                    metrica.Add("Километры", 1000000);
                    metrica.Add("Мили", 1609344);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("Миллиметры");
                    cbFrom.Items.Add("Сантиметры");
                    cbFrom.Items.Add("Дециметры");
                    cbFrom.Items.Add("Метры");
                    cbFrom.Items.Add("Километры");
                    cbFrom.Items.Add("Мили");
                    cbTo.Items.Clear();
                    cbTo.Items.Add("Миллиметры");
                    cbTo.Items.Add("Сантиметры");
                    cbTo.Items.Add("Дециметры");
                    cbTo.Items.Add("Метры");
                    cbTo.Items.Add("Километры");
                    cbTo.Items.Add("Мили");
                    cbFrom.Text = "Миллиметры";
                    cbTo.Text = "Миллиметры";
                    break;

             case "Вес":
                    metrica.Clear();
                    metrica.Add("Граммы", 1);
                    metrica.Add("Килограммы", 1000);
                    metrica.Add("Тонны", 1000000);
                    metrica.Add("Фунты", 453.6);
                    metrica.Add("oz", 283);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("Граммы");
                    cbFrom.Items.Add("Килограммы");
                    cbFrom.Items.Add("Тонны");
                    cbFrom.Items.Add("Фунты");
                    cbFrom.Items.Add("oz");
                    cbTo.Items.Clear();
                    cbTo.Items.Add("Граммы");
                    cbTo.Items.Add("Килограммы");
                    cbTo.Items.Add("Тонны");
                    cbTo.Items.Add("Фунты");
                    cbTo.Items.Add("oz");
                    cbFrom.Text = "Граммы";
                    cbTo.Text = "Граммы";
                    break;

                default:
                    break;
            }
        }
    }
}
