using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    [SerializeField] private Transform house;
    [SerializeField] private GameObject reloadButton;
    private HouseRotate houseRotate;
    private InputSystem inputSystem;
    private MoveSystem moveSystem;
    private Draw draw;
    private CreatePlayer createPlayer;
    private GameController gameController;

    private static Manager instance;

    private UnityEvent updateEvent = new UnityEvent();
    private UnityEvent fixedUpdateEvent = new UnityEvent();

    private Transform player;
    private Transform wall;



    public static Manager Get { get => instance; }
    public UnityEvent UpdateEvent { get => updateEvent; }
    public UnityEvent FixedUpdateEvent { get => fixedUpdateEvent; }
    public Transform Player { get => player; set => player = value; }
    public Transform Wall { get => wall; set => wall = value; }
    public Transform House { get => house; set => house = value; }
    public HouseRotate HouseRotate { get => houseRotate; }
    public InputSystem InputSystem { get => inputSystem;  }
    public MoveSystem MoveSystem { get => moveSystem;  }
    public Draw Draw { get => draw; }
    public CreatePlayer CreatePlayer { get => createPlayer; }
    public GameController GameController { get => gameController;  }
    public GameObject ReloadButton { get => reloadButton; }

    private void Awake()
    {
        instance = this;

        houseRotate = GetComponent<HouseRotate>();
        inputSystem = GetComponent<InputSystem>();
        moveSystem = GetComponent<MoveSystem>();
        draw = GetComponent<Draw>();
        createPlayer = GetComponent<CreatePlayer>();
        gameController = GetComponent<GameController>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        updateEvent.Invoke();
    }

    private void FixedUpdate()
    {
        fixedUpdateEvent.Invoke();
    }
}
