using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public void OnClickFinish()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
