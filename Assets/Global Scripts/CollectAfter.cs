using UnityEngine;
using UnityEngine.UI;

public class CollectAfter : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    public virtual void Update()
    {
        checkGoal(false);
    }
    public virtual void checkGoal(bool goal)
    {
        if (!goal) {
            return;
        }
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
                gameObject.GetComponent<Collider2D>().enabled = false;
                GameManager.currentInventoryItems.Add(itemButton);
                break;
            }
        }
    }
}
