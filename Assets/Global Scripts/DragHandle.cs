using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
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
    public void resetStartPosition() {
        item = null;
        transform.position = startPosition;
    }
    public void destroyObject() {
        Destroy(gameObject);
    }
}
