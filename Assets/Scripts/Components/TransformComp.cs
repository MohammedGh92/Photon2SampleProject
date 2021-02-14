using System.Collections;
using UnityEngine;
using Photon.Pun;

public class TransformComp : MonoBehaviourPunCallbacks, IPunObservable
{

    /// <summary>
    /// Reference to store the current poistion of player.
    /// </summary>
    private Vector3 _position;
    /// <summary>
    /// 
    /// </summary>
    private float _smoothness = 10f;

    /// <summary>
    /// On start method, used to start updating other players transform data.
    /// </summary>
    void Start()
    {
        if(!photonView.IsMine)
            StartCoroutine("UpdateData");

    }

    /// <summary>
    /// Coroutine used to continuously update players data.
    /// </summary>
    /// <returns></returns>
    IEnumerator UpdateData()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * _smoothness);
            yield return null;
        }
    }

    /// <summary>
    /// Photon method used to receive other players data over the server.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="info"></param>
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            _position = (Vector3)stream.ReceiveNext();
        }
    }

}
