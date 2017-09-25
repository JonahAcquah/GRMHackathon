using CommandLine;

namespace GRM
{
    internal class Options
    {
        [Option('p', "partner", Required = true, HelpText = "Partner name")]
        public string PartnerName { get; set; }

        [Option('d', "date", Required = true, HelpText = "Given download date")]
        public string DownloadDate { get; set; }
    }
}
