using UnityEngine;

public class Chest : MonoBehaviour
{
    public enum ChestType { Crystal, Tool }
    public ChestType chestType;

    [Header("Item Prefab")]
    public GameObject crystalItemPrefab;
    public GameObject toolItemPrefab;

    [Header("UI")]
    public Transform chestUI;
    public HotbarManager hotbarManager;

    private Animator anim;
    private bool playerNearby = false;
    private bool isOpen = false;

    // Reference item yang sedang ada di chest
    private GameObject spawnedItem;

    void Start()
    {
        anim = GetComponent<Animator>();
     
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleChest();
        }

        // Ambil item dari chest ke hotbar
        if (isOpen && spawnedItem != null && Input.GetKeyDown(KeyCode.Z))
        {
            TryMoveItemToHotbar();
        }
    }

    void ToggleChest()
    {
        isOpen = !isOpen;
        anim.SetBool("isOpen", isOpen);
       

        if (isOpen)
            SpawnItem();
    }

    void SpawnItem()
    {
        // Cegah spawn ganda
        if (spawnedItem != null) return;

        if (chestType == ChestType.Crystal)
            spawnedItem = Instantiate(crystalItemPrefab, chestUI);
        else
            spawnedItem = Instantiate(toolItemPrefab, chestUI);

        RectTransform rt = spawnedItem.GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.localPosition = Vector3.zero;
            rt.localScale = Vector3.one;
        }
    }

    void TryMoveItemToHotbar()
    {
        if (hotbarManager == null)
        {
            Debug.LogWarning("HotbarManager belum diset!");
            return;
        }

        bool success = hotbarManager.AddItem(spawnedItem);

        if (success)
        {
            spawnedItem = null; // chest kosong
        }
        else
        {
            Debug.Log("Hotbar penuh");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}
