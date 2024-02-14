using UnityEngine;

namespace UtilityAi.Data
{
    [CreateAssetMenu(fileName = "Action", menuName = "UtilityAi/Action")]
    public class AiActionData : ScriptableObject
    {
        public string Name;
        public AiActionType Type;
        public AiConsiderationData[] Considerations;
    }
}