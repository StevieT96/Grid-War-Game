using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    private List<ScriptableUnit> _units;
    public List<BaseUnit> Player1units;
    public List<BaseUnit> Player2units;
    public BaseUnitFaction1 SelectedUnitFaction1;

    void Awake()
    {
        instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }

    public void SpawnFaction1()
    {
        var Faction1Count = 4;

        for (int i = 0; i < Faction1Count; i++)
        {
            ScriptableUnit randomUnit = GetRandomUnit(Faction.Faction1);
            var randomPrefab = randomUnit.UnitPrefab;
            var spawnedFaction1 = Instantiate(randomPrefab);
            Player1units.Add(spawnedFaction1.GetComponent<BaseUnit>());
            var randomSpawnTile = GridManager.instance.GetFaction1SpawnTile();

            spawnedFaction1.GetComponent<BaseUnit>().SetStats(randomUnit);

            randomSpawnTile.SetUnit(spawnedFaction1);
        }

        GameManager.instance.ChangeState(GameState.SpawnFaction2);
    }
    // Adjust unit amount below, if too many units for the grid, then change grid size in unity
    public void SpawnFaction2()
    {
        var Faction2Count = 8;

        for (int i = 0; i < Faction2Count; i++)
        {
            ScriptableUnit randomUnit = GetRandomUnit(Faction.Faction2);
            var randomPrefab = randomUnit.UnitPrefab;
            var spawnedFaction2 = Instantiate(randomPrefab);
            Player1units.Add(spawnedFaction2.GetComponent<BaseUnit>());
            var randomSpawnTile = GridManager.instance.GetFaction2SpawnTile();

            spawnedFaction2.GetComponent<BaseUnit>().SetStats(randomUnit);

            randomSpawnTile.SetUnit(spawnedFaction2);
        }

        GameManager.instance.ChangeState(GameState.PlayerTurn);
    }

    private ScriptableUnit GetRandomUnit (Faction faction)
    {
        return _units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First();
    }

    public void SetSelectedUnitFaction1(BaseUnitFaction1 unitFaction1)
    {
        SelectedUnitFaction1 = unitFaction1;
        MenuManager.instance.ShowSelectedUnitFaction1(unitFaction1);
    }
    public void PlayerTurn()
    {
        foreach (BaseUnitFaction1 unitFaction1 in Player1units.Cast<BaseUnitFaction1>())
        {
            unitFaction1.ResetAction();
        }
    }
}