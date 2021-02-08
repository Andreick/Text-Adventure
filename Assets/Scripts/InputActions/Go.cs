using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Input Action/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameManager manager, string[] separetedInputWords)
    {
        manager.RoomNavigation.AttemptToChangeRooms(separetedInputWords[1]);
    }
}
