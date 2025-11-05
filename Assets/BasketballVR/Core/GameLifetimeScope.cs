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
            
            builder.RegisterComponentInHierarchy<GlobalController>();
        }
    }
}
