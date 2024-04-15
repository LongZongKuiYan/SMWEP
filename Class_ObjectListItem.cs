using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMarioWorkerEditorPro.Class_ObjectList;

namespace SuperMarioWorkerEditorPro
{
    class Class_ObjectList
    {
        public class ListItem
        {
            private string objID = string.Empty;
            private string name = string.Empty;

            public ListItem(string pID, string pName)
            {
                objID = pID;
                name = pName;
            }

            public override string ToString()
            {
                return name;
            }


            public string ObjID
            {
                get { return objID; }
                set { objID = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        public static ListItem[] ListBlock = new ListItem[999];
        public static ListItem[] ListEnemy = new ListItem[100];
        public static ListItem[] ListScene = new ListItem[100];
        public static ListItem[] ListMarks = new ListItem[100];
        public static ListItem[] ListPlats = new ListItem[100];
        public static ListItem[] ListBonus = new ListItem[100];

        /// <summary>
        /// 向地面列表中加入数据
        /// </summary>
        public static void setListBlock()
        {
            ListBlock[0] = new ListItem("00", "00 空");
            ListBlock[1] = new ListItem("01", "01 绿色草地，左上");
            ListBlock[2] = new ListItem("02", "02 绿色草地，中上");
            ListBlock[3] = new ListItem("03", "03 绿色草地，右上");
            ListBlock[4] = new ListItem("04", "04 方块，棕");
            ListBlock[5] = new ListItem("05", "05 水管，纵向，绿，上左");
            ListBlock[6] = new ListItem("06", "06 水管，纵向，绿，上右");
            ListBlock[7] = new ListItem("07", "07 水管，纵向，绿，中左");
            ListBlock[8] = new ListItem("08", "08 水管，纵向，绿，中右");
            ListBlock[9] = new ListItem("09", "09 用过的问号砖，棕");
            ListBlock[10] = new ListItem("10", "10 地下地面，左上");
            ListBlock[11] = new ListItem("11", "11 地下地面，中上");
            ListBlock[12] = new ListItem("12", "12 地下地面，右上");
            ListBlock[13] = new ListItem("13", "13 绿色草地，左下");
            ListBlock[14] = new ListItem("14", "14 绿色草地，中下");
            ListBlock[15] = new ListItem("15", "15 绿色草地，右下");
            ListBlock[16] = new ListItem("16", "16 方块，MW蓝");
            ListBlock[17] = new ListItem("17", "17 水管，纵向，绿色，中左");
            ListBlock[18] = new ListItem("18", "18 水管，纵向，绿色，中右");
            ListBlock[19] = new ListItem("19", "19 水管，纵向，绿色，下左");
            ListBlock[20] = new ListItem("20", "20 水管，纵向，绿色，下右");
            ListBlock[21] = new ListItem("21", "21 桥，灰");
            ListBlock[22] = new ListItem("22", "22 地下地面，左下");
            ListBlock[23] = new ListItem("23", "23 地下地面，中下");
            ListBlock[24] = new ListItem("24", "24 地下地面，右下");
            ListBlock[25] = new ListItem("25", "25 天空地面，左上");
            ListBlock[26] = new ListItem("26", "26 天空地面，中上");
            ListBlock[27] = new ListItem("27", "27 天空地面，右上");
            ListBlock[28] = new ListItem("28", "28 珊瑚，橙");
            ListBlock[29] = new ListItem("29", "29 水管，横向，绿色，左上");
            ListBlock[30] = new ListItem("30", "30 水管，横向，绿色，中上");
            ListBlock[31] = new ListItem("31", "31 水管，横向，绿色，中上");
            ListBlock[32] = new ListItem("32", "32 水管，横向，绿色，右上");
            ListBlock[33] = new ListItem("33", "33 桥，红，MW样式");
            ListBlock[34] = new ListItem("34", "34 红色地面，左上");
            ListBlock[35] = new ListItem("35", "35 红色地面，中上");
            ListBlock[36] = new ListItem("36", "36 红色地面，右上");
            ListBlock[37] = new ListItem("37", "37 天空地面，左下");
            ListBlock[38] = new ListItem("38", "38 天空地面，中下");
            ListBlock[39] = new ListItem("39", "39 天空地面，右下");
            ListBlock[40] = new ListItem("40", "40 水下砖块，绿");
            ListBlock[41] = new ListItem("41", "41 水管，横向，绿色，左下");
            ListBlock[42] = new ListItem("42", "42 水管，横向，绿色，中下");
            ListBlock[43] = new ListItem("43", "43 水管，横向，绿色，中下");
            ListBlock[44] = new ListItem("44", "44 水管，横向，绿色，右下");
            ListBlock[45] = new ListItem("45", "45 方块，云");
            ListBlock[46] = new ListItem("46", "46 红色地面，左下");
            ListBlock[47] = new ListItem("47", "47 红色地面，中下");
            ListBlock[48] = new ListItem("48", "48 红色地面，右下");
            ListBlock[49] = new ListItem("49", "49 水下地面，左上");
            ListBlock[50] = new ListItem("50", "50 水下地面，中上");
            ListBlock[51] = new ListItem("51", "51 水下地面，右上");
            ListBlock[52] = new ListItem("52", "52 城堡地面，左上");
            ListBlock[53] = new ListItem("53", "53 城堡地面，中上");
            ListBlock[54] = new ListItem("54", "54 城堡地面，右上");
            ListBlock[55] = new ListItem("55", "55 城堡桥，左");
            ListBlock[56] = new ListItem("56", "56 城堡桥，中");
            ListBlock[57] = new ListItem("57", "57 城堡桥，右");
            ListBlock[58] = new ListItem("58", "58 城堡砖，左");
            ListBlock[59] = new ListItem("59", "59 城堡砖，右");
            ListBlock[60] = new ListItem("60", "60 方块，棕");
            ListBlock[61] = new ListItem("61", "61 水下地面，左中");
            ListBlock[62] = new ListItem("62", "62 水下地面，中中");
            ListBlock[63] = new ListItem("63", "63 水下地面，右中");
            ListBlock[64] = new ListItem("64", "64 城堡地面，左中");
            ListBlock[65] = new ListItem("65", "65 城堡地面，中中");
            ListBlock[66] = new ListItem("66", "66 城堡地面，右中");
            ListBlock[67] = new ListItem("67", "67 蓝色地面，左上");
            ListBlock[68] = new ListItem("68", "68 蓝色地面，中上");
            ListBlock[69] = new ListItem("69", "69 蓝色地面，右上");
            ListBlock[70] = new ListItem("70", "70 蓝色地面，大号星星，无阴影");
            ListBlock[71] = new ListItem("71", "71 蓝色地面，小号星星，无阴影");
            ListBlock[72] = new ListItem("72", "72 方块，灰");
            ListBlock[73] = new ListItem("73", "73 水下地面，左下");
            ListBlock[74] = new ListItem("74", "74 水下地面，中下");
            ListBlock[75] = new ListItem("75", "75 水下地面，右下");
            ListBlock[76] = new ListItem("76", "76 城堡地面，左下");
            ListBlock[77] = new ListItem("77", "77 城堡地面，中下");
            ListBlock[78] = new ListItem("78", "78 城堡地面，右下");
            ListBlock[79] = new ListItem("79", "79 蓝色地面，左下，无阴影");
            ListBlock[80] = new ListItem("80", "80 蓝色地面，中下，无阴影");
            ListBlock[81] = new ListItem("81", "81 蓝色地面，右下，无阴影");
            ListBlock[82] = new ListItem("82", "82 蓝色地面，中下，无阴影");
            ListBlock[83] = new ListItem("83", "83 蓝色地面，中号星星，无阴影");
            ListBlock[84] = new ListItem("84", "84 方块，绿");
            ListBlock[85] = new ListItem("85", "85 85号Block");
            ListBlock[86] = new ListItem("86", "86 方块，MF蓝");
            ListBlock[87] = new ListItem("87", "87 水管，横向，金，左上");
            ListBlock[88] = new ListItem("88", "88 水管，横向，金，中上");
            ListBlock[89] = new ListItem("89", "89 水管，横向，金，右上");
            ListBlock[90] = new ListItem("90", "90 水管，横向，红，左上");
            ListBlock[91] = new ListItem("91", "91 水管，横向，红，中上");
            ListBlock[92] = new ListItem("92", "92 水管，横向，红，右上");
            ListBlock[93] = new ListItem("93", "93 蓝色地面，左下，有阴影");
            ListBlock[94] = new ListItem("94", "94 蓝色地面，中下，有阴影");
            ListBlock[95] = new ListItem("95", "95 蓝色地面，右下，有阴影");
            ListBlock[96] = new ListItem("96", "96 蓝色地面，大号星星，有阴影");
            ListBlock[97] = new ListItem("97", "97 蓝色地面，中号星星，有阴影");
            ListBlock[98] = new ListItem("98", "98 蓝色地面，小号星星，有阴影");
            ListBlock[99] = new ListItem("99", "99 水管，横向，金，左下");
            ListBlock[100] = new ListItem("A0", "A0 水管，横向，金，中下");
            ListBlock[101] = new ListItem("A1", "A1 水管，横向，金，右下");
            ListBlock[102] = new ListItem("A2", "A2 水管，横向，红，左下");
            ListBlock[103] = new ListItem("A3", "A3 水管，横向，红，中下");
            ListBlock[104] = new ListItem("A4", "A4 水管，横向，红，右下");
            ListBlock[105] = new ListItem("A5", "A5 水管，纵向，紫，上左");
            ListBlock[106] = new ListItem("A6", "A6 水管，纵向，紫，上右");
            ListBlock[107] = new ListItem("A7", "A7 方块，灰白");
            ListBlock[108] = new ListItem("A8", "A8 方块，城堡砖");
            ListBlock[109] = new ListItem("A9", "A9 水管，横向，紫，左上");
            ListBlock[110] = new ListItem("B0", "B0 水管，横向，紫，中上");
            ListBlock[111] = new ListItem("B1", "B1 水管，横向，紫，右上");
            ListBlock[112] = new ListItem("B2", "B2 水管，横向，白，左上");
            ListBlock[113] = new ListItem("B3", "B3 水管，横向，白，中上");
            ListBlock[114] = new ListItem("B4", "B4 水管，横向，白，右上");
            ListBlock[115] = new ListItem("B5", "B5 水管，纵向，紫，中左");
            ListBlock[116] = new ListItem("B6", "B6 水管，纵向，紫，中右");
            ListBlock[117] = new ListItem("B7", "B7 方块，红");
            ListBlock[118] = new ListItem("B8", "B8 方块，黄");
            ListBlock[119] = new ListItem("B9", "B9 用过的问号砖，蓝");
            ListBlock[120] = new ListItem("C0", "C0 城堡砖，特殊样式");
            ListBlock[121] = new ListItem("C1", "C1 水管，横向，紫，左下");
            ListBlock[122] = new ListItem("C2", "C2 水管，横向，紫，中下");
            ListBlock[123] = new ListItem("C3", "C3 水管，横向，紫，右下");
            ListBlock[124] = new ListItem("C4", "C4 水管，横向，白，左下");
            ListBlock[125] = new ListItem("C5", "C5 水管，横向，白，中下");
            ListBlock[126] = new ListItem("C6", "C6 水管，横向，白，右下");
            ListBlock[127] = new ListItem("C7", "C7 水管，纵向，紫，下左");
            ListBlock[128] = new ListItem("C8", "C8 水管，纵向，紫，下右");
            ListBlock[129] = new ListItem("C9", "C9 方块，紫红");
            ListBlock[130] = new ListItem("D0", "D0 方块，亮棕");
            ListBlock[131] = new ListItem("D1", "D1 用过的问号砖，灰");
            ListBlock[132] = new ListItem("D2", "D2 锁链");
            ListBlock[133] = new ListItem("D3", "D3 水管，横向，灰，左上");
            ListBlock[134] = new ListItem("D4", "D4 水管，横向，灰，中上");
            ListBlock[135] = new ListItem("D5", "D5 水管，横向，灰，右上");
            ListBlock[136] = new ListItem("D6", "D6 水管，纵向，金，上左");
            ListBlock[137] = new ListItem("D7", "D7 水管，纵向，金，上右");
            ListBlock[138] = new ListItem("D8", "D8 水管，纵向，红，上左");
            ListBlock[139] = new ListItem("D9", "D9 水管，纵向，红，上右");
            ListBlock[140] = new ListItem("E0", "E0 水管，纵向，白，上左");
            ListBlock[141] = new ListItem("E1", "E1 水管，纵向，白，上右");
            ListBlock[142] = new ListItem("E2", "E2 水管，纵向，灰，上左");
            ListBlock[143] = new ListItem("E3", "E3 水管，纵向，灰，上右");
            ListBlock[144] = new ListItem("E4", "E4 水管，纵向，灰，带点，上口左上");
            ListBlock[145] = new ListItem("E5", "E5 水管，横向，灰，左下");
            ListBlock[146] = new ListItem("E6", "E6 水管，横向，灰，中下");
            ListBlock[147] = new ListItem("E7", "E7 水管，横向，灰，右下");
            ListBlock[148] = new ListItem("E8", "E8 水管，纵向，金，中左");
            ListBlock[149] = new ListItem("E9", "E9 水管，纵向，金，中右");
            ListBlock[150] = new ListItem("F0", "F0 水管，纵向，红，中左");
            ListBlock[151] = new ListItem("F1", "F1 水管，纵向，红，中右");
            ListBlock[152] = new ListItem("F2", "F2 水管，纵向，白，中左");
            ListBlock[153] = new ListItem("F3", "F3 水管，纵向，白，中右");
            ListBlock[154] = new ListItem("F4", "F4 水管，纵向，灰，中左");
            ListBlock[155] = new ListItem("F5", "F5 水管，纵向，灰，中右");
            ListBlock[156] = new ListItem("F6", "F6 水管，纵向，灰，带点，上口左下");
            ListBlock[157] = new ListItem("F7", "F7 水管，横向，灰，带点，左口左上");
            ListBlock[158] = new ListItem("F8", "F8 水管，横向，灰，带点，左口右上");
            ListBlock[159] = new ListItem("F9", "F9 水管，横向，灰，带点，右口右上");
            ListBlock[160] = new ListItem("G0", "G0 水管，纵向，金，下左");
            ListBlock[161] = new ListItem("G1", "G1 水管，纵向，金，下右");
            ListBlock[162] = new ListItem("G2", "G2 水管，纵向，红，下左");
            ListBlock[163] = new ListItem("G3", "G3 水管，纵向，红，下右");
            ListBlock[164] = new ListItem("G4", "G4 水管，纵向，白，下左");
            ListBlock[165] = new ListItem("G5", "G5 水管，纵向，白，下右");
            ListBlock[166] = new ListItem("G6", "G6 水管，纵向，灰，下左");
            ListBlock[167] = new ListItem("G7", "G7 水管，纵向，灰，下右");
            ListBlock[168] = new ListItem("G8", "G8 水管，纵向，灰，带点，下口左下");
            ListBlock[169] = new ListItem("G9", "G9 融雪地面，左上");
            ListBlock[170] = new ListItem("H0", "H0 融雪地面，中上");
            ListBlock[171] = new ListItem("H1", "H1 融雪地面，右上");
            ListBlock[172] = new ListItem("H2", "H2 坟墓地面，左上");
            ListBlock[173] = new ListItem("H3", "H3 坟墓地面，中上");
            ListBlock[174] = new ListItem("H4", "H4 坟墓地面，右上");
            ListBlock[175] = new ListItem("H5", "H5 融雪地面，左下");
            ListBlock[176] = new ListItem("H6", "H6 融雪地面，中下");
            ListBlock[177] = new ListItem("H7", "H7 融雪地面，右下");
            ListBlock[178] = new ListItem("H8", "H8 坟墓地面，左下");
            ListBlock[179] = new ListItem("H9", "H9 坟墓地面，中下");
            ListBlock[180] = new ListItem("I0", "I0 坟墓地面，右下");
            ListBlock[181] = new ListItem("I1", "I1 冰雪地面，左上");
            ListBlock[182] = new ListItem("I2", "I2 冰雪地面，中上");
            ListBlock[183] = new ListItem("I3", "I3 冰雪地面，右上");
            ListBlock[184] = new ListItem("I4", "I4 黑暗地面，左上");
            ListBlock[185] = new ListItem("I5", "I5 黑暗地面，中上");
            ListBlock[186] = new ListItem("I6", "I6 黑暗地面，右上");
            ListBlock[187] = new ListItem("I7", "I7 冰雪地面，左下");
            ListBlock[188] = new ListItem("I8", "I8 冰雪地面，中下");
            ListBlock[189] = new ListItem("I9", "I9 冰雪地面，右下");
            ListBlock[190] = new ListItem("J0", "J0 黑暗地面，左下");
            ListBlock[191] = new ListItem("J1", "J1 黑暗地面，中下");
            ListBlock[192] = new ListItem("J2", "J2 黑暗地面，右下");
            ListBlock[193] = new ListItem("J3", "J3 沙漠地面，左上");
            ListBlock[194] = new ListItem("J4", "J4 沙漠地面，中上");
            ListBlock[195] = new ListItem("J5", "J5 沙漠地面，右上");
            ListBlock[196] = new ListItem("J6", "J6 城堡地面，左上衔接");
            ListBlock[197] = new ListItem("J7", "J7 城堡地面，右上衔接");
            ListBlock[198] = new ListItem("J8", "J8 桥，红");
            ListBlock[199] = new ListItem("J9", "J9 沙漠地面，左中");
            ListBlock[200] = new ListItem("K0", "K0 沙漠地面，中中");
            ListBlock[201] = new ListItem("K1", "K1 沙漠地面，右中");
            ListBlock[202] = new ListItem("K2", "K2 城堡地面，左下衔接");
            ListBlock[203] = new ListItem("K3", "K3 城堡地面，右下衔接");
            ListBlock[204] = new ListItem("K4", "K4 桥，蓝");
            ListBlock[205] = new ListItem("K5", "K5 沙漠地面，左下");
            ListBlock[206] = new ListItem("K6", "K6 沙漠地面，中下");
            ListBlock[207] = new ListItem("K7", "K7 沙漠地面，右下");
            ListBlock[208] = new ListItem("K8", "K8 桥，金");
            ListBlock[209] = new ListItem("K9", "K9 桥，藕荷");
            ListBlock[210] = new ListItem("L0", "L0 桥，灰");
        }

        /// <summary>
        /// 向敌人列表中加入数据
        /// </summary>
        public static void setListEnemy()
        {
            ListEnemy[0] = new ListItem("000", "000 空");
            ListEnemy[1] = new ListItem("001", "001 板栗仔");
            ListEnemy[2] = new ListItem("002", "002 绿乌龟");
            ListEnemy[3] = new ListItem("003", "003 红乌龟");
            ListEnemy[4] = new ListItem("004", "004 绿飞龟");
            ListEnemy[5] = new ListItem("005", "005 红刺猬");
            ListEnemy[6] = new ListItem("006", "006 水管绿色食人花（正向）");
            ListEnemy[7] = new ListItem("007", "007 水管绿色食人花（倒向）");
            ListEnemy[8] = new ListItem("008", "008 水管红色食人花（正向）");
            ListEnemy[9] = new ListItem("009", "009 水管红色食人花（倒向）");
            ListEnemy[10] = new ListItem("010", "010 红刺猬云");
            ListEnemy[11] = new ListItem("011", "011 炮台（正向）");
            ListEnemy[12] = new ListItem("012", "012 红飞鱼");
            ListEnemy[13] = new ListItem("013", "013 绿飞鱼");
            ListEnemy[14] = new ListItem("014", "014 蓝飞鱼");
            ListEnemy[15] = new ListItem("015", "015 黄飞鱼");
            ListEnemy[16] = new ListItem("016", "016 毒蘑菇");
            ListEnemy[17] = new ListItem("017", "017 扎地食人花");
            ListEnemy[18] = new ListItem("018", "018 岩浆");
            ListEnemy[19] = new ListItem("019", "019 锤子龟");
            ListEnemy[20] = new ListItem("020", "020 探照灯");
            ListEnemy[21] = new ListItem("021", "021 火球");
            ListEnemy[22] = new ListItem("022", "022 地刺");
            ListEnemy[23] = new ListItem("023", "023 石盾");
            ListEnemy[24] = new ListItem("024", "024 库巴");
            ListEnemy[25] = new ListItem("025", "025 灰刺猬");
            ListEnemy[26] = new ListItem("026", "026 炮台（正向，追踪）");
            ListEnemy[27] = new ListItem("027", "027 火球龟");
            ListEnemy[28] = new ListItem("028", "028 岩浆底部");
            ListEnemy[29] = new ListItem("029", "029 炮台（倒向）");
            ListEnemy[30] = new ListItem("030", "030 炮台（倒向，追踪）");
            ListEnemy[31] = new ListItem("031", "031 布布鬼");
            ListEnemy[32] = new ListItem("032", "032 硬壳龟");
            ListEnemy[33] = new ListItem("033", "033 红飞龟");
            ListEnemy[34] = new ListItem("034", "034 蓝乌龟");
            ListEnemy[35] = new ListItem("035", "035 蓝飞龟");
            ListEnemy[36] = new ListItem("036", "036 电珊瑚");
        }

        /// <summary>
        /// 向景物列表中加入数据
        /// </summary>
        public static void setListScene()
        {
            ListScene[0] = new ListItem("100", "100 空");
            ListScene[1] = new ListItem("101", "101 云（白）");
            ListScene[2] = new ListItem("102", "102 草（绿）");
            ListScene[3] = new ListItem("103", "103 树（绿，小）");
            ListScene[4] = new ListItem("104", "104 树（绿，大）");
            ListScene[5] = new ListItem("105", "105 栅栏（普通）");
            ListScene[6] = new ListItem("106", "106 树（紫，小）");
            ListScene[7] = new ListItem("107", "107 云（灰）");
            ListScene[8] = new ListItem("108", "108 草（灰）");
            ListScene[9] = new ListItem("109", "109 树（灰，小）");
            ListScene[10] = new ListItem("110", "110 树（灰，大）");
            ListScene[11] = new ListItem("111", "111 栅栏（灰）");
            ListScene[12] = new ListItem("112", "112 树（紫，大）");
            ListScene[13] = new ListItem("113", "113 云（黄）");
            ListScene[14] = new ListItem("114", "114 灯（发光）");
            ListScene[15] = new ListItem("115", "115 灯（损坏）");
            ListScene[16] = new ListItem("116", "116 城堡（小）");
            ListScene[17] = new ListItem("117", "117 城堡（大）");
            ListScene[18] = new ListItem("118", "118 库巴画像");
            ListScene[19] = new ListItem("119", "119 炮台骷髅（正向）");
            ListScene[20] = new ListItem("120", "120 炮台底座");
            ListScene[21] = new ListItem("121", "121 炮台骷髅（倒向）");
            ListScene[22] = new ListItem("122", "122 草（红）");
            ListScene[23] = new ListItem("123", "123 树（红，小）");
            ListScene[24] = new ListItem("124", "124 树（红，大）");
            ListScene[25] = new ListItem("125", "125 草（白）");
            ListScene[26] = new ListItem("126", "126 树（白，小）");
            ListScene[27] = new ListItem("127", "127 树（白，大）");
            ListScene[28] = new ListItem("128", "128 栅栏（雪地）");
            ListScene[29] = new ListItem("129", "129 城堡（小，雪地）");
            ListScene[30] = new ListItem("130", "130 城堡（大，雪地）");
        }

        /// <summary>
        /// 向标记列表中加入数据
        /// </summary>
        public static void setListMarks()
        {
            ListMarks[0] = new ListItem("217", "217 通关器");
            ListMarks[1] = new ListItem("218", "218 实心块");
            ListMarks[2] = new ListItem("219", "219 起始点");
            ListMarks[3] = new ListItem("220", "220 中途点");
            ListMarks[4] = new ListItem("222", "222 封顶用实心块");
            ListMarks[5] = new ListItem("4", "4 水管连接");
        }

        /// <summary>
        /// 向平台列表中加入数据
        /// </summary>
        public static void setListPlats()
        {
            ListPlats[0] = new ListItem("200", "200 悬浮桥（长，红）");
            ListPlats[1] = new ListItem("201", "201 横向运输桥（长，红，慢速）");
            ListPlats[2] = new ListItem("202", "200 横向运输桥（长，红，中速）");
            ListPlats[3] = new ListItem("203", "203 横向运输桥（长，红，快速）");
            ListPlats[4] = new ListItem("204", "204 纵向运输桥（长，红，向下）");
            ListPlats[5] = new ListItem("205", "205 纵向运输桥（长，红，向上）");
            ListPlats[6] = new ListItem("206", "206 悬浮桥（短，红）");
            ListPlats[7] = new ListItem("207", "207 横向运输桥（短，红，慢速）");
            ListPlats[8] = new ListItem("208", "208 横向运输桥（短，红，中速）");
            ListPlats[9] = new ListItem("209", "209 横向运输桥（短，红，快速）");
            ListPlats[10] = new ListItem("210", "210 纵向运输桥（短，红，向下）");
            ListPlats[11] = new ListItem("211", "211 纵向运输桥（短，红，向上）");
            ListPlats[12] = new ListItem("212", "212 悬浮桥（云）");
            ListPlats[13] = new ListItem("213", "213 横向运输桥（云，慢速）");
            ListPlats[14] = new ListItem("214", "214 横向运输桥（云，中速）");
            ListPlats[15] = new ListItem("215", "215 横向运输桥（云，快速）");
            ListPlats[16] = new ListItem("216", "216 纵向运输桥（云，向下）");
            ListPlats[17] = new ListItem("221", "221 纵向运输桥（云，向上）");
        }

        /// <summary>
        /// 向奖励列表中加入数据
        /// </summary>
        public static void setListBonus()
        {
            ListBonus[0] = new ListItem("300", "300 空");
            ListBonus[1] = new ListItem("301", "301 问号砖（火力花）");
            ListBonus[2] = new ListItem("302", "302 问号砖（甜菜）");
            ListBonus[3] = new ListItem("303", "303 问号砖（绿果）");
            ListBonus[4] = new ListItem("304", "304 问号砖（无敌星）");
            ListBonus[5] = new ListItem("305", "305 问号砖（绿蘑菇）");
            ListBonus[6] = new ListItem("306", "306 问号砖（毒蘑菇）");
            ListBonus[7] = new ListItem("307", "307 隐藏砖（火力花）");
            ListBonus[8] = new ListItem("308", "308 隐藏砖（甜菜）");
            ListBonus[9] = new ListItem("309", "309 隐藏砖（绿果）");
            ListBonus[10] = new ListItem("310", "310 隐藏砖（无敌星）");
            ListBonus[11] = new ListItem("311", "311 隐藏砖（绿蘑菇）");
            ListBonus[12] = new ListItem("312", "312 隐藏砖（毒蘑菇）");
            ListBonus[13] = new ListItem("313", "313 问号砖（金币）");
            ListBonus[14] = new ListItem("314", "314 隐藏砖（金币）");
            ListBonus[15] = new ListItem("315", "315 砖块（普通）");
            ListBonus[16] = new ListItem("316", "316 砖块（金币）");
            ListBonus[17] = new ListItem("317", "317 砖块（金币，隐藏）");
            ListBonus[18] = new ListItem("318", "318 金币");
            ListBonus[19] = new ListItem("319", "319 红蘑菇");
            ListBonus[20] = new ListItem("320", "320 火力花");
            ListBonus[21] = new ListItem("321", "321 甜菜");
            ListBonus[22] = new ListItem("322", "322 绿果");
            ListBonus[23] = new ListItem("323", "323 无敌星");
            ListBonus[24] = new ListItem("324", "324 绿蘑菇");
        }

        public static ListItem[] ListPipe = new ListItem[4];

        public static void setListPipe()
        {
            ListPipe[0] = new ListItem("0", "右");
            ListPipe[1] = new ListItem("1", "上");
            ListPipe[2] = new ListItem("2", "左");
            ListPipe[3] = new ListItem("3", "下");
        }
    }
}
