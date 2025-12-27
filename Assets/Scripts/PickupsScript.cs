using UnityEngine;
using UnityEngine.UI;

public class PickupsScript : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] public LayerMask excludeLayers;
    [SerializeField] public GameObject pickupPanel;
    [SerializeField] public Image mainImage;
    [SerializeField] public Sprite[] weaponIcons;
    [SerializeField] public Text mainTitle;
    [SerializeField] public string[] weaponTitles;

    private int objID = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 30, ~excludeLayers))
        {
            if (hit.transform.gameObject.CompareTag("weapon"))
            {
                pickupPanel.SetActive(true);
                objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chooseWeapon;
                mainImage.sprite = weaponIcons[objID];
                mainTitle.text = weaponTitles[objID];
            }
            else
            {
                pickupPanel.SetActive(false);
            }
        }
    }
}
