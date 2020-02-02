using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    /// <summary>
    /// Log either the error message or the text response pending whether the item can be examined.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="seperatedInputWords"></param>
    public override void RespondtoInput(GameController controller, string[] seperatedInputWords)
    {
        controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(controller.interactableItems.examineDictionary, seperatedInputWords[0], seperatedInputWords[1]));
    }
}
