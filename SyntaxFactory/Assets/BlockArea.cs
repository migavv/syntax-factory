using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BlockArea : MonoBehaviour, IDropHandler
{
  public void OnDrop(PointerEventData eventData){

    GameObject dropped = eventData.pointerDrag;
    DraggableBlocks draggableBlocks = dropped.GetComponent<DraggableBlocks>();
    draggableBlocks.parentAfterDrag = transform;

  }
}
