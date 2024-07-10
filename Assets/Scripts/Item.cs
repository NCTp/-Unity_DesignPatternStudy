using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Item : MonoBehaviour
{
    private enum ItemStates
    {
        Idle,
        Acquired
    }
    private ItemStates itemState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void DoItemEffect()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(itemState)
        {
            case ItemStates.Idle:
            break;
            case ItemStates.Acquired:
            DoItemEffect();
            break;
        }
    }
}
