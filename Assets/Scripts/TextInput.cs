using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    /// <summary>
    /// Reference to the GameController.
    /// </summary>
    GameController controller;

    /// <summary>
    /// Reference to the inputField within the UI.
    /// </summary>
    public InputField inputField;
    private void Awake()
    {
        controller = GetComponent<GameController>(); // Get and set store the Game Controller.


        inputField.onEndEdit.AddListener(AcceptStringInput);  // Calls the parameter anytime the onEndEdit event is raised. 
        /// <remarks>
        /// i.e When someone stops editing the Input Field and presses return('enter').
        /// </remarks> 


    }

    /// <summary>
    /// Make the user's input text legible.
    /// </summary>
    /// <param name="userInput"></param>
    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower(); // Convert all characters from the user's input into lowercase.
        controller.LogStringWithReturn(userInput); // Mirror the input back to the player so they can see what they typed.

        // Single item in the array is a space.
        // Characters that are being looked for to seperate the words are spaces. (Go -space- North)                                     
        char[] delimiterCharacters = { ' ' };

        string[] seperatedInputWords = userInput.Split(delimiterCharacters); // Seperate the character between the spaces.

        for (int i = 0; i < controller.inputActions.Length; i++) // Check the first word to see if it is an action associated with a keyword.
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyword == seperatedInputWords[0]) // Action should be first (0).
            {
                inputAction.RespondtoInput(controller, seperatedInputWords); // Check the second word in the array.
            }
        }


        InputComplete(); // Player input is received, input is complete.

    }

    /// <summary>
    /// Prepares the input field for use after input is complete.
    /// </summary>
    void InputComplete()
    {
        controller.DisplayLoggedText(); // Update the action log with text the user has typed.
        inputField.ActivateInputField(); // Returns the focus to the input field. (When you hit return on an input field it takes the focus away)
        inputField.text = null; // Clear the text box.
    }
}
