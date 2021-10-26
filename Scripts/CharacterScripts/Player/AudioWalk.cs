    using UnityEngine;

public class AudioWalk : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private PlayerAnimatorController _anim;

    private void Start()
    {
        _anim = GetComponent<PlayerAnimatorController>();
    }

    public void OnWalkAudio()
    {
        if (_anim.IsMove)
        {
            _source.Play();
        }
    }
}
