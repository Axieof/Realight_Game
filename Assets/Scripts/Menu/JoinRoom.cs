using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoom : MonoBehaviour
{
    private const string GameVersion = "0.1";

    public void Join()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("JOIN - Joining Random Room");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
