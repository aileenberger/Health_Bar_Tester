using UnityEngine;
using UnityEngine.SceneManagement;

namespace _06_Scripts
{
    public class CreditsManager : MonoBehaviour
    {
        public void LoadHealthBarTester()
        {
            SceneManager.LoadScene("00_Scenes/HealthBarTester");
        }
    }
}