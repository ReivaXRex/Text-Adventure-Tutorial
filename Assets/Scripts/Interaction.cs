using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    /// <summary>
    /// Reference to InputAction.
    /// </summary>
    /// <example>
    /// Go, Take, Use
    /// </example>
    public InputAction inputAction;


    /// <summary>
    /// Text response when examining an object.
    /// </summary>
    [TextArea]
    public string textResponse;

    /// <summary>
    /// Reference to Action Response.
    /// </summary>
    public ActionResponse actionResponse;

}
