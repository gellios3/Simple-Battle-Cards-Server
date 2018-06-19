using strange.extensions.command.impl;

namespace Client.Commands
{
    public class LoadGameDataCommand : Command
    {

        /// <summary>
        /// Server connector service
        /// </summary>
        [Inject] public ServerConnectorService ServerConnectorService { get; set; }        

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {
            ServerConnectorService.Connect();           
        }
    }
}