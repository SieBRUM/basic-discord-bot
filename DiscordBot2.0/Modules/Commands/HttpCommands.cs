using Discord;
using Discord.Commands;
using DiscordBot2._0.Modules.Helpers;
using System.Threading.Tasks;

namespace DiscordBot2._0.Modules
{
    public class HttpCommands : ModuleBase<SocketCommandContext>
    {
        [Command("randompost"), RequireNsfw]
        public async Task GetRandompostAsync(string text)
        {

            var request = HttpBuilder.BuildRequest($"https://www.reddit.com/r/{text}/random/.json?count=1");
            var response = HttpBuilder.MakeRequest(request);
            var data = HttpBuilder.ReadRedditResponse(response);

            data.url = WebsiteLinkFixer.ImgurFixUrl(data.url);

            var builder = CustomEmbedBuilder.RedditEmbed(data, Context);
            
            await ReplyAsync("", false, builder.Build());

            if (string.IsNullOrEmpty(builder.ImageUrl))
            {
                await ReplyAsync(data.url);
            }

        }

        [Command("randompost"), RequireNsfw]
        public async Task GetRandompostAsync()
        {
            var request = HttpBuilder.BuildRequest($"https://www.reddit.com/r/random/random/.json?count=1");
            var response = HttpBuilder.MakeRequest(request);
            var data = HttpBuilder.ReadRedditResponse(response);

            data.url = WebsiteLinkFixer.ImgurFixUrl(data.url);

            var builder = CustomEmbedBuilder.RedditEmbed(data, Context);

            await ReplyAsync("", false, builder.Build());

            if (string.IsNullOrEmpty(builder.ImageUrl))
            {
                await ReplyAsync(data.url);
            }
        }

        [Command("pepe"), RequireNsfw]
        public async Task GetPepeAsync()
        {
            var request = HttpBuilder.BuildRequest($"https://www.reddit.com/r/pepe/random/.json?count=1");
            var response = HttpBuilder.MakeRequest(request);
            var data = HttpBuilder.ReadRedditResponse(response);

            data.url = WebsiteLinkFixer.ImgurFixUrl(data.url);

            var builder = CustomEmbedBuilder.RedditEmbed(data, Context);

            await ReplyAsync("", false, builder.Build());

            if (string.IsNullOrEmpty(builder.ImageUrl))
            {
                await ReplyAsync(data.url);
            }
        }

        [Command("morejpeg")]
        public async Task GetMoreJpegAsync(string url, int amount = 1)
        {
            if(amount > 10 || amount < 1)
            {
                await ReplyAsync("JPEG amount incorrect. Number should be above 0 and under 11");
            }

            var request = HttpBuilder.BuildJpegRequest(url);
            var response = HttpBuilder.MakeRequest(request);

            if (response.ResponseUri.Segments.Length == 1)
            {
                await ReplyAsync("Could not JPEG image; is the url a direct link?");
            }

            var responseHeadersCollection = response.ResponseUri;
            for (int i = 1; i < amount; i++)
            {
                request = HttpBuilder.BuildJpegRequest("http://morejpeg.com/Image/JPEG/" + responseHeadersCollection.Segments[3].ToString());
                response = HttpBuilder.MakeRequest(request);
                responseHeadersCollection = response.ResponseUri;
            }
            var imageUrl = "http://morejpeg.com/Image/JPEG/" + response.ResponseUri.Segments[3].ToString();

            EmbedBuilder builder = new EmbedBuilder();

            builder.WithColor(3447003)
                .WithTitle($"{amount}x JPEG requested by {Context.User.Username}")
                .WithFooter(CustomEmbedBuilder.EmbedFooter(Context))
                .ImageUrl = imageUrl;

            await ReplyAsync("", false, builder.Build());
        }

        [Command("yomama")]
        public async Task GetMamaJokeAsync()
        {
            var request = HttpBuilder.BuildRequest("http://api.yomomma.info/");
            var response = HttpBuilder.MakeRequest(request);
            var joke = HttpBuilder.ReadYoMamaJokeResponse(response);

            await ReplyAsync(joke);
        }

        // Aliasses
        [Command("poopr"), RequireNsfw]
        public async Task GetPepeAliasAsync()
        {
            await GetPepeAsync();
        }
    }
}
