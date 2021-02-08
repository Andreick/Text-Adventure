using UnityEngine;

[System.Serializable]
public class Exit
{
    [SerializeField] string keyString;
    [SerializeField] string exitDescription;
    [SerializeField] Room valueRoom;

    public string ExitDescription { get { return exitDescription; } }
    public string KeyString { get { return keyString; } }
    public Room ValueRoom { get { return valueRoom; } }
}
