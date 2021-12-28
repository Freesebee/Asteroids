using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab; //assigned via Unity inspector

    public void Awake()
    {
        if (_shipPrefab == null) throw new UnityException("Ship Prefab is not assigned"); 

        CreateShip();
    }

    private GameObject CreateShip()
    {
        var ship = Instantiate(_shipPrefab);

        ship.SetActive(false); //makes assigning values before Awake() possible
        var script = ship.AddComponent<SpaceObjectExecutioner>();
        script.SpaceObject = new ScreenWrapping(new Ship(ship));
        ship.SetActive(true);
        
        return ship;
    }
}
