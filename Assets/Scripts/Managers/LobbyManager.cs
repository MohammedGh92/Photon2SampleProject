using Photon.Pun;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    /// <summary>
    /// Method called on the start, and to start connecting with PUN server.
    /// </summary>
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        LoadingScreen.Instance.ShowLoading(true);
    }

    /// <summary>
    /// Method called when connected to master successfully.
    /// </summary>
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    /// <summary>
    /// Method called when joined the lobby successfully.
    /// </summary>
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        LoadingScreen.Instance.ShowLoading(false);
    }

    /// <summary>
    /// Method called when click on the join button.
    /// </summary>
    public void JoinRoom()
    {
        SceneManager.LoadScene("Game");
        
    }
  
}