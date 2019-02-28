using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Praja.CsvProcessor.Library
{
public class CsvReader
{
    #region Public members

    public List<CsvFieldTarget> CsvFieldTargets { get; private set; }
    public List<CsvRow> CsvRowsResult { get; private set; }
    public char Separator { get; private set; }
    public bool IsFirstLineColumnName { get; private set; }
    public string FilePath { get; private set; }
        
    #endregion

    #region Constructors
    public CsvReader(string filePath, List<CsvFieldTarget> csvFieldTargets, char separator, bool isFirstLineColumnName)
    {
        FilePath = filePath;
        CsvFieldTargets = csvFieldTargets;
        Separator = separator;
        IsFirstLineColumnName = isFirstLineColumnName;
        CsvRowsResult = new List<CsvRow>();
    }

    #endregion

    #region Public methods

    public List<CsvRow> ReadCsvRows()
    {
        CsvRowsResult = IsFirstLineColumnName ? GetCsvRowIterator().Skip(1).ToList() : GetCsvRowIterator().ToList();
        return CsvRowsResult;
    }

    #endregion

    #region Private methods

    private IEnumerable<CsvRow> GetCsvRowIterator()
    {
        using (StreamReader readFile = new StreamReader(FilePath))
        {
            string line;
            string[] row;

            while ((line = readFile.ReadLine()) != null)
            {
                row = line.Split(Separator);
                var resultRow = BuildCsvRow(row);
                yield return resultRow;
            }
        }
    }


    private CsvRow BuildCsvRow(string[] row)
    {
        var resultRow = new CsvRow(CsvFieldTargets.Count);
        foreach (var csvField in CsvFieldTargets)
        {
            var field = new CsvFieldResult()
            {
                FieldName = csvField.FieldName,
                Position = csvField.Position,
                FieldValue = row[csvField.Position]
            };
            resultRow.CsvFieldsResult.Add(field);
        }

        return resultRow;
          
    }

    #endregion

}
}
