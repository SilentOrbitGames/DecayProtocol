using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{
    [Header("Flashlight Settings")]
    private Image batteryChunks; // Reference to the UI Image that represents the battery chunks
    [SerializeField] public float batteryPower = 1.0f; // Full battery power
    [SerializeField] private float drainTime = 2; // Rate at which battery drains per second]

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        batteryChunks = GameObject.Find("FLBatteryChunks").GetComponent<Image>();
        InvokeRepeating("FLBatteryDrain", drainTime, drainTime); // Start draining battery
    }

    // Update is called once per frame
    void Update()
    {
        batteryChunks.fillAmount = batteryPower; // Decrease battery chunks over time
    }

    private void FLBatteryDrain()
    {
        if (batteryPower > 0.0f)
        {
            batteryPower -= 0.25f; // Drain battery power
        }
    }

    public void StopDrain()
    {
        CancelInvoke("FLBatteryDrain"); // Stop draining battery
    }
}
