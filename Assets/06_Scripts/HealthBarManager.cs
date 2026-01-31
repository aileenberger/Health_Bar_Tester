using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _06_Scripts
{
    public class HealthBarManager : MonoBehaviour
    {
        #region Initialization
        // region help to organize
    
        [SerializeField] private TMP_InputField tankAttackInputField;
        [SerializeField] private TMP_InputField crossbowAttackInputField;
        [SerializeField] private TMP_InputField bombAttackInputField;
        [SerializeField] private TMP_InputField medikitAttackInputField;

        [SerializeField] private TMP_InputField maxHealthBarValueInputField;

        [SerializeField] private TMP_Text maxHealthBarValueDisplay;
        [SerializeField] private TMP_Text HelpDisplay;

        [SerializeField] private Slider healthBar;

        [SerializeField] private ParticleSystem panzerEffect;
        [SerializeField] private ParticleSystem crossbowEffect;
        [SerializeField] private ParticleSystem bombEffect;
        [SerializeField] private ParticleSystem medikitEffect;

        [SerializeField] private GameObject[] charSkin;

        [SerializeField] AudioSource bombSound;
        [SerializeField] AudioSource tankSound;
        [SerializeField] AudioSource crossbowSound;
        [SerializeField] AudioSource medikitSound;

        //Identifiers beginning with an underscore
        private float _tankAttackAmount;
        private float _crossbowAttackAmount;
        private float _bombAttackAmount;
        private float _medikitAttackAmount;

        private float _maxHealthBarValue;
        [SerializeField] private float _maxEingabe = 1000;

        private int _randomCharNumber, _activeIndex;

        // Identifiers beginning with an underscore followed immediately by an uppercase letter
        // _ (underscore) = avoid collision of names


        #endregion


        private void Start()
        {
            maxHealthBarValueInputField.text = healthBar.maxValue.ToString();           
            healthBar.value = healthBar.maxValue;
            maxHealthBarValueDisplay.text = healthBar.value.ToString();
        }


        public void RerollChar()
        {
            do
            {
                _randomCharNumber = Random.Range(0, 3);
            } while (charSkin[_activeIndex] == charSkin[_randomCharNumber]);

            charSkin[_activeIndex].SetActive(false);
            charSkin[_randomCharNumber].SetActive(true);

            _activeIndex = _randomCharNumber;
        }


        public void UpdateMaxHealthBarValue()
        {
            float.TryParse(maxHealthBarValueInputField.text, out _maxHealthBarValue);
            if (_maxHealthBarValue <= healthBar.minValue || _maxEingabe <= _maxHealthBarValue) 
            { 
                Debug.Log("The maximum life points must be between " + healthBar.minValue + " and " + _maxEingabe + ".");
                HelpDisplay.text = "The maximum life points must be between " + healthBar.minValue + " and " + _maxEingabe + ".";
                CancelInvoke("ClearHelpDisplay");
                Invoke("ClearHelpDisplay", 2);
                return; 
            }
            float temp = (healthBar.value/healthBar.maxValue)*_maxHealthBarValue;
            healthBar.maxValue = _maxHealthBarValue;
            healthBar.value = temp;
        }


        public void UpdateHealthValueDisplay()
        {
            maxHealthBarValueDisplay.text = healthBar.value.ToString();
        }


        public void ResetHealthBar()
        {
            healthBar.value = healthBar.maxValue;
        }


        public void TankTest()
        {
            if (healthBar.value == healthBar.minValue)
            {
                CharAlreadyDead();
                return;
            }
            
            float.TryParse(tankAttackInputField.text, out _tankAttackAmount);
            
            if (_tankAttackAmount <= healthBar.minValue || _tankAttackAmount >= healthBar.maxValue)
            {
                Debug.Log("The damage must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".");
                HelpDisplay.text = "The damage must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".";
                CancelInvoke("ClearHelpDisplay");
                Invoke("ClearHelpDisplay", 2);
                return;
            }
            
            healthBar.value -= _tankAttackAmount;
            panzerEffect.Play();
            tankSound.Play();
        }
    
    
        public void CrossbowTest()
        {
            if (healthBar.value == healthBar.minValue)
            {
                CharAlreadyDead();
                return;
            }
            
            float.TryParse(crossbowAttackInputField.text, out _crossbowAttackAmount);
            
            if (_crossbowAttackAmount <= healthBar.minValue || _crossbowAttackAmount >= healthBar.maxValue)
            {
                Debug.Log("The damage must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".");
                HelpDisplay.text = "The damage must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".";
                CancelInvoke("ClearHelpDisplay");
                Invoke("ClearHelpDisplay", 2);
                return;
            }
            
            healthBar.value -= _crossbowAttackAmount;
            crossbowEffect.Play();
            crossbowSound.Play();
        } 
    

        public void BombTest()
        {
            if (healthBar.value == healthBar.minValue)
            {
                CharAlreadyDead();
                return;
            }
            
            float.TryParse(bombAttackInputField.text, out _bombAttackAmount);
            
            if (_bombAttackAmount <= healthBar.minValue || _bombAttackAmount >= healthBar.maxValue)
            {
                Debug.Log("The damage must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".");
                HelpDisplay.text = "The damage must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".";
                CancelInvoke("ClearHelpDisplay");
                Invoke("ClearHelpDisplay", 2);
                return;
            }
            
            healthBar.value -= _bombAttackAmount;
            bombEffect.Play();
            bombSound.Play();
        }
    

        public void MedikitTest()
        {
            if (healthBar.value == healthBar.maxValue)
            {
                Debug.Log("The character is fully healed. Deal damage first.");
                HelpDisplay.text = "The character is fully healed. Deal damage first.";
                CancelInvoke("ClearHelpDisplay");
                Invoke("ClearHelpDisplay", 2);
                return;
            }
            
            float.TryParse(medikitAttackInputField.text, out _medikitAttackAmount);
            
            if (_medikitAttackAmount <= healthBar.minValue || _medikitAttackAmount >= healthBar.maxValue)
            {
                Debug.Log("The healing must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".");
                HelpDisplay.text = "The healing must be between " + healthBar.minValue + " and " + healthBar.maxValue + ".";
                CancelInvoke("ClearHelpDisplay");
                Invoke("ClearHelpDisplay", 2);
                return;
            }
            
            healthBar.value += _medikitAttackAmount;
            medikitEffect.Play();
            medikitSound.Play();
        }

        private void CharAlreadyDead()
        {
            Debug.Log("The character is already dead. Reset the life points first.");
            HelpDisplay.text = "The character is already dead. Reset the life points first.";
            CancelInvoke("ClearHelpDisplay");
            Invoke("ClearHelpDisplay", 2);
        }

        void ClearHelpDisplay()
        {
            HelpDisplay.text = "";
            Debug.Log("HelpDisplay cleared.");
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
