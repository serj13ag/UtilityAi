using UnityEngine;

namespace UtilityAi.Actions
{
    public interface IAiActionWithDestination : IAiAction
    {
        Vector3 DestinationPosition { get; }

        void SetDestinationPosition();
    }
}