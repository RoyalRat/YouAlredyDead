using System.Collections;
using UnityEngine;

public class SpellExplosion : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private void Start()
    {
        StartCoroutine(nameof(Explosion));
    }

    private IEnumerator Explosion()
    {
        _player = FindObjectOfType<PlayerMovemed>().transform;

        yield return new WaitForSeconds(1.3f);

        if (Vector3.Distance(transform.position, _player.position) <= 3f)
        {
            _player.gameObject.GetComponent<Health>().TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
