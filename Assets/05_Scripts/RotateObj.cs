using UnityEngine;
using UnityEngine.Serialization;

namespace _05_Scripts
{
    public class RotateObj : MonoBehaviour
    {
        [Header("Accelerometer")]
        [Tooltip("(float accelerometerY * Time.deltaTime)")]
        [SerializeField] private float accelerometerY;
        
        void Update()
        {
            transform.Rotate (0, accelerometerY * Time.deltaTime, 0);
        }
    }
}
