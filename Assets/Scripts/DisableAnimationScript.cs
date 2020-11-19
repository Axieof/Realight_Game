using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("LevelLoader").GetComponent<LoadScene>().enabled = false;
    }
}
