using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Action Response/Change Room")]
public class ChangeRoomResponse : ActionResponse
{
    [SerializeField] Room roomToChangeTo;

    public override bool DoActionResponse(GameManager manager)
    {
        if (manager.RoomNavigation.currentRoom.RoomName.Equals(requiredString))
        {
            manager.RoomNavigation.currentRoom = roomToChangeTo;
            manager.DisplayRoomText();
            return true;
        }

        return false;
    }
}
