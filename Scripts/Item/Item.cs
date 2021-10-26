using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected int _dropChance;
    public int DropChance => _dropChance;

    protected Transform _player;

    protected delegate void PickedUp();
    protected event PickedUp OnPickedUp;

    private float _pickDistance = 2f;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovemed>().transform;
    }

    protected void ReactionToThePlayer()
    {
        if (CheckProximityPlayer())
        {
            OnPickedUp?.Invoke();
        }
    }

    private bool CheckProximityPlayer()
    {
        return (transform.position - _player.position).sqrMagnitude < _pickDistance * _pickDistance;
    }

    
}
