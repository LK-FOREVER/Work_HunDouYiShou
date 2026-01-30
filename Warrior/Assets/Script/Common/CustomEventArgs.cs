using System;
using System.Collections.Generic;

public class ChangeWarriorArgs : EventArgs
{
    public int index_monster;
}
public class DamageArgs : EventArgs
{
    public int damage;
}
public class GameEndArgs : EventArgs
{
    public bool isWin;
}








