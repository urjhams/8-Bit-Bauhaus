using UnityEngine.EventSystems;

public class ScewDriverHandle : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.currentOverGameObjectName.Equals("metal shield"))
        {
            base.destroyObject("scewdriver");
            Destroy(gameObject);
            GameManager.Room2.goal = true;
        }
        base.OnEndDrag(eventData);
    }
    #endregion
}
