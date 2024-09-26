using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ColorPicker : MonoBehaviour, IPointerClickHandler
{
    public Color output;
    public UnityEvent changeColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        output = Pick(Camera.main.WorldToScreenPoint(eventData.position), GetComponent<Image>());
        if(changeColor != null)
        {
            changeColor.Invoke();
        }
    }

    Color Pick(Vector2 screenPoint, Image imageToPick)
    {
        Vector2 point;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageToPick.rectTransform, screenPoint, Camera.main, out point);
        point += imageToPick.rectTransform.sizeDelta / 2;
        Texture2D texture = GetComponent<Image>().sprite.texture;
        Vector2Int m_point = new Vector2Int((int)((texture.width * point.x) / imageToPick.rectTransform.sizeDelta.x), (int)((texture.height * point.y) / imageToPick.rectTransform.sizeDelta.y));
        return texture.GetPixel(m_point.x, m_point.y);
    }

    
}
