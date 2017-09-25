using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GRM.Response;

namespace GRM.DataService
{
    public interface IDataStore
    {
        IEnumerable<MusicContract> GetMusicContracts();
        IEnumerable<PartnerContract> GetPartnerContracts();
    }

    public class DataStore : IDataStore
    {
        public IEnumerable<MusicContract> GetMusicContracts()
        {
            var musicContracts = new List<MusicContract>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "GRM.Data.MusicContracts.txt";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        //This is the header. This is redundant for this test purposes
                        reader.ReadLine();

                        string s;
                        while ((s = reader.ReadLine()) != null)
                        {
                            var lineStrings = s.Split('|');
                            var musicContract = new MusicContract
                            {
                                Artist = lineStrings.Length > 0 ? lineStrings[0] : string.Empty,
                                Title = lineStrings.Length > 1 ? lineStrings[1] : string.Empty,
                                Usages = lineStrings.Length > 2 ? lineStrings[2] : string.Empty,
                                StartDate = lineStrings.Length > 3 ? lineStrings[3] : string.Empty,
                                EndDate = lineStrings.Length > 4 ? lineStrings[4] : string.Empty
                            };

                            musicContracts.Add(musicContract);
                        }
                    }

            return musicContracts;
        }

        public IEnumerable<PartnerContract> GetPartnerContracts()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "GRM.Data.PartnerContracts.txt";

            var partnerContracts = new List<PartnerContract>();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        //This is the header. This is redundant for this test purposes
                        reader.ReadLine();

                        string s;
                        while ((s = reader.ReadLine()) != null)
                        {
                            var lineStrings = s.Split('|');
                            var partnerContract = new PartnerContract
                            {
                                Partner = lineStrings.Length > 0 ? lineStrings[0] : string.Empty,
                                Usage = lineStrings.Length > 1 ? lineStrings[1] : string.Empty
                            };

                            partnerContracts.Add(partnerContract);
                        }
                    }
            }

            return partnerContracts;
        }
    }
}