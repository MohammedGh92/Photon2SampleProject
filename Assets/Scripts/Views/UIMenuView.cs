using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Menu view with events for buttons.
/// </summary>
public class UIMenuView : UIView
{
    // Event called when Join Button is clicked.
    public UnityAction OnJoinClicked;

    /// <summary>
    /// Method called by Join Room Button.
    /// </summary>
    public void JoinClicked()
    {
        OnJoinClicked?.Invoke();
    }
 
}
