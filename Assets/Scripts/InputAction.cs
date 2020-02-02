using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    /// <summary>
    /// The input that is being responded to.
    /// </summary>
    public string keyword;

    /// <summary>
    /// Log either the error message or the text response of the interactable object to the console.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="seperatedInputWords"></param>
    public abstract void RespondtoInput(GameController controller, string[] seperatedInputWords);

}
