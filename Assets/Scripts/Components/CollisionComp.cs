using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public class CollisionComp : MonoBehaviourPunCallbacks
{

    /// <summary>
    /// Event triggered when player collides with another object.
    /// </summary>
    [SerializeField]
    [InspectorName("CollisionWithOtherObject")]
    private UnityEvent _collisionWithOtherObject;

    /// <summary>
    /// Reference to player circle collider.
    /// </summary>
    [SerializeField]
    [InspectorName("Player circle collider 2D")]
    private CircleCollider2D _circleCollider2D;

    /// <summary>
    /// Event triggered when player collision ends.
    /// </summary>
    [SerializeField]
    [InspectorName("CollisionEndsWithOtherObject")]
    private UnityEvent _collisionEndsWithObject;

    /// <summary>
    /// Name of the targeted tag that trigger event when collision happen with them.
    /// </summary>
    [SerializeField]
    [InspectorName("Targeted Tag")]
    private string[] _targetedTags;

    /// <summary>
    /// Method called on the start.
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _circleCollider2D.enabled = true;
    }


    /// <summary>
    /// On Collision with other object.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string targetedTag in _targetedTags)
        {
            if (collision.transform.tag == targetedTag)
            {
                _collisionWithOtherObject.Invoke();

                photonView.RPC("TakeHit",RpcTarget.Others);
            }
        }
    }

    /// <summary>
    /// On Collision ends with other object.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (string targetedTag in _targetedTags)
        {
            if (collision.transform.tag == targetedTag)
                _collisionEndsWithObject.Invoke();
        }
    }

    /// <summary>
    /// Method used to disable player collider.
    /// </summary>
    public void DisablePlayerCollider()
    {
        _circleCollider2D.enabled = false;
    }

}
