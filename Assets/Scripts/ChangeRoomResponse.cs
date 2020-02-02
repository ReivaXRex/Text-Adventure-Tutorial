using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionResponses/ChangeRoom")]
public class ChangeRoomResponse : ActionResponse
{
    /// <summary>
    /// Room to change to upon using an object.
    /// </summary>
    /// <remarks>
    /// Current case; secret room from skull.
    /// </remarks>
    public Room roomToChangeTo;

    public override bool DoActionResponse(GameController controller)
    {
        if (controller.roomNavigation.currentRoom.roomName == requiredString) // Check the room name
        {
            controller.roomNavigation.currentRoom = roomToChangeTo; // Change rooms
            controller.DisplayRoomText();
            return true;
        }
        return false;
    }

}
