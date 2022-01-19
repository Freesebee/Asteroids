using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab; //assigned manually via Unity inspector
    [SerializeField] private GameObject _bulletPrefab; //assigned manually via Unity inspector
    private InputHandler _singleton;
    private GameObject _objectPool;

    public void Awake()
    {
        if (_shipPrefab == null) throw new UnityException("Ship Prefab is not manually assigned");
        _singleton = gameObject.AddComponent<InputHandler>();

        GameObject ship = CreateShip();
    }

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
    }

    private GameObject CreateShip()
    {
        GameObject shipGameObject = Instantiate(_shipPrefab);

        shipGameObject.SetActive(false); //makes assigning values before Awake() possible

        SpaceObjectExecutioner executor = shipGameObject.AddComponent<SpaceObjectExecutioner>();
        executor.SpaceObject = new ScreenWrapping(new Ship(shipGameObject));
        
        _singleton.getInstance().spaceshipMove
            .AddListener(((executor.SpaceObject as SpaceObjectDecorator).GetWrapped as Ship).Control);

        var objectPool = shipGameObject.AddComponent<ObjectPool>();
        objectPool.bulletPrefab = _bulletPrefab;

        _singleton.getInstance().spaceshipShoot
            .AddListener(((executor.SpaceObject as SpaceObjectDecorator).GetWrapped as Ship).Fire);

        shipGameObject.SetActive(true);

        return shipGameObject;
    }
}
