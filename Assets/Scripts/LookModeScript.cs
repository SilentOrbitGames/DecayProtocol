using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class LookModeScript : MonoBehaviour
{
    [Header("Post Processing Settings")]

    private PostProcessVolume vol;
    private bool nightVisionOn = false;
    private bool flashLightOn = false;
    private Light flashLight; // Reference to the flashlight light component
    [SerializeField] PostProcessProfile standard;
    [SerializeField] PostProcessProfile nightVision;
    [SerializeField] PostProcessProfile inventory;
    [SerializeField] GameObject nightVisionOverlay;
    [SerializeField] GameObject flashlightOverlay;
    [SerializeField] GameObject inventoryMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        flashLight = GameObject.Find("FlashLight").GetComponent<Light>(); // Find the flashlight light component
        flashLight.enabled = false; // Ensure flashlight is initially off
        nightVisionOverlay.SetActive(false);
        flashlightOverlay.SetActive(false);
        inventoryMenu.SetActive(false);
        vol.profile = standard; // Set the initial profile to standard
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) // Toggle night vision with 'N' key
        {
            if(SaveScript.inventoryOpen == false)
            {
                if (nightVisionOn == false)
                {
                    vol.profile = nightVision; // Switch to night vision profile
                    nightVisionOverlay.SetActive(true);
                    nightVisionOn = true;
                    NightVisionOff();
                }
                else if (nightVisionOn == true)
                {
                    vol.profile = standard; // Switch back to standard profile
                    nightVisionOverlay.SetActive(false);
                    nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain(); // Stop draining battery
                    this.gameObject.GetComponent<Camera>().fieldOfView = 60; // Reset FOV to default
                    nightVisionOn = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F)) // Toggle flashlight with 'F' key
        {
            if(SaveScript.inventoryOpen == false)
            {
                if (flashLightOn == false)
                {
                    flashlightOverlay.SetActive(true);
                    flashLight.enabled = true; // Enable the flashlight light component
                    flashLightOn = true;
                    FlashLightOff(); // Check if flashlight battery is drained
                }
                else if (flashLightOn == true)
                {
                    flashlightOverlay.SetActive(false);
                    flashLight.enabled = false; // Disable the flashlight light component
                    flashlightOverlay.GetComponent<FlashLightScript>().StopDrain(); // Stop draining battery
                    flashLightOn = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.I)) // Open inventory with 'I' key
        {
            if(SaveScript.inventoryOpen == false)
            {
                vol.profile = inventory; // Switch to inventory profile
                inventoryMenu.SetActive(true);
                //SaveScript.inventoryOpen = true;

                if (flashLightOn == true)
                {
                    flashlightOverlay.SetActive(false);
                    flashLight.enabled = false; // Disable the flashlight light component
                    flashlightOverlay.GetComponent<FlashLightScript>().StopDrain(); // Stop draining battery
                    flashLightOn = false;
                }
                if (nightVisionOn == true)
                {
                    nightVisionOverlay.SetActive(false);
                    nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain(); // Stop draining battery
                    this.gameObject.GetComponent<Camera>().fieldOfView = 60; // Reset FOV to default
                    nightVisionOn = false;
                }
            }
            else if (SaveScript.inventoryOpen == true)
            {
                vol.profile = standard; // Switch back to standard profile
                inventoryMenu.SetActive(false);
            }
        }

        if (nightVisionOn == true)
        {
            NightVisionOff();
        }

        if (flashLightOn == true)
        {
            FlashLightOff();
        }
    }

    private void NightVisionOff()
    {
        if (nightVisionOverlay.GetComponent<NightVisionScript>().batteryPower <= 0)
        {
            vol.profile = standard; // Switch back to standard profile
            nightVisionOverlay.SetActive(false);
            this.gameObject.GetComponent<Camera>().fieldOfView = 60; // Reset FOV to default
            nightVisionOn = false;
        }
    }

    private void FlashLightOff()
    {
        if (flashlightOverlay.GetComponent<FlashLightScript>().batteryPower <= 0)
        {
            flashlightOverlay.SetActive(false);
            flashLight.enabled = false; // Disable the flashlight light component
            flashlightOverlay.GetComponent<FlashLightScript>().StopDrain(); // Stop draining battery
            flashLightOn = false;
        }
    }
}
