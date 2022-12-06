using System.Collections.Generic;
using UnityEngine;

public class SkillActivator : MonoBehaviour
{
    [SerializeField] Transform skillArchive = null;
    private List<SkillAction> skillList = new List<SkillAction>();

    private void Awake()
    {
        skillArchive.GetComponentsInChildren<SkillAction>(skillList);
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            foreach(SkillAction skill in skillList)
            {
                if(Input.GetKeyDown(skill.activeKey))
                {
                    if (skill.currentStack > 0)
                    {
                        skill.currentStack--;
                        skill.ActiveSkill();
                    }
                }
            }
        }
    }
}
