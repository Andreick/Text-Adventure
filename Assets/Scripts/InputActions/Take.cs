using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Input Action/Take")]
public class Take : InputAction
{
    public override void RespondToInput(GameManager manager, string[] separetedInputWords)
    {
        ReadOnlyDictionary<string, string> takeDictionary = manager.InteractableItems.Take(separetedInputWords);

        if(takeDictionary != null)
        {
            manager.LogStringWithReturn(manager.TestVerbDictionaryWithNoum(takeDictionary, separetedInputWords[0], separetedInputWords[1]));
        }
    }
}
