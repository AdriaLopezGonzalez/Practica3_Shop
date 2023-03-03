using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
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

        //este foreach se puede quitar
        foreach (var result in results)
        {
            //Debug.Log(result.gameObject.name);
        }


        RaycastHit2D rayData = Physics2D.GetRayIntersection(
            Camera.main.ScreenPointToRay(Input.mousePosition));

        Debug.Log(rayData.transform);

        if (rayData)
        {
            //saber las shop features
            ShopFeatures currentFeatures = _canvas.GetComponent<InventoryManager>().CurrentFeatures;
            if (CheckItemDrop(currentFeatures, transform.gameObject, rayData))
            {

            }

            //si es que si, cambio parent del objeto y cambio numeros segun precio del objeto
            //si no, parent to mama y todo a su sitio again
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

    private bool CheckItemDrop(ShopFeatures currentFeatures, GameObject dropObject, RaycastHit2D rayData)
    {
        Debug.Log(rayData.transform);
        var possibleDrop = rayData.transform.GetComponent<InventoryUI>();
        bool isAnInventory = possibleDrop != null;
        bool isADifferentInventory = possibleDrop != _mama.GetComponent<InventoryUI>();
        Debug.Log(isADifferentInventory);
        //comprobar si donde dejo el objeto se puede dejar(estamos vendiendo o comprando)
        //comprobar tambien si es tipo de objeto correcto

        return false;
    }



}
