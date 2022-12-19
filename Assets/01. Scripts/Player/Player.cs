using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement movement = null;
    public Movement Movement {
        get {
            if(movement == null)
                movement = GetComponent<Movement>();
            return movement;
        }
    }
}
