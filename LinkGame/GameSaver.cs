using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace LinkGame
{
    class GameSaver
    {
        Record[] record;

        internal Record[] Record
        {
            get { return record; }
            set { record = value; }
        }
        public GameSaver(){
            if (!LoadGame())
            {
                record = new Record[100];
                for (int i = 0; i < 100; i++) { 
                    Record r =new Record();
                    r.name = "CPU";
                    r.score = 1000 - i * 10;
                    r.level = 10 - i / 10;
                    r.time = "1999-9-9 12:12:12";
                    record[i] = r;
                }
                SaveGame();
            }
        }
        public int FindRecord(Record r) {
            int bestRank = 100;
            for (int i = 99; i >= 0; i--)
            {
                if (r.score > record[i].score)
                    bestRank--;
            }
            return bestRank;
        }
        public void AddRecord(Record r) {
            int bestRank = FindRecord(r);
            myCompareClass myCompare = new myCompareClass();
            if (bestRank < 100) {
                record[99] = r;
                Array.Sort(record, myCompare);
            }
            SaveGame();
        }

        public bool LoadGame()
        {
            if(!File.Exists("Save/save.dat"))
                return false;
            Stream stream = File.Open("Save/save.dat", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            record = (Record[])formatter.Deserialize(stream);
            stream.Close();
            return true;
        }
        public void SaveGame(){
            Stream stream = File.Open("Save/save.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, record);
            stream.Close();
        }
        public class myCompareClass : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                Record a = (Record)x;
                Record b = (Record)y;
                if (a.score == b.score)
                    return b.time.CompareTo(a.time);
                else
                    return b.score - a.score;
            }
        }
    }

    [Serializable]
    struct Record {
        public String name;
        public int score;
        public int level;
        public String time;
    }
}
