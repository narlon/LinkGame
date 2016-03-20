using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace LinkGame
{
    class Sounder
    {
        public Sounder(String s) {
            SoundPlayer sp = new SoundPlayer(String.Format("Sound/{0}.wav",s));
            sp.Play();
        }
    }
}
