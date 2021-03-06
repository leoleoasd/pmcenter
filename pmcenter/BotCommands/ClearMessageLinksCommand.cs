using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static pmcenter.Methods;

namespace pmcenter.Commands
{
    internal class ClearMessageLinksCommand : ICommand
    {
        public bool OwnerOnly => true;

        public string Prefix => "clearmessagelinks";

        public async Task<bool> ExecuteAsync(TelegramBotClient botClient, Update update)
        {
            Log("Clearing message links...", "BOT");
            Vars.CurrentConf.MessageLinks = new System.Collections.Generic.List<Conf.MessageIDLink>();
            _ = await botClient.SendTextMessageAsync(
                update.Message.From.Id,
                Vars.CurrentLang.Message_MsgLinksCleared,
                ParseMode.Markdown,
                false,
                Vars.CurrentConf.DisableNotifications,
                update.Message.MessageId).ConfigureAwait(false);
            return true;
        }
    }
}
