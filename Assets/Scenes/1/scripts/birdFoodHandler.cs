using UnityEngine;
using UnityEngine.EventSystems;

public class birdFoodHandler : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.currentOverGameObjectName.Equals("bird")) {
            GameManager.Room1Basement.lastPeice = true;
            GameManager.Room1Basement.lastPeiceCutScene = true;
            Destroy(gameObject);
        } else {
            base.OnEndDrag(eventData);
        }
    }
    #endregion
}
