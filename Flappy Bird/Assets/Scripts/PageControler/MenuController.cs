using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void _ButtonPlay()
    {
        //Application.LoadLevel("PlayScene");
        SceneManager.LoadScene("PlayScene");
    }

}
