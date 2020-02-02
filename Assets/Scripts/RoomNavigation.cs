using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    /// <summary>
    /// Current Room the Player is in.
    /// </summary>
    public Room currentRoom;

    GameController controller;

    /// <summary>
    /// A dictionary of directions of exits for the Room.
    /// </summary>
    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    void Awake()
    {
        controller = GetComponent<GameController>(); // Get and store the Game Controller.  
    }

    /// <summary>
    /// Go over the array of exists in the current Room and pass them over to the GameController to be displayed.
    /// </summary>

    /// <remarks>
    /// Enter a room, unpack the exits, add them to the list of desciptions and get ready to show them on the screen.
    /// </remarks>
    public void UnPackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++) // Go over all of the exits in the current room.
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }

    }

    /// <summary>
    /// Check whether the player can change rooms based of the direction they chose. Changes room if they can.
    /// </summary>
    /// <param name="directionNoun"></param>
    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun)) // Check to see if the dictionary contains that key and if so...
        {
            currentRoom = exitDictionary[directionNoun]; // Set the player into the room in the direction they chose.
            controller.LogStringWithReturn("You head off to the " + directionNoun); // Report back to the Game Controller.
            controller.DisplayRoomText(); // Display the text of the new room that was entered.
        }

        else // if not...
        {
            controller.LogStringWithReturn("There is no path to the " + directionNoun); // Report back to the Game Controller
        }

    }
    /// <summary>
    /// Empty out the Exit dictionary.
    /// </summary>
    public void ClearExits()
    {
        exitDictionary.Clear();
    }

}
