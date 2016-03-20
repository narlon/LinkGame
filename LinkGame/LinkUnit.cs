using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGame
{
    class LinkUnit
    {
        public int value;
        public int depth;
        public int distance;
        public int father;
        public LinkUnit(int value,int depth,int distance,int father) {
            this.value = value;
            this.depth = depth;
            this.distance = distance;
            this.father = father;
        }
    }
}
