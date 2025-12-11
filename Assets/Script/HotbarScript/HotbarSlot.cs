using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    // Image untuk menampilkan icon item pada slot (drag di Inspector)
    public Image iconImage;

    // Menyimpan reference object item UI yang dimasukkan ke slot
    // kita simpan sebagai GameObject supaya gampang manipulasi (atau null jika kosong)
    private GameObject storedItem = null;

    // Public getter agar HotbarManager bisa mengecek
    public bool IsEmpty()
    {
        return storedItem == null;
    }

    // Dipanggil HotbarManager untuk menaruh item ke slot
    // item: GameObject prefab atau instance UI yang di-drag dari chest
    public void StoreItem(GameObject item)
    {
        if (storedItem != null)
        {
            Debug.LogWarning("Slot sudah terisi!");
            return;
        }

        if (item == null)
        {
            Debug.LogWarning("StoreItem dipanggil dengan item == null");
            return;
        }

        // Set parent ke slot supaya icon menempel pada UI slot
        RectTransform itemRect = item.GetComponent<RectTransform>();
        if (itemRect != null)
        {
            itemRect.SetParent(this.transform, false);
            itemRect.anchoredPosition = Vector2.zero;
            itemRect.localScale = Vector3.one;
        }
        else
        {
            // Jika bukan UI element, kita hanya deactive atau simpan reference
            item.transform.SetParent(this.transform, false);
        }

        // Simpan reference
        storedItem = item;

        // Update iconImage (jika tersedia)
        Image img = item.GetComponent<Image>();
        if (img != null && iconImage != null)
        {
            iconImage.sprite = img.sprite;
            iconImage.enabled = true;
        }
    }

    // Optional: fungsi untuk mengosongkan slot
    public void ClearSlot()
    {
        if (storedItem != null)
        {
            Destroy(storedItem); // atau lepaskan ke parent lain sesuai kebutuhan
            storedItem = null;
        }

        if (iconImage != null) iconImage.enabled = false;
    }
}


