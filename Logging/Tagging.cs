using Sentry;

namespace API.Data.Collector.Logging
{
    public class Tagging
    {

        public void SetTagg(string tagName, string tagValue, SentryLevel? errorLevel)
        {

            SentrySdk.ConfigureScope(scope =>
            {
                scope.SetTag(tagName, tagValue);
                scope.Level = errorLevel;
            });

        }

    }
}
