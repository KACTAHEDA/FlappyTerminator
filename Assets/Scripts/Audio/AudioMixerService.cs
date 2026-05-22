using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerService : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private float _muteValue = -80f;
    private float _linerToDbMultiplier = 20f;

    public void SetVolume(string param, float value)
    {
        if(value <= 0)
        {
            _audioMixer.SetFloat(param, _muteValue);
            return;
        }

        float db = Mathf.Log10(value) * _linerToDbMultiplier;
        _audioMixer.SetFloat(param, db);
    }
}
