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
    public partial class DLG_File_New_BGM : Form
    {
        public DLG_File_New_BGM()
        {
            InitializeComponent();
        }
        public int value;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 选中某项时进行操作
            if (listView1.SelectedItems.Count > 0)
            {
                // 获取选中项对应的代码
                value = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            }
        }
    }
}
