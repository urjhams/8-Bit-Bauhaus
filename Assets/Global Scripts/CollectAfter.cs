using UnityEngine;
using UnityEngine.UI;

public class CollectAfter : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    void Start()
    {
        try {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        } catch {
            print("the inventory is init in room 1, start from there");
        }
    }
    public virtual void checkCollect()
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
                GameManager.currentInventoryItems.Add(itemButton);
                return;
            }
        }
    }
}
