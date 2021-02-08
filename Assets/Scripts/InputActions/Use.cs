using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Input Action/Use")]
public class Use : InputAction
{
    public override void RespondToInput(GameManager manager, string[] separetedInputWords)
    {
        manager.InteractableItems.UseItem(separetedInputWords);
    }
}
