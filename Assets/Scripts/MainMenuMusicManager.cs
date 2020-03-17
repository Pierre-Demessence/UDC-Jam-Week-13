using UnityEngine;

public class MainMenuMusicManager : MonoBehaviour
{
    private void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag("MainMenuMusic");
        if (objs.Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}