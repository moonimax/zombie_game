using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawAmmorUI : MonoBehaviour
{
    public Text ammorCount;

    // Update is called once per frame
    void Update()
    {
        ammorCount.text = PlayerStats.instance.ammorCount.ToString();
    }
}
