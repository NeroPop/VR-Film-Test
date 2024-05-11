using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneLoader : MonoBehaviour
{
    [Header("Set Start Scene")]
    [Tooltip("Current Loaded Scene")]
    [SerializeField]
    int CurrentLevel = 1;

    private void Start()
    {
        SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);
    }

    public void Level1()
    {
        if (CurrentLevel != 1)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurrentLevel);
            CurrentLevel = 1;
            Debug.Log("Loaded Level" + CurrentLevel);
        }

    }

    public void Level2()
    {
        if (CurrentLevel != 2)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurrentLevel);
            CurrentLevel = 2;
            Debug.Log("Loaded Level" + CurrentLevel);
        }
    }

    public void Level3()
    {
        if (CurrentLevel != 3)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurrentLevel);
            CurrentLevel = 3;
            Debug.Log("Loaded Level" + CurrentLevel);
        }
    }

    public void Level4()
    {
        if (CurrentLevel != 4)
        {
            SceneManager.LoadScene(4, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurrentLevel);
            CurrentLevel = 4;
            Debug.Log("Loaded Level" + CurrentLevel);
        }
    }
}
