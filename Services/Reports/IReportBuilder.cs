using Data.Models;
namespace Service.Reports;

public interface IReportBuilder
{
    string ReportType();
    IReportBuilder GetTitle(string text);
    IReportBuilder GetBaseReport(List<Car> cars);
    Report Build();

}
