using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab; //assigned manually via Unity inspector

    public void Awake()
    {
        if (_shipPrefab == null) throw new UnityException("Ship Prefab is not manually assigned"); 

        //TODO: Fix not setting object reference
        //GameObject ship = CreateShip(); 
    }

    private GameObject CreateShip()
    {
        GameObject shipGameObject = Instantiate(_shipPrefab);

        shipGameObject.SetActive(false); //makes assigning values before Awake() possible
        SpaceObjectExecutioner script = shipGameObject.AddComponent<SpaceObjectExecutioner>();

        script.SpaceObject = new ScreenWrapping(new Ship(shipGameObject));
        shipGameObject.SetActive(true);

        return shipGameObject;
    }
}
