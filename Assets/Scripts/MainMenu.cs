using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject MainMenuCanvas = null;
    [SerializeField] private GameObject JoinedPanel = null;
    [SerializeField] private GameObject JoinedCanvas = null;
    [SerializeField] private GameObject JoinedCode = null;
    [SerializeField] private GameObject CreateInterest = null;

    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 4;
    public Player masterClientPlayer;

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("CONNECT - Connected to Photon network");
        }
        else
        {
            Debug.Log("CONNECT - Connecting to Photon Network");
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void Create()
    {
        MainMenuCanvas.SetActive(false);
        CreateInterest.SetActive(true);
    }

    public void Join()
    {
        MainMenuCanvas.SetActive(false);
        JoinedCanvas.SetActive(true);

        /*
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
        */
    }

    public void JoinCode()
    {
        JoinedCanvas.SetActive(false);
        JoinedCode.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("JOINFAIL - Joining random room failed, error: " + message);

        //TODO: Return to main screen
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            PhotonNetwork.LoadLevel(2);
        }
        Debug.Log("JOINEDROOM - Client successfully joined a room");
        JoinedPanel.SetActive(true);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("PLAYERENTER - Player Joining Room");
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("MASTER - Connected To Master");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //TODO: Add a disconenct screen to set active
        Debug.Log($"DISCONNECTED - Disconnected due to: {cause}");
    }
}
