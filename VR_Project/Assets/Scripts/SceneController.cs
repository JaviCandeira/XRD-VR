using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private CanvasGroup _canvasGroup;


    public void LoadThisScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
