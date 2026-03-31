using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Complete
{
    public class HealthUI : MonoBehaviour
    {
        // The amount of health each tank starts with.
        [SerializeField] private Slider m_Slider;                             // The slider to represent how much health the tank currently has.
        [SerializeField] private Image m_FillImage;                           // The image component of the slider.
        [SerializeField] private Color m_FullHealthColor = Color.green;    // The color the health bar will be when on full health.
        [SerializeField] private Color m_ZeroHealthColor = Color.red;

        [SerializeField] private TankHealth m_TankHealth;
        private bool m_SubscribedToHealthEvents = false;
        
        private void OnEnable()
        {
            SubscribeToHealthEvent();
        }

        private void Start()
        {
            if(!m_TankHealth) return;
            
            // Set the slider max value to the max health the tank can have
            m_Slider.maxValue = m_TankHealth.StartingHealth;
            
            SubscribeToHealthEvent();
        }

        private void OnDisable()
        {
            UnsubscribeToHealthEvent();
        }

        private void OnDestroy()
        {
            UnsubscribeToHealthEvent();
        }

        private void SetHealthUI()
        {
            // Set the slider's value appropriately.
            m_Slider.value = m_TankHealth.CurrentHealth;

            // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
            m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, m_TankHealth.CurrentHealth / m_TankHealth.StartingHealth);
        }

        private void SubscribeToHealthEvent()
        {
            if(m_SubscribedToHealthEvents || !m_TankHealth) return;
            
            m_SubscribedToHealthEvents = true;
            
            m_TankHealth.HealthChanged += SetHealthUI;
        }
        
        private void UnsubscribeToHealthEvent()
        {
            if(!m_SubscribedToHealthEvents || !m_TankHealth) return;
            
            m_SubscribedToHealthEvents = false;
            
            m_TankHealth.HealthChanged -= SetHealthUI;
        }
    }
}
