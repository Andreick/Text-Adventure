using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    [SerializeField] InputField inputField;

    private GameManager manager;
    private char[] delimiterCharacters = { ' ' };

    private void Awake()
    {
        manager = GetComponent<GameManager>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    private void AcceptStringInput(string userInput)
    {
        if (!string.IsNullOrEmpty(userInput))
        {
            userInput = char.ToUpper(userInput[0]) + userInput.Substring(1).ToLower();
        }

        manager.LogStringWithReturn(userInput);

        string[] separetedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < manager.InputActions.Count; i++)
        {
            InputAction inputAction = manager.InputActions[i];

            if (inputAction.KeyWord.Equals(separetedInputWords[0]))
            {
                inputAction.RespondToInput(manager, separetedInputWords);
                break;
            }
        }

        InputComplete();
    }

    private void InputComplete()
    {
        manager.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
