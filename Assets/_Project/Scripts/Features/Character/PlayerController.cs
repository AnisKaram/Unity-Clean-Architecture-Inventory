using Project.Features.Character.Data;
using Project.Features.Character.Domain;
using Project.Features.Character.View;
using UnityEngine;
using VContainer;

namespace Project.Features.Character
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputReader m_PlayerInputReader;
        private PlayerSettingsSO m_PlayerSettings;
        
        private IdleState m_IdleState;
        private MoveState m_MoveState;
        
        private StateMachine m_StateMachineInstance;
        
        [Inject]
        public void Construct(PlayerInputReader playerInputReader, PlayerSettingsSO playerSettings)
        {
            m_PlayerInputReader = playerInputReader;
            m_PlayerSettings = playerSettings;
        }

        private void Start()
        {
            m_IdleState = new IdleState(m_PlayerInputReader);
            m_MoveState = new MoveState(m_PlayerSettings, m_PlayerInputReader, transform);

            m_IdleState.OnMove += IdleState_OnMove;
            m_MoveState.OnIdle += MoveState_OnIdle; 

            m_StateMachineInstance = new StateMachine(m_IdleState);
        }
        private void Update()
        {
            m_StateMachineInstance.Update();
        }
        private void FixedUpdate()
        {
            m_StateMachineInstance.FixedUpdate();
        }
        private void OnDestroy()
        {
            m_IdleState.OnMove -= IdleState_OnMove;
            m_MoveState.OnIdle -= MoveState_OnIdle;
        }

        private void IdleState_OnMove()
        {
            m_StateMachineInstance.ChangeState(m_MoveState);
        }

        private void MoveState_OnIdle()
        {
            m_StateMachineInstance.ChangeState(m_IdleState);
        }
    }
}