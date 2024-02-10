using UnityEngine;

public abstract class AiAction : ScriptableObject
{
    public string Name;
    public float Score;

    public AiConsideration[] Considerations;

    public abstract void Execute();
}