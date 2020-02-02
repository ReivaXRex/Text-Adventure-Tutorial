using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionResponse : ScriptableObject
{

    /// <summary>
    /// Key to check against if an action is possible. 
    /// </summary>
    /// <remarks>
    /// Current case; checking to see if the player is in the right room to use the skull.
    /// </remarks>
    public string requiredString;

    /// <summary>
    /// Proceed with the action.
    /// </summary>
    /// <remarks>
    /// When making Scriptable Objects that execute code pass in any scene references as an argument when calling the function.
    /// Don't set variables on a Scriptable Object from the scene; leads to unpleasant behavior.
    /// </remarks>
    public abstract bool DoActionResponse(GameController controller);    
    
}
