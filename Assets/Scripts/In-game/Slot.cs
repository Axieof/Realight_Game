using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string Description;
    public string Type;
    public bool empty;

    public Transform slotIconGO;
    public Sprite Icon;

    private void Start()
    {
        slotIconGO = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = Icon;
    }

    //public void UseItem()
    //{
        //wait
    //}
}
