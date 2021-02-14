using UnityEngine;

/// <summary>
/// UI root class for Menu controller.
/// </summary>
public class UIMenuRoot : UIRoot
{
    // Reference to menu view class.
    [SerializeField]
    private UIMenuView menuView;
    public UIMenuView MenuView => menuView;

    /// <summary>
    /// Method used to show our element.
    /// </summary>
    public override void ShowRoot()
    {
        base.ShowRoot();

        menuView.ShowView();
    }

    /// <summary>
    /// Method used to hide our element.
    /// </summary>
    public override void HideRoot()
    {
        menuView.HideView();

        base.HideRoot();
    }
}
