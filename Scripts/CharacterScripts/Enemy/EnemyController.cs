using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Space]
    [SerializeField] private List<Transform> _chunkEnemyTargets = new List<Transform>();
    [Space]
    [SerializeField] private float _radius;
    [SerializeField] private float _radiusAttack;

    private Transform _playerTarget;
    private NavMeshAgent _agent;
    private EnemyAnimatorController _anim;
    private EnemyFeature _feature;
    
    private bool _checkDistance = true;
    private bool _inTransit = false;
    private bool _targetIsPlayer = false;
    private bool _isIdle = false;

    private void Start()
    {
        _feature = GetComponent<EnemyFeature>();
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<EnemyAnimatorController>();

        _playerTarget = FindObjectOfType<PlayerMovemed>().transform;
        ToFindEnemyTargets();

        _target = _chunkEnemyTargets[Random.Range(0, _chunkEnemyTargets.Count)];
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _playerTarget.position) <= _radius)
        {
            _target = _playerTarget;
            _agent.SetDestination(_target.position);
            _agent.stoppingDistance = _radiusAttack;
            _targetIsPlayer = true;
        }

        if (Vector3.Distance(transform.position, _target.position) <= _radiusAttack && _checkDistance)
        {
            _checkDistance = false;
            StartCoroutine(nameof(IdleTimer));
        }
        else
        { 
            _checkDistance = true;
        }

        _anim.WalkAnim(_checkDistance);

        if (_checkDistance && _isIdle == false)
        {
            if (_inTransit == false)
            {
                _agent.SetDestination(_target.position);
                _inTransit = true;
            }
        } 
    }

    private void ToFindEnemyTargets()
    {

        Transform targetParent = transform.root.GetChild(0);

        int targetsCount = targetParent.transform.childCount;

        for (int i = 0; i < targetsCount; i++)
        {
            _chunkEnemyTargets.Add(targetParent.GetChild(i));
        }
    }

    private IEnumerator IdleTimer()
    {
        if(_isIdle == false)
        {
            _isIdle = true;

            _target = _chunkEnemyTargets[Random.Range(0, _chunkEnemyTargets.Count)];

            if (_targetIsPlayer)
            {
                _anim.AttackAnim();
                yield return new WaitForSeconds(_feature.AttackSpeedVolume);
            }
            else
                yield return new WaitForSeconds(Random.Range(2f, 3f));
        }

        _inTransit = false;
        _isIdle = false;
    }
}