using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    
    private Transform[] _wayPoints;
    private int _currentPoint;
    private float _distanceToPoint = 0.2f;

    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentPoint].position, _speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, _wayPoints[_currentPoint].position) < _distanceToPoint)
        {
            if (_currentPoint < _wayPoints.Length - 1)
            {
                _currentPoint++;
            }
            else
            {
                _currentPoint = 0;
            }

            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}