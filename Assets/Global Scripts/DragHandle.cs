using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Inventory inventory;
    public static GameObject item;
    Vector3 startPosition;

    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        startPosition = transform.position;
    }
    #endregion

    #region  IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    #endregion

    #region  IEndDragHAndler implementation
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        resetStartPosition();
    }
    #endregion
    public void resetStartPosition()
    {
        item = null;
        transform.position = startPosition;
    }
    public void destroyObject(string name)
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        for (int i = 0; i < inventory.hasItem.Length; i++)
        {
            try
            {
                if (inventory.slot[i].transform.GetChild(0).name.Contains(name))
                {
                    inventory.hasItem[i] = false;
                }
            }
            catch { }
        }
    }
}
