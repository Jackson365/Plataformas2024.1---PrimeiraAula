using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InterruptorController : MonoBehaviour
{
    [SerializeField] private Animator animyFSM;

    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            animyFSM.SetTrigger("Space");
        }
    }

    public void ChageColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
