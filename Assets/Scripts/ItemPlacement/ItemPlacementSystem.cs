using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementSystem : MonoBehaviour
{
    public GameObject mouseIndicator, cellIndicator;
    public ItemPlacementManager itemPlacementManager;
    public Grid grid;
    public GameObject currentInventorySlot;
    
    void Update()
    {
        Vector3 mousePosition = itemPlacementManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        cellIndicator.transform.position = new Vector3(cellIndicator.transform.position.x, mouseIndicator.transform.position.y, cellIndicator.transform.position.z);

        if(cellIndicator.transform.childCount > 0)
        {

            
            if(Input.GetKeyDown(KeyCode.P))
            {
                if(cellIndicator.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>().sharedMaterial.GetColor("_Color") == Color.green)
                {
                    GameObject currentObject = cellIndicator.transform.GetChild(0).gameObject;
                    GameObject mesh = currentObject.transform.GetChild(0).gameObject;
                    GameObject indicator = currentObject.transform.GetChild(1).gameObject;
                    
                    currentObject.transform.parent = grid.gameObject.transform;
                    gameObject.transform.parent.gameObject.SetActive(false);
                    mesh.SetActive(true);
                    indicator.SetActive(false);
                    if(!currentObject.GetComponent<CustomTag>().HasTag("Building"))
                    {
                        InventorySlot slotScript = currentInventorySlot.GetComponent<InventorySlot>();
                    
                        slotScript.isPlacable = false;
                        slotScript.DeleteItemBtn();
                    }
                    
                }
                
            }
            
        }
    }
}
