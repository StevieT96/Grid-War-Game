using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    private List<ScriptableUnit> _units;
    public BaseUnitFaction1 SelectedUnitFaction1;

    void Awake()
    {
        instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }

    public void SpawnFaction1()
    {
        var Faction1Count = 3;

        for (int i = 0; i < Faction1Count; i++)
        {
            var randomPrefab = GetRandomUnit<BaseUnitFaction1>(Faction.Faction1);
            var spawnedFaction1 = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.instance.GetFaction1SpawnTile();

            randomSpawnTile.SetUnit(spawnedFaction1);
        }

        GameManager.instance.ChangeState(GameState.SpawnFaction2);
    }

    public void SpawnFaction2()
    {
        var Faction2Count = 5;

        for (int i = 0; i < Faction2Count; i++)
        {
            var randomPrefab = GetRandomUnit<BaseUnitFaction2>(Faction.Faction2);
            var spawnedFaction2 = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.instance.GetFaction2SpawnTile();

            randomSpawnTile.SetUnit(spawnedFaction2);
        }

        GameManager.instance.ChangeState(GameState.PlayerTurn);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedUnitFaction1(BaseUnitFaction1 unitFaction1)
    {
        SelectedUnitFaction1 = unitFaction1;
        MenuManager.instance.ShowSelectedUnitFaction1(unitFaction1);
    }
}