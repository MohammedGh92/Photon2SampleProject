using UnityEngine;

/// <summary>
/// Root controller responsible for changing game phases with SubControllers.
/// </summary>
public abstract class RootController : MonoBehaviour
{

    /// <summary>
    /// Method used by subcontrollers to change game phase.
    /// </summary>
    /// <param name="controller">Controller type.</param>
    public abstract void ChangeController(ControllerTypeEnum controller);

    /// <summary>
    /// Method used to disable all attached subcontrollers.
    /// </summary>
    public abstract void DisengageControllers();
}
