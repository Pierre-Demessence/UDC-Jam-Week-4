using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerHelper : MonoBehaviour
{
    public void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}