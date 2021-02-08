using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Input Action/Inventory")]
public class Inventory : InputAction
{
    public override void RespondToInput(GameManager manager, string[] separetedInputWords)
    {
        manager.InteractableItems.DisplayInventory();
    }
}
