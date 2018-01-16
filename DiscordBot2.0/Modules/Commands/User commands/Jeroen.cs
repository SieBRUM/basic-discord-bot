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
    [Group("jeroen")]
    public class Jeroen: ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task DefaultJeroenAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithColor(3447003)
                .WithTitle("Use the '!jeroen <boss>' to see Jeroens gear that he uses for that boss")
                .WithDescription("Note: these setups might be outdated.")
                .AddField("corp", "Gear used at Corporeal Corporeal Beast.")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context));

            await ReplyAsync("", false, builder.Build());
        }

        [Command("corp")]
        public async Task CorpAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Jeroens", "Corporeal Corporeal", "https://i.gyazo.com/d3f23c76f3b098005d72373a99215c78.png", Context);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
