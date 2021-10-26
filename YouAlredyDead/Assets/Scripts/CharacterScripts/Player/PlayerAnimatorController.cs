using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public bool IsMove { get; private set; }

    [SerializeField] private Health _HP;
    [SerializeField] private GameObject _prefabDeathExplosion;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _HP.OnDeath += DeathAnimation;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _anim.SetBool("isMove", true);
            IsMove = true;
        }
        else
        {
            _anim.SetBool("isMove", false);
            IsMove = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("Attack");
        }
    }

    private void DeathAnimation()
    {
        if (_HP.IsAlive)
        {
            GameObject exp = Instantiate(_prefabDeathExplosion, transform.position, Quaternion.identity);
            _anim.SetTrigger("isDeath");
        }
    }
}
