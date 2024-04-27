using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField]
    int CurLevel = 1;

    [SerializeField]
    int PrevLevel = 0;

    [SerializeField]
    int NextLevel = 2;

    [SerializeField]
    int MaxLevel;

    private void Start()
    {
        //Loads the current selected scene additvely on start and sets next/prev fields
        if (CurLevel > 0)
        {
            SceneManager.LoadScene(CurLevel, LoadSceneMode.Additive);

            PrevLevel = CurLevel - 1;
            NextLevel = CurLevel + 1;
        }

        //If the current scene is set to master then it will automatically start scene 1 and set the levels
        else
        {
            CurLevel = 1;
            PrevLevel = 0;
            NextLevel = 2;

            SceneManager.LoadScene(CurLevel, LoadSceneMode.Additive);
        }
        //Finds the number of scenes so we don't exceed it.
        MaxLevel = SceneManager.sceneCountInBuildSettings;
    }

    public void NextScene()
    {
        //Checks that there is a next scene to go to
        if(NextLevel < MaxLevel)
        {
            // Loads the next scene
            SceneManager.LoadScene(NextLevel, LoadSceneMode.Additive);

            //Deletes the current scene if its not master
            if (CurLevel > 0)
            {
                SceneManager.UnloadSceneAsync(CurLevel);
            }

            //Updates the current, next and previous scene values.
            NextLevel += 1;
            PrevLevel += 1;
            CurLevel += 1;
        }
    }

    public void PrevScene()
    {
        //Checks that the previous level isn't master
        if (PrevLevel > 0)
        {
            //Loads the previous scene and Unloads the current scene
            SceneManager.LoadScene(PrevLevel, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurLevel);

            //Updates the current, next and previous scene values.
            NextLevel -= 1;
            PrevLevel -= 1;
            CurLevel -= 1;
        }
    }
}
