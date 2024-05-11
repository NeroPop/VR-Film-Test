using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [Header("Set Start Scene")]
    [Tooltip("Current Loaded Scene")]
    [SerializeField]
    int StartLevel = 1;

    [Header("These values are set automatically when game starts")]

    [Tooltip("Previous Loaded Scene")]
    [SerializeField]
    int PrevLevel = 0;

    [Tooltip("Current Loaded Scene")]
    [SerializeField]
    int CurrentLevel = 0;

    [Tooltip("Next Loaded Scene")]
    [SerializeField]
    int NextLevel = 0;

    [Tooltip("Maximum number of Scenes")]
    [SerializeField]
    int MaxLevel;

    private void Start()
    {
        //Sets the current level to the start level
        CurrentLevel = StartLevel;

        //Finds the number of scenes in the build so we don't exceed it.
        MaxLevel = SceneManager.sceneCountInBuildSettings;

        //Loads the current selected scene additvely on start and sets next/prev fields
        if (CurrentLevel > 0)
        {
            if (CurrentLevel < MaxLevel)
            {
                SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);

                PrevLevel = CurrentLevel - 1;
                NextLevel = CurrentLevel + 1;
            }

            //If the current level is set above the max level then it loads the last scene.
            else
            {
                CurrentLevel = MaxLevel -1;
                PrevLevel = CurrentLevel - 1;
                NextLevel = CurrentLevel + 1;

                SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);
            }
        }

        //If the current scene is set to master then it will automatically start scene 1 and set the levels
        else
        {
            CurrentLevel = 1;
            PrevLevel = 0;
            NextLevel = 2;

            SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);
        }
    }

    public void NextScene()
    {
        //Checks that there is a next scene to go to
        if(NextLevel < MaxLevel)
        {
            // Loads the next scene
            SceneManager.LoadScene(NextLevel, LoadSceneMode.Additive);

            //Deletes the current scene if its not master
            if (CurrentLevel > 0)
            {
                SceneManager.UnloadSceneAsync(CurrentLevel);
            }

            //Updates the current, next and previous scene values.
            NextLevel += 1;
            PrevLevel += 1;
            CurrentLevel += 1;
        }
    }

    public void PrevScene()
    {
        //Checks that the previous level isn't master
        if (PrevLevel > 0)
        {
            //Loads the previous scene and Unloads the current scene
            SceneManager.LoadScene(PrevLevel, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurrentLevel);

            //Updates the current, next and previous scene values.
            NextLevel -= 1;
            PrevLevel -= 1;
            CurrentLevel -= 1;
        }
    }

    public void Restart()
    {
        //Sets the current level to the start level
        CurrentLevel = StartLevel;

        //Loads the current selected scene additvely on start and sets next/prev fields
        if (CurrentLevel > 0)
        {
            if (CurrentLevel < MaxLevel)
            {
                SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);

                PrevLevel = CurrentLevel - 1;
                NextLevel = CurrentLevel + 1;
            }

            //If the current level is set above the max level then it loads the last scene.
            else
            {
                CurrentLevel = MaxLevel - 1;
                PrevLevel = CurrentLevel - 1;
                NextLevel = CurrentLevel + 1;

                SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);
            }
        }

        //If the current scene is set to master then it will automatically start scene 1 and set the levels
        else
        {
            CurrentLevel = 1;
            PrevLevel = 0;
            NextLevel = 2;

            SceneManager.LoadScene(CurrentLevel, LoadSceneMode.Additive);
        }
    }
}
