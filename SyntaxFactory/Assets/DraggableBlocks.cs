using UnityEngine.EventSystems;
using UnityEngine;


public class DraggableBlocks : MonoBehaviour,IBeginDragHandler,IDragHandler, IEndDragHandler
{
    public UnityEngine.UI.Image image;
    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
      
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
      
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      
       transform.SetParent(parentAfterDrag);
       image.raycastTarget = true;
    }

    private void SnapToGrid()
    {
        // Implement snapping behavior here (e.g., snap to nearest grid position)
    }
}

