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
    [SerializeField] private InputField codeInputfield = null;
    [SerializeField] private Button JoinCodeButton = null;
    public string interest;
    public string code;

    public void Update()
    {
        interest = interestInputField.text;
        code = codeInputfield.text;

        if (string.IsNullOrEmpty(code))
        {
            JoinCodeButton.interactable = false;
        }
        else
        {
            JoinCodeButton.interactable = true;
        }
    }

    public void Join()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.LogFormat("Region {0}", PhotonNetwork.NetworkingClient.CloudRegion);
            Debug.Log("JOIN - Joining Random Room");
            TypedLobby interestLobby = new TypedLobby(interest, LobbyType.Default);
            PhotonNetwork.JoinRandomRoom(null, 10, MatchmakingMode.RandomMatching, interestLobby, null, null);
            Debug.Log("JOIN - Attempting to join");
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void JoinWithCode()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.LogFormat("Region {0}", PhotonNetwork.NetworkingClient.CloudRegion);
            Debug.Log("JOIN - Joining Private Room");
            Debug.LogFormat("Code is: {0}", code);
            TypedLobby codeLobby = new TypedLobby(code, LobbyType.Default);
            PhotonNetwork.JoinRandomRoom(null, 10, MatchmakingMode.RandomMatching, codeLobby, null, null);
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
