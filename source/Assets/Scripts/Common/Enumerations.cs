using UnityEngine;
using System.Collections;

public enum CharacterBehaviourState
{
    Idle,
    IdleWithBox,
    Walk,
    WalkWithBox
}

public enum FruitTarget
{
    Coconut,
    Guava,
    Cane
}

public enum MachineTarget
{
    Juice,
    Cocada,
    Jelly,
    Sugar
}

public enum HUDIconGroup
{
    Player = 0,
    JuiceMachine = 1,
    CocadaMachine = 2,
    JellyMachine = 3,
    SugarMachine = 4,
    FastIntern = 5,
    MediumIntern = 6,
    SlowIntern = 7
}

public enum HUDIconType
{
    Info,
    CoconutJuice,
    Cocada,
    GuavaJuice,
    Jelly,
    CaneJuice,
    Sugar
}

public enum HUDAnimationType
{
    HUD_4_Up = 0,
    HUD_4_Down = 1,

    HUD_5_Up = 2,
    HUD_5_Down = 3,

    HUD_6_Up = 4,
    HUD_6_Down = 5,

    HUD_35_Up = 6,
    HUD_35_Down = 7,

    HUD_45_Up = 8,
    HUD_45_Down = 9,

    HUD_55_Up = 10,
    HUD_55_Down = 11,

    HUD_65_Up = 12,
    HUD_65_Down = 13
}
