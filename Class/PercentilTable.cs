using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WomenConsulting
{
    public class PercentilTable
    {
        public List<PercentilTableRow> WeekRows = new List<PercentilTableRow>();
        public double MassConstA { get; set; }
        public double MassConstB { get; set; }
        public PercentilTable()
        {
            Init();
        }
        public void Init()
        {
            MassConstA = 0.27777;
            MassConstB = 0.001492;

            #region фетометрия
            List<int> perc97_Mass = new List<int>();
            List<int> perc95_Mass = new List<int>();
            List<int> perc90_Mass = new List<int>();
            List<int> perc10_Mass = new List<int>();
            List<int> perc5_Mass = new List<int>();
            List<int> perc3_Mass = new List<int>();

            List<int> perc90_BPR = new List<int>();
            List<int> perc10_BPR = new List<int>();
            List<int> perc5_BPR = new List<int>();

            List<int> perc90_DB = new List<int>();
            List<int> perc10_DB = new List<int>();
            List<int> perc5_DB = new List<int>();

            List<int> perc97_OZh = new List<int>();
            List<int> perc95_OZh = new List<int>();
            List<int> perc90_OZh = new List<int>();
            List<int> perc10_OZh = new List<int>();
            List<int> perc5_OZh = new List<int>();
            List<int> perc3_OZh = new List<int>();

            List<int> perc90_DPK = new List<int>();
            List<int> perc10_DPK = new List<int>();
            List<int> perc5_DPK = new List<int>();

            List<int> perc90_DPP = new List<int>();
            List<int> perc10_DPP = new List<int>();
            List<int> perc5_DPP = new List<int>();

            List<int> perc90_DKG = new List<int>();
            List<int> perc10_DKG = new List<int>();
            List<int> perc5_DKG = new List<int>();

            #region Mass
            for (int i = 0; i <= 40; i++)
            {
                perc97_Mass.Add(0);
            }
            perc97_Mass[22] = 607;
            perc97_Mass[23] = 695;
            perc97_Mass[24] = 796;
            perc97_Mass[25] = 913;
            perc97_Mass[26] = 1048;
            perc97_Mass[27] = 1202;
            perc97_Mass[28] = 1375;
            perc97_Mass[29] = 1569;
            perc97_Mass[30] = 1783;
            perc97_Mass[31] = 2016;
            perc97_Mass[32] = 2266;
            perc97_Mass[33] = 2529;
            perc97_Mass[34] = 2800;
            perc97_Mass[35] = 3071;
            perc97_Mass[36] = 3335;
            perc97_Mass[37] = 3582;
            perc97_Mass[38] = 3799;
            perc97_Mass[39] = 3976;
            perc97_Mass[40] = 4101;

            for (int i = 0; i <= 40; i++)
            {
                perc95_Mass.Add(0);
            }
            perc95_Mass[22] = 596;
            perc95_Mass[23] = 680;
            perc95_Mass[24] = 778;
            perc95_Mass[25] = 891;
            perc95_Mass[26] = 1020;
            perc95_Mass[27] = 1168;
            perc95_Mass[28] = 1335;
            perc95_Mass[29] = 1521;
            perc95_Mass[30] = 1728;
            perc95_Mass[31] = 1953;
            perc95_Mass[32] = 2195;
            perc95_Mass[33] = 2450;
            perc95_Mass[34] = 2713;
            perc95_Mass[35] = 2978;
            perc95_Mass[36] = 3237;
            perc95_Mass[37] = 3480;
            perc95_Mass[38] = 3697;
            perc95_Mass[39] = 3876;
            perc95_Mass[40] = 4006;

            for (int i = 0; i <= 40; i++)
            {
                perc90_Mass.Add(0);
            }
            perc90_Mass[22] = 578;
            perc90_Mass[23] = 658;
            perc90_Mass[24] = 751;
            perc90_Mass[25] = 858;
            perc90_Mass[26] = 980;
            perc90_Mass[27] = 1119;
            perc90_Mass[28] = 1276;
            perc90_Mass[29] = 1452;
            perc90_Mass[30] = 1647;
            perc90_Mass[31] = 1860;
            perc90_Mass[32] = 2089;
            perc90_Mass[33] = 2332;
            perc90_Mass[34] = 2583;
            perc90_Mass[35] = 2838;
            perc90_Mass[36] = 3089;
            perc90_Mass[37] = 3326;
            perc90_Mass[38] = 3541;
            perc90_Mass[39] = 3722;
            perc90_Mass[40] = 3858;

            for (int i = 0; i <= 40; i++)
            {
                perc10_Mass.Add(0);
            }
            perc10_Mass[22] = 481;
            perc10_Mass[23] = 538;
            perc10_Mass[24] = 602;
            perc10_Mass[25] = 674;
            perc10_Mass[26] = 757;
            perc10_Mass[27] = 849;
            perc10_Mass[28] = 951;
            perc10_Mass[29] = 1065;
            perc10_Mass[30] = 1190;
            perc10_Mass[31] = 1326;
            perc10_Mass[32] = 1473;
            perc10_Mass[33] = 1630;
            perc10_Mass[34] = 1795;
            perc10_Mass[35] = 1967;
            perc10_Mass[36] = 2144;
            perc10_Mass[37] = 2321;
            perc10_Mass[38] = 2495;
            perc10_Mass[39] = 2663;
            perc10_Mass[40] = 2818;

            for (int i = 0; i <= 40; i++)
            {
                perc5_Mass.Add(0);
            }
            perc5_Mass[22] = 470;
            perc5_Mass[23] = 524;
            perc5_Mass[24] = 585;
            perc5_Mass[25] = 654;
            perc5_Mass[26] = 732;
            perc5_Mass[27] = 818;
            perc5_Mass[28] = 915;
            perc5_Mass[29] = 1021;
            perc5_Mass[30] = 1138;
            perc5_Mass[31] = 1265;
            perc5_Mass[32] = 1401;
            perc5_Mass[33] = 1547;
            perc5_Mass[34] = 1700;
            perc5_Mass[35] = 1860;
            perc5_Mass[36] = 2024;
            perc5_Mass[37] = 2190;
            perc5_Mass[38] = 2355;
            perc5_Mass[39] = 2516;
            perc5_Mass[40] = 2670;

            for (int i = 0; i <= 40; i++)
            {
                perc3_Mass.Add(0);
            }
            perc3_Mass[22] = 463;
            perc3_Mass[23] = 516;
            perc3_Mass[24] = 575;
            perc3_Mass[25] = 641;
            perc3_Mass[26] = 716;
            perc3_Mass[27] = 800;
            perc3_Mass[28] = 892;
            perc3_Mass[29] = 994;
            perc3_Mass[30] = 1106;
            perc3_Mass[31] = 1227;
            perc3_Mass[32] = 1357;
            perc3_Mass[33] = 1495;
            perc3_Mass[34] = 1641;
            perc3_Mass[35] = 1792;
            perc3_Mass[36] = 1948;
            perc3_Mass[37] = 2106;
            perc3_Mass[38] = 2265;
            perc3_Mass[39] = 2422;
            perc3_Mass[40] = 2574;
            #endregion

            #region BPR
            for (int i = 0; i <= 40; i++)
            {
                perc90_BPR.Add(0);
            }

            perc90_BPR[16] = 37;
            perc90_BPR[17] = 42;
            perc90_BPR[18] = 47;
            perc90_BPR[19] = 49;
            perc90_BPR[20] = 53;
            perc90_BPR[21] = 56;
            perc90_BPR[22] = 60;
            perc90_BPR[23] = 64;
            perc90_BPR[24] = 67;
            perc90_BPR[25] = 70;
            perc90_BPR[26] = 73;
            perc90_BPR[27] = 76;
            perc90_BPR[28] = 79;
            perc90_BPR[29] = 82;
            perc90_BPR[30] = 85;
            perc90_BPR[31] = 87;
            perc90_BPR[32] = 89;
            perc90_BPR[33] = 91;
            perc90_BPR[34] = 93;
            perc90_BPR[35] = 95;
            perc90_BPR[36] = 97;
            perc90_BPR[37] = 98;
            perc90_BPR[38] = 100;
            perc90_BPR[39] = 102;
            perc90_BPR[40] = 103;

            for (int i = 0; i <= 40; i++)
            {
                perc10_BPR.Add(0);
            }
            perc10_BPR[16] = 31;
            perc10_BPR[17] = 34;
            perc10_BPR[18] = 37;
            perc10_BPR[19] = 41;
            perc10_BPR[20] = 43;
            perc10_BPR[21] = 46;
            perc10_BPR[22] = 48;
            perc10_BPR[23] = 52;
            perc10_BPR[24] = 55;
            perc10_BPR[25] = 58;
            perc10_BPR[26] = 61;
            perc10_BPR[27] = 64;
            perc10_BPR[28] = 67;
            perc10_BPR[29] = 70;
            perc10_BPR[30] = 71;
            perc10_BPR[31] = 73;
            perc10_BPR[32] = 75;
            perc10_BPR[33] = 77;
            perc10_BPR[34] = 79;
            perc10_BPR[35] = 81;
            perc10_BPR[36] = 83;
            perc10_BPR[37] = 85;
            perc10_BPR[38] = 86;
            perc10_BPR[39] = 88;
            perc10_BPR[40] = 89;

            for (int i = 0; i <= 40; i++)
            {
                perc5_BPR.Add(0);
            }
            perc5_BPR[14] = 18;
            perc5_BPR[15] = 22;
            perc5_BPR[16] = 26;
            perc5_BPR[17] = 29;
            perc5_BPR[18] = 32;
            perc5_BPR[19] = 36;
            perc5_BPR[20] = 39;
            perc5_BPR[21] = 42;
            perc5_BPR[22] = 45;
            perc5_BPR[23] = 48;
            perc5_BPR[24] = 51;
            perc5_BPR[25] = 53;
            perc5_BPR[26] = 56;
            perc5_BPR[27] = 59;
            perc5_BPR[28] = 62;
            perc5_BPR[29] = 64;
            perc5_BPR[30] = 67;
            perc5_BPR[31] = 69;
            perc5_BPR[32] = 72;
            perc5_BPR[33] = 74;
            perc5_BPR[34] = 76;
            perc5_BPR[35] = 79;
            perc5_BPR[36] = 81;
            perc5_BPR[37] = 83;
            perc5_BPR[38] = 86;
            perc5_BPR[39] = 88;
            perc5_BPR[40] = 89;
            #endregion

            #region DB
            for (int i = 0; i <= 40; i++)
            {
                perc90_DB.Add(0);
            }
            perc90_DB[12] = 11;
            perc90_DB[13] = 14;
            perc90_DB[14] = 19;
            perc90_DB[15] = 20;
            perc90_DB[16] = 23;
            perc90_DB[17] = 28;
            perc90_DB[18] = 31;
            perc90_DB[19] = 34;
            perc90_DB[20] = 37;
            perc90_DB[21] = 39;
            perc90_DB[22] = 43;
            perc90_DB[23] = 46;
            perc90_DB[24] = 50;
            perc90_DB[25] = 50;
            perc90_DB[26] = 58;
            perc90_DB[27] = 60;
            perc90_DB[28] = 61;
            perc90_DB[29] = 62;
            perc90_DB[30] = 62;
            perc90_DB[31] = 65;
            perc90_DB[32] = 66;
            perc90_DB[33] = 69;
            perc90_DB[34] = 69;
            perc90_DB[35] = 71;
            perc90_DB[36] = 72;
            perc90_DB[37] = 74;
            perc90_DB[38] = 76;
            perc90_DB[39] = 78;
            perc90_DB[40] = 80;

            for (int i = 0; i <= 40; i++)
            {
                perc10_DB.Add(0);
            }
            perc10_DB[12] = 7;
            perc10_DB[13] = 10;
            perc10_DB[14] = 13;
            perc10_DB[15] = 15;
            perc10_DB[16] = 17;
            perc10_DB[17] = 20;
            perc10_DB[18] = 23;
            perc10_DB[19] = 26;
            perc10_DB[20] = 29;
            perc10_DB[21] = 35;
            perc10_DB[22] = 37;
            perc10_DB[23] = 40;
            perc10_DB[24] = 42;
            perc10_DB[25] = 46;
            perc10_DB[26] = 49;
            perc10_DB[27] = 53;
            perc10_DB[28] = 54;
            perc10_DB[29] = 55;
            perc10_DB[30] = 56;
            perc10_DB[31] = 59;
            perc10_DB[32] = 60;
            perc10_DB[33] = 63;
            perc10_DB[34] = 64;
            perc10_DB[35] = 65;
            perc10_DB[36] = 67;
            perc10_DB[37] = 68;
            perc10_DB[38] = 70;
            perc10_DB[39] = 72;
            perc10_DB[40] = 74;

            for (int i = 0; i <= 40; i++)
            {
                perc5_DB.Add(0);
            }
            perc5_DB[14] = 8;
            perc5_DB[15] = 10;
            perc5_DB[16] = 13;
            perc5_DB[17] = 16;
            perc5_DB[18] = 18;
            perc5_DB[19] = 21;
            perc5_DB[20] = 23;
            perc5_DB[21] = 26;
            perc5_DB[22] = 28;
            perc5_DB[23] = 31;
            perc5_DB[24] = 33;
            perc5_DB[25] = 36;
            perc5_DB[26] = 38;
            perc5_DB[27] = 40;
            perc5_DB[28] = 43;
            perc5_DB[29] = 45;
            perc5_DB[30] = 47;
            perc5_DB[31] = 50;
            perc5_DB[32] = 52;
            perc5_DB[33] = 54;
            perc5_DB[34] = 57;
            perc5_DB[35] = 59;
            perc5_DB[36] = 61;
            perc5_DB[37] = 63;
            perc5_DB[38] = 65;
            perc5_DB[39] = 68;
            perc5_DB[40] = 70;
            #endregion

            #region Ozh
            for (int i = 0; i <= 40; i++)
            {
                perc97_OZh.Add(0);
            }
            perc97_OZh[14] = 88;
            perc97_OZh[15] = 101;
            perc97_OZh[16] = 113;
            perc97_OZh[17] = 126;
            perc97_OZh[18] = 138;
            perc97_OZh[19] = 150;
            perc97_OZh[20] = 162;
            perc97_OZh[21] = 174;
            perc97_OZh[22] = 186;
            perc97_OZh[23] = 197;
            perc97_OZh[24] = 209;
            perc97_OZh[25] = 221;
            perc97_OZh[26] = 232;
            perc97_OZh[27] = 243;
            perc97_OZh[28] = 255;
            perc97_OZh[29] = 266;
            perc97_OZh[30] = 277;
            perc97_OZh[31] = 288;
            perc97_OZh[32] = 300;
            perc97_OZh[33] = 311;
            perc97_OZh[34] = 322;
            perc97_OZh[35] = 333;
            perc97_OZh[36] = 345;
            perc97_OZh[37] = 356;
            perc97_OZh[38] = 368;
            perc97_OZh[39] = 380;
            perc97_OZh[40] = 392;

            for (int i = 0; i <= 40; i++)
            {
                perc95_OZh.Add(0);
            }
            perc95_OZh[14] = 87;
            perc95_OZh[15] = 100;
            perc95_OZh[16] = 112;
            perc95_OZh[17] = 124;
            perc95_OZh[18] = 136;
            perc95_OZh[19] = 148;
            perc95_OZh[20] = 160;
            perc95_OZh[21] = 172;
            perc95_OZh[22] = 184;
            perc95_OZh[23] = 195;
            perc95_OZh[24] = 207;
            perc95_OZh[25] = 218;
            perc95_OZh[26] = 230;
            perc95_OZh[27] = 241;
            perc95_OZh[28] = 252;
            perc95_OZh[29] = 263;
            perc95_OZh[30] = 274;
            perc95_OZh[31] = 285;
            perc95_OZh[32] = 296;
            perc95_OZh[33] = 307;
            perc95_OZh[34] = 319;
            perc95_OZh[35] = 330;
            perc95_OZh[36] = 341;
            perc95_OZh[37] = 352;
            perc95_OZh[38] = 364;
            perc95_OZh[39] = 375;
            perc95_OZh[40] = 387;

            for (int i = 0; i <= 40; i++)
            {
                perc90_OZh.Add(0);
            }
            perc90_OZh[14] = 86;
            perc90_OZh[15] = 98;
            perc90_OZh[16] = 110;
            perc90_OZh[17] = 122;
            perc90_OZh[18] = 134;
            perc90_OZh[19] = 146;
            perc90_OZh[20] = 158;
            perc90_OZh[21] = 169;
            perc90_OZh[22] = 181;
            perc90_OZh[23] = 192;
            perc90_OZh[24] = 203;
            perc90_OZh[25] = 215;
            perc90_OZh[26] = 226;
            perc90_OZh[27] = 237;
            perc90_OZh[28] = 248;
            perc90_OZh[29] = 259;
            perc90_OZh[30] = 270;
            perc90_OZh[31] = 281;
            perc90_OZh[32] = 291;
            perc90_OZh[33] = 302;
            perc90_OZh[34] = 313;
            perc90_OZh[35] = 324;
            perc90_OZh[36] = 335;
            perc90_OZh[37] = 346;
            perc90_OZh[38] = 356;
            perc90_OZh[39] = 367;
            perc90_OZh[40] = 379;

            for (int i = 0; i <= 40; i++)
            {
                perc10_OZh.Add(0);
            }
            perc10_OZh[14] = 75;
            perc10_OZh[15] = 86;
            perc10_OZh[16] = 96;
            perc10_OZh[17] = 107;
            perc10_OZh[18] = 117;
            perc10_OZh[19] = 128;
            perc10_OZh[20] = 138;
            perc10_OZh[21] = 148;
            perc10_OZh[22] = 159;
            perc10_OZh[23] = 169;
            perc10_OZh[24] = 179;
            perc10_OZh[25] = 189;
            perc10_OZh[26] = 199;
            perc10_OZh[27] = 209;
            perc10_OZh[28] = 219;
            perc10_OZh[29] = 229;
            perc10_OZh[30] = 238;
            perc10_OZh[31] = 247;
            perc10_OZh[32] = 257;
            perc10_OZh[33] = 265;
            perc10_OZh[34] = 274;
            perc10_OZh[35] = 282;
            perc10_OZh[36] = 291;
            perc10_OZh[37] = 299;
            perc10_OZh[38] = 306;
            perc10_OZh[39] = 314;
            perc10_OZh[40] = 321;
            for (int i = 0; i <= 40; i++)
            {
                perc5_OZh.Add(0);
            }
            perc5_OZh[14] = 74;
            perc5_OZh[15] = 84;
            perc5_OZh[16] = 94;
            perc5_OZh[17] = 105;
            perc5_OZh[18] = 115;
            perc5_OZh[19] = 125;
            perc5_OZh[20] = 135;
            perc5_OZh[21] = 145;
            perc5_OZh[22] = 156;
            perc5_OZh[23] = 166;
            perc5_OZh[24] = 176;
            perc5_OZh[25] = 186;
            perc5_OZh[26] = 195;
            perc5_OZh[27] = 205;
            perc5_OZh[28] = 215;
            perc5_OZh[29] = 224;
            perc5_OZh[30] = 234;
            perc5_OZh[31] = 243;
            perc5_OZh[32] = 252;
            perc5_OZh[33] = 260;
            perc5_OZh[34] = 269;
            perc5_OZh[35] = 277;
            perc5_OZh[36] = 285;
            perc5_OZh[37] = 293;
            perc5_OZh[38] = 300;
            perc5_OZh[39] = 307;
            perc5_OZh[40] = 312;

            for (int i = 0; i <= 40; i++)
            {
                perc3_OZh.Add(0);
            }
            perc3_OZh[14] = 73;
            perc3_OZh[15] = 83;
            perc3_OZh[16] = 93;
            perc3_OZh[17] = 103;
            perc3_OZh[18] = 113;
            perc3_OZh[19] = 123;
            perc3_OZh[20] = 133;
            perc3_OZh[21] = 143;
            perc3_OZh[22] = 154;
            perc3_OZh[23] = 163;
            perc3_OZh[24] = 173;
            perc3_OZh[25] = 183;
            perc3_OZh[26] = 193;
            perc3_OZh[27] = 203;
            perc3_OZh[28] = 212;
            perc3_OZh[29] = 221;
            perc3_OZh[30] = 231;
            perc3_OZh[31] = 240;
            perc3_OZh[32] = 248;
            perc3_OZh[33] = 257;
            perc3_OZh[34] = 265;
            perc3_OZh[35] = 273;
            perc3_OZh[36] = 281;
            perc3_OZh[37] = 288;
            perc3_OZh[38] = 295;
            perc3_OZh[39] = 302;
            perc3_OZh[40] = 308;
            #endregion

            #region DPK
            for (int i = 0; i <= 40; i++)
            {
                perc90_DPK.Add(0);
            }
            perc90_DPK[12] = 25;
            perc90_DPK[13] = 26;
            perc90_DPK[14] = 28;
            perc90_DPK[15] = 30;
            perc90_DPK[16] = 36;
            perc90_DPK[17] = 40;
            perc90_DPK[18] = 43;
            perc90_DPK[19] = 46;
            perc90_DPK[20] = 50;
            perc90_DPK[21] = 52;
            perc90_DPK[22] = 55;
            perc90_DPK[23] = 58;
            perc90_DPK[24] = 62;
            perc90_DPK[25] = 64;
            perc90_DPK[26] = 66;
            perc90_DPK[27] = 71;
            perc90_DPK[28] = 75;
            perc90_DPK[29] = 78;
            perc90_DPK[30] = 81;
            perc90_DPK[31] = 83;
            perc90_DPK[32] = 85;
            perc90_DPK[33] = 87;
            perc90_DPK[34] = 90;
            perc90_DPK[35] = 93;
            perc90_DPK[36] = 96;
            perc90_DPK[37] = 99;
            perc90_DPK[38] = 101;
            perc90_DPK[39] = 103;
            perc90_DPK[40] = 105;

            for (int i = 0; i <= 40; i++)
            {
                perc10_DPK.Add(0);
            }
            perc10_DPK[12] = 21;
            perc10_DPK[13] = 22;
            perc10_DPK[14] = 24;
            perc10_DPK[15] = 26;
            perc10_DPK[16] = 28;
            perc10_DPK[17] = 36;
            perc10_DPK[18] = 39;
            perc10_DPK[19] = 42;
            perc10_DPK[20] = 46;
            perc10_DPK[21] = 48;
            perc10_DPK[22] = 51;
            perc10_DPK[23] = 54;
            perc10_DPK[24] = 57;
            perc10_DPK[25] = 60;
            perc10_DPK[26] = 62;
            perc10_DPK[27] = 67;
            perc10_DPK[28] = 71;
            perc10_DPK[29] = 74;
            perc10_DPK[30] = 77;
            perc10_DPK[31] = 79;
            perc10_DPK[32] = 81;
            perc10_DPK[33] = 83;
            perc10_DPK[34] = 86;
            perc10_DPK[35] = 89;
            perc10_DPK[36] = 92;
            perc10_DPK[37] = 95;
            perc10_DPK[38] = 97;
            perc10_DPK[39] = 99;
            perc10_DPK[40] = 101;

            for (int i = 0; i <= 40; i++)
            {
                perc5_DPK.Add(0);
            }
            perc5_DPK[16] = 15;
            perc5_DPK[17] = 17;
            perc5_DPK[18] = 20;
            perc5_DPK[19] = 23;
            perc5_DPK[20] = 26;
            perc5_DPK[21] = 29;
            perc5_DPK[22] = 31;
            perc5_DPK[23] = 34;
            perc5_DPK[24] = 36;
            perc5_DPK[25] = 39;
            perc5_DPK[26] = 41;
            perc5_DPK[27] = 43;
            perc5_DPK[28] = 45;
            perc5_DPK[29] = 47;
            perc5_DPK[30] = 49;
            perc5_DPK[31] = 51;
            perc5_DPK[32] = 52;
            perc5_DPK[33] = 54;
            perc5_DPK[34] = 55;
            perc5_DPK[35] = 57;
            perc5_DPK[36] = 58;
            perc5_DPK[37] = 59;
            perc5_DPK[38] = 60;
            perc5_DPK[39] = 60;
            perc5_DPK[40] = 61;
            #endregion

            #region DKG
            for (int i = 0; i <= 40; i++)
            {
                perc90_DKG.Add(0);
            }
            perc90_DKG[16] = 21;
            perc90_DKG[17] = 25;
            perc90_DKG[18] = 28;
            perc90_DKG[19] = 31;
            perc90_DKG[20] = 34;
            perc90_DKG[21] = 37;
            perc90_DKG[22] = 39;
            perc90_DKG[23] = 42;
            perc90_DKG[24] = 44;
            perc90_DKG[25] = 46;
            perc90_DKG[26] = 49;
            perc90_DKG[27] = 51;
            perc90_DKG[28] = 53;
            perc90_DKG[29] = 55;
            perc90_DKG[30] = 57;
            perc90_DKG[31] = 60;
            perc90_DKG[32] = 61;
            perc90_DKG[33] = 63;
            perc90_DKG[34] = 65;
            perc90_DKG[35] = 66;
            perc90_DKG[36] = 67;
            perc90_DKG[37] = 69;
            perc90_DKG[38] = 70;
            perc90_DKG[39] = 71;
            perc90_DKG[40] = 72;

            for (int i = 0; i <= 40; i++)
            {
                perc10_DKG.Add(0);
            }
            perc10_DKG[16] = 15;
            perc10_DKG[17] = 17;
            perc10_DKG[18] = 20;
            perc10_DKG[19] = 23;
            perc10_DKG[20] = 26;
            perc10_DKG[21] = 29;
            perc10_DKG[22] = 31;
            perc10_DKG[23] = 34;
            perc10_DKG[24] = 36;
            perc10_DKG[25] = 38;
            perc10_DKG[26] = 41;
            perc10_DKG[27] = 43;
            perc10_DKG[28] = 45;
            perc10_DKG[29] = 47;
            perc10_DKG[30] = 49;
            perc10_DKG[31] = 50;
            perc10_DKG[32] = 51;
            perc10_DKG[33] = 53;
            perc10_DKG[34] = 55;
            perc10_DKG[35] = 56;
            perc10_DKG[36] = 57;
            perc10_DKG[37] = 59;
            perc10_DKG[38] = 60;
            perc10_DKG[39] = 61;
            perc10_DKG[40] = 62;

            for (int i = 0; i <= 40; i++)
            {
                perc5_DKG.Add(0);
            }
            perc5_DKG[16] = 11;
            perc5_DKG[17] = 14;
            perc5_DKG[18] = 16;
            perc5_DKG[19] = 19;
            perc5_DKG[20] = 21;
            perc5_DKG[21] = 24;
            perc5_DKG[22] = 26;
            perc5_DKG[23] = 28;
            perc5_DKG[24] = 30;
            perc5_DKG[25] = 32;
            perc5_DKG[26] = 34;
            perc5_DKG[27] = 36;
            perc5_DKG[28] = 38;
            perc5_DKG[29] = 40;
            perc5_DKG[30] = 42;
            perc5_DKG[31] = 43;
            perc5_DKG[32] = 45;
            perc5_DKG[33] = 47;
            perc5_DKG[34] = 48;
            perc5_DKG[35] = 50;
            perc5_DKG[36] = 51;
            perc5_DKG[37] = 53;
            perc5_DKG[38] = 55;
            perc5_DKG[39] = 56;
            perc5_DKG[40] = 57;
            #endregion

            #region DPP
            for (int i = 0; i <= 40; i++)
            {
                perc90_DPP.Add(0);
            }
            perc90_DPP[16] = 18;
            perc90_DPP[17] = 21;
            perc90_DPP[18] = 23;
            perc90_DPP[19] = 26;
            perc90_DPP[20] = 29;
            perc90_DPP[21] = 32;
            perc90_DPP[22] = 34;
            perc90_DPP[23] = 37;
            perc90_DPP[24] = 39;
            perc90_DPP[25] = 41;
            perc90_DPP[26] = 43;
            perc90_DPP[27] = 45;
            perc90_DPP[28] = 47;
            perc90_DPP[29] = 48;
            perc90_DPP[30] = 50;
            perc90_DPP[31] = 52;
            perc90_DPP[32] = 53;
            perc90_DPP[33] = 54;
            perc90_DPP[34] = 56;
            perc90_DPP[35] = 57;
            perc90_DPP[36] = 58;
            perc90_DPP[37] = 59;
            perc90_DPP[38] = 60;
            perc90_DPP[39] = 61;
            perc90_DPP[40] = 62;

            for (int i = 0; i <= 40; i++)
            {
                perc10_DPP.Add(0);
            }
            perc10_DPP[16] = 12;
            perc10_DPP[17] = 15;
            perc10_DPP[18] = 17;
            perc10_DPP[19] = 20;
            perc10_DPP[20] = 22;
            perc10_DPP[21] = 24;
            perc10_DPP[22] = 26;
            perc10_DPP[23] = 29;
            perc10_DPP[24] = 31;
            perc10_DPP[25] = 33;
            perc10_DPP[26] = 35;
            perc10_DPP[27] = 37;
            perc10_DPP[28] = 39;
            perc10_DPP[29] = 40;
            perc10_DPP[30] = 42;
            perc10_DPP[31] = 44;
            perc10_DPP[32] = 45;
            perc10_DPP[33] = 46;
            perc10_DPP[34] = 48;
            perc10_DPP[35] = 49;
            perc10_DPP[36] = 50;
            perc10_DPP[37] = 51;
            perc10_DPP[38] = 52;
            perc10_DPP[39] = 53;
            perc10_DPP[40] = 54;

            for (int i = 0; i <= 40; i++)
            {
                perc5_DPP.Add(0);
            }
            perc5_DPP[16] = 12;
            perc5_DPP[17] = 15;
            perc5_DPP[18] = 17;
            perc5_DPP[19] = 20;
            perc5_DPP[20] = 22;
            perc5_DPP[21] = 24;
            perc5_DPP[22] = 26;
            perc5_DPP[23] = 29;
            perc5_DPP[24] = 31;
            perc5_DPP[25] = 33;
            perc5_DPP[26] = 35;
            perc5_DPP[27] = 37;
            perc5_DPP[28] = 39;
            perc5_DPP[29] = 40;
            perc5_DPP[30] = 42;
            perc5_DPP[31] = 44;
            perc5_DPP[32] = 45;
            perc5_DPP[33] = 46;
            perc5_DPP[34] = 48;
            perc5_DPP[35] = 49;
            perc5_DPP[36] = 50;
            perc5_DPP[37] = 51;
            perc5_DPP[38] = 52;
            perc5_DPP[39] = 53;
            perc5_DPP[40] = 54;
            #endregion

            #endregion

            #region доплерометрия
            var perc95_UterineArteries = new List<double>();
            var perc5_UterineArteries = new List<double>();

            var perc95_UmbilicalArteries = new List<double>();
            var perc5_UmbilicalArteries = new List<double>();

            var perc95_CelebralAttitude = new List<double>();
            var perc5_CelebralAttitude = new List<double>();

            #region UterineArteries
            for (int i = 0; i <= 40; i++)
            {
                perc95_UterineArteries.Add(0);
            }
            perc95_UterineArteries[11] = 2.7;
            perc95_UterineArteries[12] = 2.53;
            perc95_UterineArteries[13] = 2.38;
            perc95_UterineArteries[14] = 2.24;
            perc95_UterineArteries[15] = 2.11;
            perc95_UterineArteries[16] = 1.99;
            perc95_UterineArteries[17] = 1.88;
            perc95_UterineArteries[18] = 1.79;
            perc95_UterineArteries[19] = 1.70;
            perc95_UterineArteries[20] = 1.61;
            perc95_UterineArteries[21] = 1.54;
            perc95_UterineArteries[22] = 1.47;
            perc95_UterineArteries[23] = 1.41;
            perc95_UterineArteries[24] = 1.35;
            perc95_UterineArteries[25] = 1.30;
            perc95_UterineArteries[26] = 1.25;
            perc95_UterineArteries[27] = 1.21;
            perc95_UterineArteries[28] = 1.17;
            perc95_UterineArteries[29] = 1.13;
            perc95_UterineArteries[30] = 1.10;
            perc95_UterineArteries[31] = 1.06;
            perc95_UterineArteries[32] = 1.04;
            perc95_UterineArteries[33] = 1.01;
            perc95_UterineArteries[34] = 0.99;
            perc95_UterineArteries[35] = 0.97;
            perc95_UterineArteries[36] = 0.95;
            perc95_UterineArteries[37] = 0.94;
            perc95_UterineArteries[38] = 0.92;
            perc95_UterineArteries[39] = 0.91;
            perc95_UterineArteries[40] = 0.90;

            for (int i = 0; i <= 40; i++)
            {
                perc5_UterineArteries.Add(0);
            }
            perc5_UterineArteries[11] = 1.18;
            perc5_UterineArteries[12] = 1.11;
            perc5_UterineArteries[13] = 1.05;
            perc5_UterineArteries[14] = 0.99;
            perc5_UterineArteries[15] = 0.94;
            perc5_UterineArteries[16] = 0.89;
            perc5_UterineArteries[17] = 0.85;
            perc5_UterineArteries[18] = 0.81;
            perc5_UterineArteries[19] = 0.78;
            perc5_UterineArteries[20] = 0.74;
            perc5_UterineArteries[21] = 0.71;
            perc5_UterineArteries[22] = 0.69;
            perc5_UterineArteries[23] = 0.66;
            perc5_UterineArteries[24] = 0.64;
            perc5_UterineArteries[25] = 0.62;
            perc5_UterineArteries[26] = 0.60;
            perc5_UterineArteries[27] = 0.58;
            perc5_UterineArteries[28] = 0.56;
            perc5_UterineArteries[29] = 0.55;
            perc5_UterineArteries[30] = 0.54;
            perc5_UterineArteries[31] = 0.52;
            perc5_UterineArteries[32] = 0.51;
            perc5_UterineArteries[33] = 0.50;
            perc5_UterineArteries[34] = 0.50;
            perc5_UterineArteries[35] = 0.49;
            perc5_UterineArteries[36] = 0.48;
            perc5_UterineArteries[37] = 0.48;
            perc5_UterineArteries[38] = 0.47;
            perc5_UterineArteries[39] = 0.47;
            perc5_UterineArteries[40] = 0.47;
            #endregion

            #region UmbilicalArteries
            for (int i = 0; i <= 40; i++)
            {
                perc95_UmbilicalArteries.Add(0);
            }
            perc95_UmbilicalArteries[20] = 1.553;
            perc95_UmbilicalArteries[21] = 1.526;
            perc95_UmbilicalArteries[22] = 1.499;
            perc95_UmbilicalArteries[23] = 1.472;
            perc95_UmbilicalArteries[24] = 1.446;
            perc95_UmbilicalArteries[25] = 1.420;
            perc95_UmbilicalArteries[26] = 1.395;
            perc95_UmbilicalArteries[27] = 1.371;
            perc95_UmbilicalArteries[28] = 1.346;
            perc95_UmbilicalArteries[29] = 1.322;
            perc95_UmbilicalArteries[30] = 1.299;
            perc95_UmbilicalArteries[31] = 1.275;
            perc95_UmbilicalArteries[32] = 1.252;
            perc95_UmbilicalArteries[33] = 1.229;
            perc95_UmbilicalArteries[34] = 1.207;
            perc95_UmbilicalArteries[35] = 1.184;
            perc95_UmbilicalArteries[36] = 1.162;
            perc95_UmbilicalArteries[37] = 1.140;
            perc95_UmbilicalArteries[38] = 1.118;
            perc95_UmbilicalArteries[39] = 1.097;
            perc95_UmbilicalArteries[40] = 1.075;

            for (int i = 0; i <= 40; i++)
            {
                perc5_UmbilicalArteries.Add(0);
            }
            perc5_UmbilicalArteries[20] = 0.955;
            perc5_UmbilicalArteries[21] = 0.939;
            perc5_UmbilicalArteries[22] = 0.922;
            perc5_UmbilicalArteries[23] = 0.906;
            perc5_UmbilicalArteries[24] = 0.889;
            perc5_UmbilicalArteries[25] = 0.871;
            perc5_UmbilicalArteries[26] = 0.854;
            perc5_UmbilicalArteries[27] = 0.836;
            perc5_UmbilicalArteries[28] = 0.818;
            perc5_UmbilicalArteries[29] = 0.800;
            perc5_UmbilicalArteries[30] = 0.782;
            perc5_UmbilicalArteries[31] = 0.763;
            perc5_UmbilicalArteries[32] = 0.744;
            perc5_UmbilicalArteries[33] = 0.725;
            perc5_UmbilicalArteries[34] = 0.706;
            perc5_UmbilicalArteries[35] = 0.687;
            perc5_UmbilicalArteries[36] = 0.668;
            perc5_UmbilicalArteries[37] = 0.649;
            perc5_UmbilicalArteries[38] = 0.630;
            perc5_UmbilicalArteries[39] = 0.610;
            perc5_UmbilicalArteries[40] = 0.591;
            #endregion

            #region CelebralAttitude
            for (int i = 0; i <= 40; i++)
            {
                perc95_CelebralAttitude.Add(0);
            }

            perc95_CelebralAttitude[20] = 1.686;
            perc95_CelebralAttitude[21] = 1.780;
            perc95_CelebralAttitude[22] = 1.877;
            perc95_CelebralAttitude[23] = 1.977;
            perc95_CelebralAttitude[24] = 2.079;
            perc95_CelebralAttitude[25] = 2.180;
            perc95_CelebralAttitude[26] = 2.281;
            perc95_CelebralAttitude[27] = 2.378;
            perc95_CelebralAttitude[28] = 2.471;
            perc95_CelebralAttitude[29] = 2.557;
            perc95_CelebralAttitude[30] = 2.634;
            perc95_CelebralAttitude[31] = 2.700;
            perc95_CelebralAttitude[32] = 2.753;
            perc95_CelebralAttitude[33] = 2.790;
            perc95_CelebralAttitude[34] = 2.811;
            perc95_CelebralAttitude[35] = 2.813;
            perc95_CelebralAttitude[36] = 2.795;
            perc95_CelebralAttitude[37] = 2.756;
            perc95_CelebralAttitude[38] = 2.696;
            perc95_CelebralAttitude[39] = 2.615;
            perc95_CelebralAttitude[40] = 2.514;

            for (int i = 0; i <= 40; i++)
            {
                perc5_CelebralAttitude.Add(0);
            }
            perc5_CelebralAttitude[20] = 0.872;
            perc5_CelebralAttitude[21] = 0.934;
            perc5_CelebralAttitude[22] = 0.996;
            perc5_CelebralAttitude[23] = 1.059;
            perc5_CelebralAttitude[24] = 1.121;
            perc5_CelebralAttitude[25] = 1.181;
            perc5_CelebralAttitude[26] = 1.237;
            perc5_CelebralAttitude[27] = 1.290;
            perc5_CelebralAttitude[28] = 1.336;
            perc5_CelebralAttitude[29] = 1.375;
            perc5_CelebralAttitude[30] = 1.406;
            perc5_CelebralAttitude[31] = 1.426;
            perc5_CelebralAttitude[32] = 1.436;
            perc5_CelebralAttitude[33] = 1.434;
            perc5_CelebralAttitude[34] = 1.419;
            perc5_CelebralAttitude[35] = 1.392;
            perc5_CelebralAttitude[36] = 1.353;
            perc5_CelebralAttitude[37] = 1.301;
            perc5_CelebralAttitude[38] = 1.239;
            perc5_CelebralAttitude[39] = 1.167;
            perc5_CelebralAttitude[40] = 1.086;
            #endregion
            #endregion

            for (int i = 12; i <= 40; i++)
            {
                WeekRows.Add(
                    new PercentilTableRow
                    {
                        WeekNumber = i,
                        perc3_Mass = perc3_Mass[i],
                        perc5_Mass = perc5_Mass[i],
                        perc10_Mass = perc10_Mass[i],
                        perc90_Mass = perc90_Mass[i],
                        perc95_Mass = perc95_Mass[i],
                        perc97_Mass = perc97_Mass[i],
                        perc5_BPR = perc5_BPR[i],
                        perc10_BPR = perc10_BPR[i],
                        perc90_BPR = perc90_BPR[i],
                        perc5_DB = perc5_DB[i],
                        perc10_DB = perc10_DB[i],
                        perc90_DB = perc90_DB[i],
                        perc3_OZh = perc3_OZh[i],
                        perc5_OZh = perc5_OZh[i],
                        perc10_OZh = perc10_OZh[i],
                        perc90_OZh = perc90_OZh[i],
                        perc95_OZh = perc95_OZh[i],
                        perc97_OZh = perc97_OZh[i],
                        perc5_DPK = perc5_DPK[i],
                        perc10_DPK = perc10_DPK[i],
                        perc90_DPK = perc90_DPK[i],
                        perc5_DKG = perc5_DKG[i],
                        perc10_DKG = perc10_DKG[i],
                        perc90_DKG = perc90_DKG[i],
                        perc5_DPP = perc5_DPP[i],
                        perc10_DPP = perc10_DPP[i],
                        perc90_DPP = perc90_DPP[i],
                        perc95_UterineArteries = perc95_UterineArteries[i],
                        perc5_UterineArteries = perc5_UterineArteries[i],
                        perc95_UmbilicalArteries = perc95_UmbilicalArteries[i],
                        perc5_UmbilicalArteries = perc5_UmbilicalArteries[i],
                        perc95_CelebralAttitude = perc95_CelebralAttitude[i],
                        perc5_CelebralAttitude = perc5_CelebralAttitude[i],
                    }
                );
            }
        }

        public dynamic GetParameterFromPercentileTableByName(int numberOfWeek, string nameOfParameter)
        {
            var percentile = new { percentile5 = 0, percentile10 = 0, percentile90 = 0 };

            PercentilTableRow tableRow = WeekRows.FirstOrDefault(row => row.WeekNumber == numberOfWeek);
            if (tableRow != null)
            {
                var ourWeekValue = tableRow;
                switch (nameOfParameter)
                {
                    case "Mass": return new { percentile3 = ourWeekValue.perc3_Mass, percentile5 = ourWeekValue.perc5_Mass, percentile10 = ourWeekValue.perc10_Mass, percentile90 = ourWeekValue.perc90_Mass, percentile95 = ourWeekValue.perc95_Mass, percentile97 = ourWeekValue.perc97_Mass };
                    case "BPR": return new { percentile3 = -1, percentile5 = ourWeekValue.perc5_BPR, percentile10 = ourWeekValue.perc10_BPR, percentile90 = ourWeekValue.perc90_BPR, percentile95 = int.MaxValue, percentile97 = int.MaxValue };
                    case "DB": return new { percentile3 = -1, percentile5 = ourWeekValue.perc5_DB, percentile10 = ourWeekValue.perc10_DB, percentile90 = ourWeekValue.perc90_DB, percentile95 = int.MaxValue, percentile97 = int.MaxValue };
                    case "OZh": return new { percentile3 = ourWeekValue.perc3_OZh, percentile5 = ourWeekValue.perc5_OZh, percentile10 = ourWeekValue.perc10_OZh, percentile90 = ourWeekValue.perc90_OZh, percentile95 = ourWeekValue.perc95_OZh, percentile97 = ourWeekValue.perc97_OZh };
                    case "DPK": return new { percentile3 = -1, percentile5 = ourWeekValue.perc5_DPK, percentile10 = ourWeekValue.perc10_DPK, percentile90 = ourWeekValue.perc90_DPK, percentile95 = int.MaxValue, percentile97 = int.MaxValue };
                    case "DPP": return new { percentile3 = -1, percentile5 = ourWeekValue.perc5_DPP, percentile10 = ourWeekValue.perc10_DPP, percentile90 = ourWeekValue.perc90_DPP, percentile95 = int.MaxValue, percentile97 = int.MaxValue };
                    case "DKG": return new { percentile3 = -1, percentile5 = ourWeekValue.perc5_DKG, percentile10 = ourWeekValue.perc10_DKG, percentile90 = ourWeekValue.perc90_DKG, percentile95 = int.MaxValue, percentile97 = int.MaxValue };

                    case "Uterine": return new { percentile5 = ourWeekValue.perc5_UterineArteries, percentile95 = ourWeekValue.perc95_UterineArteries };
                    case "Umbilical": return new { percentile5 = ourWeekValue.perc5_UmbilicalArteries, percentile95 = ourWeekValue.perc95_UmbilicalArteries };
                    case "Celebral": return new { percentile5 = ourWeekValue.perc5_CelebralAttitude, percentile95 = ourWeekValue.perc95_CelebralAttitude };
                    default:
                        break;
                }
            }
            return new { percentile3 = 0, percentile5 = 0, percentile10 = 0, percentile90 = 0, percentile95 = 0, percentile97 = 0 };
        }

        public Dictionary<string, int[]> GetParameterFromPercentileTableByName(int numberOfWeek, params string[] namesOfParameters)
        {
            var valuesFromTable = new Dictionary<string, int[]>();
            foreach (var parameter in namesOfParameters) 
            {
                valuesFromTable.Add(parameter, GetParameterFromPercentileTableByName(numberOfWeek, parameter));
            }
            return valuesFromTable;
        }


        public int GetCorrespondingWeekByNameOfParameter(string nameOfParameter, double valueOfParameter)
        {
            PercentilTableRow tableRow;
            switch (nameOfParameter)
            {
                case "Mass":
                    tableRow = WeekRows.Where(week => week.perc10_Mass <= valueOfParameter && week.perc90_Mass >= valueOfParameter).FirstOrDefault();
                    break;
                case "BPR":
                    tableRow = WeekRows.Where(week => week.perc10_BPR <= valueOfParameter && week.perc90_BPR >= valueOfParameter).FirstOrDefault();
                    break;
                case "OZh":
                    tableRow = WeekRows.Where(week => week.perc10_OZh <= valueOfParameter && week.perc90_OZh >= valueOfParameter).FirstOrDefault();
                    break;
                case "DPK":
                    tableRow = WeekRows.Where(week => week.perc10_DPK <= valueOfParameter && week.perc90_DPK >= valueOfParameter).FirstOrDefault();
                    break;
                case "DB":
                    tableRow = WeekRows.Where(week => week.perc10_DB <= valueOfParameter && week.perc90_DB >= valueOfParameter).FirstOrDefault();
                    break;
                case "DPP":
                    tableRow = WeekRows.Where(week => week.perc10_DPP <= valueOfParameter && week.perc90_DPP >= valueOfParameter).FirstOrDefault();
                    break;
                case "DKG":
                    tableRow = WeekRows.Where(week => week.perc10_DKG <= valueOfParameter && week.perc90_DKG >= valueOfParameter).FirstOrDefault();
                    break;
                case "Uterine":
                    tableRow = WeekRows.Where(week => week.perc5_UterineArteries <= valueOfParameter && week.perc95_UterineArteries >= valueOfParameter).FirstOrDefault();
                    break;
                case "Umbilical":
                    tableRow = WeekRows.Where(week => week.perc5_UmbilicalArteries <= valueOfParameter && week.perc95_UmbilicalArteries >= valueOfParameter).FirstOrDefault();
                    break;
                case "Celebral":
                    tableRow = WeekRows.Where(week => week.perc5_CelebralAttitude <= valueOfParameter && week.perc95_CelebralAttitude >= valueOfParameter).FirstOrDefault();
                    break;
                default: return 0;
            }
            if (tableRow == null)
            {
                return 0;
            }
            return tableRow.WeekNumber;
        }
    }
}
