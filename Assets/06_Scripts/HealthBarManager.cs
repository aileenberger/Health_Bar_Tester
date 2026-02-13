using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        [SerializeField] private TMP_Text helpDisplay;

        [SerializeField] private Slider healthBar;

        [SerializeField] private ParticleSystem panzerEffect;
        [SerializeField] private ParticleSystem crossbowEffect;
        [SerializeField] private ParticleSystem bombEffect;
        [SerializeField] private ParticleSystem medikitEffect;

        [SerializeField] private GameObject[] charSkin;

        [SerializeField] private AudioSource bombSound;
        [SerializeField] private AudioSource tankSound;
        [SerializeField] private AudioSource crossbowSound;
        [SerializeField] private AudioSource medikitSound;

        [SerializeField] private float maxInput = 1000;        

        //Identifiers beginning with an underscore
        private float _tankAttackAmount;
        private float _crossbowAttackAmount;
        private float _bombAttackAmount;
        private float _medikitAttackAmount;
        private float _maxHealthBarValue;
        
        private int _randomCharNumber, _activeIndex;

        // Identifiers beginning with an underscore followed immediately by an uppercase letter
        // _ (underscore) = avoid collision of names


        #endregion


        private void Start()
        {
            maxHealthBarValueInputField.text = $"{healthBar.maxValue}";           
            healthBar.value = healthBar.maxValue;
            maxHealthBarValueDisplay.text = $"{healthBar.value}";
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
            
            if (_maxHealthBarValue <= healthBar.minValue || maxInput <= _maxHealthBarValue) 
            { 
                Debug.Log($"The maximum life points must be between {healthBar.minValue} and {maxInput}.");
                helpDisplay.text = $"The maximum life points must be between {healthBar.minValue} and {maxInput}.";
                CancelInvoke(nameof(ClearHelpDisplay));
                Invoke(nameof(ClearHelpDisplay), 2);
                return; 
            }
            
            float temp = (healthBar.value/healthBar.maxValue)*_maxHealthBarValue;
            healthBar.maxValue = _maxHealthBarValue;
            healthBar.value = temp;
        }


        public void UpdateHealthValueDisplay()
        {
            maxHealthBarValueDisplay.text = $"{healthBar.value}"; 
        }


        public void ResetHealthBar()
        {
            healthBar.value = healthBar.maxValue;
        }


        public void TankTest()
        {
            if (healthBar.value <= healthBar.minValue)
            {
                CharAlreadyDead();
                return;
            }
            
            float.TryParse(tankAttackInputField.text, out _tankAttackAmount);
            
            if (_tankAttackAmount <= healthBar.minValue || _tankAttackAmount >= healthBar.maxValue)
            {
                DamageRangeExplanation();
                return;
            }
            
            healthBar.value -= _tankAttackAmount;
            panzerEffect.Play();
            tankSound.Play();
        }
    
    
        public void CrossbowTest()
        {
            if (healthBar.value <= healthBar.minValue)
            {
                CharAlreadyDead();
                return;
            }
            
            float.TryParse(crossbowAttackInputField.text, out _crossbowAttackAmount);
            
            if (_crossbowAttackAmount <= healthBar.minValue || _crossbowAttackAmount >= healthBar.maxValue)
            {
                DamageRangeExplanation();
                return;
            }
            
            healthBar.value -= _crossbowAttackAmount;
            crossbowEffect.Play();
            crossbowSound.Play();
        } 
    

        public void BombTest()
        {
            if (healthBar.value <= healthBar.minValue)
            {
                CharAlreadyDead();
                return;
            }
            
            float.TryParse(bombAttackInputField.text, out _bombAttackAmount);
            
            if (_bombAttackAmount <= healthBar.minValue || _bombAttackAmount >= healthBar.maxValue)
            {
                DamageRangeExplanation();
                return;
            }
            
            healthBar.value -= _bombAttackAmount;
            bombEffect.Play();
            bombSound.Play();
        }
    

        public void MedikitTest()
        {
            if (healthBar.value >= healthBar.maxValue)
            {
                Debug.Log("The character is fully healed. Deal damage first.");
                helpDisplay.text = "The character is fully healed. Deal damage first.";
                CancelInvoke(nameof(ClearHelpDisplay));
                Invoke(nameof(ClearHelpDisplay), 2);
                return;
            }
            
            float.TryParse(medikitAttackInputField.text, out _medikitAttackAmount);
            
            if (_medikitAttackAmount <= healthBar.minValue || _medikitAttackAmount >= healthBar.maxValue)
            {
                Debug.Log($"The healing must be between {healthBar.minValue} and {healthBar.maxValue}.");
                helpDisplay.text = $"The healing must be between {healthBar.minValue} and {healthBar.maxValue}.";
                CancelInvoke(nameof(ClearHelpDisplay));
                Invoke(nameof(ClearHelpDisplay), 2);
                return;
            }
            
            healthBar.value += _medikitAttackAmount;
            medikitEffect.Play();
            medikitSound.Play();
        }

        
        private void CharAlreadyDead()
        {
            Debug.Log("The character is already dead. Reset the life points first.");
            helpDisplay.text = "The character is already dead. Reset the life points first.";
            CancelInvoke(nameof(ClearHelpDisplay));
            Invoke(nameof(ClearHelpDisplay), 2);
        }


        private void DamageRangeExplanation()
        {
            Debug.Log($"The damage must be between {healthBar.minValue} and {healthBar.maxValue}.");
            helpDisplay.text = $"The damage must be between {healthBar.minValue} and {healthBar.maxValue}.";
            CancelInvoke(nameof(ClearHelpDisplay));
            Invoke(nameof(ClearHelpDisplay), 2);  
        }

        
        private void ClearHelpDisplay()
        {
            helpDisplay.text = "";
            Debug.Log("HelpDisplay cleared.");
        }

        
        public void LoadCredits()
        {
            SceneManager.LoadScene("Credits");
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
