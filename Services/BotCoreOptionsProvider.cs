using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using StatusDvBot.Models;

namespace StatusDvBot.Services
{
    internal class BotCoreOptionsProvider : IOptions<BotCoreOptions>
    {
        public const string SECTION_NAME = "BotCore";

        private readonly IConfiguration configuration;
        private BotCoreOptions? options;

        public BotCoreOptionsProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        BotCoreOptions IOptions<BotCoreOptions>.Value
        {
            get
            {
                if (options == null)
                {
                    var section = configuration.GetRequiredSection(SECTION_NAME);

                    var model = new BotCoreModel();
                    section.Bind(model);

                    options = model;
                }

                return options;
            }
        }

        private class BotCoreModel
        {
            public uint HandlersCount { get; set; }

            public static implicit operator BotCoreOptions(BotCoreModel model) => new BotCoreOptions(model.HandlersCount);
        }
    }
}
