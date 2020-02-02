using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction
{
    /// <summary>
    /// Move player between rooms if the "Go" keyword is input.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="seperatedInputWords"></param>
    
    /// <remarks>
    /// 
    /// 
    /// </remarks>    
    
    public override void RespondtoInput(GameController controller, string[] seperatedInputWords)
    {
        controller.roomNavigation.AttemptToChangeRooms(seperatedInputWords [1]); // Pass in the second word of the array. Verb - Noun Grammer (go north, use skull).
    }
}
