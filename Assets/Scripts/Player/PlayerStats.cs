using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerStats : MonoBehaviour
{
    [SerializeField] protected UnityEvent _refilled;
    [SerializeField] protected UnityEvent _decreasing;
    [SerializeField] protected ParticleSystem _particle;
    [SerializeField] private int _maxValue;

    public event UnityAction ChangeValue;
    public int CurrentValue { get; protected set; }

    public int MaxStats
    {
        get
        {
            return _maxValue;
        }
        protected set
        {
            _maxValue = MaxStats;
        }
    }

    private void OnValidate()
    {
        if (_maxValue <= 0)
        {
            _maxValue = 25;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        Decreasing();
        Change(-damage);
    }

    protected void TakeRefill(int value)
    {
        Refill();
        Change(value);
    }

    protected void Change(int value)
    {
        CurrentValue += value;
        CurrentValue = Mathf.Clamp(CurrentValue, 0, MaxStats);
        ChangeValue?.Invoke();
    }

    protected void Refill()
    {
        _refilled?.Invoke();
        _particle.Play();
    }

    protected void Decreasing()
    {
        _decreasing?.Invoke();
    }
}
