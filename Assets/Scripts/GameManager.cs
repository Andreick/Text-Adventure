using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text displayText;
    [SerializeField] InputAction[] inputActions;

    private RoomNavigation roomNavigation;
    private interactableItems interactableItems;
    private List<string> interactionDescriptionsInRoom;
    private List<string> actionLog;

    //public ReadOnlyCollection<string> InteractionDescriptionsInRoom { get { return interactionDescriptionsInRoom.AsReadOnly(); } }
    public RoomNavigation RoomNavigation { get { return roomNavigation; } }
    public ReadOnlyCollection<InputAction> InputActions { get { return new ReadOnlyCollection<InputAction>(inputActions); } }
    public interactableItems InteractableItems { get { return interactableItems; } }
    public void AddToInteractionDescriptionsInRoom(string value)
    {
        interactionDescriptionsInRoom.Add(value);
    }

    private void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
        interactableItems = GetComponent<interactableItems>();
        interactionDescriptionsInRoom = new List<string>();
        actionLog = new List<string>();
    }

    private void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);
    }

    private void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.InteractableObjectsInRoom.Count; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);

            if (!string.IsNullOrEmpty(descriptionNotInInventory))
            {
                interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInRoom = currentRoom.InteractableObjectsInRoom[i];

            for (int j = 0; j < interactableInRoom.Interactions.Count; j++)
            {
                Interaction interaction = interactableInRoom.Interactions[j];

                if (interaction.InputAction.KeyWord.Equals("Examine"))
                {
                    interactableItems.AddToExamineDictionary(interactableInRoom.Noum, interaction.TextResponse);
                }

                if (interaction.InputAction.KeyWord.Equals("Take"))
                {
                    interactableItems.AddToTakeDictionary(interactableInRoom.Noum, interaction.TextResponse);
                }
            }
        }
    }

    public string TestVerbDictionaryWithNoum(ReadOnlyDictionary<string, string> verbDictionary, string verb, string noum)
    {
        if (verbDictionary.ContainsKey(noum))
        {
            return verbDictionary[noum];
        }

        return "You can't " + verb + " " + noum;
    }

    private void ClearColletionsForNewRoom()
    {
        interactableItems.ClearCollections();
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }

    public void DisplayRoomText()
    {
        ClearColletionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom);

        string combinedText = roomNavigation.currentRoom.Description + '\n' + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + '\n');
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog);

        displayText.text = logAsText;
    }
}
