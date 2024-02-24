using UnityEngine;

namespace Npc.Interfaces
{
    public interface IWorker
    {
        void DoWork();
        Vector3 GetWorkPosition();
    }
}