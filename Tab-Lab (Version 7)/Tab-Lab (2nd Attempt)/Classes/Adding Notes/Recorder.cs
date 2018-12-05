using System;
using System.Collections;
using System.IO;



    /// <summary>
    /// Summary description for Recorde.
    /// </summary>
    public class Recorder
    {
        Hashtable FreqMap = new Hashtable();
        Hashtable TimingMap = new Hashtable();
        string Recording = "";

        public Recorder()
        {
            //
            // TODO: Add constructor logic here
            //
            ReadFreqMap();

        }

        public void ReadFreqMap()
        {
            for (int i = 0; i < freqtable.GetLength(0); i++)
            {
                FreqMap[(int)freqtable[i, 0]] = freqtable[i, 1];
            }

            for (int i = 0; i < timingtable.GetLength(0); i++)
            {
                TimingMap[(int)timingtable[i, 0]] = timingtable[i, 1];
            }
        }

        object[,] timingtable = {
        {1, "x"},
        {2, "e"},
        {4,  ""},
        {8, "a"},
        {12, "t"},
        {16, "w"}
                                };



        object[,] freqtable = {
        //{ 8000, "C"},
        //{ 8500, "Cs"},
        //{ 8500, "Df"},
        //{ 9000, "D"},
        //{ 9500, "Ds"},
        //{ 9500, "Ef"},
        //{10000, "E" },
        //{10700, "F" },
        //{11300, "Fs" },
        //{11300, "Gf" },
        //{12000, "G" },
        //{12800, "Gs"},
        //{12800, "Af"},
        //{13400, "A"},
        //{14300, "As"},
        //{14300, "Bf"},
        //{15200, "B"},
        //{16300, "Ch"},
        //{17300, "Chs"},
        //{17300, "Dhf"},
        //{18000, "Dh"},
        //{19000, "Dhs"},
        //{19000, "Ehf"},
        //{20000, "Eh"},
        //{21200, "Fh"},
        //{22300, "Ghf"},
        //{22300, "Fhs"}
        { 8000, "C"},
        { 8500, "Cs"},
        { 8500, "Df"},
        { 9000, "D"},
        { 9500, "Ds"},
        { 9500, "Ef"},
        {10000, "E" },
        {10700, "F" },
        {11300, "Fs" },
        {11300, "Gf" },
        {12000, "G" },
        {12800, "Gs"},
        {12800, "Af"},
        {55, "A"},
        {58, "As"},
        {58, "Bf"},
        {61, "B"},
        {65, "Ch"},
        {69, "Chs"},
        {69, "Dhf"},
        {73, "Dh"},
        {77, "Dhs"},
        {77, "Ehf"},
        {82, "Eh"},
        {87, "Fh"},
        {92, "Ghf"},
        {92, "Fhs"}
                              };



        int ApproxTiming = 0;
        public string GetTiming(int timing)
        {
            string timingCode = "w";
            ApproxTiming = 16;

            if (timing >= 16)
            {
                timingCode = "w";
                ApproxTiming = 16;
                return timingCode;
            }

            if (timing <= 1)
            {
                timingCode = "x";
                ApproxTiming = 1;
                return timingCode;
            }

            // may need to interpolate
            for (int i = timing; i < 16; i++)
            {
                if (TimingMap[i] != null)
                {
                    ApproxTiming = i;
                    return (string)TimingMap[i];
                }
            }


            return timingCode;
        }

        public void SaveRecording(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Title:" + filename.Substring(filename.LastIndexOf("\\") + 1, filename.LastIndexOf(".") - (filename.LastIndexOf("\\") + 1)));
            sw.WriteLine("Signature1:4");
            sw.WriteLine("Signature2:4");
            sw.WriteLine(Recording);
            sw.Close();
            fs.Close();
        }

        public void Clear()
        {
            this.Recording = "";
        }

        int TotalMeasure = 0;
        int TotalMeasuresOnStaff = 0;

        public string AddNextNote(int nextNoteFrequency, int timing)
        {
            string theNote = (string)FreqMap[nextNoteFrequency];
            string timingCode = (string)GetTiming(timing);
            Recording += theNote + timingCode;
            TotalMeasure += ApproxTiming;
            if (TotalMeasure >= 16)
            {
                Recording += "/"; // add a measure, reset measure counter
                TotalMeasure = 0;
                TotalMeasuresOnStaff++; // track staff line
                if (TotalMeasuresOnStaff > 4)
                {
                    Recording += "\n";  // add a line feed
                    TotalMeasuresOnStaff = 0; // reset staff counter
                }
            }
            else
                Recording += " ";

            return Recording;
        }
    }
