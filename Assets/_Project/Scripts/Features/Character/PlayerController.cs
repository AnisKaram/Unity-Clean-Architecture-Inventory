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

        private StateMachine m_StateMachineInstance;
        
        [Inject]
        public void Construct(PlayerInputReader playerInputReader, PlayerSettingsSO playerSettings)
        {
            m_PlayerInputReader = playerInputReader;
            m_PlayerSettings = playerSettings;
        }

        private void Start()
        {
            IState moveState = new MoveState(m_PlayerSettings, m_PlayerInputReader, transform);

            m_StateMachineInstance = new StateMachine(moveState);
        }
        private void Update()
        {
            m_StateMachineInstance.Update();
        }
        private void FixedUpdate()
        {
            m_StateMachineInstance.FixedUpdate();
        }
    }
}
