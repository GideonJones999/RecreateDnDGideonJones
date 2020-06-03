using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreateDND
{
    class NpcStats
    {
        bool intimidated, seduced, ally;
        string npcClass, npcRace;
        //add other statuses to this vvv
        public NpcStats(
            bool intimidated = false, 
            bool seduced = false, 
            bool ally = false,
            string npcClass = "None",
            string npcRace = "Unknown",
            string name = "Unknown"
            )
        {
            this.intimidated = intimidated;
            this.seduced = seduced;
            this.ally = ally;
            this.npcClass = npcClass;
            this.npcRace = npcRace;

        }
        

        private NpcStats npcStats = new NpcStats();
        public NpcStats getNpcStats()
        {
            return npcStats;
        }
    }
}
