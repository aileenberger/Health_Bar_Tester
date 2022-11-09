using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
                Debug.Log("Maximales Leben muss zwischen " + healthBar.minValue + " und " + _maxEingabe + " liegen.");
                HelpDisplay.text = "Maximales Leben muss zwischen " + healthBar.minValue + " und " + _maxEingabe + " liegen.";
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
            float.TryParse(tankAttackInputField.text, out _tankAttackAmount);
            if (_tankAttackAmount <= healthBar.minValue || _tankAttackAmount >= healthBar.maxValue || healthBar.value == healthBar.minValue)
            {
                Debug.Log("Schaden muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.");
                HelpDisplay.text = "Schaden muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.";
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
            float.TryParse(crossbowAttackInputField.text, out _crossbowAttackAmount);
            if (_crossbowAttackAmount <= healthBar.minValue || _crossbowAttackAmount >= healthBar.maxValue || healthBar.value == healthBar.minValue)
            {
                Debug.Log("Schaden muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.");
                HelpDisplay.text = "Schaden muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.";
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
            float.TryParse(bombAttackInputField.text, out _bombAttackAmount);
            if (_bombAttackAmount <= healthBar.minValue || _bombAttackAmount >= healthBar.maxValue || healthBar.value == healthBar.minValue)
            {
                Debug.Log("Schaden muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.");
                HelpDisplay.text = "Schaden muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.";
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
            float.TryParse(medikitAttackInputField.text, out _medikitAttackAmount);
            if (_medikitAttackAmount <= healthBar.minValue || _medikitAttackAmount >= healthBar.maxValue || healthBar.value == healthBar.maxValue)
            {
                Debug.Log("Heilung muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.");
                HelpDisplay.text = "Heilung muss zwischen " + healthBar.minValue + " und " + healthBar.maxValue + " liegen.";
                CancelInvoke("ClearHelpDisplay");
                Invoke("ClearHelpDisplay", 2);
                return;
            }
            healthBar.value += _medikitAttackAmount;
            medikitEffect.Play();
            medikitSound.Play();
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
