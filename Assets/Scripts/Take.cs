using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Take")]
public class Take : InputAction
{
    /// <summary>
    /// Log either the error message or the text response pending whether the item can be taken.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="seperatedInputWords"></param>
    public override void RespondtoInput(GameController controller, string[] seperatedInputWords)
    {
        Dictionary<string, string> takeDictionary = controller.interactableItems.Take(seperatedInputWords); // Try to take something and if successful return a dictionary

        if (takeDictionary != null) // If the player is able to take the object...
        {
            controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(takeDictionary, seperatedInputWords[0], seperatedInputWords[1]));
        }
    }
}
