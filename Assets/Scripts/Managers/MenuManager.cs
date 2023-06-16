using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject _selectedPlayerObject, _tileObject, _tileUnitObject;
    [SerializeField] private GameObject _tileUnitPanel, _tileUnitName, _tileUnitHP, _tileUnitDamage, _tileUnitMoveRange;
    void Awake()
    {
        instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }

        _tileObject.GetComponentInChildren<Text>().text = tile.TileName;
        _tileObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _tileUnitHP.GetComponentInChildren<Text>().text = tile.OccupiedUnit.currentHP.ToString();
            _tileUnitDamage.GetComponentInChildren<Text>().text = tile.OccupiedUnit.damage.ToString();
            _tileUnitMoveRange.GetComponentInChildren<Text>().text = tile.OccupiedUnit.MoveRange.ToString();

            _tileUnitObject.SetActive(true);
        }
    }
    public void ShowSelectedUnitFaction1(BaseUnitFaction1 unit)
    {
        if(unit == null)
        {
            _selectedPlayerObject.SetActive(false);
            return;
        }
        
        _selectedPlayerObject.GetComponentInChildren<Text>().text = unit.UnitName;
        _selectedPlayerObject.GetComponentInChildren<Text>().text = unit.currentHP.ToString();
        _selectedPlayerObject.SetActive(true);
    }
}
