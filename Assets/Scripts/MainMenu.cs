﻿using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject JoinedPanel = null;

    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 3;
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
        PhotonNetwork.ConnectUsingSettings();

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
        RoomOptions roomOptions = new RoomOptions()
        {
            IsOpen = true,
            MaxPlayers = MaxPlayersPerRoom
        };

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.CreateRoom("TestRoom", roomOptions);
            Debug.Log("CREATE - Creating a Room");
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

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

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("JOINFAIL - Joining random room failed, error: " + message);

        //TODO: Return to main screen
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("JOINEDROOM - Client successfully joined a room");
        JoinedPanel.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("PLAYERENTER - Player Joining Room");
        //PhotonNetwork.LoadLevel("PlayerTesting");

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
