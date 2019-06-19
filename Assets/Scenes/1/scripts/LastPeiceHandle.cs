using UnityEngine.EventSystems;

public class LastPeiceHandle : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.currentOverGameObjectName.Equals("correct puzzle peice 10")) {
            base.destroyObject("lastPeice");
            Destroy(gameObject);
            GameManager.Room1.goal = true;
        } else {
            base.OnEndDrag(eventData);
        }
    }
    #endregion
}
