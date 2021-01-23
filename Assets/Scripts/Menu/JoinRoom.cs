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
            Debug.LogFormat("Region {0}", PhotonNetwork.NetworkingClient.CloudRegion);
            Debug.Log("JOIN - Joining Random Room");
            TypedLobby interestLobby = new TypedLobby(interest, LobbyType.Default);
            PhotonNetwork.JoinRandomRoom(null, 2, MatchmakingMode.RandomMatching, interestLobby, null, null);
            Debug.Log("JOIN - Attempting to join");
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("JOINFAIL - Joining random room failed, error: " + message);

        //TODO: Return to main screen
    }
}
