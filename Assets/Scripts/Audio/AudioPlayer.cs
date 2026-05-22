using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [SerializeField] private AudioClip _playerShootClip;
    [SerializeField] private AudioClip _playerDeathClip;
    [SerializeField] private AudioClip _enemyShootClip;
    [SerializeField] private AudioClip _enemyDeathClip;

    [SerializeField] private AudioClip _mainMenuClip;
    [SerializeField] private AudioClip _gameOverMenueClip;
    [SerializeField] private AudioClip _gameClip;

    public static AudioPlayer Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayPlayerShootClip()
    {
        if (_playerShootClip == null)
            return;
        
            _sfxSource.PlayOneShot(_playerShootClip);
    }

    public void PlayPlayerDeathClip()
    {
        if (_playerDeathClip == null)
            return;

        _sfxSource.PlayOneShot(_playerDeathClip);
    }

    public void PlayEnemyShootClip()
    {
        if (_enemyShootClip == null)
            return;

        _sfxSource.PlayOneShot(_enemyShootClip);
    }

    public void PlayEnemyDeathClip()
    {
        if (_enemyDeathClip == null)
            return;

        _sfxSource.PlayOneShot(_enemyDeathClip);
    }

    public void PlayMainMenuClip()
    {
        if (_mainMenuClip == null || _musicSource == null)
            return;

        _musicSource.clip = _mainMenuClip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayGameClip()
    {
        if (_gameClip == null || _musicSource == null)
            return;

        _musicSource.clip = _gameClip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayGameOverClip()
    {
        if (_gameOverMenueClip == null)
            return;

        _musicSource.clip = _gameOverMenueClip;
        _musicSource.loop = true;
        _musicSource.Play();
    }
}
