using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingMenu : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectVolume;

    private void Start()
    {
        _musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        _effectVolume.value = PlayerPrefs.GetFloat("EffectVolume");
    }

    public void ChangeAudioMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-60, 10, volume));

        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeAudioEffectVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("EffectVolume", Mathf.Lerp(-60, 10, volume));

        PlayerPrefs.SetFloat("EffectVolume", volume);
    }
}
