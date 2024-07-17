using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace PlayerStates
{
    public enum PlayerCharacter
        {
            Yuuka,
            Arisu,
            Toki
        }
    public class PlayerController : MonoBehaviour
    {
        public PlayerCharacter playerCharacter;

        public float speed = 2.0f;
        public float CurrentSpeed {get; set;}
        public float attackRate = 1.0f;
        public float jumpForce = 100.0f;
        public int jumpCount = 1;
        public Rigidbody2D rigidbody;

        private IPlayerState _idleState, _moveState, _attackState, _deadState; // Idle, Move, Attack States
        private PlayerStateContext _playerStateContext;
        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collide!");
            // 점프 관련 처리
            if(collision.gameObject.CompareTag("Floor"))
            {
                //_isJumping = false;
                jumpCount = 1;
            }
        }
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            _playerStateContext = new PlayerStateContext(this);
            _idleState = gameObject.AddComponent<PlayerIdleState>();
            _moveState = gameObject.AddComponent<PlayerMoveState>();
            _attackState = gameObject.AddComponent<PlayerAttackState>();
            _deadState = gameObject.AddComponent<PlayerDeadState>();
            CurrentSpeed = 0.0f;
            _playerStateContext.CurrentState = _idleState;
            Debug.Log("I am " + playerCharacter.ToString() + "!");
        }

        void Start()
        {
        }
        void Update()
        {
        }
        public void PlayerIdle()
        {
            _playerStateContext.Transition(_idleState);
        }
        public void PlayerMove()
        {
            _playerStateContext.Transition(_moveState);
        }
        public void PlayerAttack()
        {
            _playerStateContext.Transition(_attackState);
        }
        public void PlayerDead()
        {
            _playerStateContext.Transition(_deadState);
        }
        
    }
    
}
