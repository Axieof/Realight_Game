using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;
    private bool InventoryEnabled;

    // Update is called once per frame
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
}
