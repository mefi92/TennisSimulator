using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulator
{
    public abstract class TennisRules
    {
        public bool IsCompleted { get; protected set; }
        public string? Winner { get; protected set; }
        public abstract void ScorePointForPlayer(string player);
    }
}
