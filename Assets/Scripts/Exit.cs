using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Exit
{
    /// <summary>
    /// Method or direction of exit.
    /// </summary>
    public string keyString;

    /// <summary>
    /// Exit Description to be displayed in the actionLog.
    /// </summary>
    public string exitDescription;

    /// <summary>
    /// Which room the exits lead to.
    /// </summary>
    public Room valueRoom;


}
