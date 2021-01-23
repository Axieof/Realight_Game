using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    private const string GameVersion = "0.1";
    [SerializeField] private InputField interestInputField = null;
    public string interest;

    public void Update()
    {
        interest = interestInputField.text;
    }

    public void Join()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("JOIN - Joining Random Room");
            TypedLobby interestLobby = new TypedLobby("123", LobbyType.Default);
            PhotonNetwork.JoinRandomRoom(interestLobby);
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
