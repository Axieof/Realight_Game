using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NetwrokController : MonoBehaviourPunCallbacks
{
    public Text txtStatus = null;
    public GameObject btnStart = null;
    public byte MaxPlayers = 4;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        btnStart.SetActive(false);
        Status("Conencting to Server");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        btnStart.SetActive(true);
        Status("Connected to " + PhotonNetwork.ServerAddress);
        
    }

    private void Status(string msg)
    {
        Debug.Log(msg);
        txtStatus.text = msg;
    }
}
