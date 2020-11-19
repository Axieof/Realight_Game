using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void Join()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Conencted to Photon!");
            PhotonNetwork.JoinRandomRoom();
            Debug.Log(PhotonNetwork.CurrentRoom.Name);
        }
        else
        {
            Debug.Log("Not connected to Photon");
        }
    }

    
}
