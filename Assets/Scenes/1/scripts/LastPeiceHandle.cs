using UnityEngine.EventSystems;

public class LastPeiceHandle : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.currentOverGameObjectName.Equals("correct puzzle peice 10")) {
            Destroy(gameObject);
        } else {
            base.OnEndDrag(eventData);
        }
    }
    #endregion
}
