using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    /// <summary>
    /// Text to be displayed on the screen. 
    /// </summary>
    public Text displayText;

    /// <summary>
    /// An array of the actions the player can perform.
    /// </summary>
    public InputAction[] inputActions;

    /// <summary>
    /// Reference to the RoomNavigation script.
    /// </summary>
    [HideInInspector] public RoomNavigation roomNavigation;

    /// <summary>
    /// A list of available actions for the player.
    /// </summary>
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();

    /// <summary>
    /// Reference to the InteractableItems script.
    /// </summary>
    [HideInInspector] public InteractableItems interactableItems;

    /// <summary>
    /// A List of the actions that player has performed.
    /// </summary>
    List<string> actionLog = new List<string>();

    void Awake()
    {
        // Store the references
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
    }

    /// <summary>
    /// Display the description, exits, and interactions of the current room as well as the current actionLog.
    /// </summary>
    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    /// <summary>
    /// Display the text current logged by the Action Log.
    /// </summary>
    public void DisplayLoggedText()
    {
        #region In Detail
        /* 
         Log is currently a list which is a seperate set of strings. They need to be joined together (string.Join).
         string.Join(string seperator ("\n"), params string[]value)
         actionLog(List) needs to be converted into an Array since string.Join accepts an Array as it's second argument. 
         Achieved with .ToArray function. 
         */
        #endregion

        string logAsText = string.Join("\n", actionLog.ToArray()); // Take the list of actions and turn them into a long string with new line breaks included.

        displayText.text = logAsText; // After the list as been converted to text, display it to the screen.
    }

    /// <summary>
    /// Prepare a Room with it's description, exits and interactions.
    /// </summary>
    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();

        UnPackRoom();

        string joinedInteractionDescription = string.Join("\n", interactionDescriptionsInRoom.ToArray()); // Convert the List of interaction descriptions into an Array, and join them into one string, seperated by a new line.

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescription; // Assign a string variable to contain the description of the Room & the interactions available within.

        LogStringWithReturn(combinedText); // Call the LogString function using the combinedText (room description + new line) variable as the parameter.
    }

    void UnPackRoom()
    {
        roomNavigation.UnPackExitsInRoom(); // Prepare the exits of the room.
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom); // Get the current room and prepare to display any interactable objects found within.
    }

    /// <summary>
    /// Prepare the list of objects to display within a room.
    /// </summary>
    /// <param name="currentRoom"></param>
    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++) // Go over the array of interactable objects in the current room.
        {
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i); // If it finds an object not within the inventory, store it within a string variable.
            if (descriptionNotInInventory != null)
            {
                interactionDescriptionsInRoom.Add(descriptionNotInInventory); // Add the objects to the list of available interactable ojects.
            }

            InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

            for (int j = 0; j < interactableInRoom.interactions.Length; j++) // Loop over the interactions of the interactable objects.
            {
                Interaction interaction = interactableInRoom.interactions[j];

                if (interaction.inputAction.keyword == "examine") // If the object can be examined...
                {
                    interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse); // Add it to the examine dictionary. 
                }

                if (interaction.inputAction.keyword == "take") // If the object can be taken...
                {
                    interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse); // Add it to the taken dictionary. 
                }
            }

        }

    }

    /// <summary>
    /// Check to see if the noun is in the examine dictionary before attempting to retrieve it.
    /// </summary>
    /// <param name="verbDictionary"></param>
    /// <param name="verb"></param>
    /// <param name="noun"></param>
    /// <returns></returns>
    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        if (verbDictionary.ContainsKey(noun)) // Is the noun in the examine dictionary? If so...
        {
            return verbDictionary[noun]; // Return the value stored in the dictionary corresponding to the key noun as a string.
        }

        return "You can't " + verb + " " + noun; // Display an error message to the player if the noun wasn't found within the dictionary.
    }

    /// <summary>
    /// Clear the interaction & interactable lists and empty the dictionary of exits when the Player enters a new Room.
    /// </summary>
    void ClearCollectionsForNewRoom()
    {
        interactableItems.ClearCollections();
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }

    /// <summary>
    /// Add entires into Action Log list.
    /// </summary>
    /// <param name="stringToAdd"></param>
    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n"); // Add in the new string with a new line break at the end.

    }

}
