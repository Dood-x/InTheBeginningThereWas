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

        if(controller.sceneNavigation.currentScene.anyInputExit)
        {
            controller.sceneNavigation.AttemptToChangeScenes("");
            InputComplete();
            return;

        }
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimitedCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimitedCharacters);

        bool accepted = false;

        bool foundAction = false;
        List<InputAction> actions = new List<InputAction>();

        //match the input action with the user input
        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            for (int j = 0; j < controller.inputActions[i].keyWord.Length; j++)
            {
                string[] actionWords = controller.inputActions[i].keyWord[j].Split(delimitedCharacters);

                if (actionWords.Length <= separatedInputWords.Length)
                {
                    bool matched = true;
                    for (int z = 0; z < actionWords.Length; z++)
                    {
                        if (actionWords[z] != separatedInputWords[z])
                            matched = false;
                    }

                    if(matched)
                    {
                        foundAction = true;
                        actions.Add(controller.inputActions[i]);
                    }
                }

            }
        }

        if (!foundAction)
        {
            controller.LogStringWithReturn("Nothing happens.");
            InputComplete();
            return;
        }

        InputAction action = null;
        int priority = 0;
        foreach(InputAction e in actions)
        {
            if(e.priority >= priority)
            {
                priority = e.priority;
                action = e;
            }
        }


        foreach (Exit exit in controller.sceneNavigation.currentScene.exits)
        {
            if(exit.action == action)
            {
                for(int i = 0; i < exit.keyString.Length; i++)
                {
                    string objectKeyword = "";
                    for(int j =0; j < action.keyWord.Length; j++)
                    {
                        string[] actionWords = action.keyWord[j].Split(delimitedCharacters);
                        if (actionWords.Length < separatedInputWords.Length)
                        {
                            objectKeyword = separatedInputWords[separatedInputWords.Length - 1];
                        }

                        if (exit.keyString[i] == objectKeyword)
                        {
                            accepted = true;
                            action.RespondToInput(controller, objectKeyword);
                            InputComplete();
                            return;
                        }
                    }
                    
                }
            }
        }


        if (accepted == false)
        {
            for(int j = 0; j <action.keyWord.Length; j++)
            {
                string[] actionWords = action.keyWord[j].Split(delimitedCharacters);

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

                        accepted = controller.sceneNavigation.ExecuteActionOnObject(action, objectKeyword);
                        InputComplete();
                        return;
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
