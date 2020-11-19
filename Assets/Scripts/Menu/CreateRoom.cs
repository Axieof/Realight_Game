using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour
{
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 2;
    public Player masterClientPlayer;

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
            PhotonNetwork.SetMasterClient(masterClientPlayer);
            //PhotonNetwork.LoadLevel(1);
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
