using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SuperMarioWorkerEditorPro
{
    public partial class DLG_Option : Form
    {
        public DLG_Option()
        {
            InitializeComponent();
        }

        public Font font = new Font("新宋体", 11f);
        public bool flag_checkBox1;

        public string str = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                font = fontDialog1.Font;
        }

        private void DLG_Option_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 生成配置文件内容
            string str_checkBox1 = "";
            if (checkBox1.Checked == true)
                str_checkBox1 = "1";
            if (checkBox1.Checked == false)
                str_checkBox1 = "0";
            str = str + "[Group 1]" + "\r\n";
            str = str + str_checkBox1 + "\r\n";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                flag_checkBox1 = true;
            if (checkBox1.Checked == false)
                flag_checkBox1 = false;
        }

        private void DLG_Option_Load(object sender, EventArgs e)
        {
            // 加载配置文件
            FileStream fs = File.Open(@".\Setting.ini", FileMode.OpenOrCreate, FileAccess.Read);
            var reader = new StreamReader(fs);
            string nstr = reader.ReadLine();
            string nstr_checkBox1 = reader.ReadLine();
            if (nstr_checkBox1 == "1")
                checkBox1.Checked = true;
            if (nstr_checkBox1 == "0")
                checkBox1.Checked = false;
            fs.Close();
        }
    }
}
