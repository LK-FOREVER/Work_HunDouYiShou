public static class EventName
{
    public const string ChangeScene = nameof(ChangeScene);

    //弹窗事件
    public const string ShowCommonAward = nameof(ShowCommonAward);

    //Tips事件
    public const string ShowCommonTips = nameof(ShowCommonTips);

    //新手引导
    public const string GuidanceStepComplete = nameof(GuidanceStepComplete);
    //更换异兽
    public const string ChangeWarrior = nameof(ChangeWarrior);
    //敌人受到攻击
    public const string EnemyDamage = nameof(EnemyDamage);
    //玩家受到攻击
    public const string PlayerDamage = nameof(PlayerDamage);
    //战斗结束
    public const string GameEnd = nameof(GameEnd);
    //重置玩家状态
    public const string ResetPlayerState = nameof(ResetPlayerState);
}
