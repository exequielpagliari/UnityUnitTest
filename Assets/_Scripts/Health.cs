using UnityEngine;
using System.Collections;

public class Health
{
    private float _health = 1;
    public float GetHealth()
    {
        return _health;
    }
    public bool AddHealth(float heathPlus)
    {
        if (heathPlus > 0)
        {
            _health += heathPlus;
            // ensure never more than 1
            if (_health > 1) _health = 1;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool KillCharacter()
    {
        _health = 0;
        return true;
    }
}