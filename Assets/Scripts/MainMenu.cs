using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
