using Controllers;
using UnityEngine;

namespace UtilityAi.Actions
{
    public interface IAiActionWithDestination
    {
        Vector3 DestinationPosition { get; }

        void SetDestinationPosition(NpcController npcController);
    }
}