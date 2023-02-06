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
        public Dictionary<int, WeekValues> Weeks = new Dictionary<int, WeekValues>();
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
            List<int> perc90_Mass = new List<int>();
            List<int> perc10_Mass = new List<int>();
            List<int> perc5_Mass = new List<int>();

            List<int> perc90_BPR = new List<int>();
            List<int> perc10_BPR = new List<int>();
            List<int> perc5_BPR = new List<int>();

            List<int> perc90_DB = new List<int>();
            List<int> perc10_DB = new List<int>();
            List<int> perc5_DB = new List<int>();

            List<int> perc90_OZh = new List<int>();
            List<int> perc10_OZh = new List<int>();
            List<int> perc5_OZh = new List<int>();

            List<int> perc90_DPK = new List<int>();
            List<int> perc10_DPK = new List<int>();
            List<int> perc5_DPK = new List<int>();

            List<int> perc90_KTR = new List<int>();
            List<int> perc10_KTR = new List<int>();
            List<int> perc5_KTR = new List<int>();

            List<int> perc90_DPP = new List<int>();
            List<int> perc10_DPP = new List<int>();
            List<int> perc5_DPP = new List<int>();

            List<int> perc90_DKG = new List<int>();
            List<int> perc10_DKG = new List<int>();
            List<int> perc5_DKG = new List<int>();

            #region Mass
            for (int i = 0; i <= 40; i++)
            {
                perc90_Mass.Add(0);
            }
            perc90_Mass[12] = 25;
            perc90_Mass[13] = 37;
            perc90_Mass[14] = 60;
            perc90_Mass[15] = 88;
            perc90_Mass[16] = 130;
            perc90_Mass[17] = 180;
            perc90_Mass[18] = 230;
            perc90_Mass[19] = 290;
            perc90_Mass[20] = 382;
            perc90_Mass[21] = 458;
            perc90_Mass[22] = 552;
            perc90_Mass[23] = 630;
            perc90_Mass[24] = 754;
            perc90_Mass[25] = 870;
            perc90_Mass[26] = 990;
            perc90_Mass[27] = 1200;
            perc90_Mass[28] = 1350;
            perc90_Mass[29] = 1500;
            perc90_Mass[30] = 1690;
            perc90_Mass[31] = 1800;
            perc90_Mass[32] = 2000;
            perc90_Mass[33] = 2200;
            perc90_Mass[34] = 2320;
            perc90_Mass[35] = 2600;
            perc90_Mass[36] = 2700;
            perc90_Mass[37] = 2885;
            perc90_Mass[38] = 3000;
            perc90_Mass[39] = 3223;
            perc90_Mass[40] = 3400;

            for (int i = 0; i <= 40; i++)
            {
                perc10_Mass.Add(0);
            }
            perc10_Mass[12] = 13;
            perc10_Mass[13] = 25;
            perc10_Mass[14] = 37;
            perc10_Mass[15] = 60;
            perc10_Mass[16] = 88;
            perc10_Mass[17] = 130;
            perc10_Mass[18] = 180;
            perc10_Mass[19] = 230;
            perc10_Mass[20] = 290;
            perc10_Mass[21] = 382;
            perc10_Mass[22] = 458;
            perc10_Mass[23] = 552;
            perc10_Mass[24] = 630;
            perc10_Mass[25] = 754;
            perc10_Mass[26] = 870;
            perc10_Mass[27] = 990;
            perc10_Mass[28] = 1200;
            perc10_Mass[29] = 1350;
            perc10_Mass[30] = 1500;
            perc10_Mass[31] = 1690;
            perc10_Mass[32] = 1800;
            perc10_Mass[33] = 2000;
            perc10_Mass[34] = 2200;
            perc10_Mass[35] = 2320;
            perc10_Mass[36] = 2600;
            perc10_Mass[37] = 2700;
            perc10_Mass[38] = 2885;
            perc10_Mass[39] = 3000;
            perc10_Mass[40] = 3223;

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
            #endregion

            #region BPR
            for (int i = 0; i <= 40; i++)
            {
                perc90_BPR.Add(0);
            }
            perc90_BPR[12] = 24;
            perc90_BPR[13] = 27;
            perc90_BPR[14] = 30;
            perc90_BPR[15] = 33;
            perc90_BPR[16] = 37;
            perc90_BPR[17] = 41;
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
            perc10_BPR[12] = 22;
            perc10_BPR[13] = 25;
            perc10_BPR[14] = 28;
            perc10_BPR[15] = 31;
            perc10_BPR[16] = 34;
            perc10_BPR[17] = 38;
            perc10_BPR[18] = 42;
            perc10_BPR[19] = 48;
            perc10_BPR[20] = 50;
            perc10_BPR[21] = 54;
            perc10_BPR[22] = 57;
            perc10_BPR[23] = 61;
            perc10_BPR[24] = 65;
            perc10_BPR[25] = 68;
            perc10_BPR[26] = 71;
            perc10_BPR[27] = 75;
            perc10_BPR[28] = 77;
            perc10_BPR[29] = 80;
            perc10_BPR[30] = 83;
            perc10_BPR[31] = 86;
            perc10_BPR[32] = 88;
            perc10_BPR[33] = 90;
            perc10_BPR[34] = 92;
            perc10_BPR[35] = 94;
            perc10_BPR[36] = 96;
            perc10_BPR[37] = 98;
            perc10_BPR[38] = 99;
            perc10_BPR[39] = 101;
            perc10_BPR[40] = 103;

            for (int i = 0; i <= 40; i++)
            {
                perc5_BPR.Add(0);
            }

            perc5_BPR[16] = 31;
            perc5_BPR[17] = 34;
            perc5_BPR[18] = 37;
            perc5_BPR[19] = 41;
            perc5_BPR[20] = 43;
            perc5_BPR[21] = 46;
            perc5_BPR[22] = 48;
            perc5_BPR[23] = 52;
            perc5_BPR[24] = 55;
            perc5_BPR[25] = 58;
            perc5_BPR[26] = 61;
            perc5_BPR[27] = 64;
            perc5_BPR[28] = 67;
            perc5_BPR[29] = 70;
            perc5_BPR[30] = 71;
            perc5_BPR[31] = 73;
            perc5_BPR[32] = 75;
            perc5_BPR[33] = 77;
            perc5_BPR[34] = 79;
            perc5_BPR[35] = 81;
            perc5_BPR[36] = 83;
            perc5_BPR[37] = 85;
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
            perc5_DB[16] = 17;
            perc5_DB[17] = 20;
            perc5_DB[18] = 23;
            perc5_DB[19] = 26;
            perc5_DB[20] = 29;
            perc5_DB[21] = 35;
            perc5_DB[22] = 37;
            perc5_DB[23] = 40;
            perc5_DB[24] = 42;
            perc5_DB[25] = 46;
            perc5_DB[26] = 49;
            perc5_DB[27] = 53;
            perc5_DB[28] = 54;
            perc5_DB[29] = 55;
            perc5_DB[30] = 56;
            perc5_DB[31] = 59;
            perc5_DB[32] = 60;
            perc5_DB[33] = 63;
            perc5_DB[34] = 64;
            perc5_DB[35] = 65;
            perc5_DB[36] = 67;
            perc5_DB[37] = 68;
            perc5_DB[38] = 70;
            perc5_DB[39] = 72;
            perc5_DB[40] = 74;
            #endregion

            #region Ozh
            for (int i = 0; i <= 40; i++)
            {
                perc90_OZh.Add(0);
            }
            perc90_OZh[12] = 71;
            perc90_OZh[13] = 79;
            perc90_OZh[14] = 91;
            perc90_OZh[15] = 103;
            perc90_OZh[16] = 115;
            perc90_OZh[17] = 130;
            perc90_OZh[18] = 144;
            perc90_OZh[19] = 154;
            perc90_OZh[20] = 163;
            perc90_OZh[21] = 177;
            perc90_OZh[22] = 190;
            perc90_OZh[23] = 201;
            perc90_OZh[24] = 223;
            perc90_OZh[25] = 228;
            perc90_OZh[26] = 240;
            perc90_OZh[27] = 253;
            perc90_OZh[28] = 264;
            perc90_OZh[29] = 277;
            perc90_OZh[30] = 290;
            perc90_OZh[31] = 300;
            perc90_OZh[32] = 314;
            perc90_OZh[33] = 334;
            perc90_OZh[34] = 336;
            perc90_OZh[35] = 344;
            perc90_OZh[36] = 353;
            perc90_OZh[37] = 360;
            perc90_OZh[38] = 368;
            perc90_OZh[39] = 375;
            perc90_OZh[40] = 380;

            for (int i = 0; i <= 40; i++)
            {
                perc10_OZh.Add(0);
            }
            perc10_OZh[12] = 50;
            perc10_OZh[13] = 58;
            perc10_OZh[14] = 66;
            perc10_OZh[15] = 85;
            perc10_OZh[16] = 88;
            perc10_OZh[17] = 93;
            perc10_OZh[18] = 105;
            perc10_OZh[19] = 114;
            perc10_OZh[20] = 125;
            perc10_OZh[21] = 137;
            perc10_OZh[22] = 148;
            perc10_OZh[23] = 160;
            perc10_OZh[24] = 173;
            perc10_OZh[25] = 183;
            perc10_OZh[26] = 194;
            perc10_OZh[27] = 206;
            perc10_OZh[28] = 217;
            perc10_OZh[29] = 228;
            perc10_OZh[30] = 238;
            perc10_OZh[31] = 247;
            perc10_OZh[32] = 258;
            perc10_OZh[33] = 267;
            perc10_OZh[34] = 276;
            perc10_OZh[35] = 285;
            perc10_OZh[36] = 292;
            perc10_OZh[37] = 300;
            perc10_OZh[38] = 304;
            perc10_OZh[39] = 310;
            perc10_OZh[40] = 313;
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


            for (int i = 0; i <= 40; i++)
            {
                perc10_DKG.Add(0);
            }


            for (int i = 0; i <= 40; i++)
            {
                perc5_DKG.Add(0);
            }
            perc5_DKG[16] = 15;
            perc5_DKG[17] = 17;
            perc5_DKG[18] = 20;
            perc5_DKG[19] = 23;
            perc5_DKG[20] = 26;
            perc5_DKG[21] = 29;
            perc5_DKG[22] = 31;
            perc5_DKG[23] = 34;
            perc5_DKG[24] = 36;
            perc5_DKG[25] = 38;
            perc5_DKG[26] = 41;
            perc5_DKG[27] = 43;
            perc5_DKG[28] = 45;
            perc5_DKG[29] = 47;
            perc5_DKG[30] = 49;
            perc5_DKG[31] = 50;
            perc5_DKG[32] = 51;
            perc5_DKG[33] = 53;
            perc5_DKG[34] = 55;
            perc5_DKG[35] = 56;
            perc5_DKG[36] = 57;
            perc5_DKG[37] = 59;
            perc5_DKG[38] = 60;
            perc5_DKG[39] = 61;
            perc5_DKG[40] = 62;
            #endregion

            #region DPP
            for (int i = 0; i <= 40; i++)
            {
                perc90_DPP.Add(0);
            }


            for (int i = 0; i <= 40; i++)
            {
                perc10_DPP.Add(0);
            }


            for (int i = 0; i <= 40; i++)
            {
                perc5_DPP.Add(0);
            }
            #endregion

            for (int i = 12; i <= 40; i++)
            {
                Weeks.Add(
                    i,
                    new WeekValues{
                        WeekNumber = i,
                        perc5_Mass = perc5_Mass[i],
                        perc10_Mass = perc10_Mass[i],
                        perc90_Mass = perc90_Mass[i],
                        perc5_BPR = perc5_BPR[i],
                        perc10_BPR = perc10_BPR[i],
                        perc90_BPR = perc90_BPR[i],
                        perc5_DB = perc5_DB[i],
                        perc10_DB = perc10_DB[i],
                        perc90_DB = perc90_DB[i],
                        perc5_OZh = perc5_OZh[i],
                        perc10_OZh = perc10_OZh[i],
                        perc90_OZh = perc90_OZh[i],
                        perc5_DPK = perc5_DPK[i],
                        perc10_DPK = perc10_DPK[i],
                        perc90_DPK = perc90_DPK[i],
                        perc5_DKG = perc5_DKG[i],
                        perc10_DKG = perc10_DKG[i],
                        perc90_DKG = perc90_DKG[i],
                        perc5_DPP = perc5_DPP[i],
                        perc10_DPP = perc10_DPP[i],
                        perc90_DPP = perc90_DPP[i]
                    }
                );
            }
        }

        public dynamic GetParameterFromPercentileTableByName(int numberOfWeek, string nameOfParameter)
        {
            var percentile = new { percentile5 = 0, percentile10 = 0, percentile90 = 0 };

            WeekValues ourWeek;
            if (Weeks.ContainsKey(numberOfWeek))
            {
                ourWeek = Weeks[numberOfWeek];
                switch (nameOfParameter)
                {
                    case "Mass": return new { percentile5 = ourWeek.perc5_Mass, percentile10 = ourWeek.perc10_Mass, percentile90 = ourWeek.perc90_Mass };
                    case "BPR": return new { percentile5 = ourWeek.perc5_BPR, percentile10 = ourWeek.perc10_BPR, percentile90 = ourWeek.perc90_BPR };
                    case "DB": return new { percentile5 = ourWeek.perc5_DB, percentile10 = ourWeek.perc10_DB, percentile90 = ourWeek.perc90_DB };
                    case "OZh": return new { percentile5 = ourWeek.perc5_OZh, percentile10 = ourWeek.perc10_OZh, percentile90 = ourWeek.perc90_OZh };
                    case "DPK": return new { percentile5 = ourWeek.perc5_DPK, percentile10 = ourWeek.perc10_DPK, percentile90 = ourWeek.perc90_DPK };
                    default:
                        return new { percentile5 = 0, percentile10 = 0, percentile90 = 0 };
                }
            }
            else
            {
                return new { percentile5 = 0, percentile10 = 0, percentile90 = 0 };
            }      
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
            KeyValuePair<int, WeekValues>? ourWeek;
            switch (nameOfParameter)
            {
                case "Mass":
                    ourWeek = Weeks.Where(week => week.Value.perc10_Mass <= valueOfParameter && week.Value.perc90_Mass >= valueOfParameter).FirstOrDefault();
                    break;
                case "BPR":
                    ourWeek = Weeks.Where(week => week.Value.perc10_BPR <= valueOfParameter && week.Value.perc90_BPR >= valueOfParameter).FirstOrDefault();
                    break;
                case "OZh":
                    ourWeek = Weeks.Where(week => week.Value.perc10_OZh <= valueOfParameter && week.Value.perc90_OZh >= valueOfParameter).FirstOrDefault();
                    break;
                case "DPK":
                    ourWeek = Weeks.Where(week => week.Value.perc10_DPK <= valueOfParameter && week.Value.perc90_DPK >= valueOfParameter).FirstOrDefault();
                    break;
                case "DB":
                    ourWeek = Weeks.Where(week => week.Value.perc10_DB <= valueOfParameter && week.Value.perc90_DB >= valueOfParameter).FirstOrDefault();
                    break;
                default: return 0;
            }
            if (ourWeek == null)
            {
                return 0;
            }
            return ourWeek.Value.Key;
        }
    }
}
