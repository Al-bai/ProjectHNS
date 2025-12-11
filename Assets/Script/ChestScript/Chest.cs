using UnityEngine;

public class Chest : MonoBehaviour
{
    public enum ChestType { Crystal, Tool }
    public ChestType chestType;

    public GameObject crystalItemPrefab;
    public GameObject toolItemPrefab;
    public Transform chestUI; // panel UI chest

    private Animator anim;
    private bool playerNearby = false;
    private bool isOpen = false;

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
        GameObject item = null;

        if (chestType == ChestType.Crystal)
            item = Instantiate(crystalItemPrefab, chestUI);
        else
            item = Instantiate(toolItemPrefab, chestUI);

        item.GetComponent<RectTransform>().localPosition = Vector3.zero;
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
