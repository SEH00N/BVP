using UnityEngine;

public class EndRoomPattern : AIDecision
{
    public bool isEnd = false;

    public override bool MakeDecision()
    {
        return isEnd;
    }

    public void Reset()
    {
        isEnd = false;
    }
}
