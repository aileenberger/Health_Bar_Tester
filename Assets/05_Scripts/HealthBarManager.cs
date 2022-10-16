using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _05_Scripts
{
    public class HealthBarManager : MonoBehaviour
    {
        #region Initialization
        // region help to organize
    
        [SerializeField] private TMP_InputField tankAttackInputField;
        [SerializeField] private TMP_InputField crossbowAttackInputField;
        [SerializeField] private TMP_InputField poisonAttackInputField;
        [SerializeField] private TMP_InputField bombAttackInputField;
        [SerializeField] private TMP_InputField shielAttackInputField;
        [SerializeField] private TMP_InputField medikitAttackInputField;

        [SerializeField] private Slider healthBar;

        [SerializeField] private ParticleSystem panzerEffect;
        [SerializeField] private ParticleSystem crossbowEffect;
        [SerializeField] private ParticleSystem poisonEffect;
        [SerializeField] private ParticleSystem bombEffect;
        [SerializeField] private ParticleSystem shieldEffect;
        [SerializeField] private ParticleSystem medikitEffect;

    
        //Identifiers beginning with an underscore
        private float _tankAttackAmount;
        private float _crossbowAttackAmount;
        private float _poisonAttackAmount;
        private float _bombAttackAmount;
        private float _shieldAttackAmount;
        private float _medikitAttackAmount;
    
        // Identifiers beginning with an underscore followed immediately by an uppercase letter
        public float Test = 0.1f;

        // _ (underscore) = avoid collision of names

        #endregion
    
    
        public void TankTest()
        {
            float.TryParse(tankAttackInputField.text, out _tankAttackAmount);

            // if not (_tankAttackAmount > 0 = true) do nothing.
            if (!(_tankAttackAmount > 0)) return;
            healthBar.value -= _tankAttackAmount;
            panzerEffect.Play();
        }
    
    
        public void CrossbowTest()
        {
            float.TryParse(crossbowAttackInputField.text, out _crossbowAttackAmount);
            if (!(_crossbowAttackAmount > 0)) return;
            healthBar.value -= _crossbowAttackAmount;
            crossbowEffect.Play();
        }

    
        public void PoisonTest()
        {
            //TODO: Create PoisonTest function
        }
    
    
        public void BombTest()
        {
            float.TryParse(bombAttackInputField.text, out _bombAttackAmount);
            if (!(_bombAttackAmount > 0)) return;
            healthBar.value -= _bombAttackAmount;
            bombEffect.Play();
        }

    
        public void ShieldTest()
        {
            //TODO: Create ShieldTest function
        }
    
    
        public void MedikitTest()
        {
            float.TryParse(medikitAttackInputField.text, out _medikitAttackAmount);

            if (!(_medikitAttackAmount > 0)) return;
            healthBar.value += _medikitAttackAmount;
            medikitEffect.Play();
        }
    
    
        public void QuitOnClick()
        {
            Debug.Log("ButtonClick - Quit");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
#else
            Application.Quit();
#endif
        }
    }
}
