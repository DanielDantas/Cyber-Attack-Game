using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    private float[] offset = { 0, .05f, .1f, .2f, .25f, .3f };
    private int i = 0;
    private bool offsetForward = true;


    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            ChangeScene("Main");
        }
        transform.position = new Vector3(0, -3 + offset[i/5], 0);
        if (offsetForward)
        {
            i++;
            if (i >= offset.Length * 5)
            {
                i--;
                offsetForward = false;
            }
        }
        else
        {
            i--;
            if (i < 0)
            {
                i++;
                offsetForward = true;
            }
        }

    }


    public void ChangeScene(String scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
