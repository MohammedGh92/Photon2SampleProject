using UnityEngine;

public class AvailablePlaceChecker : MonoBehaviour
{

    /// <summary>
    /// Reference to start searching position.
    /// </summary>
    [SerializeField]
    [InspectorName("Start Position")]
    private Vector2 _startPosition = new Vector2(-14,12);

    /// <summary>
    /// The radius of searching area.
    /// </summary>
    [SerializeField]
    [InspectorName("Overlape Circle Radius")]
    private float _overlapeCircleRadius=0.75f;

    /// <summary>
    /// The amount of shifting to right when there is player around.
    /// </summary>
    [SerializeField]
    [InspectorName("Right Shift Amount")]
    private float _rightShiftAmount=4;

    /// <summary>
    /// The amount of shifting to down when there is player around.
    /// </summary>
    [SerializeField]
    [InspectorName("Down Shift Amount")]
    private float _downShiftAmount = 2;


    /// <summary>
    /// Function used to get the available vector starting from top left.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetAvailablePlaceToSpawn()
    {

        //I've created an algorithem to search for available place for players to spawn at and not spawn over each others,
        //but based on your requeirments you need a random position to spawn, so I returned a random position and commented other codes.
        return new Vector2(Random.RandomRange(-14,14),Random.RandomRange(-12,12));

        //transform.position = new Vector2(_startPosition.x, _startPosition.y);
        //Vector2 _returnedVect = transform.position;

        //bool ThereIsPlayerAround = true;

        //while (ThereIsPlayerAround)
        //{
        //    Collider2D[] ResultColliders = Physics2D.OverlapCircleAll(transform.position, _overlapeCircleRadius);
        //    if (IsTherePlayerAround(ResultColliders))
        //        transform.position = NextPos();
        //    else
        //    {
        //        _returnedVect = transform.position;
        //        ThereIsPlayerAround = false;
        //        break;
        //    }
        //}

        //return _returnedVect;
    }

    /// <summary>
    /// Function used to get the next position for this position checker.
    /// </summary>
    /// <returns></returns>
    private Vector2 NextPos()
    {

        Vector2 _currentPos = transform.position;
        if (_currentPos.x <= Mathf.Abs(_startPosition.x) -2)
            return new Vector2(_currentPos.x + _rightShiftAmount, _currentPos.y);
        else
            return new Vector2(_startPosition.x, _currentPos.y - _downShiftAmount);


    }


    /// <summary>
    /// Function used to check if there is a player around this checker.
    /// </summary>
    /// <param name="ResultColliders"></param>
    /// <returns></returns>
    private bool IsTherePlayerAround(Collider2D[] ResultColliders)
    {
        for (int i = 0; i < ResultColliders.Length; i++)
        {
            if (ResultColliders[i].tag == "Player")
                return true;
        }
        return false;
    }


}