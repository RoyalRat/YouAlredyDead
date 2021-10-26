using UnityEngine;

public class PlayerMovemed : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [Space]
    [SerializeField] private Transform _targetLook;

    private float _gravity;
    private Rigidbody _rigidbodyb;

    private bool _isGround;

    private void Awake()
    {
        _rigidbodyb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            _targetLook.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(_targetLook);
        }
    }

    public void Move(float x, float z)
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_capsuleCollider.height + _capsuleCollider.radius) / 1.9f;

            _isGround = hit.distance >= check;

            if (_isGround)
            {
                _gravity = -10f;
            }
            else
            {
                _gravity = 0;
            }
        }

        _rigidbodyb.velocity = new Vector3(x * _speedMove, _gravity, z * _speedMove);
    }
}
