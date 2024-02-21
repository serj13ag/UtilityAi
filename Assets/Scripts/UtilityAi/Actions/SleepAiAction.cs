using Controllers.Interfaces;
using UnityEngine;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class SleepAiAction : AiAction, IAiActionWithDestination
    {
        private readonly ISleeper _sleeper;

        public Vector3 DestinationPosition { get; private set; }

        public SleepAiAction(string name, AiConsideration[] considerations, ISleeper sleeper)
            : base(name, considerations)
        {
            _sleeper = sleeper;
        }

        public override void Execute()
        {
            _sleeper.DoSleep();
        }

        public void SetDestinationPosition()
        {
            DestinationPosition = _sleeper.GetSleepPosition();
        }
    }
}