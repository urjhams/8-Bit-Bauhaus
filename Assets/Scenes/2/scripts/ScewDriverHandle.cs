using UnityEngine.EventSystems;

public class ScewDriverHandle : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        print(GameManager.currentOverGameObjectName);
        if (GameManager.currentOverGameObjectName.Equals("metal shield"))
        {
            base.destroyObject("scewddriver");
            Destroy(gameObject);
            GameManager.Room2.goal = true;
        }
        else
        {
            base.OnEndDrag(eventData);
        }
    }
    #endregion
}
