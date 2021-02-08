using UnityEngine;

public abstract class ActionResponse : ScriptableObject
{
    [SerializeField] protected string requiredString;

    public abstract bool DoActionResponse(GameManager manager);
}
