using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using TeamCityApi;

namespace FirstBotApp
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private TeamCityListener _teamCityListener;
        public MessagesController()
        {
            _teamCityListener = new TeamCityListener();
        }

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // calculate something for us to return
                int length = (message.Text ?? string.Empty).Length;


                if (message.Text.Contains("\\state"))
                {
                    var buildState = await _teamCityListener.GetState(Projects.Alpha);
                    return message.CreateReplyMessage(buildState.GetInfo());
                }

                // return our reply to the user
                return message.CreateReplyMessage("I don't understand you");
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}