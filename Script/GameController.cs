using SkillzSDK;
using UnityEngine;

public sealed class GameController : SkillzMatchDelegate
{
    private const string GameSceneName      = "Level";
    private const string StartMenuSceneName = "Start";

    public void OnMatchWillBegin(Match matchInfo)
    {
    }

    public void OnSkillzWillExit()
    {
    }
}
