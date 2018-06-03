using strange.extensions.context.impl;

namespace Contexts
{
    public class AppRoot : ContextView
    {
        private void Awake()
        {
            context = new AppContext(this);
        }
    }
}