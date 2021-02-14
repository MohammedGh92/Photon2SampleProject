using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class HealthComp : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Player health amount.
    /// </summary>
    [SerializeField]
    [InspectorName("Health")]
    private int _health;

    /// <summary>
    /// Delay time between every hit.
    /// </summary>
    [SerializeField]
    [InspectorName("Delay Time Hits")]
    private float _delayTimeHits;

    /// <summary>
    /// Key to start taking damage.
    /// </summary>
    private bool _takingDamage=false;

    /// <summary>
    /// On player death event
    /// </summary>
    [SerializeField]
    public UnityEvent OnPlayerDeath;


    /// <summary>
    /// Method called on the start.
    /// </summary>
    /// <returns></returns>
    private void Start()
    {
        StartCoroutine(DelayTimeBetweenEveryHitsCor());
    }

    /// <summary>
    /// Triggered when player take damage and collides with other players.
    /// </summary>
    [PunRPC]
    public void TakeHit()
    {
        if (!_takingDamage)
            return;
        StopAllCoroutines();
        StartCoroutine(DelayTimeBetweenEveryHitsCor());
        _health -= 1;
        if (IsDead())
            OnPlayerDeath.Invoke();
    }

    private IEnumerator DelayTimeBetweenEveryHitsCor()
    {
        _takingDamage = false;
        yield return new WaitForSeconds(_delayTimeHits);
        _takingDamage = true;
    }

    /// <summary>
    /// Check if the player is dead or not.
    /// </summary>
    /// <returns></returns>
    private bool IsDead()
    {
        return _health == 0;
    }

}