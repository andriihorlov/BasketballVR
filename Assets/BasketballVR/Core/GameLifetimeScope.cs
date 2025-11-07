using BasketballVR.Basket;
using BasketballVR.Game;
using BasketballVR.UI;
using VContainer;
using VContainer.Unity;

namespace BasketballVR.Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UiPresenter>();
            builder.Register<IUiModel, UiModel>(Lifetime.Scoped);
            builder.RegisterComponentInHierarchy<UiView>();
            
            builder.RegisterEntryPoint<GamePresenter>();
            builder.Register<IGameModel, GameModel>(Lifetime.Scoped);
            builder.RegisterComponentInHierarchy<GameView>();        
            
            builder.RegisterEntryPoint<BasketPresenter>();
            builder.Register<IBasketModel, BasketModel>(Lifetime.Scoped);
            builder.RegisterComponentInHierarchy<BasketView>();

            builder.RegisterComponentInHierarchy<GlobalController>();
        }
    }
}
