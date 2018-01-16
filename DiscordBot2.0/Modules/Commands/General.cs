using Discord;
using Discord.Commands;
using DiscordBot2._0.Modules.Helpers;
using System.Threading.Tasks;

namespace DiscordBot2._0.Modules.Commands
{
    public class General: ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithColor(3447003)
                .WithTitle("This bot used the '!' (exclamation mark) prefix.")
                .WithDescription("{this is required} [this is optional].")
                .AddField("help", "Will show all commands with their instructions.")
                .AddField("randompost {subreddit}", "Will return a random post from given subreddit with it's details.")
                .AddField("pepe", "Will return a random pepe with it's details.")
                .AddField("emoji {text}", "Will turn your text into emoji's.")
                .AddField("morejpeg {text} [jpegamount]", "Will turn your text into emoji's. jpegamount defaults to 1 and can't be lower than 1 or higher than 10.")
                .AddField("name {text}", "Will change the nickname of the bot.")
                .AddField("tom", "Will return an image of the almighty Tom.")
                .AddField("gerben", "Will return an image of the almighty Gerben.")
                .AddField("siebren [boss]", "Returns Siebrens boss gear used at requested boss.")
                .AddField("raids", "Returns raids cycle.")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context));

            await ReplyAsync("", false, builder.Build());
        }

        [Command("name")]
        public async Task ChangeNameAsync([Remainder]string name)
        {
            var currentUsername = Context.Guild.CurrentUser.Nickname;
            await Context.Guild.CurrentUser.ModifyAsync(x => x.Nickname = name);

            EmbedBuilder builder = new EmbedBuilder();
            builder.WithColor(3447003)
                .WithTitle($"{Context.User.Username} requested a nickname change.")
                .WithDescription($"*{currentUsername}* => *{name}*")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context));

            await ReplyAsync("", false, builder.Build());
        }

        [Command("raids")]
        public async Task SendRaidPhotoAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithColor(3447003)
                .WithImageUrl("https://i.gyazo.com/f15026bba9f7adb2d78135869567939a.png")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context));

            await ReplyAsync("", false, builder.Build());
            await ReplyAsync("");
        }
    }
}
