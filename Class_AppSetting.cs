using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SuperMarioWorkerEditorPro
{
    [DefaultProperty("文件信息")]
    class Class_AppSetting
    {
        public static bool readmode = false;
        private string filename;
        private int levelWidth;
        private int levelHeight;
        private string levelName;
        private string levelAuthor;
        private int levelTime;
        private decimal levelGravity;
        private double levelKoopaEnergy;
        private int levelWaterLevel;
        private int levelBackground;
        private int levelBGM;
        private string levelSMWPver;

        [Category("文件信息"), ReadOnly(true)]
        public string 文件路径
        {
            get { return filename; }
            set { filename = value; }
        }

        [Category("关卡尺寸参数"), Description("关卡的长度，单位为像素。")]
        public int 关卡长度
        {
            get { return levelWidth; }
            set
            {
                if ((value < 640 || value > 1920 * 32 + 10) && readmode == false)
                {
                    MessageBox.Show("您输入的数据不合法，请重新输入！");
                    value = levelWidth;
                }
                else
                    levelWidth = value;
            }
        }

        [Category("关卡尺寸参数"), Description("关卡的高度，单位为像素。")]
        public int 关卡高度
        {
            get { return levelHeight; }
            set
            {
                if ((value < 480 || value > 1920 * 32 + 10) && readmode == false)
                {
                    MessageBox.Show("您输入的数据不合法，请重新输入！");
                    value = levelHeight;
                }
                else
                    levelHeight = value;
            }
        }
        [Category("关卡制作者信息"), Description("关卡的名称，其中以#表示换行。"), Editor(typeof(newname), typeof(System.Drawing.Design.UITypeEditor))]
        public string 关卡名称
        {
            get { return levelName; }
            set { levelName = value; }
        }

        [Category("关卡制作者信息"), Description("关卡的作者。")]
        public string 关卡作者
        {
            get { return levelAuthor; }
            set { levelAuthor = value; }
        }

        [Category("关卡基本参数"), Description("关卡的限时，-1表示无限时间（需Super Mario Worker Project 1.5.0 及以上版本支持。")]
        public int 关卡限时
        {
            get { return levelTime; }
            set
            {
                if ((value < -1) && readmode == false)
                {
                    MessageBox.Show("您输入的数据不合法，请重新输入！");
                    value = levelTime;
                }
                else
                    levelTime = value;
            }
        }

        [Category("关卡基本参数"), Description("关卡的重力参数，支持小数。")]
        public decimal 关卡重力
        {
            get { return levelGravity; }
            set { levelGravity = value; }
        }

        [Category("关卡附加参数"), Description("关卡中库巴的血量，支持小数，实际游戏过程中向上取整。")]
        public double 库巴血量
        {
            get { return levelKoopaEnergy; }
            set
            {
                if ((value < 0) && readmode == false)
                {
                    MessageBox.Show("您输入的数据不合法，请重新输入！");
                    value = levelKoopaEnergy;
                }
                else
                    levelKoopaEnergy = value;
            }
        }

        [Category("关卡附加参数"), Description("关卡的水位高度，即水面的Y坐标。")]
        public int 关卡水位
        {
            get { return levelWaterLevel; }
            set
            {
                if ((value < 0) && readmode == false)
                {
                    MessageBox.Show("您输入的数据不合法，请重新输入！");
                    value = levelWaterLevel;
                }
                else
                    levelWaterLevel = value;
            }
        }

        [Category("关卡欣赏性参数"), Description("关卡的背景对应的序号。"), Editor(typeof(newBackGround), typeof(System.Drawing.Design.UITypeEditor))]
        public int 背景序号
        {
            get { return levelBackground; }
            set { levelBackground = value; }
        }

        [Category("关卡欣赏性参数"), Description("关卡的背景音乐对应的序号。"), Editor(typeof(newBGM), typeof(System.Drawing.Design.UITypeEditor))]
        public int 音乐序号
        {
            get { return levelBGM; }
            set { levelBGM = value; }
        }

        [Category("关卡制作者信息"), ReadOnly(true), Description("制作关卡时使用的SMWP或SMWEP版本，仅支持SMWP 1.1.1及以上版本或者SMWEP制作的关卡。")]
        public string 开发版本
        {
            get { return levelSMWPver; }
            set { levelSMWPver = value; }
        }
    }

    // 以下三个类为继承自UITypeEditor的类，用于在属性栏中相应选项后面添加一个允许自定义内容的按钮

    internal class newname : UITypeEditor
    {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                DLG_Property_LevelName dlg = new DLG_Property_LevelName();

                edSvc.ShowDialog(dlg);
                if (dlg.DialogResult == DialogResult.OK)
                    value = dlg.newname;         
            }
            return value;
        }
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }
    }

    internal class newBackGround : UITypeEditor
    {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                DLG_Property_Background dlg = new DLG_Property_Background();

                edSvc.ShowDialog(dlg);
                if (dlg.DialogResult == DialogResult.OK)
                    value = dlg.value;
            }
            return value;
        }
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }
    }


    internal class newBGM : UITypeEditor
    {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                DLG_Property_BGM dlg = new DLG_Property_BGM();

                edSvc.ShowDialog(dlg);
                if (dlg.DialogResult == DialogResult.OK)
                    value = dlg.value;
            }
            return value;
        }
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }
    }
}
