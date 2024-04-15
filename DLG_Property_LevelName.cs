using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarioWorkerEditorPro
{
    public partial class DLG_Property_LevelName : Form
    {
        public DLG_Property_LevelName()
        {
            InitializeComponent();
        }

        // 定义字符串变量存储关卡名称
        public string newname = "";

        private void DLG_Property_LevelName_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 将文本框中的关卡名逐行写入关卡名变量，并在行尾加上换行符
            foreach (string line in textBox_newname.Lines)
            {
                newname = newname + line + "#";
            }

            // 删去多余的换行符
            while (newname != "" && newname.Last() == '#')
                newname = newname.Remove(newname.Length - 1, 1);
        }
    }
}
