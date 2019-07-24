using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            ChangeScene("Main");
        }
    }


    public void ChangeScene(String scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
