using BoikoQuiz.WP.Resources;

namespace BoikoQuiz.WP
{
    /// <summary>
    /// Gives the access for strokovыm resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}