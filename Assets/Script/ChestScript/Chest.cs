using UnityEngine;

public class Chest : MonoBehaviour
{
    public enum ChestType
    {
        Crystal,
        Tool
    }

    public ChestType chestType;

    private Animator anim;
    private bool isOpen = false;
    private bool playerNearby = false;

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
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        if (chestType == ChestType.Crystal)
        {
            Debug.Log("Chest mengeluarkan CRYSTAL");
        }
        else if (chestType == ChestType.Tool)
        {
            Debug.Log("Chest mengeluarkan TOOL REPAIR");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
