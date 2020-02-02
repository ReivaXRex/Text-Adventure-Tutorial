using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "TextAdventure/InputActions/Inventory")]
public class Inventory : InputAction
{
    /// <summary>
    /// Display the player's inventory when the 'inventory' keyword is input.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="seperatedInputWords"></param>
    public override void RespondtoInput(GameController controller, string[] seperatedInputWords)
    {
        controller.interactableItems.DisplayInventory();
    }
}
