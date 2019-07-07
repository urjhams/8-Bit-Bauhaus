using UnityEngine.EventSystems;

public class KeyHandle : DragHandle
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        #region  IEndDragHAndler implementation
        if (GameManager.currentOverGameObjectName.Equals("puzzle peice 10"))
        {
            base.destroyObject("key");
            Destroy(gameObject);
            GameManager.Room1Basement.goal = true;
        }
        else
        {
            base.OnEndDrag(eventData);
        }
    }
    #endregion
}
