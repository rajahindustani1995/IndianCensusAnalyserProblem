using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(StateCensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            try
            {
                switch (country)
                {
                    case (StateCensusAnalyser.Country.INDIA):
                        return new IndianSensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    //case (CensusAnalyser.Country.US):
                    //    return new USCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);

                }
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
