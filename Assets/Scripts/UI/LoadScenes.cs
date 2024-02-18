using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEditor;

public class LoadScenes : MonoBehaviour
{
    public void LoadScene(int s)
    {
        SceneManager.LoadScene(s);
    }
}
