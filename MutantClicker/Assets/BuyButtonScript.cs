﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonScript : MonoBehaviour
{
    public int displayRate = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Pass current clicker cost as a reference, provide modifier to add on and button reference. Set value accordingly and change text.
    public bool setNewClickerCost(ref int cost, int modifier)
    {
        cost = cost + modifier;

        GetComponentInChildren<Text>().text = "Buy " + gameObject.name + " (Cost = " + cost + " clicks)\n (" + displayRate + " click/s)";
        return true;
    }
}
