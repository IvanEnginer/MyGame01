using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSizeVertical;
    [SerializeField] private float _stepSizeHorizontal;
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _minWidth;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPosition(0, _stepSizeVertical);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPosition(0, -_stepSizeVertical);
    }

    public void TryMoveLeft()
    {
        if (_targetPosition.x > _minWidth)
            SetNextPosition(-_stepSizeHorizontal, 0);
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _maxWidth)
            SetNextPosition(_stepSizeHorizontal, 0);
    }

    private void SetNextPosition(float stepSizeHorizontal, float stepSizeVertical)
    {
        _targetPosition = new Vector3(_targetPosition.x + stepSizeHorizontal, _targetPosition.y + stepSizeVertical);
    }
}
