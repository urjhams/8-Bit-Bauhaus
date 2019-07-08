using UnityEngine.EventSystems;

public class KeyHandle : DragHandle
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        #region  IEndDragHAndler implementation
        if (GameManager.currentOverGameObjectName.Equals("detail_finalBox_discover"))
        {
            base.destroyObject("key");
            Destroy(gameObject);
            GameManager.Room1Basement.goal = true;
        }
        base.OnEndDrag(eventData);
    }
    #endregion
}
