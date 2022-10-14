using System.Collections;
using System.Runtime.CompilerServices;
using Systems.GameplayObjects;
using Systems.Input;
using Systems.Moves;
using Systems.Spawners;
using Systems.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UnityComponents.Common
{
    public interface IManager
    {
        public void OnStart();
        public void OnStop();
    }

    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;

        private SpawnSystem _spawnSystem;
        private InputSystem _inputSystem;
        public PathContainer PathContainer;
        public GameplayObjectsSystem ObjectsSystem;

        private void Awake()
        {
            _spawnSystem = new SpawnSystem(_sceneData, _staticData);
            PathContainer = new PathContainer();
            ObjectsSystem = new GameplayObjectsSystem(_staticData.CoinsNumber, _sceneData.UIControl);
            _inputSystem = new InputSystem(_sceneData, new IAddToPath[2] { PathContainer, _sceneData.PathLines });
        }

        private void OnEnable()
        {
            EventManager.StartListening(EventManager.EVENTS.start, StartGame);
            EventManager.StartListening(EventManager.EVENTS.restart, RestartGame);
            EventManager.StartListening(EventManager.EVENTS.win, GameOver);
            EventManager.StartListening(EventManager.EVENTS.lose, GameOver);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventManager.EVENTS.start, StartGame);
            EventManager.StopListening(EventManager.EVENTS.restart, RestartGame);
            EventManager.StopListening(EventManager.EVENTS.win, GameOver);
            EventManager.StopListening(EventManager.EVENTS.lose, GameOver);
        }
        private void StartGame()
        {            
            _spawnSystem.OnStart();
            _inputSystem.OnStart();
        }

        private void GameOver()
        {
            _inputSystem.OnStop();
        }


        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
