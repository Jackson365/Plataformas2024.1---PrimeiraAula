using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

//Manda o conteudo
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private Vector2 _moveDirection;

    private Stack<Command> _playerCommands;
    public float coin;
    private Command[] _recordedCommands;
    //
    private void Start()
    {
        _playerCommands = new Stack<Command>();
    }


    public void RegisterMovement(InputAction.CallbackContext context)
    {

    }

    private void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            _playerCommands.Push(new Move(Time.time, transform, Vector3.up));
            _playerCommands.Peek().Do();
        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            _playerCommands.Push(new Move(Time.time, transform, Vector3.down));
            _playerCommands.Peek().Do();
        }
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            _playerCommands.Push(new Move(Time.time, transform, Vector3.left));
            _playerCommands.Peek().Do();
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            _playerCommands.Push(new Move(Time.time, transform, Vector3.right));
            _playerCommands.Peek().Do();
        }

        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            if (_playerCommands.Count > 0)
            {
                _playerCommands.Pop().Undo();
            }
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _playerCommands.Push(new Move.ColetarMoeda(Time.time, collision.gameObject, this));
            _playerCommands.Peek().Do();
            collision.gameObject.SetActive(false);
        }
    }

    public void ToGoBack()
    {
        if (_playerCommands.Count > 0)
        {
            _playerCommands.Pop().Undo();
        }
    }
    
    
}

public abstract class Command
{
    public float Time;

    protected Command(float time)
    {
        this.Time = time;
    }
    
    public abstract void Do();
    public abstract void Undo();
}

public class Move : Command
{
    private Transform transform;
    private Vector3 direcao;
    
    public Move(float time, Transform tran, Vector3 dire) : base(time)
    {
        transform = tran;
        direcao = dire;
    }

    public override void Do()
    {
        transform.position += direcao;
    }

    public override void Undo()
    {
        transform.position -= direcao;
    }
    public class ColetarMoeda : Command
    {
        private GameObject coin;
        private PlayerController _player;
        public ColetarMoeda(float time, GameObject moeda, PlayerController player) : base(time)
        {
            coin = moeda;
            _player = player;

        }

        public override void Do()
        {
            _player.coin += 1;
            coin.gameObject.SetActive(false);
        }

        public override void Undo()
        {
            _player.coin -= 1;
            _player.ToGoBack();
            coin.gameObject.SetActive(true);
        }
    }
}
