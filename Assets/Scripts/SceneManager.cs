using UnityEngine;

public class SceneManager : MonoBehaviour
{
    /*
    private readonly Dictionary<SceneAsset, AsyncOperation> _asyncOperations = new Dictionary<SceneAsset, AsyncOperation>();
    private SceneAsset[] _scenesToPreLoad;
    [SerializeField] private SceneAsset _sceneToPreLoad;

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        _scenesToPreLoad = _sceneToPreLoad ? new[] {_sceneToPreLoad} : new SceneAsset[] { };
        foreach (var scene in _scenesToPreLoad) StartCoroutine(PreLoadScene(scene));
    }
    */

    /*
    private IEnumerator PreLoadScene(SceneAsset scene)
    {
        yield return null;
        _asyncOperations[scene] = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.name);
        _asyncOperations[scene].allowSceneActivation = false;
        _asyncOperations[scene].completed += o => _asyncOperations.Remove(scene);
        while (!_asyncOperations[scene].isDone) yield return null;
    }

    public void LoadScene(SceneAsset scene)
    {
        if (_asyncOperations.ContainsKey(scene)) _asyncOperations[scene].allowSceneActivation = true;
        else UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }
    */

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}