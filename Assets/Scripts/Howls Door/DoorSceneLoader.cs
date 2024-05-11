using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneLoader : MonoBehaviour
{
    [Header("Set Start Scene")]
    [Tooltip("First Scene to load on start")]
    [SerializeField]
    int StartLevel = 1;

    [Tooltip("Current Loaded Scene")]
    [SerializeField]
    int CurrentLevel = 1;

    private void Start()
    {
        CurrentLevel = StartLevel;
        SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(CurrentLevel);

        CurrentLevel = 1;
    }

    public void Level2()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(CurrentLevel);

        CurrentLevel = 2;
    }

    public void Level3()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(CurrentLevel);

        CurrentLevel = 3;
    }

    public void Level4()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(CurrentLevel);

        CurrentLevel = 4;
    }
}
