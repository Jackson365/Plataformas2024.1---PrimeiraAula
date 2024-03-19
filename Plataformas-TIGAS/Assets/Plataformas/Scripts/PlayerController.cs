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

    public float coin;

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

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    public void SetMove(Vector2 move)
    {
        _moveDirection = move;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            
            //collision.gameObject.GetComponent<Player>().IncreaseLife(valueHaelth);
            collision.gameObject.SetActive(false);
            coin++;
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
    public class Coin : Command
    {
        private Collision collision;
        public Coin(float time, Collision coll) : base(time)
        {
            collision = coll;
            
        }

        public override void Do()
        {
            collision.gameObject.SetActive(false);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}