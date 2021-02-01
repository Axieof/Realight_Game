using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameTag : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            return;
        }
        SetName();
    }

    private void SetName()
    {
        nameText.text = photonView.Owner.NickName;
    }

}
