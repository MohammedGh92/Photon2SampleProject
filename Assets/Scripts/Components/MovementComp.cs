using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComp : MonoBehaviour
{

    /// <summary>
    /// 2D Rigidbody attached to our player.
    /// </summary>
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    /// <summary>
    /// Condition to check if player can move or not.
    /// </summary>
    private bool _canMove=true;


    /// <summary>
    /// The speed of our player.
    /// </summary>
    [SerializeField]
    [InspectorName("Speed")]
    private float _speed;

    /// <summary>
    /// Reference to the current player moving direction.
    /// </summary>
    private Directions _currentMovingDirection;

    /// <summary>
    /// Subscribe moving methods to direction buttons events.
    /// </summary>
    public void SubscribeToDirectionBTNS()
    {
        GameController _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _gameController.DirectionButtonClicked += DirButtonClicked;
    }

    /// <summary>
    /// Method called when player press on one of the direction buttons.
    /// </summary>
    /// <param name="MovingDirInt"></param>
    private void DirButtonClicked(int MovingDirInt)
    {
        Move((Directions)MovingDirInt);
    }

    /// <summary>
    /// Method that control the player movement in 8 directions.
    /// </summary>
    /// <param name="MovingDir"></param>
    public void Move(Directions MovingDir)
    {
        if (!_canMove)
            return;

        _currentMovingDirection = MovingDir;
        switch (MovingDir)
        {
            case Directions.UpLeft:
                _rigidbody2D.velocity = new Vector2(_speed * -1, _speed);
                break;

            case Directions.Left:
                _rigidbody2D.velocity = new Vector2(_speed * -1, 0);
                break;

            case Directions.DownLeft:
                _rigidbody2D.velocity = new Vector2(_speed * -1, _speed * -1);
                break;

            case Directions.Down:
                _rigidbody2D.velocity = new Vector2(0, _speed * -1);
                break;

            case Directions.DownRight:
                _rigidbody2D.velocity = new Vector2(_speed * 1, _speed * -1);
                break;

            case Directions.Right:
                _rigidbody2D.velocity = new Vector2(_speed * 1, 0);
                break;

            case Directions.UpRight:
                _rigidbody2D.velocity = new Vector2(_speed * 1, _speed * 1);
                break;

            case Directions.Up:
                _rigidbody2D.velocity = new Vector2(0, _speed);
                break;

            case Directions.Center:
                _rigidbody2D.velocity = Vector2.zero;
                break;

            default: _rigidbody2D.velocity = Vector2.zero; break;

        }
    }

    /// <summary>
    /// Method to stop player from moving and set collision force to zero.
    /// </summary>
    public void StopMoving()
    {
        if(_currentMovingDirection==Directions.Center)
            Move(Directions.Center);
    }

    /// <summary>
    /// Called when player dead to stop anymove.
    /// </summary>
    public void PlayerDeathNoMove()
    {

        Move(Directions.Center);
        _canMove = false;
    }


}
