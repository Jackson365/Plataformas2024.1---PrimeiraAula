using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

//Manda o conteudo
//public class PlayerControllerAntigo : MonoBehaviour
//{
    /*public int coin;
    
    // Start is called before the first frame update
    void Update()
    {
        Space();
        GameManager.Instance.UpdateLives(coin);
    }
    
    private void CoinPlayerChanged(int valuePlayer)
    {
        //Manda o video para o youtube
        PlayerObserverMenager.PlayerChanged(valuePlayer);
    }

    public void Space()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coin = coin + 1;
            CoinPlayerChanged(coin);
        }
        
        Debug.Log(coin);
    }

    
    //COMMADER
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;

    private Stack<Command> _playerCommands;

    //Replay
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private float _startTime;
    private Vector2 _startVelocity;
    private float _startPlayTime;

    private bool _isRecording;
    private bool _isPlaying;
    private int _playHead;

    private Command[] _recordedCommands;
    //
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerCommands = new Stack<Command>();
    }

    public void RegisterJump(InputAction.CallbackContext context)
    {
        if (_isPlaying) return;
        
        if(!context.performed) return;
        
        _playerCommands.Push(new Jump(Time.time, _rigidbody2D, jumpForce));
        _playerCommands.Peek().Do();

        if (!_isRecording) _playerCommands.Pop();
        
        Debug.Log("Pulou");
    }
    public void RegisterMovement(InputAction.CallbackContext context)
    {
        if (_isPlaying) return;
        
        _playerCommands.Push(new Movement(Time.time, context.ReadValue<Vector2>(), this));
        _playerCommands.Peek().Do();
        
        if (!_isRecording) _playerCommands.Pop();
        
        Debug.Log("Moveu");
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            
            //Replay
            if (!_isRecording)
            {
                _isRecording = true;
                _startPosition = transform.position;
                _startRotation = transform.rotation;
                _startTime = Time.time;
                _startVelocity = _rigidbody2D.velocity;
            }
            else
            {
                _isRecording = false;
            }
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (!_isPlaying)
            {
                _isPlaying = true;
                _recordedCommands = _playerCommands.ToArray();
                _playHead = _recordedCommands.Length -1;
                transform.position = _startPosition;
                transform.rotation = _startRotation;
                _rigidbody2D.velocity = _startVelocity;
                _startPlayTime = Time.time;
            }
        }

        if (_isPlaying)
        {
            if(_recordedCommands[_playHead].Time- _startTime <= Time.time - _startPlayTime)
            {
                _recordedCommands[_playHead].Do();
                _playHead--;

                if (_playHead < 0) _isPlaying = false;
            }
        }
        //
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    public void SetMove(Vector2 move)
    {
        _moveDirection = move;
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

public class Jump : Command
{
    private Rigidbody2D _rigidbody2D;
    private float jumpForce;
    
    public Jump(float time, Rigidbody2D _rb2D, float jump) : base(time)
    {
        _rigidbody2D = _rb2D;
        jumpForce = jump;
    }

    public override void Do()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}

public class Movement : Command
{
    private Vector2 moveDirection;
    private PlayerController playerController;
    
    public Movement(float time, Vector2 move, PlayerController player) : base(time)
    {
        moveDirection = move;
        playerController = player;
    }

    public override void Do()
    {
        playerController.SetMove(moveDirection);
    }

    public override void Undo()
    {
        playerController.SetMove(moveDirection * -1);
    }
}*/
