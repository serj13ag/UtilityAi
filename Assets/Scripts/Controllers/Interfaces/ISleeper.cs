using UnityEngine;

namespace Controllers.Interfaces
{
    public interface ISleeper
    {
        void DoSleep();
        Vector3 GetSleepPosition();
    }
}