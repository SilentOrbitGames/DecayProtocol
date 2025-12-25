using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    [Header("Inventory Switch Settings")]
    [SerializeField] GameObject weaponPanel, itemsPanel, combinePanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponPanel.SetActive(true);
        itemsPanel.SetActive(false);
    }

    public void SwitchToItemsOn()
    {
        weaponPanel.SetActive(false);
        itemsPanel.SetActive(true);
        combinePanel.SetActive(false);
    }

    public void SwitchToWeaponsOn()
    {
        weaponPanel.SetActive(true);
        itemsPanel.SetActive(false);
        combinePanel.SetActive(false);
    }
}
