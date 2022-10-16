using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarManager : MonoBehaviour
{
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

    float TankAttackAmount;
    float CrossbowAttackAmount;
    float PoisonAttackAmount;
    float BombAttackAmount;
    float ShieldAttackAmount;
    float MedikitAttackAmount;

    //Test-Button-Funktion des Panzers
    
    public void TankTest()
    {
        //string-to-float-Konvertierung
        float.TryParse(TankAttackInputField.text, out TankAttackAmount);

        if (TankAttackAmount > 0) //Input muss grˆﬂer 0 sein
        {
            //Schaden von Lebensanzeige abziehen
            HealthBar.value -= TankAttackAmount;

            //Particle Effect des Panzer wird abgespielt
            PanzerEffect.Play();
        }
    }

    //Test-Button-Funktion des Crossbows
    public void CrossbowTest()
    {
        float.TryParse(CrossbowAttackInputField.text, out CrossbowAttackAmount);
        if (CrossbowAttackAmount > 0)
        {
            HealthBar.value -= CrossbowAttackAmount;
            CrossbowEffect.Play();
        }
            
    }

    public void PoisonTest()
    {

    }

    //Test-Button-Funktion der Bombe
    public void BombTest()
    {
        float.TryParse(BombAttackInputField.text, out BombAttackAmount);
        if (BombAttackAmount > 0)
        {
            HealthBar.value -= BombAttackAmount;
            BombEffect.Play();
        }
            
    }

    public void ShieldTest()
    {

    }

    //Test-Button-Funktion des Medikits
    public void MedikitTest()
    {
        float.TryParse(MedikitAttackInputField.text, out MedikitAttackAmount);

        if (MedikitAttackAmount > 0)
        {
            //Heilung zu Lebensanzeige addieren
            HealthBar.value += MedikitAttackAmount;

            MedikitEffect.Play();
        }
        
    }

    //Programm schlieﬂen
    public void QuitOnClick()
    {
        Debug.Log("ButtonClick - Quit");
        Application.Quit();

        //Playmode im Editor stoppen
        UnityEditor.EditorApplication.isPlaying = false; 
    }

}
