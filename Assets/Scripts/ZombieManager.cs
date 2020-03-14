using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ZombieManager : MonoBehaviour
{
    [SerializeField] [Required] private AudioSource _audioSource;
    private IEnumerable<Enemy> _enemies;
    [SerializeField] [Required] private AudioClip _normalMusic;
    private bool _tension;
    [SerializeField] [Required] private AudioClip _tensionMusic;
    private bool Tension
    {
        get => _tension;
        set
        {
            _tension = value;
            _audioSource.clip = Tension ? _tensionMusic : _normalMusic;
            _audioSource.Play();
        }
    }

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();
        Tension = false;
    }

    private void Update()
    {
        if (!Tension && _enemies.Any(enemy => enemy.Target != null)) Tension = true;
        if (Tension && _enemies.All(enemy => enemy.Target == null)) Tension = false;
    }
}