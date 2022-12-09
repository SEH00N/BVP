using UnityEngine;

public class DEFINE
{
    public const int GroundLayer = 1 << 6;
    
    //Dont Destroy On Load 걸려있는 캔버스 (로딩 패널 같은 놈 집어넣는 용도)
    private static Transform staticCanvas = null;
    public static Transform StaticCanvas {
        get {
            if(staticCanvas == null)
                staticCanvas = GameObject.Find("StaticCanvas").transform;
            
            return staticCanvas;
        }
    }

    private static Transform player = null;
    public static Transform Player {
        get {
            if(player == null)
                player = GameObject.Find("Player").transform;

            return player;
        }
    }
}
