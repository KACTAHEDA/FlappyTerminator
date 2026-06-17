using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterAudioPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _shootAudioClip;
    [SerializeField] private AudioClip _deathAudioClip;

    private AudioSource _audioSource;
    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.Died += PlayDeathClip;
        _player.Shooted += PlayShootClip;
    }

    private void OnDisable()
    {
        _player.Died -= PlayDeathClip;
        _player.Shooted -= PlayShootClip;
    }

    private void PlayShootClip()
    {
        if (_shootAudioClip != null)
            _audioSource.PlayOneShot(_shootAudioClip);
    }

    private void PlayDeathClip()
    {
        if (_deathAudioClip != null)
            _audioSource.PlayOneShot(_deathAudioClip);
    }
}
