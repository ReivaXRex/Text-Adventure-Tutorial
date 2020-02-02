using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
public class Use : InputAction
{
    /// <summary>
    /// Use an item when it's keyword is inputted.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="separatedInputWords"></param>
    public override void RespondtoInput(GameController controller, string[] separatedInputWords)
    {
        controller.interactableItems.UseItem(separatedInputWords);
    }
}
