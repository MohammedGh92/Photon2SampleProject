using UnityEngine;

/// <summary>
/// Root controller responsible for changing game phases with SubControllers.
/// </summary>
public class LobbyRootController : RootController
{
    // SubControllers types.

    // References to the subcontrollers.
    [Header("Controllers")]
    [SerializeField]
    protected MenuController menuController;

    /// <summary>
    /// Unity method called on first frame.
    /// </summary>
    private void Start()
    {
        menuController.root = this;
        ChangeController(ControllerTypeEnum.Menu);
    }

    /// <summary>
    /// Method used by subcontrollers to change game phase.
    /// </summary>
    /// <param name="controller">Controller type.</param>
    public override void ChangeController(ControllerTypeEnum controller)
    {
        // Reseting subcontrollers.
        DisengageControllers();

        // Enabling subcontroller based on type.
        switch (controller)
        {
            case ControllerTypeEnum.Menu:
                menuController.EngageController();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Method used to disable all attached subcontrollers.
    /// </summary>
    public override void DisengageControllers()
    {
        menuController.DisengageController();
    }
}
