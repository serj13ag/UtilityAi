using UnityEngine;

namespace Controllers.Interfaces
{
    public interface IWorker
    {
        void DoWork();
        Vector3 GetWorkPosition();
    }
}