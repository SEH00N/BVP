using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRotate : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            Debug.Log(transform.eulerAngles);

            transform.rotation *= Quaternion.AngleAxis(-10f, transform.forward);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            Debug.Log(transform.eulerAngles);

            transform.rotation *= Quaternion.AngleAxis(10f, transform.forward);
        }
    }
}
