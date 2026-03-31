using System;

namespace Tanks.Complete
{
    public interface IHealth
    {
        public float StartingHealth { get; }
        public float CurrentHealth { get; }
        public bool HasShield { get; }
        
        public event Action HealthChanged;
        
        public void TakeDamage(float amount);
        public void IncreaseHealth(float amount);
        public void ToggleShield(float shieldAmount);
        public void ToggleInvincibility();
    }
}

