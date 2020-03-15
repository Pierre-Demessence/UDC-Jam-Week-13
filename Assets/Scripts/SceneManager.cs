using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private readonly Dictionary<SceneAsset, AsyncOperation> _asyncOperations = new Dictionary<SceneAsset, AsyncOperation>();
    private SceneAsset[] _scenesToPreLoad;
    [SerializeField] private SceneAsset _sceneToPreLoad;

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        _scenesToPreLoad = _sceneToPreLoad ? new[] {_sceneToPreLoad} : new SceneAsset[] { };

        _scenesToPreLoad.ForEach(scene =>
        {
            _asyncOperations[scene] = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.name);
            _asyncOperations[scene].allowSceneActivation = false;
            _asyncOperations[scene].completed += o => _asyncOperations.Remove(scene);
        });
    }

    public void LoadScene(SceneAsset scene)
    {
        if (_asyncOperations.ContainsKey(scene)) _asyncOperations[scene].allowSceneActivation = true;
        else UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }
}