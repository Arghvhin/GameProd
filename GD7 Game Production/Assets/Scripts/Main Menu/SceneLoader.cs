using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Add your scene names here
    public string[] sceneNames;

    private int currentSceneIndex = 0;

    public void LoadNextScene()
    {
        // Make sure the currentSceneIndex is valid
        if (currentSceneIndex < sceneNames.Length - 1)
        {
            currentSceneIndex++;
            SceneManager.LoadScene(sceneNames[currentSceneIndex]);
        }
        else
        {
            Debug.LogWarning("No more scenes to load.");
        }
    }
}
