using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    public void Exit()
    {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
    }
}
