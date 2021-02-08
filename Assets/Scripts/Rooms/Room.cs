using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Room")]
public class Room : ScriptableObject
{
    [TextArea]
    [SerializeField] string description;
    [SerializeField] string roomName;
    [SerializeField] Exit[] exits;
    [SerializeField] InteractableObject[] interactableObjectsInRoom;

    public string Description { get => description; }
    public string RoomName { get => roomName; }
    public ReadOnlyCollection<Exit> Exits { get => new ReadOnlyCollection<Exit>(exits); }
    public ReadOnlyCollection<InteractableObject> InteractableObjectsInRoom { get => new ReadOnlyCollection<InteractableObject>(interactableObjectsInRoom); }
}
