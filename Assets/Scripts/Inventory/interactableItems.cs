using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class interactableItems : MonoBehaviour
{
    [SerializeField] List<InteractableObject> usableItems;
    private List<string> noumsInRoom;
    private List<string> noumsInInventory;
    private Dictionary<string, string> examineDictionary;
    private Dictionary<string, string> takeDictionary;
    private Dictionary<string, ActionResponse> useDictionary;
    private GameManager manager;

    public ReadOnlyDictionary<string, string> ExamineDictionary { get { return new ReadOnlyDictionary<string, string>(examineDictionary); } }
    public void AddToExamineDictionary(string key, string value)
    {
        examineDictionary.Add(key, value);
    }
    public void AddToTakeDictionary(string key, string value)
    {
        takeDictionary.Add(key, value);
    }

    private void Awake()
    {
        noumsInRoom = new List<string>();
        noumsInInventory = new List<string>();
        examineDictionary = new Dictionary<string, string>();
        takeDictionary = new Dictionary<string, string>();
        useDictionary = new Dictionary<string, ActionResponse>();
        manager = GetComponent<GameManager>();
    }

    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.InteractableObjectsInRoom[i];

        if (!noumsInInventory.Contains(interactableInRoom.Noum))
        {
            noumsInRoom.Add(interactableInRoom.Noum);
            return interactableInRoom.Description;
        }

        return null;
    }

    InteractableObject GetIteractableObjectFromUsableItems(string noum)
    {
        for (int i = 0; i < usableItems.Count; i++)
        {
            if (usableItems[i].Noum.Equals(noum))
            {
                return usableItems[i];
            }
        }

        return null;
    }

    public void AddActionResponsesToUseDictionary()
    {
        for (int i = 0; i < noumsInInventory.Count; i++)
        {
            string noum = noumsInInventory[i];

            InteractableObject interactableObjectInInventory = GetIteractableObjectFromUsableItems(noum);

            if (interactableObjectInInventory == null)
            {
                continue;
            }

            for (int j = 0; j < interactableObjectInInventory.Interactions.Count; j++)
            {
                Interaction interaction = interactableObjectInInventory.Interactions[j];

                if (interaction.ActionResponse == null)
                {
                    continue;
                }

                if (!useDictionary.ContainsKey(noum))
                {
                    useDictionary.Add(noum, interaction.ActionResponse);
                }
            }
        }
    }

    public void DisplayInventory()
    {
        manager.LogStringWithReturn("You look in your backpack, inside you have: ");

        for (int i = 0; i < noumsInInventory.Count; i++)
        {
            manager.LogStringWithReturn(noumsInInventory[i]);
        }
    }

    public void ClearCollections()
    {
        noumsInRoom.Clear();
        examineDictionary.Clear();
        takeDictionary.Clear();
    }

    public ReadOnlyDictionary<string, string> Take (string[] separatedInputWords)
    {
        string noum = separatedInputWords[1];

        if (noumsInRoom.Contains(noum))
        {
            noumsInInventory.Add(noum);
            noumsInRoom.Remove(noum);
            examineDictionary.Remove(noum);
            AddActionResponsesToUseDictionary();

            return new ReadOnlyDictionary<string, string>(takeDictionary);
        }
        else
        {
            manager.LogStringWithReturn("There is no " + noum + " here to take.");
            return null;
        }
    }

    public void UseItem(string[] separatedInputWords)
    {
        string noumToUse = separatedInputWords[1];

        if (noumsInInventory.Contains(noumToUse))
        {
            if (useDictionary.ContainsKey(noumToUse))
            {
                if (!useDictionary[noumToUse].DoActionResponse(manager))
                {
                    manager.LogStringWithReturn("Hmm. Nothing happens");
                }
            }
            else
            {
                manager.LogStringWithReturn("You can't use the " + noumToUse);
            }
        }
        else
        {
            manager.LogStringWithReturn("There is no " + noumToUse + " in your inventory to use");
        }
    }
}
