using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNetworkManager : MonoBehaviourPunCallbacks
{

    /// <summary>
    /// Reference to our singular instance.
    /// </summary>
    private static GameNetworkManager instance;
    public static GameNetworkManager Instance => instance;

    /// <summary>
    /// Unity method called just after object creation - like constructor.
    /// </summary>
    protected void Awake()
    {
        // If we don't have reference to instance than this object will take control
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) // Else this is other instance and we should destroy it!
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Version of the online game.
    /// </summary>
    [SerializeField]
    [InspectorName("Game Version")]
    private string _gameVersion="0.1";

    /// <summary>
    /// The number of maximum players in the room.
    /// </summary>
    [SerializeField]
    [InspectorName("Max Number Of Players")]
    private int _maxNumberOfPlayers = 3;
    

    /// <summary>
    /// Leave room delay time.
    /// </summary>
    [SerializeField]
    [InspectorName("Leave Room Delay Time After Death")]
    private float _leaveRoomDelayTimeAfterDeath;

    /// <summary>
    /// Name of the online room.
    /// </summary>
    [SerializeField]
    [InspectorName("Room Name")]
    private string _roomName= "MainRoom";

    /// <summary>
    /// Reference to a script that get available place for new players.
    /// </summary>
    [SerializeField]
    [InspectorName("Available Place Checker Script")]
    private AvailablePlaceChecker _availablePlaceChecker;

    /// <summary>
    /// Method called on start to join the room.
    /// </summary>
    private void Start()
    {
        JoinRoom();
    }

    /// <summary>
    /// Method used to join the defult room.
    /// </summary>
    private void JoinRoom()
    {
        RoomOptions Newoptipons = new RoomOptions();
        Newoptipons.MaxPlayers = (byte)_maxNumberOfPlayers;
        PhotonNetwork.GameVersion = _gameVersion;
        PhotonNetwork.JoinOrCreateRoom(_roomName, Newoptipons, TypedLobby.Default);
        LoadingScreen.Instance.ShowLoading(true);
    }

    /// <summary>
    /// Method triggered when player joined room successfully.
    /// </summary>
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("Player", _availablePlaceChecker.GetAvailablePlaceToSpawn(), Quaternion.identity);
        LoadingScreen.Instance.ShowLoading(false);
    }

    /// <summary>
    /// Method called when player click escape and leave the room.
    /// </summary>
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        LoadingScreen.Instance.ShowLoading(true);
    }

    /// <summary>
    /// Method called when player left the room successfully.
    /// </summary>
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene("Lobby");
    }

    /// <summary>
    /// Method called when player death.
    /// </summary>
    public void LeaveRoomAfterSometime()
    {
        StopAllCoroutines();
        StartCoroutine(LeaveRoomAfterSometimeCor());
    }

    /// <summary>
    /// Coroutine used to leave room after some time.
    /// </summary>
    private IEnumerator LeaveRoomAfterSometimeCor()
    {
        yield return new WaitForSeconds(_leaveRoomDelayTimeAfterDeath);
        LeaveRoom();
    }

}