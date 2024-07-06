using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    private bool check;
    public void ToggleBool()
    {
        if (check)
        {
            gameObject.SetActive(false);
            check = false;
        }
        else if (!check)
        {
            gameObject.SetActive(true);
            check = true;
        }
    }
}
