using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarManager : MonoBehaviour
{
    #region Initialization
    // region help to organize

    //Identifiers beginning with an underscore - [SerializeField] are global.
    [SerializeField] TMP_InputField TankAttackInputField;
    [SerializeField] TMP_InputField CrossbowAttackInputField;
    [SerializeField] TMP_InputField PoisonAttackInputField;
    [SerializeField] TMP_InputField BombAttackInputField;
    [SerializeField] TMP_InputField ShielAttackInputField;
    [SerializeField] TMP_InputField MedikitAttackInputField;

    [SerializeField] Slider HealthBar;

    [SerializeField] ParticleSystem PanzerEffect;
    [SerializeField] ParticleSystem CrossbowEffect;
    [SerializeField] ParticleSystem PoisonEffect;
    [SerializeField] ParticleSystem BombEffect;
    [SerializeField] ParticleSystem ShieldEffect;
    [SerializeField] ParticleSystem MedikitEffect;

    
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
        float.TryParse(TankAttackInputField.text, out _tankAttackAmount);

        // if not (_tankAttackAmount > 0 = true) do nothing.
        if (!(_tankAttackAmount > 0)) return;
        HealthBar.value -= _tankAttackAmount;
        PanzerEffect.Play();
    }
    
    
    public void CrossbowTest()
    {
        float.TryParse(CrossbowAttackInputField.text, out _crossbowAttackAmount);
        if (!(_crossbowAttackAmount > 0)) return;
        HealthBar.value -= _crossbowAttackAmount;
        CrossbowEffect.Play();
    }

    
    public void PoisonTest()
    {
        //TODO: Create PoisonTest function
    }
    
    
    public void BombTest()
    {
        float.TryParse(BombAttackInputField.text, out _bombAttackAmount);
        if (!(_bombAttackAmount > 0)) return;
        HealthBar.value -= _bombAttackAmount;
        BombEffect.Play();
    }

    
    public void ShieldTest()
    {
        //TODO: Create ShieldTest function
    }
    
    
    public void MedikitTest()
    {
        float.TryParse(MedikitAttackInputField.text, out _medikitAttackAmount);

        if (!(_medikitAttackAmount > 0)) return;
        HealthBar.value += _medikitAttackAmount;
        MedikitEffect.Play();
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
