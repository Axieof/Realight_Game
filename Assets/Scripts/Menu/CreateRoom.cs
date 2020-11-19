using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Create()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Conencted to Photon!");
            OnCreateClicked();
        }
        else
        {
            Debug.Log("Not connected to Photon");
        }
    }

    public void OnCreateClicked()
    {
        PhotonNetwork.CreateRoom("TestHangout");
    }
}
