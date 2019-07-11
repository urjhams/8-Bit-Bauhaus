using UnityEngine;
using UnityEngine.EventSystems;

public class birdFoodHandler : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.currentOverGameObjectName.Equals("bird")) {
            GameObject.Find("bird").GetComponent<Room1BasementMouseControl>().endDetailView();
            GameManager.Room1Basement.lastPeice = true;
            GameManager.Room1Basement.lastPeiceCutScene = true;
            GameManager.Room1Basement.lastPeiceCollected = true;
            base.destroyObject("bird food");
            Destroy(gameObject);
        }
        base.OnEndDrag(eventData);
    }
    #endregion
}
