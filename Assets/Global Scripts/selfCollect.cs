﻿using UnityEngine;
using UnityEngine.UI;

public class selfCollect : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    void Start()
    {
        try 
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        } catch {}
    }
    public virtual void OnMouseDown()
    {
        if (itemButton == null)
            return;
        for (int i = 0; i < inventory.slot.Length; i++)
        {
            if (!inventory.hasItem[i])
            {
                inventory.hasItem[i] = true;
                var color = inventory.slot[i].GetComponent<Image>().material.color;
                color.a = 1.0f;
                Instantiate(itemButton, inventory.slot[i].transform, false);
                Destroy(gameObject);
                GameManager.currentInventoryItems.Add(itemButton);
                break;
            }
        }
    }
}