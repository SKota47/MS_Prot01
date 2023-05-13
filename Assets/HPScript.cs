using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    public Slider _slider;
    private float currentHealth;
    void Awake()
    {
        currentHealth = _maxHealth;
    }
    public void UpdateHP(float damageval)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageval, 0, _maxHealth);
        _slider.value = currentHealth;
    }
}
