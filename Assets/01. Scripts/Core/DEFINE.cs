using UnityEngine;

public class DEFINE
{
    //Dont Destroy On Load 걸려있는 캔버스 (로딩 패널 같은 놈 집어넣는 용도)
    private static Transform staticCanvas = null;
    public static Transform StaticCanvas {
        get {
            if(staticCanvas == null)
                staticCanvas = GameObject.Find("StaticCanvas").transform;
            
            return staticCanvas;
        }
    }
}
