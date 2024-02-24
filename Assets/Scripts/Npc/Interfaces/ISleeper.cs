using UnityEngine;

namespace Npc.Interfaces
{
    public interface ISleeper
    {
        void DoSleep();
        Vector3 GetSleepPosition();
    }
}