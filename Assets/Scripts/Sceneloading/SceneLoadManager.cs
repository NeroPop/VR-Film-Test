using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField]
    int PrevLevel = 0;

    [SerializeField]
    int CurLevel = 1;

    [SerializeField]
    int NextLevel = 2;


    public void NextScene()
    {
        
        SceneManager.LoadScene(NextLevel, LoadSceneMode.Additive);

        if(CurLevel > 0)
        {
            SceneManager.UnloadSceneAsync(CurLevel);
        }

        NextLevel += 1;
        PrevLevel += 1;
        CurLevel += 1;
    }

    public void PrevScene()
    {
        if (PrevLevel > 0)
        {
            SceneManager.LoadScene(PrevLevel, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurLevel);
            NextLevel -= 1;
            PrevLevel -= 1;
            CurLevel -= 1;
        }
    }
}
