using Photon.Pun;
using Photon.Voice.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VoiceConnection))]
public class NetworkVoiceManager : MonoBehaviour
{
    public Transform remoteVoiceParent;

    private VoiceConnection voiceConnection;
    private Recorder voiceRecorder;

    void Awake()
    {
        voiceConnection = GetComponent<VoiceConnection>();
        voiceRecorder = GetComponent<Recorder>();
        Debug.Log("awake");
        //THIS WORKS
    }

    private void OnEnable()
    {
        voiceConnection.SpeakerLinked += this.OnSpeakerCreated;
    }

    private void OnDisable()
    {
        voiceConnection.SpeakerLinked -= this.OnSpeakerCreated;
    }

    private void OnSpeakerCreated(Speaker speaker)
    {
        speaker.transform.SetParent(this.remoteVoiceParent);
        speaker.OnRemoteVoiceRemoveAction += OnRemoteVoiceRemove;
        Debug.Log("Speaker Created");
        //does not work
    }

    private void OnRemoteVoiceRemove(Speaker speaker)
    {
        if (speaker != null)
        {
            Destroy(speaker.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKey("v"))
        {
            voiceRecorder.TransmitEnabled = true;
            //Debug.Log("Pressed");
        }

        else if (Input.GetKeyUp("v"))
        {
            voiceRecorder.TransmitEnabled = false;
            //Debug.Log("Release");
        }
    }
}
