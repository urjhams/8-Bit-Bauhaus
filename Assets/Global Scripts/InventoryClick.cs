using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryClick : MonoBehaviour
{
    public GameObject inventoryFrame;
    public void onInventoryClick() {
        print("clicked");
        inventoryFrame.SetActive(!inventoryFrame.activeSelf);
    }
}
