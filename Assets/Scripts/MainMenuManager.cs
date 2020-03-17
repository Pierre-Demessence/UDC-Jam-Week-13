using System.Linq;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void DestroyMusic()
    {
        var objs = GameObject.FindGameObjectsWithTag("MainMenuMusic");
        objs.ToList().ForEach(Destroy);
    }
}