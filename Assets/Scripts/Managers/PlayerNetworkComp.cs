using Photon.Pun;
using UnityEngine.Events;

public class PlayerNetworkComp : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Event triggered when my local player instantiated.
    /// </summary>
    public UnityEvent OnMyLocalPlayerInstantiated;

    
    /// <summary>
    /// Method called when player created.
    /// </summary>
    private void Start()
    {
        if (photonView.IsMine)
            OnMyLocalPlayerInstantiated.Invoke();
    }

    /// <summary>
    /// Method used to leave the room 
    /// </summary>
    public void LeaveRoom()
    {
        if (photonView.IsMine)
            GameNetworkManager.Instance.LeaveRoomAfterSometime();
    }
}