using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab; //assigned manually via Unity inspector
    private InputHandler _singleton;

    public void Awake()
    {
        if (_shipPrefab == null) throw new UnityException("Ship Prefab is not manually assigned");
        _singleton = gameObject.AddComponent<InputHandler>();

        GameObject ship = CreateShip();
    }

    private GameObject CreateShip()
    {
        GameObject shipGameObject = Instantiate(_shipPrefab);

        shipGameObject.SetActive(false); //makes assigning values before Awake() possible

        SpaceObjectExecutioner executor = shipGameObject.AddComponent<SpaceObjectExecutioner>();
        executor.SpaceObject = new ScreenWrapping(new Ship(shipGameObject));
        
        _singleton.getInstance().spaceshipMove
            .AddListener(((executor.SpaceObject as SpaceObjectDecorator).GetWrapped as Ship).Control);

        shipGameObject.SetActive(true);

        return shipGameObject;
    }
}
