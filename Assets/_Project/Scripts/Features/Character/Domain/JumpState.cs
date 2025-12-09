using System;
using Project.Features.Character.Data;
using UnityEngine;

namespace Project.Features.Character.Domain
{
    public class JumpState : IState
    {
        private readonly Rigidbody m_Rigidbody;
        private readonly PlayerSettingsSO m_PlayerSettings;
        private readonly Transform m_ObjectTransform;

        public event Action OnLand;
        
        public JumpState(PlayerSettingsSO playerSettings, Rigidbody rigidbody, Transform objectTransform)
        {
            m_PlayerSettings = playerSettings;
            m_Rigidbody = rigidbody;
            m_ObjectTransform = objectTransform;
        }
        
        public void Enter()
        {
            Debug.Log("Enter Jump State");
            
            // Reset the velocity
            Vector3 currentVelocity = m_Rigidbody.linearVelocity;
            m_Rigidbody.linearVelocity = new Vector3(currentVelocity.x, 0f, currentVelocity.z);
            
            // Add Force
            m_Rigidbody.AddForce(Vector3.up * m_PlayerSettings.jumpForce, ForceMode.Impulse);
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            if (m_Rigidbody.linearVelocity.y < 0)
            {
                if (Physics.Raycast(m_ObjectTransform.position, Vector3.down, 1.1f, m_PlayerSettings.groundLayer))
                {
                    OnLand?.Invoke();
                    Debug.Log("Landed on ground");
                }
            }
        }

        public void Exit()
        {
            Debug.Log("Exit Jump State");
        }
    }
}
