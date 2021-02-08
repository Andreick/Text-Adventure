using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    private GameManager manager;
    private Dictionary<string, Room> exitDictionary;

    private void Awake()
    {
        manager = GetComponent<GameManager>();
        exitDictionary = new Dictionary<string, Room>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.Exits.Count; i++)
        {
            exitDictionary.Add(currentRoom.Exits[i].KeyString, currentRoom.Exits[i].ValueRoom);
            manager.AddToInteractionDescriptionsInRoom(currentRoom.Exits[i].ExitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            manager.LogStringWithReturn("You head off to the " + directionNoun);
            manager.DisplayRoomText();
        }
        else
        {
            manager.LogStringWithReturn("There is no path to the " + directionNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
