using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Faction Faction;
    public GameObject highlight;
    public LineRenderer path;

    [Space(10)]
    public Tile OccupiedTile;

    [HideInInspector] public int currentHP;

    [Space(10)]
    public int maxHP;
    public int MoveRange;
    public int attackRange;
    public int damage;

    [Space(10)]
    public bool turnDone = false;

    private void Awake()
    {
        currentHP = maxHP;
    }
    public void TurnGray()
    {
        highlight.SetActive(true);
        turnDone = true;
    }
    public void ResetAction()
    {
        highlight.SetActive(false);
        turnDone = false;
    }

    public void SetDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        if (currentHP <= 0)
        {
            RemoveUnit();
        }
    }

    public void RemoveUnit()
    {
        if (Faction == Faction.Faction1)
        {
            UnitManager.instance.Player1units.Remove(this);
        }
        if (Faction == Faction.Faction2)
        {
            UnitManager.instance.Player2units.Remove(this);
        }
        OccupiedTile.CleanUnit(this);
        this.gameObject.SetActive(false);
    }

    public void Attack(BaseUnit target)
    {
        target.SetDamage(damage);

    }

    public void SetStats(ScriptableUnit data)
    {
        maxHP = data.maxHP;
        MoveRange = data.MoveRange;
        attackRange = data.attackRange;
        damage = data.damage;
    }
}
