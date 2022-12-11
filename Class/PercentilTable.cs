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
        public Dictionary<int, WeekValues> Weeks = new Dictionary<int,WeekValues>();
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
            List<int> MaxMass = new List<int>();
            List<int> MinMass = new List<int>();
            List<int> MaxBPR = new List<int>();
            List<int> MinBPR = new List<int>();
            List<int> MaxDB = new List<int>();
            List<int> MinDB = new List<int>();
            List<int> MaxOZh = new List<int>();
            List<int> MinOZh = new List<int>();
            List<int> MaxDGK = new List<int>();
            List<int> MinDGK = new List<int>();
            for (int i = 0; i <= 40; i++)
            {
                MaxMass.Add(0);
            }
            MaxMass[12] = 25;
            MaxMass[13] = 37;
            MaxMass[14] = 60;
            MaxMass[15] = 88;
            MaxMass[16] = 130;
            MaxMass[17] = 180;
            MaxMass[18] = 230;
            MaxMass[19] = 290;
            MaxMass[20] = 382;
            MaxMass[21] = 458;
            MaxMass[22] = 552;
            MaxMass[23] = 630;
            MaxMass[24] = 754;
            MaxMass[25] = 870;
            MaxMass[26] = 990;
            MaxMass[27] = 1200;
            MaxMass[28] = 1350;
            MaxMass[29] = 1500;
            MaxMass[30] = 1690;
            MaxMass[31] = 1800;
            MaxMass[32] = 2000;
            MaxMass[33] = 2200;
            MaxMass[34] = 2320;
            MaxMass[35] = 2600;
            MaxMass[36] = 2700;
            MaxMass[37] = 2885;
            MaxMass[38] = 3000;
            MaxMass[39] = 3223;
            MaxMass[40] = 3400;

            for (int i = 0; i <= 40; i++)
            {
                MaxBPR.Add(0);
            }
            MaxBPR[12] = 24;
            MaxBPR[13] = 27;
            MaxBPR[14] = 30;
            MaxBPR[15] = 33;
            MaxBPR[16] = 37;
            MaxBPR[17] = 41;
            MaxBPR[18] = 47;
            MaxBPR[19] = 49;
            MaxBPR[20] = 53;
            MaxBPR[21] = 56;
            MaxBPR[22] = 60;
            MaxBPR[23] = 64;
            MaxBPR[24] = 67;
            MaxBPR[25] = 70;
            MaxBPR[26] = 73;
            MaxBPR[27] = 76;
            MaxBPR[28] = 79;
            MaxBPR[29] = 82;
            MaxBPR[30] = 85;
            MaxBPR[31] = 87;
            MaxBPR[32] = 89;
            MaxBPR[33] = 91;
            MaxBPR[34] = 93;
            MaxBPR[35] = 95;
            MaxBPR[36] = 97;
            MaxBPR[37] = 98;
            MaxBPR[38] = 100;
            MaxBPR[39] = 102;
            MaxBPR[40] = 103;
            for (int i = 0; i <= 40; i++)
            {
                MaxDB.Add(0);
            }
            MaxDB[12] = 11;
            MaxDB[13] = 14;
            MaxDB[14] = 19;
            MaxDB[15] = 20;
            MaxDB[16] = 23;
            MaxDB[17] = 28;
            MaxDB[18] = 31;
            MaxDB[19] = 34;
            MaxDB[20] = 37;
            MaxDB[21] = 39;
            MaxDB[22] = 43;
            MaxDB[23] = 46;
            MaxDB[24] = 50;
            MaxDB[25] = 50;
            MaxDB[26] = 58;
            MaxDB[27] = 60;
            MaxDB[28] = 61;
            MaxDB[29] = 62;
            MaxDB[30] = 62;
            MaxDB[31] = 65;
            MaxDB[32] = 66;
            MaxDB[33] = 69;
            MaxDB[34] = 69;
            MaxDB[35] = 71;
            MaxDB[36] = 72;
            MaxDB[37] = 74;
            MaxDB[38] = 76;
            MaxDB[39] = 78;
            MaxDB[40] = 80;
            for (int i = 0; i <= 40; i++)
            {
                MaxOZh.Add(0);
            }
            MaxOZh[12] = 71;
            MaxOZh[13] = 79;
            MaxOZh[14] = 91;
            MaxOZh[15] = 103;
            MaxOZh[16] = 115;
            MaxOZh[17] = 130;
            MaxOZh[18] = 144;
            MaxOZh[19] = 154;
            MaxOZh[20] = 163;
            MaxOZh[21] = 177;
            MaxOZh[22] = 190;
            MaxOZh[23] = 201;
            MaxOZh[24] = 223;
            MaxOZh[25] = 228;
            MaxOZh[26] = 240;
            MaxOZh[27] = 253;
            MaxOZh[28] = 264;
            MaxOZh[29] = 277;
            MaxOZh[30] = 290;
            MaxOZh[31] = 300;
            MaxOZh[32] = 314;
            MaxOZh[33] = 334;
            MaxOZh[34] = 336;
            MaxOZh[35] = 344;
            MaxOZh[36] = 353;
            MaxOZh[37] = 360;
            MaxOZh[38] = 368;
            MaxOZh[39] = 375;
            MaxOZh[40] = 380;
            for (int i = 0; i <= 40; i++)
            {
                MaxDGK.Add(0);
            }
            MaxDGK[12] = 25;
            MaxDGK[13] = 26;
            MaxDGK[14] = 28;
            MaxDGK[15] = 30;
            MaxDGK[16] = 36;
            MaxDGK[17] = 40;
            MaxDGK[18] = 43;
            MaxDGK[19] = 46;
            MaxDGK[20] = 50;
            MaxDGK[21] = 52;
            MaxDGK[22] = 55;
            MaxDGK[23] = 58;
            MaxDGK[24] = 62;
            MaxDGK[25] = 64;
            MaxDGK[26] = 66;
            MaxDGK[27] = 71;
            MaxDGK[28] = 75;
            MaxDGK[29] = 78;
            MaxDGK[30] = 81;
            MaxDGK[31] = 83;
            MaxDGK[32] = 85;
            MaxDGK[33] = 87;
            MaxDGK[34] = 90;
            MaxDGK[35] = 93;
            MaxDGK[36] = 96;
            MaxDGK[37] = 99;
            MaxDGK[38] = 101;
            MaxDGK[39] = 103;
            MaxDGK[40] = 105;
            for (int i = 0; i <= 40; i++)
            {
                MinMass.Add(0);
            }
            MinMass[12] = 13;
            MinMass[13] = 25;
            MinMass[14] = 37;
            MinMass[15] = 60;
            MinMass[16] = 88;
            MinMass[17] = 130;
            MinMass[18] = 180;
            MinMass[19] = 230;
            MinMass[20] = 290;
            MinMass[21] = 382;
            MinMass[22] = 458;
            MinMass[23] = 552;
            MinMass[24] = 630;
            MinMass[25] = 754;
            MinMass[26] = 870;
            MinMass[27] = 990;
            MinMass[28] = 1200;
            MinMass[29] = 1350;
            MinMass[30] = 1500;
            MinMass[31] = 1690;
            MinMass[32] = 1800;
            MinMass[33] = 2000;
            MinMass[34] = 2200;
            MinMass[35] = 2320;
            MinMass[36] = 2600;
            MinMass[37] = 2700;
            MinMass[38] = 2885;
            MinMass[39] = 3000;
            MinMass[40] = 3223;
            for (int i = 0; i <= 40; i++)
            {
                MinBPR.Add(0);
            }
            MinBPR[12] = 22;
            MinBPR[13] = 25;
            MinBPR[14] = 28;
            MinBPR[15] = 31;
            MinBPR[16] = 34;
            MinBPR[17] = 38;
            MinBPR[18] = 42;
            MinBPR[19] = 48;
            MinBPR[20] = 50;
            MinBPR[21] = 54;
            MinBPR[22] = 57;
            MinBPR[23] = 61;
            MinBPR[24] = 65;
            MinBPR[25] = 68;
            MinBPR[26] = 71;
            MinBPR[27] = 75;
            MinBPR[28] = 77;
            MinBPR[29] = 80;
            MinBPR[30] = 83;
            MinBPR[31] = 86;
            MinBPR[32] = 88;
            MinBPR[33] = 90;
            MinBPR[34] = 92;
            MinBPR[35] = 94;
            MinBPR[36] = 96;
            MinBPR[37] = 98;
            MinBPR[38] = 99;
            MinBPR[39] = 101;
            MinBPR[40] = 103;
            for (int i = 0; i <= 40; i++)
            {
                MinDB.Add(0);
            }
            MinDB[12] = 7;
            MinDB[13] = 10;
            MinDB[14] = 13;
            MinDB[15] = 15;
            MinDB[16] = 17;
            MinDB[17] = 20;
            MinDB[18] = 23;
            MinDB[19] = 26;
            MinDB[20] = 29;
            MinDB[21] = 35;
            MinDB[22] = 37;
            MinDB[23] = 40;
            MinDB[24] = 42;
            MinDB[25] = 46;
            MinDB[26] = 49;
            MinDB[27] = 53;
            MinDB[28] = 54;
            MinDB[29] = 55;
            MinDB[30] = 56;
            MinDB[31] = 59;
            MinDB[32] = 60;
            MinDB[33] = 63;
            MinDB[34] = 64;
            MinDB[35] = 65;
            MinDB[36] = 67;
            MinDB[37] = 68;
            MinDB[38] = 70;
            MinDB[39] = 72;
            MinDB[40] = 74;
            for (int i = 0; i <= 40; i++)
            {
                MinOZh.Add(0);
            }
            MinOZh[12] = 50;
            MinOZh[13] = 58;
            MinOZh[14] = 66;
            MinOZh[15] = 85;
            MinOZh[16] = 88;
            MinOZh[17] = 93;
            MinOZh[18] = 105;
            MinOZh[19] = 114;
            MinOZh[20] = 125;
            MinOZh[21] = 137;
            MinOZh[22] = 148;
            MinOZh[23] = 160;
            MinOZh[24] = 173;
            MinOZh[25] = 183;
            MinOZh[26] = 194;
            MinOZh[27] = 206;
            MinOZh[28] = 217;
            MinOZh[29] = 228;
            MinOZh[30] = 238;
            MinOZh[31] = 247;
            MinOZh[32] = 258;
            MinOZh[33] = 267;
            MinOZh[34] = 276;
            MinOZh[35] = 285;
            MinOZh[36] = 292;
            MinOZh[37] = 300;
            MinOZh[38] = 304;
            MinOZh[39] = 310;
            MinOZh[40] = 313;
            for (int i = 0; i <= 40; i++)
            {
                MinDGK.Add(0);
            }
            MinDGK[12] = 21;
            MinDGK[13] = 22;
            MinDGK[14] = 24;
            MinDGK[15] = 26;
            MinDGK[16] = 28;
            MinDGK[17] = 36;
            MinDGK[18] = 39;
            MinDGK[19] = 42;
            MinDGK[20] = 46;
            MinDGK[21] = 48;
            MinDGK[22] = 51;
            MinDGK[23] = 54;
            MinDGK[24] = 57;
            MinDGK[25] = 60;
            MinDGK[26] = 62;
            MinDGK[27] = 67;
            MinDGK[28] = 71;
            MinDGK[29] = 74;
            MinDGK[30] = 77;
            MinDGK[31] = 79;
            MinDGK[32] = 81;
            MinDGK[33] = 83;
            MinDGK[34] = 86;
            MinDGK[35] = 89;
            MinDGK[36] = 92;
            MinDGK[37] = 95;
            MinDGK[38] = 97;
            MinDGK[39] = 99;
            MinDGK[40] = 101;
            for (int i = 12; i <= 40; i++)
            {
                Weeks.Add(i, new WeekValues(i,MinMass[i],MaxMass[i],MinBPR[i],MaxBPR[i],MinDB[i],MaxDB[i],MinOZh[i],MaxOZh[i],MinDGK[i],MaxDGK[i]));
            }
        }
    }
}
