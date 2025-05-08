using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int life = 10;
    private int health = 1;
    
    public int GetHealt()
    {
        return health;
    }

    public int SetHealth(int value)
    {
        health = value;
        return health;
    }

    void Transforming()
    {

    }
}
