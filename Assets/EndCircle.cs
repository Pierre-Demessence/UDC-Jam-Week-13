using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EndCircle : MonoBehaviour
{
    [SerializeField] private AudioSource _winSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _winSound.Play();
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}