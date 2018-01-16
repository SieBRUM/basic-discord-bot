using Discord;
using Discord.Commands;
using DiscordBot2._0.Modules.ResponseClasses;

namespace DiscordBot2._0.Modules.Helpers
{
    public static class CustomEmbedBuilder
    {
        public static EmbedBuilder RedditEmbed(Data2 data, SocketCommandContext Context)
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithColor(3447003)
                .WithTitle($"Post requested by {Context.User.Username}")
                .WithDescription(data.title)
                .AddInlineField("Posted by:", data.author)
                .AddInlineField("Upvotes:", data.ups)
                .WithFooter(EmbedFooter(Context));

            if (!data.url.Contains("gfycat"))
            {
                builder.Url = data.url;
                builder.ImageUrl = data.url;
            }

            return builder;
        }

        public static EmbedFooterBuilder EmbedFooter(SocketCommandContext Context)
        {
            EmbedFooterBuilder footer = new EmbedFooterBuilder();
            footer.Text = "This bot is made by SieBRUM!";
            footer.IconUrl = Context.Client.GetUser(223100696411635712).GetAvatarUrl();

            return footer;
        }

        public static EmbedBuilder RunescapeGearEmbed(string playerName, string bossName, string url, SocketCommandContext Context)
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithColor(3447003)
                .WithTitle($"{playerName} {bossName} gear requested by {Context.User.Username}")
                .WithFooter(EmbedFooter(Context))
                .WithImageUrl(url);

            return builder;
        }
    }
}
