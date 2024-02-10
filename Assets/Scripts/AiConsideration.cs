using UnityEngine;

public abstract class AiConsideration : ScriptableObject
{
    public string Name;
    public float Score;

    public abstract float ScoreConsideration();
}