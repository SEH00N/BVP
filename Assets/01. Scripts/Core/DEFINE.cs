using Cinemachine;
using UnityEngine;

public class DEFINE
{
    public const int GroundLayer = 1 << 6;
    public const int PlayerLayer = 1 << 8;
    public const int EnemyLayer = 1 << 9;
    
    //Dont Destroy On Load 걸려있는 캔버스 (로딩 패널 같은 놈 집어넣는 용도)
    private static Transform staticCanvas = null;
    public static Transform StaticCanvas {
        get {
            if(staticCanvas == null)
                staticCanvas = GameObject.Find("StaticCanvas").transform;
            
            return staticCanvas;
        }
    }

    private static Transform mainCanvas = null;
    public static Transform MainCanvas {
        get {
            if(mainCanvas == null)
                mainCanvas = GameObject.Find("MainCanvas").transform;

            return mainCanvas;
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

    private static Camera mainCam = null;
    public static Camera MainCam {
        get {
            if(mainCam == null)
                mainCam = Camera.main;

            return mainCam;
        }
    }

    private static CinemachineVirtualCamera cmMainCam = null;
    public static CinemachineVirtualCamera CmMainCam  {
        get {
            if(cmMainCam == null)
                cmMainCam = GameObject.Find("CmMainCam").GetComponent<CinemachineVirtualCamera>();

            return cmMainCam;
        }
    }
}
