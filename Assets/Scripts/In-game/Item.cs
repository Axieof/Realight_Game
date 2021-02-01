using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string Description;
    public string Type;
    public Sprite Icon;
    public bool pickedUp;
    public bool Equipped;

    public void Update()
    {
        if (Equipped)
        {
            //do wtv
        }
    }
    
    public void ItemUsage()
    {
        if (Type == "Weapon")
        {
            Equipped = true;
        }
    }
}
