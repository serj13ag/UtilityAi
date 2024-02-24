using Npc.Interfaces;
using UnityEngine;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class WorkAiAction : AiAction, IAiActionWithDestination
    {
        private readonly IWorker _worker;

        public Vector3 DestinationPosition { get; private set; }

        public WorkAiAction(string name, AiConsideration[] considerations, IWorker worker)
            : base(name, considerations)
        {
            _worker = worker;
        }

        public override void Execute()
        {
            _worker.DoWork();
        }

        public void SetDestinationPosition()
        {
            DestinationPosition = _worker.GetWorkPosition();
        }
    }
}