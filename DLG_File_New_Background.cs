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
    public partial class DLG_File_New_Background : Form
    {
        public DLG_File_New_Background()
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

                // 创建并初始化图像对象
                Image image = Res_Backgrounds._1;

                // 根据选中项的代码选择对应的图像
                switch (value)
                {
                    case 1: image = Res_Backgrounds._1; break;
                    case 2: image = Res_Backgrounds._2; break;
                    case 3: image = Res_Backgrounds._3; break;
                    case 4: image = Res_Backgrounds._4; break;
                    case 5: image = Res_Backgrounds._5; break;
                    case 6: image = Res_Backgrounds._6; break;
                    case 7: image = Res_Backgrounds._7; break;
                    case 8: image = Res_Backgrounds._8; break;
                    case 9: image = Res_Backgrounds._9; break;
                    case 10: image = Res_Backgrounds._10; break;
                    case 11: image = Res_Backgrounds._11; break;
                    case 12: image = Res_Backgrounds._12; break;
                    case 13: image = Res_Backgrounds._13; break;
                    case 14: image = Res_Backgrounds._14; break;
                    case 15: image = Res_Backgrounds._15; break;
                    case 16: image = Res_Backgrounds._16; break;
                    case 17: image = Res_Backgrounds._17; break;
                    case 18: image = Res_Backgrounds._18; break;
                    case 19: image = Res_Backgrounds._19; break;
                    case 20: image = Res_Backgrounds._20; break;
                    case 21: image = Res_Backgrounds._21; break;
                    case 22: image = Res_Backgrounds._22; break;
                    case 23: image = Res_Backgrounds._23; break;
                }
                // 在pictureBox1 中显示图像
                pictureBox1.Image = image;
            }
        }

        // 对话框内容初始化
        private void DLG_File_New_Background_Load(object sender, EventArgs e)
        {
            listView1.Items[0].Selected = true;
        }
    }
}
