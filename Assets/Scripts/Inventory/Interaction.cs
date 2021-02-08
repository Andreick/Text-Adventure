using UnityEngine;

[System.Serializable]
public class Interaction
{
    [SerializeField] InputAction inputAction;
    [TextArea]
    [SerializeField] string textResponse;
    [SerializeField] ActionResponse actionResponse;

    public InputAction InputAction { get { return inputAction; } }
    public string TextResponse { get { return textResponse; } }
    public ActionResponse ActionResponse { get { return actionResponse; } }
}
