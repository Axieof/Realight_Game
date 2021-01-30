using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 10;
    public Player masterClientPlayer;
    [SerializeField] private Button CreateButton = null;
    [SerializeField] private Button PublicButton = null;
    [SerializeField] private Button PrivateButton = null;
    [SerializeField] private InputField interestInputField = null;
    public string interest;
    public bool publicIsPressed = false;
    public bool privateIsPressed = false;
    public System.Random rdm = new System.Random();


    public void Start()
    {
        PublicButton.interactable = true;
        PrivateButton.interactable = true;
    }

    public void Update()
    {
        interest = interestInputField.text;
        if (string.IsNullOrEmpty(interest) & (publicIsPressed | privateIsPressed))
        {
            CreateButton.interactable = false;
        }
        else
        {
            CreateButton.interactable = true;
        }
    }

    public int GenerateRandomCode()
    {
        int minimum = 1000;
        int maximum = 9999;

        int code = rdm.Next(minimum, maximum);
        //return code;
        return 9999;
    }

    public void publicPressed()
    {
        publicIsPressed = true;
        privateIsPressed = false;

        PublicButton.GetComponent<Image>().color = Color.magenta;
        PrivateButton.GetComponent<Image>().color = Color.white;
    }

    public void privatePressed()
    {
        privateIsPressed = true;
        publicIsPressed = false;

        PrivateButton.GetComponent<Image>().color = Color.magenta;
        PublicButton.GetComponent<Image>().color = Color.white;
    }

    public void interestEntered()
    {
        string interest = interestInputField.text;
    }

    public void Create()
    {
        if (publicIsPressed)
        {
            RoomOptions roomOptions = new RoomOptions()
            {
                IsOpen = true,
                MaxPlayers = MaxPlayersPerRoom,
                CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
            };

            if (PhotonNetwork.IsConnected)
            {
                TypedLobby interestLobby = new TypedLobby(interest, LobbyType.Default);
                PhotonNetwork.CreateRoom("TestRoom", roomOptions, interestLobby);
                Debug.Log("CREATE - Creating a Room");
                PhotonNetwork.SetMasterClient(masterClientPlayer);
                //PhotonNetwork.LoadLevel(1);
                Debug.LogFormat("Region {0}", PhotonNetwork.NetworkingClient.CloudRegion);
            }
            else
            {
                PhotonNetwork.GameVersion = GameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        else if (privateIsPressed)
        {
            RoomOptions roomOptions = new RoomOptions()
            {
                IsOpen = true,
                MaxPlayers = MaxPlayersPerRoom,
                CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
            };

            if (PhotonNetwork.IsConnected)
            {
                int code = GenerateRandomCode();
                string Code = code.ToString();
                Debug.LogFormat("Code is: {0}", code);
                Debug.LogFormat("Interest is: {0}", interest);
                string interestCode = interest + Code;
                Debug.LogFormat("InterestCode is: {0}", interestCode);

                TypedLobby interestLobby = new TypedLobby(interestCode, LobbyType.Default);
                PhotonNetwork.CreateRoom("TestRoom", roomOptions, interestLobby);
                Debug.Log("CREATE - Creating a Room");
                PhotonNetwork.SetMasterClient(masterClientPlayer);
                //PhotonNetwork.LoadLevel(1);
                Debug.LogFormat("Region {0}", PhotonNetwork.NetworkingClient.CloudRegion);
                //Debug.LogFormat("Code is: ", interestCode);
            }
            else
            {
                PhotonNetwork.GameVersion = GameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }   
    }
}
