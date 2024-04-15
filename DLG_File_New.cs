using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarioWorkerEditorPro
{
    public partial class DLG_File_New : Form
    {
        public DLG_File_New()
        {
            InitializeComponent();
        }

        // 定义字符串变量存储新建文件时生成的关卡内容代码
        public string str = String.Empty;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // 选中 单位长度 （即 格数）时，转换关卡宽高的单位并修正数字选框的最值
            if (radioButton1.Checked == true )
            {
                numericUpDown_Width.Minimum = 20;
                numericUpDown_Width.Value = numericUpDown_Width.Value / 32;
                numericUpDown_Width.Maximum = 1920;
                numericUpDown_Height.Minimum = 15;
                numericUpDown_Height.Value = numericUpDown_Height.Value / 32;
                numericUpDown_Height.Maximum = 1920;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // 选中 像素 时，转换关卡宽高的单位并修正数字选框的最值
            if (radioButton2.Checked == true )
            {
                numericUpDown_Width.Maximum = 1920 * 32 + 10; 
                numericUpDown_Width.Value = numericUpDown_Width.Value * 32;
                numericUpDown_Width.Minimum = 20 * 32;
                numericUpDown_Height.Maximum = 1920 * 32 + 10;               
                numericUpDown_Height.Value = numericUpDown_Height.Value * 32;
                numericUpDown_Height.Minimum = 15 * 32;
            }
        }

        // 关闭窗口前要执行的内容，新建文件的关卡内容代码在此处生成
        private void Form_File_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 定义并初始化关卡宽度和高度（像素和格数）变量，允许小数
            decimal new_width = 640, new_height = 480;
            decimal new_w = 20, new_h = 15;

            // 根据当前选中的格式计算关卡宽度与高度（像素和格数）
            if (radioButton1.Checked == true)
            {
                new_width = numericUpDown_Width.Value * 32;
                new_height = numericUpDown_Height.Value * 32;
                new_w = numericUpDown_Width.Value;
                new_h = numericUpDown_Height.Value;
            }
            else if (radioButton2.Checked == true)
            {
                new_width = numericUpDown_Width.Value;
                new_height = numericUpDown_Height.Value;
                new_w = numericUpDown_Width.Value / 32;
                new_h = numericUpDown_Height.Value / 32;
            }

            // 定义并初始化关卡名变量
            string new_name = String.Empty;

            // 将文本框中的关卡名逐行写入关卡名变量，并在行尾加上换行符
            foreach (string line in textBox_name.Lines)
            {
                new_name = new_name + line + "#";
            }

            // 删去多余的换行符
            while(new_name!=""&&new_name.Last() == '#')
                new_name = new_name.Remove(new_name.Length - 1, 1);

            // 将各变量写入关卡内容代码
            str = str + new_width + Environment.NewLine;                       // 关卡宽度
            str = str + new_height + Environment.NewLine;                      // 关卡高度
            str = str + new_name + Environment.NewLine;                        // 关卡名
            str = str + textBox_Author.Text + Environment.NewLine;             // 作者
            str = str + numericUpDown_Time.Value + Environment.NewLine;        // 关卡限时
            str = str + textBox_gravity.Text + Environment.NewLine;            // 重力系数
            str = str + numericUpDown_Koopa.Value + Environment.NewLine;       // 库巴血量
            str = str + numericUpDown_WaterLevel.Value + Environment.NewLine;  // 水位
            str = str + numericUpDown_Background.Value + Environment.NewLine;  // 背景图像
            str = str + numericUpDown_BGM.Value + Environment.NewLine;         // 背景音乐
            str = str + "BlocksDataStart" + Environment.NewLine;               // 地面信息开始标志

            // 根据之前计算得到的宽度和高度（格数）生成地面信息代码
            // 由于使用了decimal类型的数据，可以自动处理格数的小数部分
            for (decimal i = 0; i < new_h; i++)
            {
                for (decimal j = 0; j < new_w; j++)
                {
                    // 空白关卡
                    str = str + "00";
                }
                str = str + Environment.NewLine;
            }
            str = str + "BlocksEnd" + Environment.NewLine;                     // 地面信息结束标志
            str = str + Environment.NewLine;
            str = str + "Super Mario Worker Editor Pro ver = " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); // 写入使用的SMWEP版本号
        }

        private void numericUpDown_Height_ValueChanged(object sender, EventArgs e)
        {
            // 设定水位允许的最大值
            if (radioButton1.Checked == true)
            {
                numericUpDown_WaterLevel.Maximum = numericUpDown_Height.Value * 32 + 500;
            }
            else if (radioButton2.Checked == true)
            {
                numericUpDown_WaterLevel.Maximum = numericUpDown_Height.Value + 500;
            }
        }

        private void textBox_gravity_TextChanged(object sender, EventArgs e)
        {
            // 重力系数因为没有小数点后位数与最大最小值的限制，故使用了文本框控件来获得数据
            // 判断输入的内容是否为数字，若不是数字则提示错误并重置重力系数
            try
            {
                decimal.Parse(textBox_gravity.Text);
            }
            catch
            {
                MessageBox.Show("您输入的数据不合法，请重新输入！");
                textBox_gravity.Text = "5";
            }
        }

        private void button_Background_Click(object sender, EventArgs e)
        {
            DLG_Property_Background dlg_new = new DLG_Property_Background();

            // 显示背景选取对话框
            if (dlg_new.ShowDialog() == DialogResult.OK)
            {
                numericUpDown_Background.Value = dlg_new.value;
            }
        }

        private void button_BGM_Click(object sender, EventArgs e)
        {
            DLG_Property_BGM dlg_new = new DLG_Property_BGM();

            // 显示BGM选取对话框
            if(dlg_new.ShowDialog() == DialogResult.OK)
            {
                numericUpDown_BGM.Value = dlg_new.value;
            }
        }
    }
}
