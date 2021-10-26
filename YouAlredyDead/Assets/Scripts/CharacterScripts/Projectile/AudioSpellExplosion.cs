using System.Collections;
using UnityEngine;

public class AudioSpellExplosion : MonoBehaviour
{
    [SerializeField] private AudioSource _beginExplosion;
    [SerializeField] private AudioSource _endExplosion;

    [SerializeField] [Range(0, 2)] private float _timer;

    private void Start()
    {
        StartCoroutine(nameof(AudioTimerOfExplosion));
    }

    private IEnumerator AudioTimerOfExplosion()
    {
        _beginExplosion.Play();

        yield return new WaitForSeconds(_timer);

        _endExplosion.Play();
    }
}
