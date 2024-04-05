﻿using AmongUs.GameOptions;

namespace TOHE.Roles.Neutral;

internal class Sunnyboy : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 14400;
    private static readonly HashSet<byte> PlayerIds = [];
    public static bool HasEnabled => PlayerIds.Count > 0;
    public override bool IsEnable => HasEnabled;
    public override CustomRoles ThisRoleBase => CustomRoles.Scientist;
    //==================================================================\\
    
    public override void Init()
    {
        PlayerIds.Clear();
    }
    public override void Add(byte playerId)
    {
        PlayerIds.Add(playerId);
    }

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        AURoleOptions.ScientistCooldown = 0f;
        AURoleOptions.ScientistBatteryCharge = 60f;
    }
    public static bool CheckSpawn()
    {
        var Rand = IRandom.Instance;
        return Rand.Next(0, 100) < Jester.SunnyboyChance.GetInt();
    }
    public override bool HasTasks(GameData.PlayerInfo player, CustomRoles role, bool ForRecompute)
        => !ForRecompute;

    public static bool CheckGameEnd()
        => CustomRoles.Sunnyboy.RoleExist() && Main.AllAlivePlayerControls.Length > 1;
}