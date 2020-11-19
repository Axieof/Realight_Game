using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionTest : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Connecting to server...");
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GamerVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);

        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconencted from server for reason " + cause.ToString());
    }

}
