using System;
using System.Collections.Generic;

public class ChangeMusicArgs : EventArgs
{
    public int index_music;
}
public class ChangeSoundArgs : EventArgs
{
    public int index_sound;
}
public class ChangeWarriorArgs : EventArgs
{
    public int index_monster;
}
public class DamageArgs : EventArgs
{
    public int damage;
    public int enemyID;
}
public class GameEndArgs : EventArgs
{
    public bool isWin;
}
public class InitPlayerStateArgs : EventArgs
{
    public float hp;
    public int atk;
    public float speed;
}
public class CoolDownArgs : EventArgs
{
    public float coolDownTime;
}