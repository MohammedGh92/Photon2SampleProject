using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class VisualComp : MonoBehaviour
{

    /// <summary>
    /// Reference to player name text component.
    /// </summary>
    [SerializeField]
    [InspectorName("PlayerNameText")]
    private TextMeshPro _playerNameText;

    /// <summary>
    /// Reference to player death particle gameobject.
    /// </summary>
    [SerializeField]
    [InspectorName("Death Particle")]
    private GameObject _deathParticle;


    /// <summary>
    /// Reference to player sprite renderer.
    /// </summary>
    [SerializeField]
    [InspectorName("Player Sprite")]
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// Method called on the start.
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _spriteRenderer.enabled = true;
    }

    /// <summary>
    /// Method used to set player name text.
    /// </summary>
    public void SetPlayerName()
    {
        _playerNameText.SetText("Me");
    }

    /// <summary>
    /// Method used to hide player sprite.
    /// </summary>
    public void HidePlayerSprite()
    {
        _spriteRenderer.enabled = false;
    }

    /// <summary>
    /// Method used to show player death particle.
    /// </summary>
    public void ShowDeathParticle()
    {
        _deathParticle.SetActive(true);
    }

  
}
