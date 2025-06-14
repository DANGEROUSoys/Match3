using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PieceCreator _creator;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ActionBar _actionBar;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PiecesConfig>().AsSingle();
        Container.BindInterfacesAndSelfTo<PiecesGenerator>().AsSingle();

        Container.BindInterfacesAndSelfTo<PieceCreator>().FromInstance(_creator).AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerInput>().FromInstance(_playerInput).AsSingle();

        Container.BindInterfacesAndSelfTo<ActionBar>().FromInstance(_actionBar).AsSingle();
    }
}
