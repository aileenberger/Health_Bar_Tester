using UnityEngine;
using UnityEngine.Serialization;

namespace _06_Scripts
{
    public class RotateObj : MonoBehaviour
    {
        [Header("Accelerometer")]
        [Tooltip("(float accelerometerY * Time.deltaTime)")]
        [SerializeField] private float accelerometerX;
        [SerializeField] private float accelerometerY;
        [SerializeField] private float accelerometerZ;

        void Update()
        {
            transform.Rotate(0, accelerometerY * Time.deltaTime, 0);
            transform.Rotate(accelerometerX * Time.deltaTime, 0, 0);
            transform.Rotate(0, 0, accelerometerZ * Time.deltaTime);
        }
    }
}
