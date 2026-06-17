using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemysAudioPlayer : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private AudioClip _shootAudioClip;
    [SerializeField] private AudioClip _deadAudioClip;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _enemySpawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemySpawned -= OnEnemySpawned;
        
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Dead -= PlayDeadClip;
        enemy.Dead += PlayDeadClip;

        enemy.Shooted -= PlayShootClip;
        enemy.Shooted += PlayShootClip;
    }

    private void PlayShootClip(Enemy _)
    {
        if (_audioSource != null && _shootAudioClip != null)
            _audioSource.PlayOneShot(_shootAudioClip);
    }

    private void PlayDeadClip(Enemy _)
    {
        if (_audioSource != null && _deadAudioClip != null)
            _audioSource.PlayOneShot(_deadAudioClip);
    }
}
