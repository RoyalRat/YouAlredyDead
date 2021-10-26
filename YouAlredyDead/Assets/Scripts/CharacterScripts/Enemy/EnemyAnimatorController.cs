using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimatorController : MonoBehaviour
{
    private EnemyFeature _feature;
    private Animator _anim;

    private void Start()
    {
        _feature = GetComponent<EnemyFeature>();
        _anim = GetComponent<Animator>();
    }

    public void AttackAnim()
    {
        if (_feature.Type == EnumEnemyType.Mage)
        {
            _anim.SetTrigger("Spell");
        }
        else
        {
            _anim.SetTrigger("Attack");
        }
    }

    public void WalkAnim(bool isWalk)
    {
        if (isWalk)
        {
            _anim.SetBool("Walk", true);
        }
        else
        {
            _anim.SetBool("Walk", false);
        }
    }
}
