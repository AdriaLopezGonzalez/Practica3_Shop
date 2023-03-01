using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour , IBeginDragHandler , IDragHandler, IEndDragHandler
{
    InventoryItem Item;
    Inventory _inventory;

    [SerializeField]
    Image Image;
    [SerializeField]
    TextMeshProUGUI TextAmount;

    private Transform _mama;

    Canvas _canvas;
    GraphicRaycaster _graphicRaycaster;
    public void OnBeginDrag(PointerEventData eventData)
    {
       
        _mama = transform.parent;

        _canvas = GetComponentInParent<Canvas>();
        _graphicRaycaster = _canvas.GetComponent<GraphicRaycaster>();

        transform.SetParent(_canvas.transform, true);
        transform.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)
    {
    
        transform.localPosition += new Vector3(
            eventData.delta.x / transform.lossyScale.x,
            eventData.delta.y / transform.lossyScale.y,
            0);

       

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(eventData, results);

        foreach (var result in results)
        {
            //Debug.Log(result.gameObject.name);
        }


        RaycastHit2D rayData = Physics2D.GetRayIntersection(
            Camera.main.ScreenPointToRay(Input.mousePosition));

        if (rayData)
        {
            //aqui estava lo del personatge
        }

        transform.SetParent(_mama);
        transform.localPosition = Vector3.zero;

    }

    public void SetStuff(InventorySlot slot)
    {
        Item = slot.Item;
        Image.sprite = slot.Item.ImageUI;
        TextAmount.text = slot.Amount.ToString();
        _inventory = slot.Inventory;
    }

   
    
}
