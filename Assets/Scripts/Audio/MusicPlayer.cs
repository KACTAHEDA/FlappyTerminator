using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private AudioClip _gameOverMenueClip;
    [SerializeField] private AudioClip _gameClip;

    private void Awake()
    {
        _musicSource.loop = true;
    }

    public void PlayGameClip()
    {
        if (_gameClip == null || _musicSource == null)
            return;

        _musicSource.clip = _gameClip;
        _musicSource.Play();
    }

    public void PlayGameOverClip()
    {
        if (_gameOverMenueClip == null)
            return;

        _musicSource.clip = _gameOverMenueClip;
        _musicSource.Play();
    }
}
