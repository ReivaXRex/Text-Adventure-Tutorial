using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    /// <summary>
    /// Name of the object.
    /// </summary>
    public string noun = "name";

    /// <summary>
    /// The description of the object.
    /// </summary>
    [TextArea]
    public string description = "Description in room";

    /// <summary>
    /// An array of interactions for the object. 
    /// </summary>
    public Interaction[] interactions;
}
