using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TextAdventure/Room")]                                                    
public class Room : ScriptableObject
{ 
    /// <summary>
    /// Description of the room.
    /// </summary>
    [TextArea]  // [Text Area] Allows the display of a large text entry box in the Inspector.
    public string description;

    /// <summary>
    /// Name of the room.
    /// </summary>
    public string roomName;

    /// <summary>
    ///  An array of room exits.
    /// </summary>
    public Exit[] exits;

    /// <summary>
    /// An array of interactable objects that can be found within a room.
    /// </summary>
    public InteractableObject[] interactableObjectsInRoom;
}
