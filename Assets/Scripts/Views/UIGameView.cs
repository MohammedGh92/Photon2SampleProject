using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Game view with events for buttons and showing data.
/// </summary>
public class UIGameView : UIView
{
    // Event called when one of direction buttons clicked.
    public UnityAction<int> OnDirButtonClicked;
    // Event called when one of direction buttons is unclicked.
    public UnityAction OnDirButtonUnClicked;

    /// <summary>
    /// Method called by one of directions buttons.
    /// </summary>
    public void DirButtonClicked(int MovingDirIntEnumValue)
    {
        OnDirButtonClicked?.Invoke(MovingDirIntEnumValue);
    }

    /// <summary>
    /// Method called when player stop pressing on any of the directions buttons.
    /// </summary>
    public void DirButtonUnClicked()
    {
        OnDirButtonUnClicked?.Invoke();
    }


}
