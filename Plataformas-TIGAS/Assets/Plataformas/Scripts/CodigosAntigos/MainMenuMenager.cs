using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMenager : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.LoadGamePlay();
    }
}
