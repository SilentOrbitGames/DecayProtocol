using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsUIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] public GameObject pistolPanel;
    [SerializeField] public GameObject shotgunPanel;
    [SerializeField] public GameObject sprayPanel;

    [Header("UI Texts")]
    [SerializeField] public Text pistolTotalAmmo;
    [SerializeField] public Text pistolCurrentAmmo;
    [SerializeField] public Text shotgunTotalAmmo;
    [SerializeField] public Text shotgunCurrentAmmo;

    private bool panelOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pistolPanel.SetActive(false);
        shotgunPanel.SetActive(false);
        sprayPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.weaponID == 4)
        {
            if(panelOn == false)
            {
                panelOn = true;
                pistolPanel.SetActive(true);   
            }
        }
        if (SaveScript.weaponID == 5)
        {
            if (panelOn == false)
            {
                panelOn = true;
                shotgunPanel.SetActive(true);
            }
        }
        if (SaveScript.weaponID == 6)
        {
            if (panelOn == false)
            {
                panelOn = true;
                sprayPanel.SetActive(true);
            }
        }
        if (SaveScript.inventoryOpen == true)
        {
            panelOn = false;
            pistolPanel.SetActive(false);
            shotgunPanel.SetActive(false);
            sprayPanel.SetActive(false);
        }
    }

    private void OnGUI()
    {
        pistolTotalAmmo.text = SaveScript.ammoAmts[0].ToString();
        shotgunTotalAmmo.text = SaveScript.ammoAmts[1].ToString();
        pistolCurrentAmmo.text = SaveScript.currentAmmo[4].ToString();
        shotgunCurrentAmmo.text = SaveScript.currentAmmo[5].ToString();
    }
}
