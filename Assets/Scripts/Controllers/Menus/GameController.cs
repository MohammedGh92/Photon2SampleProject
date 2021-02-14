using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Controller responsible for game phase.
/// </summary>
public class GameController : SubController<UIGameRoot>
{

    /// <summary>
    /// Method called by one of directions buttons.
    /// </summary>
    public UnityAction<int> DirectionButtonClicked;

    /// <summary>
    /// Method used to engage controller.
    /// </summary>
    public override void EngageController()
    {

        ui.GameView.OnDirButtonClicked += DirButtonClicked;
        ui.GameView.OnDirButtonUnClicked += OnDirButtonUnClicked;
        base.EngageController();
    }


    /// <summary>
    /// Method used to disengage controller.
    /// </summary>
    public override void DisengageController()
    {
        base.DisengageController();

        // Detaching UI events.
        ui.GameView.OnDirButtonClicked -= DirButtonClicked;
        ui.GameView.OnDirButtonUnClicked -= OnDirButtonUnClicked;
    }

    /// <summary>
    /// Method called when player holds on one of the directions buttons.
    /// </summary>
    /// <param name="MovingDir"></param>
    private void DirButtonClicked(int MovingDir)
    {
        DirectionButtonClicked.Invoke(MovingDir);
    }

    /// <summary>
    /// Method called when player stop pressing on any of the directions buttons.
    /// </summary>
    private void OnDirButtonUnClicked()
    {
        DirectionButtonClicked.Invoke(8);
    }

}
