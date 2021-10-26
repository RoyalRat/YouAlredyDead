using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _playerPosition.position;  
    }

    private void Update()
    {
        transform.position = _playerPosition.position + _offset;
    }
}