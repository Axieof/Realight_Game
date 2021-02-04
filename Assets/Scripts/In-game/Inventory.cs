using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private bool InventoryEnabled;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject Slotholder;

    void Start()
    {
        //var Slotholder = GameObject.FindWithTag("Inventory");

        allSlots = 12;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            //Debug.Log(Slotholder);
            slot[i] = Slotholder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
            //check all object and set all slots to empty at start of game
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryEnabled = !InventoryEnabled;

            if (InventoryEnabled == true)
            {
                inventory.SetActive(true);
            }

            else
            {
                inventory.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collected");

        if (other.tag == "Items")
        {
            GameObject itempickedup = other.gameObject;
            Item item = itempickedup.GetComponent<Item>();

            addItem(itempickedup, item.ID, item.Type, item.Description, item.Icon);
        }
    }

    void addItem(GameObject itemobject, int id, string type, string description, Sprite icon) 
    {
        for (int i = 0; i < allSlots; i++)
        {
            //Debug.Log(slot[i].GetComponent<Slot>().empty);
            if (slot[i].GetComponent<Slot>().empty)
            {
                //ADD ITEM
                itemobject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().Icon = icon;
                slot[i].GetComponent<Slot>().item = itemobject;
                slot[i].GetComponent<Slot>().ID = id;
                slot[i].GetComponent<Slot>().Description = description;
                slot[i].GetComponent<Slot>().Type = type;

                itemobject.transform.parent = slot[i].transform;
                itemobject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
        }
    }
}
