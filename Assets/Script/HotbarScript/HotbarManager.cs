using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public HotbarSlot[] slots;

    public bool AddItem(GameObject item)
    {
        foreach (HotbarSlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.StoreItem(item);
                return true;
            }
        }

        return false;
    }
}

