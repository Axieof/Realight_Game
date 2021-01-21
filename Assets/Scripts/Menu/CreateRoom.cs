using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 2;
    public Player masterClientPlayer;
    [SerializeField] private Button CreateButton = null;
    [SerializeField] private Button PublicButton = null;
    [SerializeField] private Button PrivateButton = null;
    [SerializeField] private InputField interestInputField = null;
    public string interest;
    public bool publicIsPressed = false;
    public bool privateIsPressed = false;

    public void Start()
    {
        PublicButton.interactable = true;
        PrivateButton.interactable = true;
    }

    public void Update()
    {
        interest = interestInputField.text;
        if (string.IsNullOrEmpty(interest) & publicIsPressed | privateIsPressed)
        {
            CreateButton.interactable = false;
        }
        else
        {
            CreateButton.interactable = true;
        }
    }

    public void publicPressed()
    {
        publicIsPressed = true;
        privateIsPressed = false;
    }

    public void privatePressed()
    {
        privateIsPressed = true;
        publicIsPressed = false;
    }

    public void Create()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            IsOpen = true,
            MaxPlayers = MaxPlayersPerRoom,
            CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
        };


        if (publicIsPressed)
        {
            roomOptions.CustomRoomProperties.Add("Exclusive", "public");
        }
        else if (privateIsPressed)
        {
            roomOptions.CustomRoomProperties.Add("Exclusive", "private");
        }

        roomOptions.CustomRoomProperties.Add("Interest", interest);

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

    public void interestEntered()
    {
        string interest = interestInputField.text;
        
    }
}
