using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;
    public bool Walkable => _isWalkable && OccupiedUnit == null;


    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.instance.ShowTileInfo(this);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.instance.ShowTileInfo(null);
    }

    void OnMouseDown()
    {
        if (GameManager.instance.GameState != GameState.PlayerTurn) return;

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.Faction1) UnitManager.instance.SetSelectedUnitFaction1((BaseUnitFaction1)OccupiedUnit);
            else
            {
                if (UnitManager.instance.SelectedUnitFaction1 != null)
                {
                    var Faction2 = (BaseUnitFaction2) OccupiedUnit;
                    Destroy(Faction2.gameObject);
                    UnitManager.instance.SetSelectedUnitFaction1(null);
                }
            }
        }
        else
        {
            if (UnitManager.instance.SelectedUnitFaction1 != null)
            {
                SetUnit(UnitManager.instance.SelectedUnitFaction1);
                UnitManager.instance.SetSelectedUnitFaction1(null);
            }
        }

    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;

    }
    public void CleanUnit(BaseUnit unit)
    {
        unit.OccupiedTile = null;
        OccupiedUnit = null;
    }
}