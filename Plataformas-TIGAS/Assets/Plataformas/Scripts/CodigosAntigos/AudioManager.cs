using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private float volume = 1f;

    public static AudioManager Intance;

    private void Awake()
    {
        if (Intance == null)
        {
            Intance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        //me inscrevo no canal e associo com o +=, o metodo para dizer
        // o que vai acontecer com o video novo (Se eu vou assistir, se
        // eu vou dar like, se eu vou comentar, etc)
        AudioObserverManager.OnVolumeChanged += ProcessVolumeChanged;
    }

    private void ProcessVolumeChanged(float value)
    {
        //decido que vou assistir o video(nesse caso, mudo o volume
        //para o valor que está chegando)
        volume = value;
    }

    private void OnDisable()
    {
        // Desinscreve do canal antes de ser desativado
        //(nesse youtube é obrigatorio desincrever antes de sair)
        AudioObserverManager.OnVolumeChanged -= ProcessVolumeChanged;
    }
}
