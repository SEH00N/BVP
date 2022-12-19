using UnityEngine;

public class EndRoomPattern : AIDecision
{
    public bool isEnd = false;

    public override bool MakeDecision()
    {
        return isEnd;
        //링 포탈 패턴 끝났는지 안 끝났는지 확인
        //올바른 포탈 들어갔으면 돌아와서 포탈 터지고
        //잘못된 포탈 들어갔으면 데미지 받고 2페이즈 계속
    }

    public void Reset()
    {
        isEnd = false;
    }
}
