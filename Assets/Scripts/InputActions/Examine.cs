using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Input Action/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GameManager manager, string[] separetedInputWords)
    {
        manager.LogStringWithReturn(manager.TestVerbDictionaryWithNoum(manager.InteractableItems.ExamineDictionary, separetedInputWords[0], separetedInputWords[1]));
    }
}
