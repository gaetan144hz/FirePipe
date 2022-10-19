using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_LoadScene : MonoBehaviour
{

    [SerializeField] private int scene;
    
    public void Load()
    {
        SceneManager.LoadScene(scene);
    }
}