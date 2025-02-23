namespace Alertify.Application.Common
{
    public record ExcelReportResponse(byte[] FileContents, string Option, string FileName);
}
