using UnityEngine.EventSystems;

public class birdFoodHandler : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
    }
    #endregion
}
