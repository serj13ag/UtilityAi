using System;
using Npc;
using UtilityAi.Actions;
using UtilityAi.Considerations;
using UtilityAi.Data;

namespace UtilityAi
{
    public static class AiActionFactory
    {
        public static IAiAction[] CreateActions(AiActionData[] actionsData, DefaultNpc npc)
        {
            var actions = new IAiAction[actionsData.Length];

            for (var i = 0; i < actionsData.Length; i++)
            {
                var actionData = actionsData[i];

                var considerations = CreateConsiderations(actionData.Considerations, npc);

                IAiAction aiAction;
                switch (actionData.Type)
                {
                    case AiActionType.Eat:
                        aiAction = new EatAiAction(actionData.Name, considerations, npc);
                        break;
                    case AiActionType.Sleep:
                        aiAction = new SleepAiAction(actionData.Name, considerations, npc);
                        break;
                    case AiActionType.Work:
                        aiAction = new WorkAiAction(actionData.Name, considerations, npc);
                        break;
                    case AiActionType.Undefined:
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                actions[i] = aiAction;
            }

            return actions;
        }

        private static AiConsideration[] CreateConsiderations(AiConsiderationData[] considerationsData,
            DefaultNpc npc)
        {
            var considerations = new AiConsideration[considerationsData.Length];
            for (var i = 0; i < considerationsData.Length; i++)
            {
                var considerationData = considerationsData[i];

                AiConsideration consideration;
                switch (considerationData.Type)
                {
                    case AiConsiderationType.Energy:
                        consideration = new EnergyAiConsideration(considerationData.Name, considerationData.ResponseCurve, npc);
                        break;
                    case AiConsiderationType.Hunger:
                        consideration = new HungerAiConsideration(considerationData.Name, considerationData.ResponseCurve, npc);
                        break;
                    case AiConsiderationType.Money:
                        consideration = new MoneyAiConsideration(considerationData.Name, considerationData.ResponseCurve, npc);
                        break;
                    case AiConsiderationType.Undefined:
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                considerations[i] = consideration;
            }

            return considerations;
        }
    }
}