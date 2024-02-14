using UnityEngine;

namespace UtilityAi.Data
{
    [CreateAssetMenu(fileName = "Consideration", menuName = "UtilityAi/Consideration")]
    public class AiConsiderationData : ScriptableObject
    {
        public string Name;
        public AiConsiderationType Type;
        public AnimationCurve ResponseCurve;
    }
}