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
    public partial class DLG_Create_020 : Form
    {
        public DLG_Create_020()
        {
            InitializeComponent();
        }

        public string str = String.Empty;

        /// <summary>
        /// 定义了一组探照灯的属性
        /// </summary>
        public class GroupOf020
        {
            private int index;
            private int number = 1;
            private decimal coorX;
            private decimal coorY;
            private decimal deltaX;
            private decimal deltaY;
            private decimal radius = 150;
            private decimal deltaR;
            private decimal phi;
            private decimal deltaPhi;
            private decimal omega = 1;
            private decimal deltaOmega;

            public int Index
            {
                get { return index; }
                set { index = value; }
            }
            public int Number
            {
                get { return number; }
                set { number = value; }
            }
            public decimal CoorX
            {
                get { return coorX; }
                set { coorX = value; }
            }
            public decimal CoorY
            {
                get { return coorY; }
                set { coorY = value; }
            }
            public decimal DeltaX
            {
                get { return deltaX; }
                set { deltaX = value; }
            }
            public decimal DeltaY
            {
                get { return deltaY; }
                set { deltaY = value; }
            }
            public decimal Radius
            {
                get { return radius; }
                set { radius = value; }
            }
            public decimal DeltaR
            {
                get { return deltaR; }
                set { deltaR = value; }
            }
            public decimal Phi
            {
                get { return phi; }
                set { phi = CheckPhi(value); }
            }
            public decimal DeltaPhi
            {
                get { return deltaPhi; }
                set { deltaPhi = value; }
            }
            public decimal Omega
            {
                get { return omega; }
                set { omega = CheckOmega(value); }
            }
            public decimal DeltaOmega
            {
                get { return deltaOmega; }
                set { deltaOmega = value; }
            }
        }

        public class ListItem
        {
            private GroupOf020 group = new GroupOf020();
            private string name = string.Empty;

            public ListItem(GroupOf020 pGroup, string pName)
            {
                group = pGroup;
                name = pName;
            }

            public override string ToString()
            {
                return name;
            }


            public GroupOf020 Group
            {
                get { return group; }
                set { group = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        public static GroupOf020 Group0 = new GroupOf020();
        ListItem ListItem0 = new ListItem(Group0, "Group0");


        /// <summary>
        /// 根据每组的数据计算该组的代码
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private static string GetAGroup(GroupOf020 group)
        {
            decimal[] coorX = new decimal[600];
            decimal[] coorY = new decimal[600];
            decimal[] radius = new decimal[600];
            decimal[] phi = new decimal[600];
            decimal[] omega = new decimal[600];
            string[] RotoDisk = new string[600];

            string str = String.Empty;
            string strX, strY, strR, strPhi, strOmega;
            int intR;

            coorX[0] = group.CoorX;
            coorY[0] = group.CoorY;
            radius[0] = group.Radius;
            phi[0] = group.Phi;
            omega[0] = group.Omega;

            intR = Convert.ToInt32(radius[0]);
            radius[0] = Convert.ToDecimal(intR);

            CheckPhi(phi[0]);
            CheckPhi(omega[0]);

            int n_020 = Convert.ToInt32(group.Number);

            // 生成数据并更正超出限值为最大值
            for (int i = 0; i < n_020; i++)
            {
                coorX[i + 1] = coorX[i] + group.DeltaX;
                if (coorX[i + 1] > 61999)
                    coorX[i + 1] = 61999;
                if (coorX[i + 1] < -999)
                    coorX[i + 1] = -999;
                coorY[i + 1] = coorY[i] + group.DeltaY;
                if (coorY[i + 1] > 61999)
                    coorY[i + 1] = 61999;
                if (coorY[i + 1] < -999)
                    coorY[i + 1] = -999;
                radius[i + 1] = radius[i] + group.DeltaR;
                if (radius[i + 1] > 999)
                    radius[i + 1] = 999;
                if (radius[i + 1] < 0)
                    radius[i + 1] = 0;

                intR = Convert.ToInt32(radius[i + 1]);
                radius[i + 1] = Convert.ToDecimal(intR);

                phi[i + 1] = phi[i] + group.DeltaPhi;
                omega[i + 1] = omega[i] + group.DeltaOmega;

                CheckPhi(phi[i + 1]);
                CheckPhi(omega[i + 1]);
            }
            for (int i = 0; i < n_020; i++)
            {
                strX = Class_SMWEP_Function.ConvCoorToString(coorX[i]);
                strY = Class_SMWEP_Function.ConvCoorToString(coorY[i]);
                strR = Class_SMWEP_Function.ConvRPhiOmegaToString(radius[i]);
                strPhi = Class_SMWEP_Function.ConvRPhiOmegaToString(phi[i]);
                strOmega = Class_SMWEP_Function.ConvRPhiOmegaToString(omega[i]);
                RotoDisk[i] = "020" + strX + strY + strR + strPhi + strOmega;
                str = str + RotoDisk[i] + Environment.NewLine;
            }

            return str;
        }

        private static decimal CheckPhi(decimal num)
        {
            while (num > 359)
                num = num - 360;
            while (num <= -1)
                num = num + 360;
            return num;
        }

        private static decimal CheckOmega(decimal num)
        {
            while (num > 359 && num != 360)
                num = num - 360;
            while (num <= -1 || num == 0)
                num = num + 360;
            return num;
        }

        private void DLG_Create_020_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(ListItem0);
            listBox2.SelectedItem = "自定义";
            listBox1.SelectedItem = ListItem0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            str = String.Empty;
            foreach (ListItem Item in listBox1.Items)
                str += GetAGroup(Item.Group);
            textBox1.Text = str;
            button2.Enabled = true;
        }

        private void button_AddGroup_Click(object sender, EventArgs e)
        {
            GroupOf020 newGroup = new GroupOf020();
            ListItem newListItem = new ListItem(newGroup, "newGroup");
            listBox1.Items.Add(newListItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 0)
                button_DeleteGroup.Enabled = true;
            else
                button_DeleteGroup.Enabled = false;
            numericUpDown_n.Value = ((ListItem)listBox1.SelectedItem).Group.Number;
            numericUpDown_X0.Value = ((ListItem)listBox1.SelectedItem).Group.CoorX;
            numericUpDown_Y0.Value = ((ListItem)listBox1.SelectedItem).Group.CoorY;
            numericUpDown_dX.Value = ((ListItem)listBox1.SelectedItem).Group.DeltaX;
            numericUpDown_dY.Value = ((ListItem)listBox1.SelectedItem).Group.DeltaY;
            numericUpDown_R0.Value = ((ListItem)listBox1.SelectedItem).Group.Radius;
            numericUpDown_dR.Value = ((ListItem)listBox1.SelectedItem).Group.DeltaR;
            numericUpDown_phi0.Value = ((ListItem)listBox1.SelectedItem).Group.Phi;
            numericUpDown_dphi.Value = ((ListItem)listBox1.SelectedItem).Group.DeltaPhi;
            numericUpDown_omega.Value = ((ListItem)listBox1.SelectedItem).Group.Omega;
            numericUpDown_domega.Value = ((ListItem)listBox1.SelectedItem).Group.DeltaOmega;
        }

        private void button_DeleteGroup_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void numericUpDown_n_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.Number = (int)numericUpDown_n.Value;
        }

        private void numericUpDown_X0_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.CoorX = numericUpDown_X0.Value;
        }

        private void numericUpDown_Y0_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.CoorY = numericUpDown_Y0.Value;
        }

        private void numericUpDown_dX_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.DeltaX = numericUpDown_dX.Value;
        }

        private void numericUpDown_dY_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.DeltaY = numericUpDown_dY.Value;
        }

        private void numericUpDown_R0_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.Radius = numericUpDown_R0.Value;
        }

        private void numericUpDown_dR_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.DeltaR = numericUpDown_dR.Value;
        }

        private void numericUpDown_phi0_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.Phi = numericUpDown_phi0.Value;
        }

        private void numericUpDown_dphi_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.DeltaPhi = numericUpDown_dphi.Value;
        }

        private void numericUpDown_omega_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.Omega = numericUpDown_omega.Value;
        }

        private void numericUpDown_domega_ValueChanged(object sender, EventArgs e)
        {
            ((ListItem)listBox1.SelectedItem).Group.DeltaOmega = numericUpDown_domega.Value;
        }
    }
}
