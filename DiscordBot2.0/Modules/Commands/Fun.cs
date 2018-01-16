using Discord;
using Discord.Commands;
using DiscordBot2._0.Modules.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordBot2._0.Modules.Commands
{
    public class Fun: ModuleBase<SocketCommandContext>
    {
        [Command("emoji")]
        public async Task MakeEmojiAsync([Remainder] string text)
        {
            string emojiText = "";
            foreach (var letter in text)
            {
                bool isAlphaBet = Regex.IsMatch(letter.ToString(), "[a-z]", RegexOptions.IgnoreCase);

                if (isAlphaBet)
                    emojiText += ":regional_indicator_" + letter.ToString().ToLower() + ":";
                else if (letter.Equals('?'))
                    emojiText += ":question:";
                else if (letter.Equals('!'))
                    emojiText += ":exclamation:";
                else if (letter.Equals('#'))
                    emojiText += ":hash:";
                else
                    emojiText += letter;
            }

            await ReplyAsync(emojiText);
        }

        [Command("gerben")]
        public async Task SendGerbenAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithColor(3447003)
                .WithTitle($"Gerben picture requested by {Context.User.Username}")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context))
                .ImageUrl = "https://image.prntscr.com/image/bd9a127e4fda43f1adffed6a6523d14d.png";

            await ReplyAsync("", false, builder.Build());
        }

        [Command("tom")]
        public async Task SendTomAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithColor(3447003)
                .WithTitle($"Tom picture requested by {Context.User.Username}")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context))
                .ImageUrl = "https://i.gyazo.com/34e5abdccafb8313b6d8fcf607a7ab6a.png";

            await ReplyAsync("", false, builder.Build());
        }
    }
}
