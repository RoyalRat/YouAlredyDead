using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(nameof(DestroyPS));
    }

    private IEnumerator DestroyPS()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
