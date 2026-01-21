using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    public Image iconImage;

    private GameObject storedItem = null;

    public bool IsEmpty()
    {
        return storedItem == null;
    }

    public void StoreItem(GameObject item)
    {
        if (storedItem != null || item == null)
            return;

        RectTransform itemRect = item.GetComponent<RectTransform>();
        if (itemRect != null)
        {
            itemRect.SetParent(transform, false);
            itemRect.anchoredPosition = Vector2.zero;
            itemRect.localScale = Vector3.one;
        }
        else
        {
            item.transform.SetParent(transform, false);
        }

        storedItem = item;

        // Update icon
        Image img = item.GetComponent<Image>();
        if (img != null && iconImage != null)
        {
            iconImage.sprite = img.sprite;
            iconImage.enabled = true;
        }
    }

    public void ClearSlot()
    {
        if (storedItem != null)
        {
            Destroy(storedItem);
            storedItem = null;
        }

        if (iconImage != null)
            iconImage.enabled = false;
    }
}
