using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerHelper : MonoBehaviour
{
    private static readonly Dictionary<string, AsyncOperation> _asyncOperations = new Dictionary<string, AsyncOperation>();

    public void LoadScene(SceneAsset scene)
    {
        LoadScene(scene.name);
    }

    public void LoadScene(string sceneName)
    {
        if (_asyncOperations.ContainsKey(sceneName))
            _asyncOperations[sceneName].allowSceneActivation = true;
        else
            SceneManager.LoadScene(sceneName);
    }

    public void PreaLoadScene(SceneAsset scene)
    {
        PreLoadScene(scene.name);
    }

    public void PreLoadScene(string sceneName)
    {
        if (_asyncOperations.ContainsKey(sceneName)) throw new Exception($"Scene {sceneName} is already being loaded.");
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        asyncOperation.completed += operation => _asyncOperations.Remove(sceneName);
        _asyncOperations[sceneName] = asyncOperation;
    }
}