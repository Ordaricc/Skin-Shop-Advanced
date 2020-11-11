using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFunctions : MonoBehaviour
{
    public void ChangeSceneByAddingIndex(int indexToAdd)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + indexToAdd);
    }
}