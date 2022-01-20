using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab; //assigned manually via Unity inspector
    [SerializeField] private GameObject _bulletPrefab; //assigned manually via Unity inspector
    [SerializeField] private GameObject _smallAsteroidPrefab; //assigned manually via Unity inspector
    [SerializeField] private Text _hpText; //assigned manually via Unity inspector

    private InputHandler _singleton;
    private ISpaceObjectFactory _factory;
    private SpaceObjectGenerator _generator;
    private IMediator _gameLogic;

    public void Awake()
    {
        _singleton = gameObject.AddComponent<InputHandler>();

        _gameLogic = new GameLogic();

        _factory = gameObject.AddComponent<BasicSOFactory>();
        _factory.gameLogic = _gameLogic;
        (_factory as BasicSOFactory).asteroidPrefab = _smallAsteroidPrefab;
        
        _generator = gameObject.AddComponent<SpaceObjectGenerator>();
        _generator.factory = _factory;

        GameObject shipGameObject = Instantiate(_shipPrefab);

        shipGameObject.SetActive(false); //makes assigning values before Awake() possible

        SpaceObjectExecutioner shipExecutor = shipGameObject.AddComponent<SpaceObjectExecutioner>();
        shipExecutor.SpaceObject = new ScreenWrapping(new Ship(shipGameObject, _gameLogic));

        _singleton.getInstance().spaceshipMove
            .AddListener(((shipExecutor.SpaceObject as SpaceObjectDecorator).GetWrapped as Ship).Control);

        var objectPool = shipGameObject.AddComponent<ObjectPool>();
        objectPool.bulletPrefab = _bulletPrefab;

        _singleton.getInstance().spaceshipShoot
            .AddListener(((shipExecutor.SpaceObject as SpaceObjectDecorator).GetWrapped as Ship).Fire);

        shipGameObject.SetActive(true);

        (_gameLogic as GameLogic).HPText = _hpText;
        (_gameLogic as GameLogic).Ship = ((shipExecutor.SpaceObject as SpaceObjectDecorator).GetWrapped as Ship);

    }

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);

        _generator.Init();
    }
}
