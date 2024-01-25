using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int slotID;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        PookiePickup pookiePickup = dropped.GetComponent<PookiePickup>();
        //PookieData pookieData = dropped.GetComponent<PookieData>();
        pookiePickup.parentAfterDrag = transform;

        pookiePickup.CheckForGridSlot();
    }
}
