using System;
using System.Linq;
using CommandLine;
using GRM.DataService;
using GRM.Response;

namespace GRM
{
    public partial class Program
    {
        private readonly IDataStore _dataStore;

        public Program(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Start(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args) as Parsed<Options>;
            var options = result?.Value;

            var musicContracts = _dataStore.GetMusicContracts();
            var partnerContracts = _dataStore.GetPartnerContracts();

            var partner = partnerContracts.FirstOrDefault(contract => contract.Partner.Equals(options?.PartnerName.Trim(), StringComparison.OrdinalIgnoreCase));
            var musicContractsForPartner = musicContracts
                                            .Where(contract => partner != null && options != null && HasUsage(contract.Usages, partner.Usage) &&
                                                               IsWithinTimeFrame(contract, options))
                                            .ToList();

            if(musicContractsForPartner.Any())
                Console.WriteLine("Artist|Title|Usage|StartDate|EndDate");

            foreach (var musicContract in musicContractsForPartner)
            {
                Console.WriteLine($"{musicContract.Artist}|{musicContract.Title}|{musicContract.Usages}|{musicContract.StartDate}|{musicContract.EndDate}");
            }
        }

        private bool IsWithinTimeFrame(MusicContract contract, Options options)
        {
            return options.DownloadDate.ParseGrmExact() > contract.StartDate.ParseGrmExact() &&
                   (contract.EndDate.ParseGrmExact() == DateTime.MinValue || options.DownloadDate.ParseGrmExact() <
                    contract.EndDate.ParseGrmExact());
        }

        private bool HasUsage(string usages, string usage)
        {
            var usageArray = usages.Split(',');
            return usageArray.Any(s => s.Trim().Equals(usage, StringComparison.OrdinalIgnoreCase));
        }
    }
}