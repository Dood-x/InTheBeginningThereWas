using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;
    private GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptInput);
    }
    void AcceptInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimitedCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimitedCharacters);

        bool accepted = false;

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            for (int j = 0; j < inputAction.keyWord.Length; j++)
            {
                bool twoKeywords = false;
                if (separatedInputWords.Length > 2)
                {
                    twoKeywords = inputAction.keyWord[j] == separatedInputWords[0] + " " + separatedInputWords[1];
                }

                if (inputAction.keyWord[j] == separatedInputWords[0] || twoKeywords)
                {
                    accepted = true;
                    inputAction.RespondToInput(controller, separatedInputWords);
                    break;
                }


            }

        }

        if (accepted == false)
        {
            foreach (ActionOnObject element in controller.sceneNavigation.currentScene.actionsOnObjects)
            {
                for(int i = 0; i < controller.inputActions.Length; i++)
                {
                    for(int j = 0; j < controller.inputActions[i].keyWord.Length; j++)
                    {
                        string[] actionWords = controller.inputActions[i].keyWord[j].Split(delimitedCharacters);

                        if(actionWords.Length <= separatedInputWords.Length)
                        {
                            bool matched = true;
                            for(int z = 0; z < actionWords.Length; z++)
                            {
                                if (actionWords[z] != separatedInputWords[z])
                                    matched = false;
                            }

                            if(matched)
                            {
                                string objectKeyword = "";
                                if(actionWords.Length < separatedInputWords.Length)
                                {
                                    objectKeyword = separatedInputWords[separatedInputWords.Length - 1];
                                }

                                accepted = controller.sceneNavigation.ExecuteActionOnObject(controller.inputActions[i], objectKeyword);
                            }
                        }

                    }
                }
                
            }
            
        }

        if (accepted == false)
        {
            controller.LogStringWithReturn("Nothing happens.");
        }

        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
