using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PiecesConfig>().AsSingle();
        Container.BindInterfacesAndSelfTo<PiecesGenerator>().AsSingle();

        Container.BindInterfacesAndSelfTo<PieceCreator>().AsSingle();
    }
}
