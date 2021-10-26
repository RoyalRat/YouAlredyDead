using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _dmg;

    private void Awake()
    {
        StartCoroutine(nameof(DestroyProjectile));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Damageble") && collision.gameObject.name != "Player")
        {
            GameObject explosion = Instantiate(_prefab, collision.transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<Health>().TakeDamage(_dmg);
            Destroy(gameObject);
        }
        else Destroy(gameObject);
    }

    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
