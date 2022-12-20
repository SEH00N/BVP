using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public Animator Anim{
    get {
            if(anim == null)
                anim = GetComponent<Animator>();
            return anim;
        }
    }
    private Movement movement = null;
    public Movement Movement {
        get {
            if(movement == null)
                movement = GetComponent<Movement>();
            return movement;
        }
    }

    private PlayerHealth playerHealth = null;
    public PlayerHealth PlayerHealth {
        get {
            if(playerHealth = null)
                playerHealth = GetComponent<PlayerHealth>();
            return playerHealth;
        }
    }
}
