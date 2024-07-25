using TransportWebApi.Models;

namespace KrasTechMontacApplication.Logic.Reports;

public interface IReportBuilder
{
    string ReportType();
    IReportBuilder GetTitle(string text);
    IReportBuilder GetBaseReport(List<Car> cars);
    Report Build();

}
