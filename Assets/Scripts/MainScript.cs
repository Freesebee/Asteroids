using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab; //assigned via Unity inspector

    public void Awake()
    {
        if (_shipPrefab == null) throw new UnityException("Ship Prefab is not assigned"); 

        GameObject ship = CreateShip();
    }

    private GameObject CreateShip()
    {
        GameObject shipGameObject = Instantiate(_shipPrefab);

        shipGameObject.SetActive(false); //makes assigning values before Awake() possible
        SpaceObjectExecutioner script = shipGameObject.AddComponent<SpaceObjectExecutioner>();

        Ship ship = new Ship(shipGameObject);
        ship.Control(Vector2.right);

        script.SpaceObject = new ScreenWrapping(ship);
        shipGameObject.SetActive(true);

        return shipGameObject;
    }
}
