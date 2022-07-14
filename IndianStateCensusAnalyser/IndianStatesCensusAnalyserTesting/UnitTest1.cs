using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace IndianStatesCensusAnalyserTesting
{
    public class Tests
    {
        //UC1 - File Paths for indian state census
        string stateCensusFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndianPopulation.csv";
        string wrongTypeFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string stateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";

        //UC2 - File paths for indian state codes
        string statCodeFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCodeNotExist.csv";
        string wrongStateCodeTypeFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"D:\RajeshBridgeLabz\Indian State Census Analyser\IndianCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";


        public CSVAdapterFactory csvAdapter = null;
        Dictionary<string, CensusDTO> stateRecords = null;
        Dictionary<string, CensusDTO> stateCodeRecords = null;

        [SetUp]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();
        }

        //TC 1.1 Given correct path To ensure number of records matches
        [Test]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(expected, stateRecords.Count);
        }

        //TC 1.2 Given incorrect file should return custom exception - File not found
        [Test]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
        //TC 2.1 Given correct path To ensure number of records matches
        [Test]
        public void GivenStateCodesCsvReturnStateRecords()
        {
            int expected = 37;
            stateCodeRecords = csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, statCodeFilePath, stateCodeHeader);
            Assert.AreEqual(expected, stateCodeRecords.Count);
        }

        //TC 2.2 Given incorrect file should return custom exception - File not found
        [Test]
        public void GivenStateCodesWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongStateCodeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        public void GivenStateCodesWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongStateCodeTypeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        public void GivenStateCodesWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongStateCodeDelimiterFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        public void GivenStateCodesWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(StateCensusAnalyser.Country.INDIA, wrongStateCodeHeaderFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

    }
}