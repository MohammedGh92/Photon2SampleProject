using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller responsible for menu phase.
/// </summary>
public class MenuController : SubController<UIMenuRoot>
{

    /// <summary>
    /// Method used to engage controller.
    /// </summary>
    public override void EngageController()
    {
        // Attaching UI events.
        ui.MenuView.OnJoinClicked += JoinClicked;

        base.EngageController();
    }

    /// <summary>
    /// Method used to disengage controller.
    /// </summary>
    public override void DisengageController()
    {
        base.DisengageController();

        // Detaching UI events.
        ui.MenuView.OnJoinClicked -= JoinClicked;
    }

    /// <summary>
    /// Handling UI Start Button Click.
    /// </summary>
    private void JoinClicked()
    {
        SceneManager.LoadScene("Game");
    }

}
