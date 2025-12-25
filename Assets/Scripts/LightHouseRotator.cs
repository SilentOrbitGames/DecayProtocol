using UnityEngine;

public class LightHouseRotator : MonoBehaviour
{
    [Header("LightHouse Settings")]
    [SerializeField] private float rotateSpeed = 3.5f;

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
