using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inscrito : MonoBehaviour
{
    public TMP_Text Coinstext;
    private void OnEnable()
    {
        //me inscrevo no canal e associo com o +=, o metodo para dizer
        // o que vai acontecer com o video novo (Se eu vou assistir, se
        // eu vou dar like, se eu vou comentar, etc)
        PlayerObserverMenager.OnPlayerChanged += ProcessPlayerChanged;
    }

    private void ProcessPlayerChanged(int value)
    {
        //decido que vou assistir o video(nesse caso, mudo o volume
        //para o valor que está chegando)
        Coinstext.text = value.ToString();
    }

    private void OnDisable()
    {
        // Desinscreve do canal antes de ser desativado
        //(nesse youtube é obrigatorio desincrever antes de sair)
        PlayerObserverMenager.OnPlayerChanged -= ProcessPlayerChanged;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
