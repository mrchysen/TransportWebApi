using Core.Domains.Cars.Models;
using Core.Domains.Reports.Models;

namespace Core.Domains.Reports.Services;

public interface IReportBuilder
{
    string ReportType();
    IReportBuilder GetTitle(string text);
    IReportBuilder GetBaseReport(List<Car> cars);
    Report Build();

}
