using UnityEngine;

/// <summary>
/// UI root for Game controller.
/// </summary>
public class UIGameRoot : UIRoot
{
    // Reference to game view class.
    [SerializeField]
    private UIGameView gameView;
    public UIGameView GameView => gameView;

    /// <summary>
    /// Method used to show our element.
    /// </summary>
    public override void ShowRoot()
    {
        base.ShowRoot();

        gameView.ShowView();
    }

    /// <summary>
    /// Method used to hide our element.
    /// </summary>
    public override void HideRoot()
    {
        gameView.HideView();

        base.HideRoot();
    }
}
