using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SuperMarioWorkerEditorPro
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        // 存储当前文件的路径
        public string filepath;

        // 当前字体
        Font currentFont = new Font("新宋体", 11f);

        // 保存状态
        bool currentSaveCondition = false;

        // 实例化 Class_AppSetting 类
        Class_AppSetting appSet = new Class_AppSetting();

        /// <summary>
        /// 实现从关卡文件中读取关卡属性
        /// </summary>
        private void setAppSetting()
        {
            string temp;
            string[] arr = new string[textBox_Main.Lines.Length];
            for (int i = 0; i < textBox_Main.Lines.Length; i++)
                arr[i] = textBox_Main.Lines[i];
            appSet.文件路径 = filepath;
            appSet.关卡长度 = int.Parse(arr[0]);
            appSet.关卡高度 = int.Parse(arr[1]);
            appSet.关卡名称 = arr[2];
            appSet.关卡作者 = arr[3];
            appSet.关卡限时 = int.Parse(arr[4]);
            appSet.关卡重力 = decimal.Parse(arr[5]);
            appSet.库巴血量 = double.Parse(arr[6]);
            appSet.关卡水位 = int.Parse(arr[7]);
            appSet.背景序号 = int.Parse(arr[8]);
            appSet.音乐序号 = int.Parse(arr[9]);

            // 版本信息的处理
            if (textBox_Main.Text.Contains("version=") == true)
                for (int i = textBox_Main.Lines.Length - 1; i > 0; i--)
                {
                    if (arr[i].Contains("version=") == true)
                    {
                        temp = arr[i];
                        if (temp[10] == '0')
                            appSet.开发版本 = "SMWP " + temp[8] + "." + temp[9] + "." + temp[11];
                        else
                            appSet.开发版本 = "SMWP " + temp[8] + "." + temp[9] + "." + temp.Substring(10, 2);
                        break;
                    }
                }
            else if (textBox_Main.Text.Contains("Super Mario Worker Editor Pro ver = ") == true)
                for (int i = textBox_Main.Lines.Length - 1; i > 0; i--)
                {
                    if (arr[i].Contains("Super Mario Worker Editor Pro ver = ") == true)
                    {
                        temp = arr[i];
                        appSet.开发版本 = "SMWEP " + temp.Remove(0, 36);
                        break;
                    }
                }
            else
                appSet.开发版本 = "";

            // 更新属性框视图
            propertyGrid_Main.SelectedObject = appSet;
        }

        /// <summary>
        /// 将属性框中属性重置
        /// </summary>
        private void restoreAppSetting()
        {
            appSet.文件路径 = "";
            appSet.关卡长度 = 0;
            appSet.关卡高度 = 0;
            appSet.关卡名称 = "";
            appSet.关卡作者 = "";
            appSet.关卡限时 = 0;
            appSet.关卡重力 = 0;
            appSet.库巴血量 = 0;
            appSet.关卡水位 = 0;
            appSet.背景序号 = 0;
            appSet.音乐序号 = 0;
            appSet.开发版本 = "";
            propertyGrid_Main.SelectedObject = appSet;
        }

        // 打开文件
        private void OpenOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                // 设置可打开文件的类型
                dialog.Filter = "所有支持的格式|*.smwl;*.mfl;|Super Mario Worker Level|*.smwl|Mario Worker Level|*.mfl|所有文件|*.*";
                // dialog.Filter = "所有支持的格式|*.mfl;*.smwl;*.mfs;*.smws|(Super) Mario Worker Level|*.mfl;*.smwl|(Super) Mario Worker Scenario|*.mfs;*.smws|所有文件|*.*";
                string strPath;                

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    strPath = dialog.FileName;
                    filepath = strPath;
                    string strnewPath;
                    textBox_Main.Clear();
                   
                    // 检验文件是否为 MW/SMWP 的压缩文件格式
                    string bx = Class_Gzip.CheckTrueFileName(strPath);
                    
                    // 若为压缩文件，则调用 Decompress 函数解压，反之则直接读取
                    if (bx == "31139")
                    {
                        Class_Gzip.Decompress(strPath, out strnewPath);
                    }
                    else
                    {
                        FileInfo finfo = new FileInfo(strPath);
                        using (FileStream originalFileStream = finfo.OpenRead())
                        {
                            string currentFileName = finfo.FullName;
                            strnewPath = currentFileName + "x";

                            // 检验 .*x文件是否存在，若存在，则继续加x
                            while (File.Exists(strnewPath))
                                strnewPath = strnewPath + "x";

                            // 创建 .*x文件并将原文件经处理后得到的内容写入新文件
                            finfo.CopyTo(strnewPath);
                        }
                    }

                    // 在文本框中加载关卡代码内容信息
                    string resultTxt = "";
                    using (FileStream fss = new FileStream(strnewPath, FileMode.Open))
                    {
                        byte[] bys = new byte[fss.Length];
                        fss.Read(bys, 0, bys.Length);
                        resultTxt = Encoding.UTF8.GetString(bys);
                    }
                    textBox_Main.Text = resultTxt;

                    // 删除临时生成的文件
                    File.Delete(strnewPath);
                    
                    // 更改菜单栏中相关选项的状态
                    SaveSToolStripMenuItem.Enabled = true;
                    SaveAsAToolStripMenuItem.Enabled = true;
                    CloseCToolStripMenuItem.Enabled = true;
                    Create020ToolStripMenuItem.Enabled = true;

                    // 文件未改动，设置保存状态为真
                    currentSaveCondition = true;

                    // 将关卡属性载入属性栏
                    setAppSetting();

                    // 设置属性框可编辑
                    propertyGrid_Main.Enabled = true;
                    groupBox2.Enabled = true;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        // 文件另存为
        private void SaveAsAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Super Mario Worker Level|*.smwl|Mario Worker Level|*.mfl|所有文件|*.*";
            // dialog.Filter = "Mario Worker Level|*.mfl|Super Mario Worker Level|*.smwl|Mario Worker Scenario|*.mfs|Super Mario Worker Scenario|*.smws|所有文件|*.*";

            // 显示对话框
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 文件名
                string fileName = dialog.FileName;

                // 创建文件，准备写入
                FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter wr = new StreamWriter(fs);

                // 将textBox1的内容写入到文件中
                wr.Write(this.textBox_Main.Text);

                filepath = dialog.FileName;

                // 关闭文件
                wr.Flush();
                wr.Close();
                fs.Close();
            }
        }

        // 文件保存
        private void SaveSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 判断文件路径是否存在，若不存在则执行另存为操作
            if (filepath != null)
            {
                // 文件名
                string fileName = filepath;
                
                // 创建文件，准备写入
                FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter wr = new StreamWriter(fs);

                // 逐行将textBox的内容写入到文件中
                wr.Write(this.textBox_Main.Text);

                // 关闭文件
                wr.Flush();
                wr.Close();
                fs.Close();
            }
            else
                SaveAsAToolStripMenuItem_Click(sender, e);
            currentSaveCondition = true;
            setAppSetting();
        }

        // 关闭打开的文件
        private void CloseCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 清空文本框和当前文件路径变量
            textBox_Main.Clear();
            filepath = "";
            currentSaveCondition = false;
            restoreAppSetting();

            // 重置菜单栏各选项与属性框状态
            SaveSToolStripMenuItem.Enabled = false;
            SaveAsAToolStripMenuItem.Enabled = false;
            CloseCToolStripMenuItem.Enabled = false;
            Create020ToolStripMenuItem.Enabled = false;
            propertyGrid_Main.Enabled = false;
            groupBox2.Enabled = false;
        }

        // 关闭程序
        private void ExitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close() ;
        }

        // 剪切
        private void CutTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 获取选中内容，目前只支持对主文本框的操作
                string strTemp = textBox_Main.SelectedText;

                // 未选中任何内容则直接返回，不执行操作
                if (strTemp.Equals(""))
                    return;

                // 清空剪贴板
                Clipboard.Clear();

                // 剪切
                textBox_Main.Cut();
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        // 复制
        private void CopyCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 获取选中内容，目前只支持对主文本框的操作
                string strTemp = textBox_Main.SelectedText;

                // 未选中任何内容则直接返回，不执行操作
                if (strTemp.Equals(""))
                    return;

                // 清空剪贴板，并存入选中的内容
                Clipboard.Clear(); 
                Clipboard.SetText(strTemp);
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        // 粘贴
        private void PastePToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.textBox_Main.Paste(); 
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        // 撤消
        private void UndoUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                textBox_Main.Undo();
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        // 全选
        private void SelectAllAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                textBox_Main.SelectAll();
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        // 关闭窗口前要执行的内容
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 若主文本框内容为空，则直接关闭
            if (textBox_Main.Text == "" || currentSaveCondition == true)
            {
            }
            else
            {
                // 若主文本框内容非空，则提示是否保存，并获取用户的选择结果
                DialogResult result;
                result = MessageBox.Show("内容尚未保存，是否保存？", "Super Mario Worker Editor Pro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                // 结果为 Yes 则执行保存操作
                if (result == DialogResult.Yes)
                {
                    SaveSToolStripMenuItem_Click(sender, e);
                }

                // 为 No 则直接关闭
                else if (result == DialogResult.No)
                {
                }

                // 为 Cancel 则取消关闭窗口操作
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;

                }
            }
        }

        // 新建 MFL/SMWL 关卡文件
        private void mflsmwlFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DLG_File_New dlg_new = new DLG_File_New();
            currentSaveCondition = false;

            // 显示对话框并获取选择结果
            if (dlg_new.ShowDialog() == DialogResult.OK)
            {
                // 写入生成的关卡内容代码
                textBox_Main.Text = dlg_new.str;

                // 更改菜单栏各选项的状态
                SaveSToolStripMenuItem.Enabled = true;
                SaveAsAToolStripMenuItem.Enabled = true;
                CloseCToolStripMenuItem.Enabled = true;
                Create020ToolStripMenuItem.Enabled = true;

                // 将关卡属性载入属性栏
                setAppSetting();

                // 设置属性框可编辑
                propertyGrid_Main.Enabled = true;
                groupBox2.Enabled = true;
            }
        }

        // 选项
        private void OptionOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DLG_Option dlg_option = new DLG_Option();

            // 显示对话框
            if(dlg_option.ShowDialog()==DialogResult.OK)
            {
                // 设置当前字体
                currentFont = dlg_option.font;

                // 设置当前编辑模式
                if (dlg_option.flag_checkBox1 == true)
                {
                    textBox_Main.ReadOnly = false;
                    textBox_Main.ForeColor = Color.Black;
                    textBox_Main.BackColor = Color.White;
                }
                if (dlg_option.flag_checkBox1 == false)
                {
                    textBox_Main.ReadOnly = true;
                    textBox_Main.ForeColor = Color.Black;
                    textBox_Main.BackColor = Color.LightGray;
                }

                // 输出配置文件
                string fileName = @".\Setting.ini";

                // 创建文件，准备写入
                FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter wr = new StreamWriter(fs);

                wr.Write(dlg_option.str);

                // 关闭文件
                wr.Flush();
                wr.Close();
                fs.Close();
            }
            textBox_Main.Font = currentFont;
        }

        // 初始化
        private void Form_Main_Load(object sender, EventArgs e)
        {
            textBox_Main.ClearUndo();
            // 加载配置文件
            FileStream fs = File.Open(@".\Setting.ini", FileMode.OpenOrCreate, FileAccess.Read);
            var reader = new StreamReader(fs);
            string nstr = reader.ReadLine();
            string nstr_checkBox1 = reader.ReadLine();
            if (nstr_checkBox1 == "1")
            {
                textBox_Main.ReadOnly = false;
                textBox_Main.ForeColor = Color.Black;
                textBox_Main.BackColor = Color.White;
            }
            if (nstr_checkBox1 == "0")
            {
                textBox_Main.ReadOnly = true;
                textBox_Main.ForeColor = Color.Black;
                textBox_Main.BackColor = Color.LightGray;
            }
            fs.Close();
            propertyGrid_Main.SelectedObject = appSet;
            propertyGrid_Main.Enabled = false;

            groupBox2.Enabled = false;

            label1.Visible = false;
            label2.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            Class_ObjectList.setListPipe();
            for (int i = 0; i < 4; i++)
            {
                comboBox1.Items.Add(Class_ObjectList.ListPipe[i]);
                comboBox2.Items.Add(Class_ObjectList.ListPipe[i]);
            }
            comboBox_Class.SelectedIndex = 1;
            comboBox1.SelectedItem = Class_ObjectList.ListPipe[3];
            comboBox2.SelectedItem = Class_ObjectList.ListPipe[1];
        }

        // 文本框中内容发生变化时的响应函数
        private void textBox_Main_TextChanged(object sender, EventArgs e)
        {
            // 文本框中内容变化时将保存状态设置为否
            currentSaveCondition = false;

            // 更新属性栏
            Class_AppSetting.readmode = true;
            try
            {
                setAppSetting();
            }
            catch
            {
            }
            Class_AppSetting.readmode = true;
        }

        // 属性框中内容发生变化时的响应函数
        private void propertyGrid_Main_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string oldstr = "";
            for (int i = 0; i < 10; i++)
                oldstr += textBox_Main.Lines[i] + Environment.NewLine;
            string newstr = appSet.关卡长度 + Environment.NewLine
                          + appSet.关卡高度 + Environment.NewLine
                          + appSet.关卡名称 + Environment.NewLine
                          + appSet.关卡作者 + Environment.NewLine
                          + appSet.关卡限时 + Environment.NewLine
                          + appSet.关卡重力 + Environment.NewLine
                          + appSet.库巴血量 + Environment.NewLine
                          + appSet.关卡水位 + Environment.NewLine
                          + appSet.背景序号 + Environment.NewLine
                          + appSet.音乐序号 + Environment.NewLine;
            textBox_Main.Text = textBox_Main.Text.Replace(oldstr, newstr);
            currentSaveCondition = false;
        }

        // 类别选框内容发生变化时的响应函数
        private void comboBox_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_Class.SelectedItem.ToString() == "地面 Blocks")
            {
                comboBox_Object.Items.Clear();
                Class_ObjectList.setListBlock();
                for (int i = 1; i < 211; i++)
                    comboBox_Object.Items.Add(Class_ObjectList.ListBlock[i]);
                comboBox_Object.SelectedItem = Class_ObjectList.ListBlock[1];
            }
            if (comboBox_Class.SelectedItem.ToString() == "敌人 Buddies")
            {
                comboBox_Object.Items.Clear();
                Class_ObjectList.setListEnemy();
                for (int i = 1; i < 37; i++)
                    comboBox_Object.Items.Add(Class_ObjectList.ListEnemy[i]);
                comboBox_Object.SelectedItem = Class_ObjectList.ListEnemy[1];
            }
            if (comboBox_Class.SelectedItem.ToString() == "景物 Scenery")
            {
                comboBox_Object.Items.Clear();
                Class_ObjectList.setListScene();
                for (int i = 1; i < 31; i++)
                    comboBox_Object.Items.Add(Class_ObjectList.ListScene[i]);
                comboBox_Object.SelectedItem = Class_ObjectList.ListScene[1];
            }
            if (comboBox_Class.SelectedItem.ToString() == "标记 Marks")
            {
                comboBox_Object.Items.Clear();
                Class_ObjectList.setListMarks();
                for (int i = 0; i < 6; i++)
                    comboBox_Object.Items.Add(Class_ObjectList.ListMarks[i]);
                comboBox_Object.SelectedItem = Class_ObjectList.ListMarks[0];
            }
            if (comboBox_Class.SelectedItem.ToString() == "平台 Platform")
            {
                comboBox_Object.Items.Clear();
                Class_ObjectList.setListPlats();
                for (int i = 0; i < 18; i++)
                    comboBox_Object.Items.Add(Class_ObjectList.ListPlats[i]);
                comboBox_Object.SelectedItem = Class_ObjectList.ListPlats[0];
            }
            if (comboBox_Class.SelectedItem.ToString() == "奖励 Bonus")
            {
                comboBox_Object.Items.Clear();
                Class_ObjectList.setListBonus();
                for (int i = 1; i < 25; i++)
                    comboBox_Object.Items.Add(Class_ObjectList.ListBonus[i]);
                comboBox_Object.SelectedItem = Class_ObjectList.ListBonus[1];
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // 选中 像素 时，转换关卡宽高的单位并修正数字选框的最值
            if (radioButton1.Checked == true )
            {
                numericUpDown_X1.Maximum = 1920 * 32 + 10;
                numericUpDown_X1.Value = numericUpDown_X1.Value * 32;
                numericUpDown_X1.Minimum = -999 * 32 - 10;
                numericUpDown_Y1.Maximum = 1920 * 32 + 10;
                numericUpDown_Y1.Value = numericUpDown_Y1.Value * 32;
                numericUpDown_Y1.Minimum = -999 * 32 -10;
                if(comboBox_Object.SelectedItem.ToString() == "4 水管连接")
                {
                    numericUpDown3.Maximum = 1920 * 32 + 10;
                    numericUpDown3.Value = numericUpDown3.Value * 32;
                    numericUpDown3.Minimum = -999 * 32 - 10;
                    numericUpDown4.Maximum = 1920 * 32 + 10;
                    numericUpDown4.Value = numericUpDown4.Value * 32;
                    numericUpDown4.Minimum = -999 * 32 - 10;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // 选中 单位长度 （即 格数）时，转换关卡宽高的单位并修正数字选框的最值
            if (radioButton2.Checked == true )
            {
                numericUpDown_X1.Value = numericUpDown_X1.Value / 32;
                numericUpDown_X1.Maximum = 1920;
                numericUpDown_X1.Minimum = -999;
                numericUpDown_Y1.Value = numericUpDown_Y1.Value / 32;
                numericUpDown_Y1.Maximum = 1920;
                numericUpDown_Y1.Minimum = -999;
                if (comboBox_Object.SelectedItem.ToString() == "4 水管连接")
                {
                    numericUpDown3.Value = numericUpDown3.Value / 32;
                    numericUpDown3.Maximum = 1920;
                    numericUpDown3.Minimum = -999;
                    numericUpDown4.Value = numericUpDown4.Value / 32;
                    numericUpDown4.Maximum = 1920;
                    numericUpDown4.Minimum = -999;
                }
            }
        }

        // 对象选框内容发生变化时的响应函数
        private void comboBox_Object_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Object.SelectedItem.ToString() == "020 探照灯")
            {
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = true;
                comboBox1.Enabled = false;
                comboBox1.Visible = false;
                comboBox2.Enabled = false;
                comboBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label6.Visible = false;
                label7.Visible = false;

                label3.Text = "　半径";
                label4.Text = "初相位";
                label5.Text = "角速度";

                numericUpDown3.Value = 0;
                numericUpDown4.Value = 0;
                numericUpDown5.Value = 0;

                numericUpDown4.DecimalPlaces = 2;
                numericUpDown5.DecimalPlaces = 2;

                numericUpDown3.Maximum = 999; numericUpDown3.Minimum = 0;
                numericUpDown4.Maximum = 360; numericUpDown4.Minimum = -99;
                numericUpDown5.Maximum = 360; numericUpDown5.Minimum = -99;
            }
            else if (comboBox_Object.SelectedItem.ToString() == "4 水管连接")
            {
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
                numericUpDown5.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Enabled = true;
                comboBox2.Visible = true;
                comboBox2.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                label5.Visible = false;
                label6.Visible = true;
                label7.Visible = true;

                label3.Text = "参数三";
                label4.Text = "参数四";
                label5.Text = "参数五";

                numericUpDown3.Value = 0;
                numericUpDown4.Value = 0;

                numericUpDown4.DecimalPlaces = 0;
                numericUpDown5.DecimalPlaces = 0;

                numericUpDown3.Maximum = 61999; numericUpDown3.Minimum = -999;
                numericUpDown4.Maximum = 61999; numericUpDown4.Minimum = -999;
            }
            else
            {
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                numericUpDown5.Visible = true;
                comboBox1.Visible = false;
                comboBox1.Enabled = false;
                comboBox2.Visible = false;
                comboBox2.Enabled = false;
                label1.Visible = false;
                label2.Visible = false;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                label3.Text = "参数三";
                label4.Text = "参数四";
                label5.Text = "参数五";

                numericUpDown3.Value = 0;
                numericUpDown4.Value = 0;
                numericUpDown5.Value = 0;

                numericUpDown4.DecimalPlaces = 0;
                numericUpDown5.DecimalPlaces = 0;
            }
        }

        // 根据选定项新增一行代码
        private void button_Add_Click(object sender, EventArgs e)
        {
            if (comboBox_Class.SelectedItem.ToString() != "地面 Blocks")
            {
                string str_add_new = String.Empty;
                string str_id = ((Class_ObjectList.ListItem)comboBox_Object.SelectedItem).ObjID;
                decimal num_X = 0, num_Y = 0;
                string str_pipe1 = ((Class_ObjectList.ListItem)comboBox1.SelectedItem).ObjID;
                string str_pipe2 = ((Class_ObjectList.ListItem)comboBox2.SelectedItem).ObjID;
                decimal num_X2 = 0, num_Y2 = 0;
                string str_X1, str_Y1, str_X2, str_Y2;
                int intR;

                if (comboBox_Object.SelectedItem.ToString() == "4 水管连接")
                {
                    if (radioButton2.Checked == true)
                    {
                        num_X2 = numericUpDown3.Value * 32;
                        num_Y2 = numericUpDown4.Value * 32;
                    }
                    else if (radioButton1.Checked == true)
                    {
                        num_X2 = numericUpDown3.Value;
                        num_Y2 = numericUpDown4.Value;
                    }
                }

                if (radioButton2.Checked == true)
                {
                    num_X = numericUpDown_X1.Value * 32;
                    num_Y = numericUpDown_Y1.Value * 32;
                }
                else if (radioButton1.Checked == true)
                {
                    num_X = numericUpDown_X1.Value;
                    num_Y = numericUpDown_Y1.Value;
                }

                str_X1 = Class_SMWEP_Function.ConvCoorToString(num_X);
                str_X2 = Class_SMWEP_Function.ConvCoorToString(num_X2);
                str_Y1 = Class_SMWEP_Function.ConvCoorToString(num_Y);
                str_Y2 = Class_SMWEP_Function.ConvCoorToString(num_Y2);

                if (comboBox_Object.SelectedItem.ToString() == "020 探照灯")
                {
                    string num_r, num_phi, num_omega;
                    str_add_new = str_add_new + str_id;
                    str_add_new = str_add_new + str_X1 + str_Y1;
                    while (numericUpDown4.Value < 0)
                        numericUpDown4.Value += 360;
                    while (numericUpDown5.Value <= 0)
                        numericUpDown5.Value += 360;

                    intR = Convert.ToInt32(numericUpDown3.Value);
                    numericUpDown3.Value = Convert.ToDecimal(intR);

                    num_r = Class_SMWEP_Function.ConvRPhiOmegaToString(numericUpDown3.Value);
                    num_phi = Class_SMWEP_Function.ConvRPhiOmegaToString(numericUpDown4.Value);
                    num_omega = Class_SMWEP_Function.ConvRPhiOmegaToString(numericUpDown5.Value);
                    str_add_new = str_add_new + num_r + num_phi + num_omega;
                }
                else if (comboBox_Object.SelectedItem.ToString() == "4 水管连接")
                {
                    str_add_new = str_add_new + str_id;
                    str_add_new = str_add_new + str_X1 + str_Y1;
                    str_add_new = str_add_new + str_X2 + str_Y2;
                    str_add_new = str_add_new + str_pipe1 + str_pipe2;
                }
                else
                {
                    str_add_new = str_add_new + str_id;
                    str_add_new = str_add_new + str_X1 + str_Y1;
                }
                string oldstr = "BlocksEnd" + Environment.NewLine;
                string newstr = "BlocksEnd" + Environment.NewLine + str_add_new + Environment.NewLine;
                textBox_Main.Text = textBox_Main.Text.Replace(oldstr, newstr);
                currentSaveCondition = false;
            }
        }

        private void Create020ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DLG_Create_020 dlg = new DLG_Create_020();
            dlg.ShowDialog();
            if(dlg.DialogResult==DialogResult.OK)
            {
                string oldstr = "BlocksEnd" + Environment.NewLine;
                string newstr = "BlocksEnd" + Environment.NewLine + dlg.str;
                textBox_Main.Text = textBox_Main.Text.Replace(oldstr, newstr);
                currentSaveCondition = false;
            }
        }
    }
}
