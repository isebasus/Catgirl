﻿using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using catgirl_bot.Util;
using Discord;

namespace catgirl_bot.Commands
{
    public class Actions : ModuleBase<SocketCommandContext>
    {
        private async Task Action(string key, string message, string action, string user)
        {
            if (user == "")
            {
                user = Context.User.Mention;
            }

            // Check if user exists
            if (Context.Guild.Users.Any(x => x.Mention == user))
            {
                var index = Context.Guild.Users.Select(x => x.Mention).IndexOf(user);
                await CommandSource.SendAction(Context, Context.Guild.Users.ElementAt(index), key, message, action);
            }
            else
            {
                await ReplyAsync("nu! that is not a real person xd", messageReference: new MessageReference(Context.Message.Id)).ConfigureAwait(false);
            }
        }
        [Command("kiss")]
        public async Task Kiss(string user = "")
        {
            await Action("kiss", "😽 mwuah", "kissing", user);
        }

        [Command("lick")]
        public async Task Lick(string user = "")
        {
            await Action("lick", "👅 lick!", "licking", user);
        }

        [Command("hug")]
        public async Task Hug(string user = "")
        {
            await Action("hug", "💞 hug!", "hugging", user);
        }

        [Command("slap")]
        public async Task Slap(string user = "")
        {
            await Action("slap", "🔪 slap!", "slapping", user);
        }

        [Command("cuddle")]
        public async Task Cuddle(string user = "")
        {
            await Action("cuddle", "💖 cuddle!", "cuddling", user);
        }
    }
}