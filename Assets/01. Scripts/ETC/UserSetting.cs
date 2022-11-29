using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserSetting : Data
{
    public float test1;
    public string test2;

    public override void Generate()
    {
        test1 = 1f;
        test2 = "AD";
    }

    public override bool IsNull()
    { 
        if(test1 == 0f || test2 == "")
            return true;

        return false;
    }

    public override void Save()
    {
        
    }
}
