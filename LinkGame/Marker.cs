using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGame
{
    class Marker
    {
        private int mark = 0;

        public int Mark
        {
            get { return mark; }
        }
        private int comboCount = 0;
        public Marker() { 
        }
        public void Add(bool isCombo,int lType){
            int plus = 0;
            if (!isCombo)
            {
                plus = 40;
                if (!isCombo)
                    comboCount = 0;
            }
            else {
                plus = (comboCount++ / 5) * 8 + 40;
            }
            plus = CalBonus(mark,plus,lType);
            mark += plus;
        }

        private int CalBonus(int m,int s,int ltype)
        {
            switch (ltype) {
                case 21: return s + 100; 
                case 22: return s + 150; 
                case 23: return s * 3;
                case 24: return s * 5;
                case 27: return s + m / 20;
                case 28: return s + m / 10; 
                default: break;
            }
            return s;
        }
    }
}
