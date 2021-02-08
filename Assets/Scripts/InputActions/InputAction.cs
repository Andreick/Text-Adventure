using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    [SerializeField] string keyWord;

    public string KeyWord { get { return keyWord; } }

    public abstract void RespondToInput(GameManager manager, string[] separetedInputWords);
}
