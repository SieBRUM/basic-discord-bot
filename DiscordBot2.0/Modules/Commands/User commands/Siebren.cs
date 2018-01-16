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
    [Group("siebren")]
    public class Siebren: ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task DefaultSiebrenAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithColor(3447003)
                .WithTitle("Use the '!siebren <boss>' to see Siebrens gear that he uses for that boss")
                .WithDescription("Note: these setups might be outdated.")
                .AddField("raids", "Gear used at raids (Before entering).")
                .AddField("midraids", "Gear used before Ohlm")
                .AddField("dks", "Gear used at DKS.")
                .AddField("gorillas", "Gear used at Demonic gorilla's.")
                .AddField("tankbandos", "Gear used as tank at Bandos.")
                .AddField("gargoyle", "Gear used at Gargoyle boss.")
                .AddField("corp", "Gear used at Corporeal Corporeal Beast.")
                .AddField("vorkath", "Gear used at vorkath.")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context));

            await ReplyAsync("", false, builder.Build());
        }

        [Command("raids")]
        public async Task RaidsAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "Raids", "https://image.prntscr.com/image/0FVbquRkSSSHoppLWtKtdA.png", Context);

            await ReplyAsync("", false, builder.Build());
        }

        [Command("midraids")]
        public async Task InraidsAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "mid-raid", "https://image.prntscr.com/image/NYE9USInRx_BdEKjVe8eMw.png", Context);

            await ReplyAsync("", false, builder.Build());
        }

        [Command("dks")]
        public async Task DksAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "DKS", "https://image.prntscr.com/image/IF-LmrjdQuSDxOqOIB1VBQ.png", Context);

            await ReplyAsync("", false, builder.Build());
        }

        [Command("gorillas")]
        public async Task GorillasAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "Gorillas", "https://image.prntscr.com/image/e1dws4bkS9OWRzR3w7MNVw.png", Context);

            await ReplyAsync("", false, builder.Build());
        }

        [Command("tankbandos")]
        public async Task TankBandosAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "tank Bandos", "https://image.prntscr.com/image/kCjofuWcTnOa_E3pOYrJfw.png", Context);

            await ReplyAsync("", false, builder.Build());
        }


        [Command("gargoyle")]
        public async Task GargoyleAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "Gargoyle", "https://image.prntscr.com/image/vJIYsH49RPSuY2KmWpKPaQ.png", Context);

            await ReplyAsync("", false, builder.Build());
        }

        [Command("corp")]
        public async Task CorpAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "Corporeal Corporeal", "https://image.prntscr.com/image/uXMoIhaLSyqbzEaoHbti9w.png", Context);

            await ReplyAsync("", false, builder.Build());
        }

        [Command("vorkath")]
        public async Task VorkathAsync()
        {
            var builder = CustomEmbedBuilder.RunescapeGearEmbed("Siebrens", "Vorkath", "https://image.prntscr.com/image/cVuUNV2FTSK7274VrXNsWA.png", Context);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
