﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string Description;
    public string Type;
    public Sprite Icon;
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    public GameObject playersobject;

    [HideInInspector]
    public GameObject itemManager;

    private Text itemTextDescription;

    public bool playerCurrentObject;

    //Get player and original object position
    //public GameObject player;
    private Vector3 originalPos;

    public float ballDistance = 2f;
    //Snowball throwing parameters
    public float snowballUpForce = 2f;
    public float snowballFrontForce = 2f;
    //Basketball throwing parameters
    public float basketballUpForce = 5f;
    public float basketballFrontForce = 2f;

    public void Start()
    {
        originalPos = this.transform.position;
    }

    public void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                equipped = false;
            }

            if(equipped == false)
            {
                this.gameObject.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (this.Type == "ThrowBall")
                {
                    this.GetComponent<Rigidbody>().useGravity = true;
                    Debug.Log("Throwing Snowball");

                }

                else if (this.Type == "BasketBall")
                {
                    this.GetComponent<Rigidbody>().useGravity = true;
                    this.GetComponent<Rigidbody>().AddForce(0, basketballUpForce, basketballFrontForce);
                    Debug.Log("Kobe");
                }

                Invoke("Return", 5);
            }
        }
    }
    
    public void ItemUsage()
    {
        itemManager = GameObject.FindWithTag("ItemManager");
        int allobjects = itemManager.transform.childCount;

        for (int i = 0; i < allobjects; i++)
        {
            itemManager.transform.GetChild(i).gameObject.SetActive(false);

            if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
            {
                playersobject = itemManager.transform.GetChild(i).gameObject;
                //itemTextDescription = GameObject.Find("Description").GetComponent<Text>();
                //Debug.Log(itemTextDescription);
                //itemTextDescription.text = playersobject.GetComponent<Item>().Description;
            }
        }

        if (Type == "ThrowBall")
        {
            playersobject.SetActive(true);
            playersobject.GetComponent<Rigidbody>().useGravity = false;
            playersobject.GetComponent<Item>().equipped = true;
            Debug.Log("ThrowBall equipped");
        }

        if (Type == "BasketBall")
        {
            playersobject.SetActive(true);
            playersobject.GetComponent<Rigidbody>().useGravity = false;
            playersobject.GetComponent<Item>().equipped = true;
            Debug.Log("BasketBall equipped");
        }
    }

    public void Return()
    {
        Debug.Log("Returning");
        this.transform.position = originalPos;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().useGravity = false;
    }
}
