using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject _selectedUnitFaction1Object, _tileObject, _tileUnitObject;

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
            _tileUnitObject.SetActive(true);
        }
    }
    public void ShowSelectedUnit(BaseUnit unit)
    {
        if(unit == null)
        {
            _selectedUnitFaction1Object.SetActive(false);
            return;
        }
        
        _selectedUnitFaction1Object.GetComponentInChildren<Text>().text = unit.UnitName;
        _selectedUnitFaction1Object.SetActive(true);
    }
}
