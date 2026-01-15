using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickupsScript : MonoBehaviour
{
    [Header("Pickup Settings")]
    private RaycastHit hit;
    [SerializeField] public LayerMask excludeLayers;
    [SerializeField] public GameObject pickupPanel;
    [SerializeField] public float pickupDisplayDistance = 3;

    [Header("Pickup UI Settings")]
    [SerializeField] public Image mainImage;
    [SerializeField] public Sprite[] weaponIcons;
    [SerializeField] public Sprite[] itemIcons;
    [SerializeField] public Sprite[] ammoIcons;

    [SerializeField] public Text mainTitle;
    [SerializeField] public string[] weaponTitles;
    [SerializeField] public string[] itemTitles;
    [SerializeField] public string[] ammoTitles;
    [SerializeField] public GameObject doorMessageObj;
    [SerializeField] public Text doorMessage;
    [SerializeField] public AudioClip[] pickupSounds;

    private int objID = 0;
    private AudioSource audioPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupPanel.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
        doorMessageObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //pickupPanel.SetActive(false);
        //doorMessageObj.SetActive(false);

        if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 30, ~excludeLayers))
        {
            if (Vector3.Distance(transform.position, hit.transform.position) < pickupDisplayDistance)
            {
                if (hit.transform.gameObject.CompareTag("weapon"))
                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chooseWeapon;
                    mainImage.sprite = weaponIcons[objID];
                    mainTitle.text = weaponTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.weaponAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("item"))
                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<ItemType>().chooseItem;
                    mainImage.sprite = itemIcons[objID];
                    mainTitle.text = itemTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.itemAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("ammo"))
                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<AmmoType>().chooseAmmo;
                    mainImage.sprite = ammoIcons[objID];
                    mainTitle.text = ammoTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.ammoAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("door"))
                {
                    objID = (int)hit.transform.gameObject.GetComponent<DoorType>().chooseDoor;
                    if(hit.transform.gameObject.GetComponent<DoorType>().locked == true)
                    {
                        hit.transform.gameObject.GetComponent<DoorType>().message = "Locked. Need " + hit.transform.gameObject.GetComponent<DoorType>().chooseDoor + " key";
                    }
                    doorMessage.text = hit.transform.gameObject.GetComponent<DoorType>().message;
                    doorMessageObj.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.GetComponent<DoorType>().locked == false)
                    {
                        audioPlayer.clip = pickupSounds[objID];
                        audioPlayer.Play();

                        if (hit.transform.gameObject.GetComponent<DoorType>().opened == false)
                        {
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Open");
                            hit.transform.gameObject.GetComponent<DoorType>().opened = true;
                            hit.transform.gameObject.GetComponent<DoorType>().message = "[E] Close";
                        }
                        else if (hit.transform.gameObject.GetComponent<DoorType>().opened == true)
                        {
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Close");
                            hit.transform.gameObject.GetComponent<DoorType>().opened = false;
                            hit.transform.gameObject.GetComponent<DoorType>().message = "[E] Open";
                        }
                    }
                }
            }
        }
        else
        {
            pickupPanel.SetActive(false);
            doorMessageObj.SetActive(false);
        }
    }
}
