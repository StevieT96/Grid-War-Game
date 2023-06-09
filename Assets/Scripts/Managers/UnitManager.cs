using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class UnitManager : MonoBehaviour
{
   public static UnitManager instance;

    private List<ScriptableUnit> _units;
    private void Awake()
    {
        instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }
    public void SpawnUnitFaction1()
    {
        var UnitFaction1Count = 1;

        for (int i = 0; i < UnitFaction1Count; i++) { 
        var randomPrefab = GetRandomUnit<BaseUnitFaction1>(Faction.Faction1);
        var SpawnedUnitFaction1 = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.instance.GetUnitFaction1SpawnTile();

        randomSpawnTile.SetUnit(SpawnedUnitFaction1);
        

        }
    }
    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }
}
