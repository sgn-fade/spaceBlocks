using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public void OnSettingsPressed()
    {
        gameObject.SetActive(true);
    }
    public void OnExitPressed()
    {
        gameObject.SetActive(false);
    }

}
