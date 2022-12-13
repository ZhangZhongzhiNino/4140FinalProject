using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Test Trigger Stay");
    }
}
