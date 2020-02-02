using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{

    /// <summary>
    /// A dictionary of items that can be examined.
    /// </summary>
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();

    /// <summary>
    /// A dictionary of items that can be taken.
    /// </summary>
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

    /// <summary>
    /// A dictionary of the items that can be used.
    /// </summary>
    Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();

    /// <summary>
    /// A list of all the usable items in the game.
    /// </summary>
    public List<InteractableObject> usableItemList;

    /// <summary>
    /// A list of the names of all the objects in a room. 
    /// </summary>
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    /// <summary>
    /// A list of the names of the objects in the Player's Inventory. 
    /// </summary>
    List<string> nounsInInventory = new List<string>();

    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    /// <summary>
    /// Build a list of the objects in the room that are not in the Player's Inventory.
    /// </summary>
    /// <param name="currentRoom"></param>
    /// <param name="i"></param>
    /// <returns></returns> 
    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i]; // Convenience variable to hold the array of the interactable objects in the current room.

        if (!nounsInInventory.Contains(interactableInRoom.noun)) // Check the player's inventory for an item found within the room.
        {
            nounsInRoom.Add(interactableInRoom.noun); // If it's not, add it to the list of objects in the room
            return interactableInRoom.description; // Return the description of the interactable item.
        }
        return null;

    }

    /// <summary>
    /// Build up the UseDictionary.
    /// </summary>
    public void AddActionResponsesToUseDictionary()
    {
        for (int i = 0; i < nounsInInventory.Count; i++) // Loop over the items in the player's inventory.
        {
            string noun = nounsInInventory[i]; // Convenience variable for current item.

            InteractableObject interactableObjectInIventory = GetInteractableObjectFromUsableList(noun); // Get the object from the usable item list based off it's name.
            if (interactableObjectInIventory == null) // If it's not in the list...
                continue; // break out of this iteration of the loop and continue.

            for (int j = 0; j < interactableObjectInIventory.interactions.Length; j++) // Loop over the interactions of the usable item
            {
                Interaction interaction = interactableObjectInIventory.interactions[j]; // Convenience variable for current item's interactions.

                if (interaction.actionResponse == null) // Item doesn't contain an Action Response
                    continue; // break out of this iteration of the loop and continue.

                if (!useDictionary.ContainsKey(noun)) // If this item isn't in the UseDictionary already
                {
                    useDictionary.Add(noun, interaction.actionResponse); // Add it to the UseDictionary. 
                }

            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="noun"></param>
    /// <returns></returns>
    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < usableItemList.Count; i++) // Loop over the list of items in the game.
        {
            if (usableItemList[i].noun == noun) // Check to see if the item is in the list
            {
                return usableItemList[i];
            }
        }
        return null;
    }

    /// <summary>
    /// Display the player's inventory.
    /// </summary>
    public void DisplayInventory()
    {
        controller.LogStringWithReturn("You look into your backpack, inside you have: ");

        for (int i = 0; i < nounsInInventory.Count; i++) // Loop over the items in player's inventory
        {
            controller.LogStringWithReturn(nounsInInventory[i]); // Display the items to the action Log.
        }
    }

    /// <summary>
    /// Clear the collections (dictonaries & lists) to be rebuilt upon entering a room.
    /// </summary>

    public void ClearCollections()
    {
        examineDictionary.Clear();
        takeDictionary.Clear();
        nounsInRoom.Clear();

    }

    /// <summary>
    /// A dictionary of items that can be examined. Adds item to inventory & removes from Room.
    /// </summary>
    /// <param name="seperatedInputWords"></param>
    /// <returns> string </returns>
    public Dictionary<string, string> Take(string[] seperatedInputWords)
    {
        string noun = seperatedInputWords[1]; // The second inputted word is the item (noun).

        if (nounsInRoom.Contains(noun)) // If the item is in the room
        {
            nounsInInventory.Add(noun); // Add the item to the player's inventory
            AddActionResponsesToUseDictionary(); // Rebuild the UseDictionary.
            nounsInRoom.Remove(noun); // Remove the item from the Room.
            return takeDictionary;
        }
        else
        {
            controller.LogStringWithReturn("There is no " + noun + " here to take"); // Error message if the item isn't within the room.
            return null;
        }
    }

    /// <summary>
    /// Use an item from the player's inventory if conditions are met. 
    /// </summary>
    /// <param name="separatedInputWords"></param>
    public void UseItem(string[] separatedInputWords)
    {
        string nounToUse = separatedInputWords[1]; // Create & set a string variable to hold the name of the item. (2nd inputted word)

        if (nounsInInventory.Contains(nounToUse)) // Check to see if the item is in the player's inventory.
        {
            if (useDictionary.ContainsKey(nounToUse)) // Check to see if said item is also within the UseDictionary.
            {
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller); // Proceed with the action of the item based off it's ActionResponse.
                if (!actionResult) // If the action fails...
                {

                    controller.LogStringWithReturn("Nothing happens..."); // You can use the item within the current Room but it has no effect.
                }
            }
            else
            {
                controller.LogStringWithReturn("You can't use the " + nounToUse); // The item is in the player's inventory but not usable within the current Room.
            }
        }
        else
        {
            controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use"); // The item isn't in the player's inventory.
        }
    }

}
