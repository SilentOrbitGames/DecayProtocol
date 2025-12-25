using UnityEngine;
using UnityEngine.UI;

public class NightVisionScript : MonoBehaviour
{
    [Header("Night Vision Settings")]
    private Image zoomBar;
    private Image batteryChunks;
    private Camera cam;

    [SerializeField] public float batteryPower = 1.0f; // Full battery power
    [SerializeField] private float drainTime = 2; // Rate at which battery drains per second


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoomBar = GameObject.Find("ZoomBar").GetComponent<Image>();
        batteryChunks = GameObject.Find("BatteryChunks").GetComponent<Image>();
        cam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
    }

    void OnEnable()
    {
        InvokeRepeating("BatteryDrain", drainTime, drainTime); // Start draining battery
        if (zoomBar != null)
        {
            zoomBar.fillAmount = 0.6f; // Set initial zoom bar value
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            // Zoom in
            if (cam.fieldOfView > 10)
            {
                cam.fieldOfView -= 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        { 
            // Zoom out
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        batteryChunks.fillAmount = batteryPower; // Decrease battery chunks over time
    }

    private void BatteryDrain()
    {
        if (batteryPower > 0.0f)
        {
            batteryPower -= 0.25f; // Drain battery power
        }
    }

    public void StopDrain()
    {
        CancelInvoke("BatteryDrain"); // Stop draining battery
    }
}
